using QaReporter.Abstraction;
using QaReporter.HtmlWriter.Mappers;

namespace QaReporter.HtmlWriter;

/// <summary>
/// Simple html report writer
/// </summary>
public class HtmlWriter : IRecordWriter
{
    public string WriterName => "Simple Html Writer";
    private readonly IRecordMapper<HtmlReportRenderer> _recordMapper;
    public string WritePath { get; }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="writePath">Path where report should be placed (without file name)</param>
    /// <param name="recordMapper">Mapper which will map ReportRecord into HtmlReportRenderer</param>
    public HtmlWriter(string writePath, IRecordMapper<HtmlReportRenderer> recordMapper)
    {
        WritePath = writePath;
        _recordMapper = recordMapper;
    }

    /// <summary>
    /// Saves ReportRecord to html report file
    /// </summary>
    /// <param name="reportRecord"></param>
    public void Write(ReportRecord reportRecord)
    {
        var mappedHtml = _recordMapper.Map(reportRecord);
        File.WriteAllText(GetFileFullPath(reportRecord.TestInfo.TestKey), mappedHtml.Render());
    }

    /// <summary>
    /// Saves ReportRecord to html report file in async way
    /// </summary>
    /// <param name="reportRecord"></param>
    /// <returns></returns>
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
