# Welcome! It's QaReporter

QaReporter is easy to use and fully free, small and fast library for reporting into html file in automation tests frameworks, like Selenium or Playwright. It's based on .NET6 and is still under development. Feel free to fetch and use.


# How to start ?

Simply, start with creating new TestRecord inside of your test class by
```
TestInfo = new TestInfo("TEST-1", "This is the mock test");
ReportRecord record = new ReportRecord(testInfo);
```

Inside of your test log step, by calling AddReportStep() method
```
var step = new StepInstructions("Step1", "Mock step 1", "Mock expected 1");
//taking base 64 screenshot logic
var screenshotInfo = new EvidenceInfo(base64Screenshot, "step1.png");
record.AddReportStep(step, screenshotInfo);
```
After finishing test execution, call
```
record.FinishTest();
```
