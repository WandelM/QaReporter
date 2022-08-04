namespace QaReporter.HtmlWriter
{
    public class TestStep
    {
        public TestStep(string id, string instruction, string expectedResult, IReadOnlyList<StepScreenshot> stepScreenshots = null)
        {
            Id = id;
            Instruction = instruction;
            ExpectedResult = expectedResult;
            StepScreenshots = stepScreenshots;
        }

        public string Id { get; }
        public string Instruction { get; }
        public string ExpectedResult { get; }
        public Status Status { get; }
        public IReadOnlyList<StepScreenshot>? StepScreenshots { get; }
    }
}