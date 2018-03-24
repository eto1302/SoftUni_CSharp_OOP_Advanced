using OpenClosedAndLiskov.Models.Contracts;

namespace OpenClosedAndLiskov.Models
{
    internal class FileAppender : IAppender
    {
        private ILayout layout;
        private ErrorLevel errorLevel;
        private ILogFile logFile;
        public FileAppender(ILayout layout, ErrorLevel errorLevel, ILogFile logFile)
        {
            this.Layout = layout;
            this.Level = errorLevel;
            this.logFile = logFile;
            this.MessagesAppended = 0;
        }


        public ErrorLevel Level { get; }
        public ILayout Layout { get; }
        public int MessagesAppended { get; private set; }

        public void Append(IError error)
        {
            string formattedError = this.Layout.FormatError(error);
            this.logFile.WriteToFile(formattedError);
        }

        public override string ToString()
        {
            string result =
                $"Appender type: {this.GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {this.Level}, Messages appended: {this.MessagesAppended}, File size: {this.logFile.Size}";
            return result;
        }
    }
}