namespace QaReporter.HtmlWriter.Abstractions;

/// <summary>
/// Template for html renderer, used to render every section
/// </summary>
public interface IHtmlSectionRenderer
{
    string Render();
}
