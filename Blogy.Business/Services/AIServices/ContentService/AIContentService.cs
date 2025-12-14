using Blogy.Business.DTOs.AIDtos;
using Blogy.Business.Settings;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Blogy.Business.Services.AIServices.ContentService
{
    public class AIContentService : IAIContentService
    {
        private readonly HttpClient _httpClient;
        private readonly OpenAiSettings _settings;

        public AIContentService(HttpClient httpClient, IOptions<OpenAiSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings.Value;

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _settings.ApiKey);
        }

        public async Task<ResultAIDto> CreateArticleAsync(CreateAIArticleDto articleDto)
        {
            var prompt =
                $"\"{articleDto.Keyword}\" anahtar kelimesine sahip, " +
                $"yaklaşık 400-600 kelimelik, modern ve akıcı bir blog yazısı üret. " +
                $"Düz paragraf formatında yaz.";

            return await SendPromptAsync(prompt);
        }

        public async Task<ResultAIDto> CreateAboutAsync(CreateAIAboutDto aboutDto)
        {
            var prompt =
                $"\"{aboutDto.Topic}\" üzerine odaklanan kişisel bir yazılım blogu için " +
                $"kısa ve profesyonel bir footer hakkında metni yaz.";

            return await SendPromptAsync(prompt);
        }

        public async Task<ResultAIDto> CreateMessageAsync(string messageContent)
        {
            var prompt =
                $"Kullanıcının aşağıdaki mesajına nazik, profesyonel ve yardımcı bir cevap yaz:\n\n" +
                $"{messageContent}";

            return await SendPromptAsync(prompt);
        }

       
        private async Task<ResultAIDto> SendPromptAsync(string prompt)
        {
            var requestBody = new
            {
                model = _settings.Model,
                messages = new[]
                {
                    new { role = "system", content = "You are a helpful assistant." },
                    new { role = "user", content = prompt }
                }
            };

            var json = JsonSerializer.Serialize(requestBody);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(
                "https://api.openai.com/v1/chat/completions",
                httpContent);

            response.EnsureSuccessStatusCode();

            var responseJson = await response.Content.ReadAsStringAsync();
            using var document = JsonDocument.Parse(responseJson);

            var aiContent = document
                .RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return new ResultAIDto
            {
                Content = aiContent ?? string.Empty
            };
        }
    }
}
