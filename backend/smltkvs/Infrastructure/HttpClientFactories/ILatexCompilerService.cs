namespace Infrastructure.HttpClientFactories;

public interface ILatexCompilerService
{
    Task<byte[]> GetCompiledLatexPdf(string latexFile);
}