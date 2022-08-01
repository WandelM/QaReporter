namespace QaReporter.Models
{
    /// <summary>
    /// Informations aboud evidence
    /// </summary>
    public class EvidenceInfo
    {
        /// <summary>
        /// Base64 converted screenshot
        /// </summary>
        public string Base64Screenshot { get; }

        /// <summary>
        /// Name of the screenshot file
        /// </summary>
        public string FileName
        {
            get
            {
                return string.IsNullOrEmpty(_fileName) ? $"screenshot_{Guid.NewGuid}.png" : _fileName;
            }
        }
        private string _fileName;

        public EvidenceInfo(string base64Screenshot, string fileName = "")
        {
            Base64Screenshot = base64Screenshot;
            _fileName = fileName;
        }
    }
}