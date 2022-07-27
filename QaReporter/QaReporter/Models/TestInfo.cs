namespace QaReporter.Models
{
    /// <summary>
    /// Data class which holds test specyfic data like Test Key or Test Name
    /// </summary>
    public class TestInfo
    {
        /// <summary>
        /// Unique key of a test
        /// </summary>
        public string TestKey { get; }

        /// <summary>
        /// Name of a test
        /// </summary>
        public string TestName { get; }

        public TestInfo(string testKey, string testName)
        {
            TestKey = testKey;
            TestName = testName;
        }
    }
}