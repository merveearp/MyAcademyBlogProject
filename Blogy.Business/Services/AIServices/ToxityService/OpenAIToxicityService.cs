using Blogy.Business.Services.AIServices.ToxityService;
using Blogy.Business.Settings;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

public class OpenAIToxicityService : IToxicityService
{
    private readonly HttpClient _httpClient;
    private readonly OpenAiSettings _settings;

    private const string OPENAI_URL =
        "https://api.openai.com/v1/moderations";

    public OpenAIToxicityService(
        HttpClient httpClient,
        IOptions<OpenAiSettings> settings)
    {
        _httpClient = httpClient;
        _settings = settings.Value;

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _settings.ApiKey);
    }

    public async Task<double> GetToxicityScoreAsync(string text)
    {
        var requestBody = new
        {
            model = "omni-moderation-latest",
            input = text
        };

        var content = new StringContent(
            JsonSerializer.Serialize(requestBody),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PostAsync(OPENAI_URL, content);
        response.EnsureSuccessStatusCode();

        var responseJson = await response.Content.ReadAsStringAsync();
        using var document = JsonDocument.Parse(responseJson);

        var result = document.RootElement
            .GetProperty("results")[0];

        bool flagged = result.GetProperty("flagged").GetBoolean();

        var categories = result.GetProperty("categories");

        bool harassment =
            categories.GetProperty("harassment").GetBoolean();

        bool harassmentThreat =
            categories.GetProperty("harassment/threatening").GetBoolean();

        bool hate =
            categories.GetProperty("hate").GetBoolean();

       
        if (flagged && (harassment || harassmentThreat || hate))
            return 1.0; 

        return 0.0; // CLEAN
    }

}
