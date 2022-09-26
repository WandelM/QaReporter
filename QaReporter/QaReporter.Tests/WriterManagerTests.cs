using NUnit.Framework;
using QaReporter.Abstraction;
using System;
using System.Threading.Tasks;

namespace QaReporter.Tests;

[TestFixture]
public class WriterManagerTests
{
    private IRecordWriter mockWriterPrimary;
    private IRecordWriter mockWriterSecondary;
    private IRecordWriter mockWriterTertiary;
    private WriterManager manager;

    public WriterManagerTests()
    {
        mockWriterPrimary = new MockFileWriter();
        mockWriterSecondary = new MockFileWriter();
        mockWriterTertiary = new MockJsonWriter();
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
        IRecordWriter? nullRecordWriter = null;

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
    public void UserShouldBeAbleToRegisterMultipleWriters()
    {
        manager.Register(mockWriterPrimary);
        manager.Register(mockWriterTertiary);

        Assert.That(manager.Writers.Count, Is.EqualTo(2));
    }
}
