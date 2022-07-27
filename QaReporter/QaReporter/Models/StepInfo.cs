namespace QaReporter.Models;

/// <summary>
/// Step informations
/// </summary>
public class StepInfo
{
    /// <summary>
    /// Unique id of the step
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
    /// Timestamp of the step
    /// </summary>
    public DateTime Timestamp { get; }

    /// <summary>
    /// Status of step
    /// </summary>
    public Status Status { get; }

    /// <summary>
    /// Step evidences - base64 screenshots
    /// </summary>
    public IReadOnlyList<EvidenceInfo> Evidences => _evidences;
    private List<EvidenceInfo> _evidences;
    

    public StepInfo(
        string id,
        string instruction,
        string expectedResult,
        DateTime timestamp,
        Status status)
    {
        Id = id;
        Instruction = instruction;
        ExpectedResult = expectedResult;
        Timestamp = timestamp;
        Status = status;
        _evidences = new List<EvidenceInfo>();
    }

    /// <summary>
    /// Adds single evidence into step
    /// </summary>
    /// <param name="evidenceInfo">Info about evidence</param>
    public void AddEvidence(EvidenceInfo? evidenceInfo)
    {
        if (evidenceInfo == null)
            return;

        _evidences.Add(evidenceInfo);
    }

    /// <summary>
    /// Adds collection of evidences into step
    /// </summary>
    /// <param name="evidenceInfos"></param>
    public void AddEvidences(IReadOnlyList<EvidenceInfo>? evidenceInfos)
    {
        if (evidenceInfos == null)
            return;

        _evidences.AddRange(evidenceInfos);
    }
}
