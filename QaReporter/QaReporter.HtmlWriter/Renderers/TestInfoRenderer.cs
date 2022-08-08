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

        testInfoBuilder.AppendLine($"<p>Test Key: {TestKey}</p>");
        testInfoBuilder.AppendLine($"<p>Test Name: {TestName}</p>");
        testInfoBuilder.AppendLine($"<p>Start Date: {StartDate}</p>");
        testInfoBuilder.AppendLine($"<p>Finish Date: {EndDate}</p>");
        testInfoBuilder.AppendLine($"<p>Status: {Status}</p>");

        if (AdditionalInfo != null)
            foreach (var item in AdditionalInfo)
                testInfoBuilder.AppendLine($"<p>{item.Key}: {item.Value}</p>");


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
    }

    public string TestKey { get; }
    public string TestName { get; }
    public DateTime StartDate { get; }
    public DateTime EndDate { get; }
    public string Status { get; }
    public IReadOnlyDictionary<string, string>? AdditionalInfo { get; }
}