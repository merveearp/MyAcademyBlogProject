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

    private const string TurkishChars = "çğıöşüÇĞİÖŞÜ";

    public AILanguageService(
        HttpClient httpClient,
        IOptions<OpenAiSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings.Value;

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _settings.ApiKey);
    }

    public bool HasTurkishCharacters(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return false;

        return text.Any(c => TurkishChars.Contains(c));
    }

    public async Task<string> TranslateAsync(string comment)
    {
        if (string.IsNullOrWhiteSpace(comment))
            return string.Empty;

        var requestBody = new
        {
            model = _settings.Model,
            messages = new[]
            {
                new
                {
                    role = "system",
                    content = "Translate the given text into English. Return only the translated text."
                },
                new
                {
                    role = "user",
                    content = comment
                }
            }
        };

        var content = new StringContent(
            JsonSerializer.Serialize(requestBody),
            Encoding.UTF8,
            "application/json");

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
                   .GetString()
               ?? string.Empty;
    }
}
