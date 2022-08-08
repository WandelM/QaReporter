using QaReporter.HtmlWriter.Abstractions;

namespace QaReporter.HtmlWriter;

/// <summary>
/// Rendets html report body
/// </summary>
public class HtmlReportRenderer: IHtmlSectionRenderer
{
    /// <summary>
    /// Name of the test
    /// </summary>
    public string TestName { get; }

    /// <summary>
    /// Rendered steps
    /// </summary>
    public string Steps { get; }

    /// <summary>
    /// Rebdered test info
    /// </summary>
    public string TestInfo { get; }

    /// <summary>
    /// Styles used in the report
    /// </summary>
    public string CssStyles { get; }

    public string Render()
    {
        return $@"
            <!DOCTYPE html>
            <html lang='en'>
                <head>
                    <meta charset = 'UTF-8'>
                    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
                    <meta name = 'viewport' content='width=device-width, initial-scale=1.0'>
                    <title>{TestName}</title>
                    <styles>{CssStyles}</styles>
                </head>
                <body>
                    <div id = 'test-info'>
                        {TestInfo}
                    </div>
                    <div id = 'steps'>
                        {Steps}
                    </div>
                </body>
            </html>";
    }

    public HtmlReportRenderer(string testName, string testInoTemplate, string stepsTemplate, string cssStyles)
    {
        TestName = testName;
        Steps = stepsTemplate;
        TestInfo = testInoTemplate;
        CssStyles = cssStyles;
    }
}
