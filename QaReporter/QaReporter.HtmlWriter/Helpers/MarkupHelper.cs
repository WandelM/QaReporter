namespace QaReporter.HtmlWriter;

/// <summary>
/// Helper class for rendering basic html tags used in the report
/// </summary>
public static class MarkupHelper
{
    /// <summary>
    /// Renders <hr/> tag
    /// </summary>
    /// <returns></returns>
    public static string HorizontalLine()
    {
        return "<hr/>";
    }

    /// <summary>
    /// Renders <p></p> tag
    /// </summary>
    /// <param name="content"></param>
    /// <returns></returns>
    public static string Paragraph(string content)
    {
        return $"<p>{content}</p>";
    }

    /// <summary>
    /// Renders h1 with id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="content"></param>
    /// <returns></returns>
    public static string Heading1(string id, string content)
    {
        return $"<h1 id=\"{id}\">{content}</h1>";
    }

    /// <summary>
    /// Renders image
    /// </summary>
    /// <param name="base64String"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static string ImageBase64(string base64String, string? fileName = null)
    {
        return $"<img alt=\"{fileName}\" src=\"data:image/png;base64,{base64String}\"/>";
    }
}