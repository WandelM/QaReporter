using NUnit.Framework;
using QaReporter.Models;
using System;

namespace QaReporter.Tests
{
    [TestFixture]
    public class StepInfoTests
    {
        [Test]
        public void Evidences_Should_Be_Not_Null()
        {
            var testInfo = new StepInfo("Step", "Instruction", "Expected", DateTime.UtcNow, Status.Passed);

            Assert.IsNotNull(testInfo.Evidences);
        }

        [Test]
        public void Evidences_Should_Contain_One_Item()
        {
            var testInfo = new StepInfo("Step", "Instruction", "Expected", DateTime.UtcNow, Status.Passed);

            testInfo.AddEvidence(new EvidenceInfo("fakeBase64", "fakeName.png"));

            Assert.IsNotNull(testInfo.Evidences);
            Assert.That(testInfo.Evidences.Count == 1);
        }

        [Test]
        public void EvidanceShouldStayEmptyIfEvidenceIsNull()
        {
            var testInfo = new StepInfo("Step1", "Instruction1", "Expected1", DateTime.UtcNow, Status.Passed);

            testInfo.AddEvidence(null);

            Assert.IsNotNull(testInfo.Evidences);
            Assert.That(testInfo.Evidences.Count == 0);
        }
    }
}
