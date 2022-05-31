using System.Text;
using System.Web;

namespace Infrastructure.HttpClientFactories;

public class LatexCompilerService : ILatexCompilerService
{
    private readonly HttpClient _httpClient;

    public LatexCompilerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<byte[]> GetCompiledLatexPdf(string latexFile)
    {
        var urlEncodedFile = HttpUtility.UrlEncode(latexFile);
        var url = "https://latex-bakis-nb.azurewebsites.net/compile?text=" + urlEncodedFile; //TODO: move url to appsettings

        var result2 = await _httpClient.GetAsync(url);

        return await result2.Content.ReadAsByteArrayAsync();
    }
}