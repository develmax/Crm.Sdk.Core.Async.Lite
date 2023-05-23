using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;
using System.Text;
using System.Xml.Linq;

namespace Microsoft.Xrm.Sdk.Query
{
    public sealed class ColumnSet
    {
        public bool AllColumns { get; set; }
        public DataCollection<string> Columns { get; set; }
        public ColumnSet()
        {
            this.Columns = new DataCollection<string>();
        }
        public ColumnSet(bool allColumns)
            : this()
        {
            this.AllColumns = allColumns;
        }
        public ColumnSet(params string[] columns)
            : this()
        {
            this.AddColumns(columns);
            this.AllColumns = false;
        }
        public void AddColumn(string column)
        {
            this.Columns.Add(column);
        }
        public void AddColumns(params string[] columns)
        {
            foreach (var item in columns)
            {
                this.Columns.Add(item);
            }
        }
        internal string ToValueXml()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Util.ObjectToXml(AllColumns, "a:AllColumns", true));
            sb.Append(Util.ObjectToXml(Columns.ToArray(), "a:Columns", true));
            return sb.ToString();
        }
        static internal ColumnSet LoadFromXml(XElement item)
        {
            ColumnSet columnSet = new ColumnSet()
            {
                AllColumns = Util.LoadFromXml<bool>(item.Element(Util.ns.a + "AllColumns"))
            };
            foreach (XElement Column in item.Element(Util.ns.a + "Columns").Elements(Util.ns.f + "string"))
            {
                columnSet.Columns.Add(Column.Value);
            }
            return columnSet;
        }
    }
}