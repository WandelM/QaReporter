using QaReporter.Models;

namespace QaReporter;

/// <summary>
/// Single report record from test. Contains all data needed for test, including start and end date or steps.
/// </summary>
public class ReportRecord
{
    /// <summary>
    /// Info about test
    /// </summary>
    public TestInfo TestInfo { get; }

    /// <summary>
    /// Start date of a test
    /// </summary>
    public DateTime StartDate { get; }

    /// <summary>
    /// End date of a test
    /// </summary>
    public DateTime EndDate { get; private set; }

    /// <summary>
    /// Status of a test
    /// </summary>
    public Status Status { get; private set; }

    /// <summary>
    /// Steps taken in test
    /// </summary>
    public IReadOnlyList<StepInfo> Steps => _steps;
    private List<StepInfo> _steps;

    public ReportRecord(TestInfo testInfo)
    {
        TestInfo = testInfo;
        StartDate = DateTime.UtcNow;
        _steps = new List<StepInfo>();
        EndDate = default;
    }

    /// <summary>
    /// Add step into test record
    /// </summary>
    /// <param name="instructions">Step instructions</param>
    /// <param name="stepEvidences">List of evidences from the test</param>
    /// <param name="timestamp">Timestamp of the step</param>
    /// <param name="stepStatus">Status of the step</param>
    public void AddReportStep(StepInstructions instructions, IReadOnlyList<EvidenceInfo> stepEvidences, DateTime timestamp = default, Status stepStatus = Status.Passed)
    {
        var stepInfo = new StepInfo(instructions.StepId, instructions.Instruction, instructions.ExpectedResult, timestamp, stepStatus);
        stepInfo.AddEvidences(stepEvidences);
        _steps.Add(stepInfo);
    }

    /// <summary>
    /// Adds step into test record with one evidence
    /// </summary>
    /// <param name="instructions">Step instructions</param>
    /// <param name="stepEvidence">Single evidence from the test</param>
    /// <param name="timestamp">Timestamp of the step</param>
    /// <param name="stepStatus">Status of the step</param>
    public void AddReportStep(StepInstructions instructions, EvidenceInfo stepEvidence, DateTime timestamp = default, Status stepStatus = Status.Passed)
    {
        var stepInfo = new StepInfo(instructions.StepId, instructions.Instruction, instructions.ExpectedResult, timestamp, stepStatus);
        stepInfo.AddEvidence(stepEvidence);
        _steps.Add(stepInfo);
    }

    /// <summary>
    /// Adds step without evidences
    /// </summary>
    /// <param name="instructions">Step instructions</param>
    /// <param name="timestamp">Timestamp of the step</param>
    /// <param name="stepStatus">Status of the step</param>
    public void AddReportStep(StepInstructions instructions, DateTime timestamp = default, Status stepStatus = Status.Passed)
    {
        var stepInfo = new StepInfo(instructions.StepId, instructions.Instruction, instructions.ExpectedResult, timestamp, stepStatus);
        _steps.Add(stepInfo);
    }

    /// <summary>
    /// Finishes execution of the test
    /// </summary>
    public void FinishTest()
    {
        EndDate = DateTime.UtcNow;
        Status = _steps.Any(step => step.Status == Status.Failed) ? Status.Failed : Status.Passed;
    }
}
