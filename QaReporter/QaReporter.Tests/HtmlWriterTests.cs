using NUnit.Framework;
using QaReporter.HtmlWriter;
using QaReporter.Models;
using System;
using System.IO;

namespace QaReporter.Tests
{
    public  class HtmlWriterTests
    {
        private ReportRecord _record;

        [SetUp]
        public void SetUp()
        {
            var testInfo = new TestInfo("TEST-1", "This is mocked report record");

            _record = new ReportRecord(testInfo);

            var step1 = new StepInstructions("Step1", "Mock step 1", "Mock expected 1");
            var step1Screenshot = new EvidenceInfo(HelperConsts.Base64Screenshot, "step1.png");

            _record.AddReportStep(step1, step1Screenshot, DateTime.UtcNow);

            var step2 = new StepInstructions("Step2", "Mock step 2", "Mock expected 2");
            var step2Screenshot = new EvidenceInfo(HelperConsts.Base64Screenshot, "step2.png");

            _record.AddReportStep(step2, step2Screenshot, DateTime.UtcNow, Models.Status.Failed);
            _record.FinishTest();
        }

        [Test]
        public void WritersShouldNotBeNull()
        {
            var writer = new HtmlWriter.HtmlWriter(Directory.GetCurrentDirectory());

            writer.Write(_record);
        }
    }
}
