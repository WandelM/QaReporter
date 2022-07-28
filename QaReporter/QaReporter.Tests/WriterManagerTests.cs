using NUnit.Framework;
using QaReporter.Abstraction;
using System;

namespace QaReporter.Tests;

[TestFixture]
public class WriterManagerTests
{
    private IRecordWriter mockWriterPrimary;
    private IRecordWriter mockWriterSecondary;
    private WriterManager manager;

    public WriterManagerTests()
    {
        mockWriterPrimary = new MockFileWriter();
        mockWriterSecondary = new MockFileWriter();
    }

    [SetUp]
    public void SetUp()
    {
        manager = new WriterManager();
    }

    [Test]
    public void WritersShouldNotBeNull()
    {
        Assert.IsNotNull(manager.Writers);
    }

    [Test]
    public void WhenWriterIsNullWriterIsRegisteredExceptionShouldBeThrown()
    {
        IRecordWriter nullRecordWriter = null;

        Assert.Throws<NullReferenceException>(() => manager.Register(nullRecordWriter));
    }

    [Test]
    public void UserShouldBeAbleToRegisterNewWriter()
    {
        manager.Register(mockWriterPrimary);

        Assert.That(manager.Writers.Count, Is.EqualTo(1));
    }

    [Test]
    public void WhenTheSameSecondWriterIsRegisteredThenItShouldNotBeAddedToWriterList()
    {
        manager.Register(mockWriterPrimary);
        manager.Register(mockWriterSecondary);

        Assert.That(manager.Writers.Count, Is.EqualTo(1));
    }

    [Test]
    public void WhenSavesReportsWithoutWritersAttachesExceptionShouldBeThrown()
    {
        ReportRecord record = new ReportRecord(new Models.TestInfo("Key1", "Test1"));

        Assert.Throws<Exception>(() => manager.SaveReportsAsync(record));
    }
}
