using System;
using Microsoft.Xrm.Sdk;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class AddSolutionComponentRequest : OrganizationRequest
{
    public bool AddRequiredComponents
    {
        get
        {
            if (Parameters.Contains("AddRequiredComponents"))
                return (bool)Parameters["AddRequiredComponents"];
            return default(bool);
        }
        set { Parameters["AddRequiredComponents"] = value; }
    }
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
    public AddSolutionComponentRequest()
    {
        this.ResponseType = new AddSolutionComponentResponse();
        this.RequestName = "AddSolutionComponent";
    }
    internal override string GetRequestBody()
    {
        Parameters["AddRequiredComponents"] = AddRequiredComponents;
        Parameters["ComponentId"] = ComponentId;
        Parameters["ComponentType"] = ComponentType;
        Parameters["SolutionUniqueName"] = SolutionUniqueName;
        return GetSoapBody();
    }
}