namespace QaReporter.HtmlWriter;

public static class MarkupHelper
{
    public static string HorizontalLine()
    {
        return "<hr/>";
    }

    public static string Paragraph(string content)
    {
        return $"<p>{content}</p>";
    }

    public static string ImageBase64(string base64String, string? fileName = null)
    {
        return $"<img style=\"max-width: 1400px\" alt=\"{fileName}\" src=\"data:image/png;base64,{base64String}\"\\>";
    }
}