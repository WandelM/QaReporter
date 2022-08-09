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
            .WithCssStyles(ReportCss)
            .Build();

        return reportBuilded;
    }

    public static RecordMapper Instance => new RecordMapper();
    
    //TODO: Move it to separate file as a tamplate and read file during report generation
    private const string ReportCss = @"
                        *{
                            font-family: 'Trebuchet MS', 'Lucida Sans Unicode', 'Lucida Grande', 'Lucida Sans', Arial, sans-serif;
                            margin: 0;
                            padding: 0;
                        }
                        #test-info p{
                            font-weight: 700;
                            margin: .5em;
                            padding: 0;
                        }
                        #test-info h2{
                            font-weight: 700;
                            margin: .5em;
                        }
                        img{
                            width: 100%;
                            margin-top: .5em;
                            margin-bottom: .5em;
                        }
                        #test-title{
                            text-align: center;
                        }
                        ";
}
