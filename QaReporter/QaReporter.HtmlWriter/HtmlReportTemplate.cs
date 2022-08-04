namespace QaReporter.HtmlWriter;

public class HtmlReportTemplate: IHtmlSectionRenderer
{
    public string TestName { get; }
    public string StepsTemplate { get; }
    public string TestInfoTemplate { get; }
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
                        {TestInfoTemplate}
                    </div>
                    <div id = 'steps'>
                        {StepsTemplate}
                    </div>
                </body>
            </html>";
    }

    public HtmlReportTemplate(string testName, string testInoTemplate, string stepsTemplate, string cssStyles)
    {
        TestName = testName;
        StepsTemplate = stepsTemplate;
        TestInfoTemplate = testInoTemplate;
        CssStyles = cssStyles;
    }
}
