using System;
using System.Text;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Xrm.Sdk;

public class OrganizationRequest
{
    public string RequestName { get; set; }
    public Guid RequestId { get; set; }
    public Object item { get; set; }
    public ParameterCollection Parameters { get; set; }
    // responseType stores each message response instance so that
    // Execute method can return correct type.
    // I am not sure if it is good idea to instantiate the response
    // when request instantiated though.  
    internal OrganizationResponse ResponseType { get; set; }
    // ctor
    public OrganizationRequest()
    {
        this.Parameters = new ParameterCollection();
    }
    public object this[string parameterName]
    {
        get
        {
            if (this.Parameters.ContainsKey(parameterName))
                return this.Parameters[parameterName];
            else
                return null;
        }
        set
        {
            this.Parameters[parameterName] = value;
        }
    }
    // Each message request has override method which generates
    // correct SOAP request.
    internal virtual string GetRequestBody() { return ""; }
    /// <summary>
    /// Generate Soap XML request
    /// </summary>
    /// <returns></returns>
    internal string GetSoapBody()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<d:request>");
        sb.Append((this.Parameters.Count == 0) ? "<a:Parameters />" :
            "<a:Parameters>" + GetParameters() + "</a:Parameters>");
        sb.Append((this.RequestId == null || this.RequestId == Guid.Empty) ? "<a:RequestId i:nil='true' />" :
            "<a:RequestId>" + RequestId.ToString() + "</a:RequestId>");
        sb.Append("<a:RequestName>" + RequestName + "</a:RequestName>");
        sb.Append("</d:request>");
        return sb.ToString();
    }
    /// <summary>
    /// This method generates parameter nodes for Soap request
    /// </summary>
    /// <returns></returns>
    internal string GetParameters()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var parameter in Parameters)
        {
            if (parameter.Value == null)
                continue;
            sb.Append("<a:KeyValuePairOfstringanyType>");
            sb.Append("<b:key>" + parameter.Key + "</b:key>");
            // Use util class method to generate appropriate node.
            sb.Append(Util.ObjectToXml(parameter.Value, "b:value"));
            sb.Append("</a:KeyValuePairOfstringanyType>");
        }
        return sb.ToString();
    }
}