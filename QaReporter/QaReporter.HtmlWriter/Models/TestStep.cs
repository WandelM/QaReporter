namespace QaReporter.HtmlWriter
{
    /// <summary>
    /// Single test step model
    /// </summary>
    public class TestStep
    {
        public TestStep(string id, string instruction, string expectedResult, IReadOnlyList<StepScreenshot>? stepScreenshots = null)
        {
            Id = id;
            Instruction = instruction;
            ExpectedResult = expectedResult;
            StepScreenshots = stepScreenshots;
        }

        /// <summary>
        /// Unique id of step
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Step instruction
        /// </summary>
        public string Instruction { get; }

        /// <summary>
        /// Step expected result
        /// </summary>
        public string ExpectedResult { get; }

        /// <summary>
        /// Status of step taken
        /// </summary>
        public Status Status { get; }

        /// <summary>
        /// List os screenshots taken in step
        /// </summary>
        public IReadOnlyList<StepScreenshot>? StepScreenshots { get; }
    }
}