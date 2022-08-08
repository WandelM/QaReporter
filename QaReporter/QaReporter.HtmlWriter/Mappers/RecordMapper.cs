namespace QaReporter.HtmlWriter.Mappers;

/// <summary>
/// Simple mapper used to map ReportRecord into HtmlReportRendere, which will later render report
/// </summary>
public class RecordMapper : IRecordMapper<HtmlReportRenderer>
{
    public HtmlReportRenderer Map(ReportRecord reportRecord)
    {
        var testInfo = new TestInfoBuilder()
            .WithTestName(reportRecord.TestInfo.TestName)
            .WithTestKey(reportRecord.TestInfo.TestKey)
            .WithStartDate(reportRecord.StartDate)
            .WithEndDate(reportRecord.EndDate)
            .WithStatus(reportRecord.Status.ToString())
            .Build();

        var mappedSteps = reportRecord
            .Steps
            .Select(s => new TestStep(s.Id, s.Instruction, s.ExpectedResult, s.Evidences
                                                                              .Select(e => new StepScreenshot(e.FileName, e.Base64Screenshot)).ToList())).ToList();

        var testSteps = new TestStepRenderer(mappedSteps);

        var reportBuilded = HtmlReportBuilder.Create()
            .WithTestName(reportRecord.TestInfo.TestName)
            .WithTestInfoTemplate(testInfo)
            .WithStepsTemplate(testSteps.Render())
            .Build();

        return reportBuilded;
    }

    public static RecordMapper Instance => new RecordMapper();
}
