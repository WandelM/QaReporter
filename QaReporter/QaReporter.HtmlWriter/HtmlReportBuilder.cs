namespace QaReporter.HtmlWriter;

/// <summary>
/// Builds html report
/// </summary>
public class HtmlReportBuilder
{
    private string TestName;
    private string StepsTemplate;
    private string TestInfoTemplate;
    private string CssStyles;

    public static HtmlReportBuilder Create()
    {
        return new HtmlReportBuilder();
    }

    private HtmlReportBuilder()
    {
        TestName = String.Empty;
        StepsTemplate = String.Empty;
        TestInfoTemplate = String.Empty;
        CssStyles = String.Empty;
    }

    public HtmlReportTemplate Build()
    {
        if (string.IsNullOrEmpty(TestName) || string.IsNullOrEmpty(StepsTemplate) || string.IsNullOrEmpty(TestInfoTemplate))
            throw new Exception("One of the members ware empty");

        var htmlReportTemplate = new HtmlReportTemplate(TestName, TestInfoTemplate, StepsTemplate, CssStyles);

        return htmlReportTemplate;
    }

    public HtmlReportBuilder WithTestName(string testName)
    {
        TestName = testName;
        return this;
    }

    public HtmlReportBuilder WithStepsTemplate(string stepsTemplate)
    {
        StepsTemplate = stepsTemplate;
        return this;
    }

    public HtmlReportBuilder WithTestInfoTemplate(string testInfoTemplate)
    {
        TestInfoTemplate = testInfoTemplate;
        return this;
    }

    public HtmlReportBuilder WithCssStyles(string cssStyles)
    {
        CssStyles = cssStyles;
        return this;
    }
}
