namespace QaReporter.HtmlWriter;

/// <summary>
/// Builder for test info
/// </summary>
public class TestInfoBuilder
{
    public string Build()
    {
        if (string.IsNullOrEmpty(TestKey) || string.IsNullOrEmpty(TestName) || StartDate == null || EndDate == null || string.IsNullOrEmpty(Status))
            throw new Exception("Please provide all values needed");

        var testInfoRenderer = new TestInfoRenderer(TestKey, TestName, StartDate.Value, EndDate.Value, Status, AdditionalInfo);
        return testInfoRenderer.Render();
    }

    public TestInfoBuilder WithTestKey(string testKey)
    {
        TestKey = testKey;
        return this;
    }

    public TestInfoBuilder WithTestName(string testName)
    {
        TestName = testName;
        return this;
    }

    public TestInfoBuilder WithStartDate(DateTime startDate)
    {
        StartDate = startDate;
        return this;
    }

    public TestInfoBuilder WithEndDate(DateTime endDate)
    {
        EndDate = endDate;
        return this;
    }

    public TestInfoBuilder WithStatus(string status)
    {
        Status = status;
        return this;
    }

    public TestInfoBuilder WithAdditionalInfo(IReadOnlyDictionary<string,string> additionalInfo)
    {
        AdditionalInfo = additionalInfo;
        return this;
    }

    public static TestInfoBuilder Create()
    {
        return new TestInfoBuilder();
    }

    private string? TestKey;
    private string? TestName;
    private DateTime? StartDate;
    private DateTime? EndDate;
    private string? Status;
    private IReadOnlyDictionary<string, string>? AdditionalInfo;
}
