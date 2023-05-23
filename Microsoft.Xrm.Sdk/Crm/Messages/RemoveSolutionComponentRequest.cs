using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RemoveSolutionComponentRequest : OrganizationRequest
{
    public Guid ComponentId
    {
        get
        {
            if (Parameters.Contains("ComponentId"))
                return (Guid)Parameters["ComponentId"];
            return default(Guid);
        }
        set { Parameters["ComponentId"] = value; }
    }
    public int ComponentType
    {
        get
        {
            if (Parameters.Contains("ComponentType"))
                return (int)Parameters["ComponentType"];
            return default(int);
        }
        set { Parameters["ComponentType"] = value; }
    }
    public string SolutionUniqueName
    {
        get
        {
            if (Parameters.Contains("SolutionUniqueName"))
                return (string)Parameters["SolutionUniqueName"];
            return default(string);
        }
        set { Parameters["SolutionUniqueName"] = value; }
    }
    public RemoveSolutionComponentRequest()
    {
        this.ResponseType = new RemoveSolutionComponentResponse();
        this.RequestName = "RemoveSolutionComponent";
    }
    internal override string GetRequestBody()
    {
        Parameters["ComponentId"] = ComponentId;
        Parameters["ComponentType"] = ComponentType;
        Parameters["SolutionUniqueName"] = SolutionUniqueName;
        return GetSoapBody();
    }
}