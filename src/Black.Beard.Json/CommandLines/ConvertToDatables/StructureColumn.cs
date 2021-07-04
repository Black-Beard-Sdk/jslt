using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Diagnostics;

namespace Bb.ConvertToDatables
{

    [DebuggerDisplay("{Name} {DbType}")]
    public class StructureColumn
    {


        public StructureColumn()
        {

            Initialize = null;

        }

        public string Name { get; set; }

        public string Caption { get; set; }

        /// <summary>
        /// By default the value is String
        /// </summary>
        public System.Data.DbType? DbType { get; set; }

        public int MaxLength { get; set; } = 256;

        public int Ordinal { get; set; } = -1;

        public JToken DefaultValue { get; set; }

        public bool IsPrimary { get; set; }

        public bool IsUnique { get; set; }

        public bool Nullable { get; set; }

        public System.Data.DataSetDateTime DateTimeMode { get; set; } = System.Data.DataSetDateTime.Utc;
        public StructureSchema Schema { get; internal set; }

        public DataColumn DataColumn { get; internal set; }
        
        public Func<object> Initialize { get; internal set; }


        /// <summary>
        /// Return the type of the specified TypeName
        /// </summary>
        /// <returns></returns>
        public System.Type GetColumnType()
        {

            if (DbType == null)
                DbType = System.Data.DbType.String;

            if (_type == null)
                ResolveType();

            return _type;

        }

        private void ResolveType()
        {
            lock (_lock)
                if (_type == null)
                {

                    switch (this.DbType)
                    {
                        case System.Data.DbType.StringFixedLength:
                        case System.Data.DbType.String:
                        case System.Data.DbType.AnsiString:
                        case System.Data.DbType.AnsiStringFixedLength:
                            _type = typeof(System.String);
                            break;

                        case System.Data.DbType.Guid:
                            _type = typeof(System.Guid);
                            break;

                        case System.Data.DbType.Boolean:
                            _type = typeof(System.Boolean);
                            break;

                        case System.Data.DbType.VarNumeric:
                        case System.Data.DbType.Single:
                        case System.Data.DbType.Double:
                        case System.Data.DbType.Decimal:
                        case System.Data.DbType.Currency:
                            _type = typeof(System.Double);
                            break;

                        case System.Data.DbType.UInt16:
                            _type = typeof(System.UInt16);
                            break;
                        case System.Data.DbType.UInt32:
                            _type = typeof(System.UInt32);
                            break;
                        case System.Data.DbType.UInt64:
                            _type = typeof(System.UInt64);
                            break;
                        case System.Data.DbType.Int16:
                            _type = typeof(System.Int16);
                            break;
                        case System.Data.DbType.Int32:
                            _type = typeof(System.Int32);
                            break;
                        case System.Data.DbType.Int64:
                            _type = typeof(System.Int64);
                            break;

                        case System.Data.DbType.Date:
                        case System.Data.DbType.DateTime:
                        case System.Data.DbType.DateTime2:
                            _type = typeof(System.DateTime);
                            break;
                        case System.Data.DbType.DateTimeOffset:
                            _type = typeof(System.DateTimeOffset);
                            break;

                        case System.Data.DbType.Time:
                            _type = typeof(System.TimeSpan);
                            break;

                        case System.Data.DbType.Byte:
                            _type = typeof(System.Byte);
                            break;
                        case System.Data.DbType.SByte:
                            _type = typeof(System.SByte);
                            break;


                        case System.Data.DbType.Xml:
                            break;

                        case System.Data.DbType.Object:
                            break;

                        case System.Data.DbType.Binary:
                            break;

                        default:
                            break;
                    }



                }
        }

        private System.Type _type;
        private volatile object _lock = new object();

    }


}
