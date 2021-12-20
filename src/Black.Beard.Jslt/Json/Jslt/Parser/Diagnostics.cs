using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Bb.Json.Jslt.Parser
{

    public class Diagnostics : IList<ErrorModel>, System.Collections.Specialized.INotifyCollectionChanged
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

            if (location == null)
                location = new TokenLocation();

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
                Severity = SeverityEnum.Error,
            });

        }

        public void AddError(string filename, TokenLocation location, string text, string message)
        {

            if (location == null)
                location = new TokenLocation();

            this.Add(new ErrorModel()
            {
                Filename = filename,
                Line = location?.Line ?? 0,
                StartIndex = location?.StartIndex ?? 0,
                Column = location?.Column ?? 0,
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

            if (location == null)
                location = new TokenLocation();

            this.Add(new ErrorModel()
            {
                Filename = filename,
                Line = location?.Line ?? 0,
                StartIndex = location?.StartIndex ?? 0,
                Column = location?.Column ?? 0,
                Text = text,
                Message = message,
                Severity = severityEnum,
            });
        }

        #endregion Add

        #region Implemente IList

        public IEnumerator<ErrorModel> GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this._list.GetEnumerator();
        }

        public int IndexOf(ErrorModel item)
        {
            return this._list.IndexOf(item);
        }

        public void Insert(int index, ErrorModel item)
        {
            this._list.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            this._list.RemoveAt(index);
        }

        public void Add(ErrorModel item)
        {
            if (item != null)
            {
                this._list.Add(item);
                if (CollectionChanged != null)
                {
                    var args = new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add);
                    args.NewItems.Add(item);
                    CollectionChanged(this, args);
                }
            }
        }

        public void Clear()
        {
            this._list.Clear();
        }

        public bool Contains(ErrorModel item)
        {
            return this._list.Contains(item);
        }

        public void CopyTo(ErrorModel[] array, int arrayIndex)
        {
            this._list.CopyTo(array, arrayIndex);
        }

        public bool Remove(ErrorModel item)
        {
            return this._list.Remove(item);
        }

        #endregion Implemente IList

        public IEnumerable<ErrorModel> Errors { get => this._list.Where(c => c.Severity == SeverityEnum.Error); }

        public bool Success { get => !this._list.Any(c => c.Severity == SeverityEnum.Error); }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public ErrorModel this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private List<ErrorModel> _list = new List<ErrorModel>();

    }

}
