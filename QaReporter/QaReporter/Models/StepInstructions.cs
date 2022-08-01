namespace QaReporter.Models;

/// <summary>
/// Instructions of individual step
/// </summary>
public class StepInstructions
{
    /// <summary>
    /// Unique id of a step
    /// </summary>
    public string StepId { get; }
    
    /// <summary>
    /// Step instruction
    /// </summary>
    public string Instruction { get; }

    /// <summary>
    /// Expected result of a step
    /// </summary>
    public string ExpectedResult { get; }

    public StepInstructions(string stepId, string action, string expectedResult)
    {
        StepId = stepId;
        Instruction = action;
        ExpectedResult = expectedResult;
    }
}
