using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class FindParentResourceGroupRequest : OrganizationRequest
{
    public Guid[] ChildrenIds
    {
        get
        {
            if (Parameters.Contains("ChildrenIds"))
                return (Guid[])Parameters["ChildrenIds"];
            return default(Guid[]);
        }
        set { Parameters["ChildrenIds"] = value; }
    }
    public Guid ParentId
    {
        get
        {
            if (Parameters.Contains("ParentId"))
                return (Guid)Parameters["ParentId"];
            return default(Guid);
        }
        set { Parameters["ParentId"] = value; }
    }
    public FindParentResourceGroupRequest()
    {
        this.ResponseType = new FindParentResourceGroupResponse();
        this.RequestName = "FindParentResourceGroup";
    }
    internal override string GetRequestBody()
    {
        Parameters["ChildrenIds"] = ChildrenIds;
        Parameters["ParentId"] = ParentId;
        return GetSoapBody();
    }
}