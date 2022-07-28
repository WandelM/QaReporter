namespace QaReporter.Abstraction;

/// <summary>
/// Abstraction over every single test record writer
/// </summary>
public interface IRecordWriter
{
    string WriterName { get; }
    void Write(ReportRecord reportRecord);
    Task WriteAsync(ReportRecord reportRecord);
}
