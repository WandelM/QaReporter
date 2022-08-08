
namespace QaReporter.HtmlWriter.Mappers
{
    public interface IRecordMapper<T>
    {
        T Map(ReportRecord reportRecord);
    }
}