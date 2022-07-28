using QaReporter.Abstraction;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace QaReporter.Tests;

public class MockFileWriter : IRecordWriter
{
    public string WriterName => "Mock File Writer";

    private string MapRecord(ReportRecord reportRecord)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine($"Test name: {reportRecord.TestInfo.TestName}");
        builder.AppendLine($"Test Key: {reportRecord.TestInfo.TestKey}");

        return builder.ToString();
    }

    public void Write(ReportRecord reportRecord)
    {
        var recordString = MapRecord(reportRecord);
        var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "report.txt");
        File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory, recordString);
    }

    public async Task WriteAsync(ReportRecord reportRecord)
    {
        var recordString = MapRecord(reportRecord);
        var fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "report.txt");
        await File.WriteAllTextAsync(AppDomain.CurrentDomain.BaseDirectory, recordString);
        await Task.CompletedTask;
    }
}
