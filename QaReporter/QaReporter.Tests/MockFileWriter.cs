using Newtonsoft.Json;
using QaReporter.Abstraction;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace QaReporter.Tests;

public class MockFileWriter : IRecordWriter
{
    public string WriterName => "Mock File Writer";
    public string WritePath => Directory.GetCurrentDirectory();

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
        var fullPath = Path.Combine(WritePath, "report.txt");
        File.WriteAllText(fullPath, recordString);
    }

    public async Task WriteAsync(ReportRecord reportRecord)
    {
        var recordString = MapRecord(reportRecord);
        var fullPath = Path.Combine(WritePath, "report.txt");
        await File.WriteAllTextAsync(fullPath, recordString);
        await Task.CompletedTask;
    }
}

public class MockJsonWriter : IRecordWriter
{
    public string WriterName => "Mock Json Writer";
    public string WritePath => Directory.GetCurrentDirectory();

    public void Write(ReportRecord reportRecord)
    {
        var convertedRecord = JsonConvert.SerializeObject(reportRecord);
        var fullPath = Path.Combine(WritePath, "report.json");
        File.WriteAllText(fullPath, convertedRecord);
    }

    public async Task WriteAsync(ReportRecord reportRecord)
    {
        var convertedRecord = JsonConvert.SerializeObject(reportRecord);
        var fullPath = Path.Combine(WritePath, "report.json");
        await File.WriteAllTextAsync(fullPath, convertedRecord);
        await Task.CompletedTask;
    }
}
