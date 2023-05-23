using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Utility;
using Newtonsoft.Json;

namespace Microsoft.Xrm.Sdk;

public class Entity : Microsoft.Xrm.Sdk.Extension.BaseEntity
{
    //[JsonIgnore]
    public object __metadata { get; set; }
    [JsonExtensionData]
    public AttributeCollection Attributes { get; set; }
    public FormattedValueCollection FormattedValues { get; set; }
    public EntityState? EntityState { get; set; }
    public override Guid Id { get; set;  }
    public string LogicalName { get; set; }
    public RelatedEntityCollection RelatedEntities { get; set; }
    public Entity()
    {
        Attributes = new AttributeCollection();
        FormattedValues = new FormattedValueCollection();
        RelatedEntities = new RelatedEntityCollection();
    }
    public Entity(string LogicalName)
        : this()
    {
        if (!String.IsNullOrEmpty(LogicalName))
            this.LogicalName = LogicalName;
    }
    public Entity(Entity entity)
    {
        Attributes = new AttributeCollection();
        FormattedValues = new FormattedValueCollection();
        RelatedEntities = new RelatedEntityCollection();
        this.LogicalName = entity.LogicalName;
        this.Attributes = entity.Attributes;
        this.FormattedValues = entity.FormattedValues;
        this.RelatedEntities = entity.RelatedEntities;
    }
    public object this[string attributeName]
    {
        get
        {
            if (this.Attributes.ContainsKey(attributeName))
                return this.Attributes[attributeName];
            else
                return null;
        }
        set
        {
            this.Attributes[attributeName] = value;
        }
    }
    public bool Contains(string attributeName)
    {
        if (!String.IsNullOrEmpty(attributeName))
            return this.Attributes.Contains(attributeName);
        else
            return false;
    }
    public virtual T GetAttributeValue<T>(string attributeLogicalName)
    {
        // Check if key exists and value type if same as specified.
        if (!String.IsNullOrEmpty(attributeLogicalName) && this.Contains(attributeLogicalName))
        {
            try
            {
                return (T)this.Attributes[attributeLogicalName];
            }
            catch (Exception)
            {
                return default(T);
            }
        }
        // If value not exist yet, return default value.
        else
            return default(T);
    }
    protected virtual string GetFormattedAttributeValue(string attributeLogicalName)
    {
        // Check if this contains the key
        if (!String.IsNullOrEmpty(attributeLogicalName) && this.FormattedValues.Contains(attributeLogicalName))
            return this.FormattedValues[attributeLogicalName];
        else
            return null;
    }
    protected virtual IEnumerable<TEntity> GetRelatedEntities<TEntity>(string relationshipSchemaName,
        Nullable<EntityRole> primaryEntityRole) where TEntity : Entity
    {
        if (!String.IsNullOrEmpty(relationshipSchemaName))
        {
            Relationship key = new Relationship(relationshipSchemaName)
            {
                PrimaryEntityRole = primaryEntityRole
            };

            // Create relationship
            if (RelatedEntities.Contains(key))
                return RelatedEntities[key].Entities.Cast<TEntity>();
            else
                return null;
        }
        else
            return null;
    }
    protected virtual TEntity GetRelatedEntity<TEntity>(string relationshipSchemaName,
        Nullable<EntityRole> primaryEntityRole) where TEntity : Entity
    {
        if (!String.IsNullOrEmpty(relationshipSchemaName))
        {
            // Create relationship
            Relationship key = new Relationship(relationshipSchemaName)
            {
                PrimaryEntityRole = primaryEntityRole
            };

            if (RelatedEntities.Contains(key))
                return (TEntity)RelatedEntities[key].Entities.FirstOrDefault();
            else
                return null;
        }
        else
            return null;
    }
    protected virtual void SetAttributeValue(string attributeLogicalName, Object value)
    {
        if (!String.IsNullOrEmpty(attributeLogicalName))
            this[attributeLogicalName] = value;
    }
    protected virtual void SetRelatedEntities<TEntity>(string relationshipSchemaName, Nullable<EntityRole> primaryEntityRole,
        IEnumerable<TEntity> entities) where TEntity : Entity
    {
        // Check schemaname
        if (String.IsNullOrEmpty(relationshipSchemaName))
            return;

        // Create relationship
        Relationship key = new Relationship(relationshipSchemaName)
        {
            PrimaryEntityRole = primaryEntityRole
        };

        // check entities
        if (entities == null || entities.Count() == 0)
        {
            RelatedEntities[key] = null;
            return;
        }

        // Instantiate EntityCollection and pass properties
        EntityCollection collection = new EntityCollection();
        collection.EntityName = entities.First().LogicalName;
        collection.Entities.AddRange(entities);

        RelatedEntities[key] = collection;
    }
    protected virtual void SetRelatedEntity<TEntity>(string relationshipSchemaName, Nullable<EntityRole> primaryEntityRole,
        TEntity entity) where TEntity : Entity
    {
        // Check schemaname
        if (String.IsNullOrEmpty(relationshipSchemaName))
            return;

        // Create relationship
        Relationship key = new Relationship(relationshipSchemaName)
        {
            PrimaryEntityRole = primaryEntityRole
        };

        if (entity == null)
        {
            RelatedEntities[key] = null;
            return;
        }

        // Instantiate EntityCollection and pass properties
        EntityCollection collection = new EntityCollection();
        collection.EntityName = entity.LogicalName;
        collection.Entities.Add(entity);

        RelatedEntities[key] = collection;
    }
    // Convert Entity to early bound class like Account, Contact, etc.
    public T ToEntity<T>() where T : Entity
    {
        // If T is Entity, then just returns it's copy.
        if (typeof(T) == typeof(Entity))
        {
            Entity record = new Entity(this);
            return record as T;
        }

        // Instantiate early bound class object.
        T castedRecord = (T)Activator.CreateInstance(typeof(T), null);
        // Pass properties.
        castedRecord.Id = this.Id;
        castedRecord.Attributes = this.Attributes;
        castedRecord.FormattedValues = this.FormattedValues;
        return castedRecord;
    }
    // Convert Entity to EntityReference
    public EntityReference ToEntityReference()
    {
        if (this.Id == Guid.Empty)
            throw new Exception("Cannot convert to EntityReference without Id value");
        return new EntityReference()
        {
            Id = this.Id,
            LogicalName = this.LogicalName
        };
    }
    internal string ToValueXml()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(Attributes.ToXml());
        sb.Append("<a:EntityState i:nil='true' />");
        sb.Append(this.FormattedValues.ToXml());
        sb.Append("<a:Id>");
        sb.Append((this.Id == Guid.Empty) ? "00000000-0000-0000-0000-000000000000" : Id.ToString());
        sb.Append("</a:Id>");
        sb.Append("<a:LogicalName>" + this.LogicalName + "</a:LogicalName>");
        sb.Append(this.RelatedEntities.ToXml());
        return sb.ToString();
    }
    static internal Entity LoadFromXml(XElement item)
    {
        Entity entity = new Entity();
        entity.LogicalName = Util.LoadFromXml<string>(item.Element(Util.ns.a + "LogicalName"));
        entity.Id = Util.LoadFromXml<Guid>(item.Element(Util.ns.a + "Id"));
        entity.Attributes.LoadFromXml(item);
        entity.FormattedValues.LoadFromXml(item);
        return EntityTypes.ConvertToEarlyBound(entity);
    }
}