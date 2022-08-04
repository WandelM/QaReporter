using System.Text;

namespace QaReporter.HtmlWriter;

public class TestStepTemplate: IHtmlSectionRenderer
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

        stepBuilder.AppendLine(MarkupHelper.HorizontalLine());
        stepBuilder.AppendLine(MarkupHelper.Paragraph($"Status: {step.Status}"));
        stepBuilder.AppendLine(MarkupHelper.Paragraph($"Step id: {step.Id}"));
        stepBuilder.AppendLine(MarkupHelper.Paragraph($"Step instruction: {step.Instruction}"));
        stepBuilder.AppendLine(MarkupHelper.Paragraph($"Step expected result: {step.ExpectedResult}"));

        if (step.StepScreenshots != null && step.StepScreenshots.Any())
        {
            foreach (var evidence in step.StepScreenshots)
            {
                stepBuilder.AppendLine(MarkupHelper.ImageBase64(evidence.Base64StrinScreenshot, evidence.FileName));
            }
        }
        stepBuilder.AppendLine(MarkupHelper.HorizontalLine());

        return stepBuilder.ToString();
    }

    public TestStepTemplate(IReadOnlyList<TestStep> testSteps)
    {
        TestSteps = testSteps;
    }

    public IReadOnlyList<TestStep> TestSteps { get; }
}
