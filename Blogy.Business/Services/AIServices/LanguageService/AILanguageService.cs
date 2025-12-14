using Blogy.Business.Services.AIServices.LanguageService;
using Blogy.Business.Settings;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

public class AILanguageService : IAILanguageService
{
    private readonly HttpClient _httpClient;
    private readonly OpenAiSettings _settings;

    public AILanguageService(HttpClient httpClient, IOptions<OpenAiSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings.Value;

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _settings.ApiKey);
    }

    public async Task<string> TranslateAsync(string comment)
    {
        var prompt =
            $"Translate the following text into English. " +
            $"Do not add explanations. Only return the translated text:\n\n{comment}";

        var requestBody = new
        {
            model = _settings.Model,
            messages = new[]
            {
                new { role = "system", content = "You are a professional translator." },
                new { role = "user", content = prompt }
            }
        };

        var json = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(
            "https://api.openai.com/v1/chat/completions",
            content);

        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();
        using var document = JsonDocument.Parse(responseJson);

        return document.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString() ?? string.Empty;
    }
}
