using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk;

public sealed class EntityCollection
{
    public string EntityName { get; set; }
    public string MinActiveRowVersion { get; set; }
    public bool MoreRecords { get; set; }
    public string PagingCookie { get; set; }
    public int TotalRecordCount { get; set; }
    public bool TotalRecordCountLimitExceeded { get; set; }
    public DataCollection<Entity> Entities { get; set; }
    public EntityCollection()
    {
        this.Entities = new DataCollection<Entity>();
    }
    public EntityCollection(Entity[] Entities)
        : this()
    {
        foreach (Entity item in Entities)
        {
            this.Entities.Add(item);
        }

    }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Util.ObjectToXml(Entities.ToArray(), "a:Entities", true));
        sb.Append(Util.ObjectToXml(EntityName, "a:EntityName", true));
        sb.Append(Util.ObjectToXml(MinActiveRowVersion, "a:MinActiveRowVersion", true));
        sb.Append(Util.ObjectToXml(MoreRecords, "a:MoreRecords", true));
        sb.Append(Util.ObjectToXml(PagingCookie, "a:PagingCookie", true));
        sb.Append(Util.ObjectToXml(TotalRecordCount, "a:TotalRecordCount", true));
        sb.Append(Util.ObjectToXml(TotalRecordCountLimitExceeded, "a:TotalRecordCountLimitExceeded", true));
        return sb.ToString();
    }
    public Entity this[int i]
    {
        get
        {
            if (Entities.Count > 0)
                return this.Entities[i];
            else
                return null;
        }
    }
    static internal EntityCollection LoadFromXml(XElement item)
    {
        EntityCollection entityCollection = new EntityCollection()
        {
            EntityName = Util.LoadFromXml<string>(item.Element(Util.ns.a + "EntityName")),
            MinActiveRowVersion = Util.LoadFromXml<string>(item.Element(Util.ns.a + "MinActiveRowVersion")),
            PagingCookie = Util.LoadFromXml<string>(item.Element(Util.ns.a + "PagingCookie")),
            MoreRecords = Util.LoadFromXml<bool>(item.Element(Util.ns.a + "MoreRecords")),
            TotalRecordCount = Util.LoadFromXml<int>(item.Element(Util.ns.a + "TotalRecordCount")),
            TotalRecordCountLimitExceeded = Util.LoadFromXml<bool>(item.Element(Util.ns.a + "TotalRecordCountLimitExceeded")),
        };
        foreach (var entity in item.Element(Util.ns.a + "Entities").Elements(Util.ns.a + "Entity"))
        {
            entityCollection.Entities.Add(Entity.LoadFromXml(entity));
        }
        if (entityCollection.Entities.Count > 0)
            entityCollection.TotalRecordCount = entityCollection.Entities.Count;
        return entityCollection;
    }
}