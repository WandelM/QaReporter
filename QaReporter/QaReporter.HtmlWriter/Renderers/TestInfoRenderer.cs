using QaReporter.HtmlWriter.Abstractions;
using System.Text;

namespace QaReporter.HtmlWriter;

/// <summary>
/// Renderer for test info section
/// </summary>
public class TestInfoRenderer : IHtmlSectionRenderer
{
    public string Render()
    {
        var testInfoBuilder = new StringBuilder();
        testInfoBuilder.AppendLine(_markupService.Paragraph($"Test Key: {TestKey}"));
        testInfoBuilder.AppendLine(_markupService.Paragraph($"Test Name: {TestName}"));
        testInfoBuilder.AppendLine(_markupService.Paragraph($"Start Date: {StartDate})"));
        testInfoBuilder.AppendLine(_markupService.Paragraph($"Finish Date: {EndDate}"));
        testInfoBuilder.AppendLine(_markupService.Paragraph($"Status: {Status}"));

        if (AdditionalInfo != null)
            foreach (var item in AdditionalInfo)
                testInfoBuilder.AppendLine(_markupService.Paragraph($"{item.Key}: {item.Value}"));


        return testInfoBuilder.ToString();
    }

    public TestInfoRenderer(
        string testKey,
        string testName,
        DateTime startDate,
        DateTime endDate,
        string status, IReadOnlyDictionary<string, string>? additionalInfo = null)
    {
        TestKey = testKey;
        TestName = testName;
        StartDate = startDate;
        EndDate = endDate;
        Status = status;
        AdditionalInfo = additionalInfo;
        _markupService = new MarkupService();
    }

    private readonly MarkupService _markupService;
    public string TestKey { get; }
    public string TestName { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public string Status { get; }
    public IReadOnlyDictionary<string, string>? AdditionalInfo { get; }
}