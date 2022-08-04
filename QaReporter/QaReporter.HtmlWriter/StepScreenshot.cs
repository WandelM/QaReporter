namespace QaReporter.HtmlWriter
{
    public class StepScreenshot
    {
        public StepScreenshot(string fileName, string base64StrinScreenshot)
        {
            FileName = fileName;
            Base64StrinScreenshot = base64StrinScreenshot;
        }

        public string FileName { get; }
        public string Base64StrinScreenshot { get; }
    }
}