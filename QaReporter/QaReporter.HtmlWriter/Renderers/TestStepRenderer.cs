using QaReporter.HtmlWriter.Abstractions;
using System.Text;

namespace QaReporter.HtmlWriter;

/// <summary>
/// Steps renderer
/// </summary>
public class TestStepRenderer : IHtmlSectionRenderer
{
    public string Render()
    {
        var stepsBuilder = new StringBuilder();

        foreach (var step in TestSteps)
        {
            var renderedStep = RenderSingleStep(step);
            stepsBuilder.AppendLine(renderedStep);
        }

        return stepsBuilder.ToString();
    }

    private string RenderSingleStep(TestStep step)
    {
        var stepBuilder = new StringBuilder();

        stepBuilder.AppendLine(_markupService.HorizontalLine());
        stepBuilder.AppendLine("<div class='report-step'>");
        stepBuilder.AppendLine(_markupService.Paragraph($"Status: {step.Status}"));
        stepBuilder.AppendLine(_markupService.Paragraph($"Step id: {step.Id}"));
        stepBuilder.AppendLine(_markupService.Paragraph($"Step instruction: {step.Instruction}"));
        stepBuilder.AppendLine(_markupService.Paragraph($"Step expected result: {step.ExpectedResult}"));

        if (step.StepScreenshots != null && step.StepScreenshots.Any())
        {
            foreach (var evidence in step.StepScreenshots)
            {
                stepBuilder.AppendLine(_markupService.ImageBase64(evidence.Base64StrinScreenshot, evidence.FileName));
            }
        }

        stepBuilder.AppendLine("</div>");

        return stepBuilder.ToString();
    }

    public TestStepRenderer(IReadOnlyList<TestStep> testSteps)
    {
        TestSteps = testSteps;
        _markupService = new MarkupService();
    }

    /// <summary>
    /// Steps associated with test
    /// </summary>
    public IReadOnlyList<TestStep> TestSteps { get; }
    private readonly MarkupService _markupService;
}
