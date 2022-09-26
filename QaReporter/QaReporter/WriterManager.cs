using QaReporter.Abstraction;

namespace QaReporter;

/// <summary>
/// Manages writers and saves all reports if needed
/// </summary>
public class WriterManager : IWriterManager
{
    /// <summary>
    /// All registered writers
    /// </summary>
    public IReadOnlyList<IRecordWriter> Writers => _writers;
    private readonly List<IRecordWriter> _writers;
    
    public WriterManager()
    {
        _writers = new List<IRecordWriter>();
    }

    /// <summary>
    /// Registers new report writer
    /// </summary>
    /// <param name="writer">Writer</param>
    /// <exception cref="NullReferenceException"></exception>
    public void Register(IRecordWriter writer)
    {
        if (writer == null)
            throw new NullReferenceException($"Writer cannot be null {nameof(writer)}");

        if (_writers.Exists(w => w.WriterName == writer.WriterName))
            return;

        _writers.Add(writer);
    }

    /// <summary>
    /// Removes writer from writers list
    /// </summary>
    /// <param name="writer"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void Unregister(IRecordWriter writer)
    {
        if (_writers.Contains(writer))
            _writers.Remove(writer);
    }

    /// <summary>
    /// Saves report using all registered writers
    /// </summary>
    /// <param name="reportRecord">Report Record</param>
    /// <exception cref="Exception"></exception>
    public void SaveReports(ReportRecord reportRecord)
    {
        if (!_writers.Any())
            throw new Exception("No Writers registered");

        foreach (var writer in _writers)
            writer.Write(reportRecord);
    }

    /// <summary>
    /// Saves report using all registered writers in async way
    /// </summary>
    /// <param name="reportRecord">Report Record</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public async Task SaveReportsAsync(ReportRecord reportRecord)
    {
        if (!_writers.Any())
            throw new InvalidOperationException("No Writers registered");

        foreach (var writer in _writers)
            await writer.WriteAsync(reportRecord);
    }
}
