namespace QaReporter.Abstraction;

/// <summary>
/// Abstraction over writer manager
/// </summary>
public interface IWriterManager
{
    IReadOnlyList<IRecordWriter> Writers { get; }
    void Register(IRecordWriter writer);
    void Unregister(IRecordWriter writer);
    void SaveReports(ReportRecord reportRecord);
    Task SaveReportsAsync(ReportRecord reportRecord);
}
