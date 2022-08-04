namespace QaReporter.HtmlWriter.Mappers;

public class RecordMapper
{ 
    public HtmlReportTemplate Map(ReportRecord reportRecord)
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

        var testSteps = new TestStepTemplate(mappedSteps);

        var reportBuilded = HtmlReportBuilder.Create()
            .WithTestName(reportRecord.TestInfo.TestName)
            .WithTestInfoTemplate(testInfo)
            .WithStepsTemplate(testSteps.Render())
            .Build();

        return reportBuilded;
    }
}
