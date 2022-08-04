using QaReporter.Abstraction;
using QaReporter.HtmlWriter.Mappers;

namespace QaReporter.HtmlWriter;

public class HtmlWriter : IRecordWriter
{
    public string WriterName => "Simple Html Writer";
    private readonly RecordMapper _recordMapper;
    public string WritePath { get; }

    public HtmlWriter(string writePath)
    {
        WritePath = writePath;
        _recordMapper = new RecordMapper();
    }

    public void Write(ReportRecord reportRecord)
    {
        var mappedHtml = _recordMapper.Map(reportRecord);
        File.WriteAllText(GetFileFullPath(reportRecord.TestInfo.TestKey), mappedHtml.Render());
    }

    public async Task WriteAsync(ReportRecord reportRecord)
    {
        var mappedHtml = _recordMapper.Map(reportRecord);
        await File.WriteAllTextAsync(GetFileFullPath(reportRecord.TestInfo.TestKey), mappedHtml.Render());
        await Task.CompletedTask;
    }

    private string GetFileFullPath(string testKey)
    {
        var fileName = string.Format("{0}_report_{1}.html", testKey, DateTime.UtcNow.ToString("yyyy-MM-dd_HH-mm-ss-ffff"));
        return Path.Combine(WritePath ?? Directory.GetCurrentDirectory(), fileName);
    }
}
