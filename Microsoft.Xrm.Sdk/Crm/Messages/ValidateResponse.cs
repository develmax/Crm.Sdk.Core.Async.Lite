using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Utility;

namespace Microsoft.Crm.Sdk.Messages;

public sealed class ValidateResponse : OrganizationResponse
{
    public ValidationResult[] Result { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "Result")
            {
                List<ValidationResult> list = new List<ValidationResult>();
                foreach (var item in result.Element(Util.ns.b + "value").Elements())
                {
                    list.Add(ValidationResult.LoadFromXml(item));
                }
                this.Result = list.ToArray();
            }
        }
    }
}