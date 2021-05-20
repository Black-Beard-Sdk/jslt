using System.Collections.Generic;
using System.Linq;

namespace Bb.Json.Jslt.Parser
{

    public class Diagnostics : List<ErrorModel>
    {


        #region Add

        public void AddInformation(string filename, int line, int startIndex, int column, string text, string message)
        {
            this.Add(new ErrorModel()
            {
                Filename = filename,
                Line = line,
                StartIndex = startIndex,
                Column = column,
                Text = text,
                Message = message,
                Severity = SeverityEnum.Information,
            });

        }

        public void AddInformation(string filename, TokenLocation location, string text, string message)
        {
            this.Add(new ErrorModel()
            {
                Filename = filename,
                Line = location.Line,
                StartIndex = location.StartIndex,
                Column = location.Column,
                Text = text,
                Message = message,
                Severity = SeverityEnum.Information,
            });

        }



        public void AddWarning(string filename, int line, int startIndex, int column, string text, string message)
        {
            this.Add(new ErrorModel()
            {
                Filename = filename,
                Line = line,
                StartIndex = startIndex,
                Column = column,
                Text = text,
                Message = message,
                Severity = SeverityEnum.Warning,
            });

        }

        public void AddWarning(string filename, TokenLocation location, string text, string message)
        {
            this.Add(new ErrorModel()
            {
                Filename = filename,
                Line = location.Line,
                StartIndex = location.StartIndex,
                Column = location.Column,
                Text = text,
                Message = message,
                Severity = SeverityEnum.Warning,
            });

        }



        public void AddError(string filename, int line, int startIndex, int column, string text, string message)
        {
            this.Add(new ErrorModel()
            {
                Filename = filename,
                Line = line,
                StartIndex = startIndex,
                Column = column,
                Text = text,
                Message = message,
                Severity = SeverityEnum.Error   ,
            });

        }

        public void AddError(string filename, TokenLocation location, string text, string message)
        {
            this.Add(new ErrorModel()
            {
                Filename = filename,
                Line = location.Line,
                StartIndex = location.StartIndex,
                Column = location.Column,
                Text = text,
                Message = message,
                Severity = SeverityEnum.Error,
            });

        }



        public void AddDiagnostic(SeverityEnum severityEnum, string filename, int line, int startIndex, int column, string text, string message)
        {
            this.Add(new ErrorModel()
            {
                Filename = filename,
                Line = line,
                StartIndex = startIndex,
                Column = column,
                Text = text,
                Message = message,
                Severity = severityEnum,
            });

        }

        public void AddDiagnostic(SeverityEnum severityEnum, string filename, TokenLocation location, string text, string message)
        {
            this.Add(new ErrorModel()
            {
                Filename = filename,
                Line = location.Line,
                StartIndex = location.StartIndex,
                Column = location.Column,
                Text = text,
                Message = message,
                Severity = severityEnum,
            });

        }

        #endregion Add

        public IEnumerable<ErrorModel> Errors { get => this.Where(c => c.Severity == SeverityEnum.Error); }

        public bool Success { get => !this.Any(c => c.Severity == SeverityEnum.Error); }

    }

}
