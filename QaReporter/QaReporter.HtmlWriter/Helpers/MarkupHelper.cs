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
    /// Renders image
    /// </summary>
    /// <param name="base64String"></param>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static string ImageBase64(string base64String, string? fileName = null)
    {
        return $"<img style=\"max-width: 1400px\" alt=\"{fileName}\" src=\"data:image/png;base64,{base64String}\"\\>";
    }
}