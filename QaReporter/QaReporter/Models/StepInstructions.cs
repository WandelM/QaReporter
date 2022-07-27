namespace QaReporter.Models;

public class StepInstructions
{
    public string StepId { get; }
    public string Instruction { get; }
    public string ExpectedResult { get; }

    public StepInstructions(string stepId, string action, string expectedResult)
    {
        StepId = stepId;
        Instruction = action;
        ExpectedResult = expectedResult;
    }
}
