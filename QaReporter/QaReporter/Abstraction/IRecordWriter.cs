namespace QaReporter.Abstraction;

/// <summary>
/// Abstraction over every single test record writer
/// </summary>
public interface IRecordWriter
{
    string WriterName { get; }
    string WritePath { get; }
    void Write(ReportRecord reportRecord);
    Task WriteAsync(ReportRecord reportRecord);
}
