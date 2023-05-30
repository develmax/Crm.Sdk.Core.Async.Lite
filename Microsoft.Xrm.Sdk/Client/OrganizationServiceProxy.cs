using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Utility;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Microsoft.Xrm.Sdk.Client
{
    public class OrganizationServiceProxy : OrganizationServiceProxyBase, IOrganizationService
    {
        #region class members

        private const string webEndpoint = "/XRMServices/2011/Organization.svc/web";

        public Guid CallerId { get; set; }

        public OrganizationServiceProxy(string serviceUrl) : base(serviceUrl)
        {
        }

        public OrganizationServiceProxy(string serviceUrl, NetworkCredential credential) : base(serviceUrl, credential)
        {
        }
        

        #endregion class members

        #region Soap Methods

        // Provide same methods as IOrganizationService with same parameter and types
        // so that developer can use this class without confusion.

        /// <summary>
        /// Creates a link between records.
        /// </summary>
        /// <param name="entityName">The logical name of the entity that is specified in the entityId parameter.</param>
        /// <param name="entityId">The ID of the record to which the related records are associated.</param>
        /// <param name="relationship">The name of the relationship to be used to create the link.</param>
        /// <param name="relatedEntities">A collection of entity references (references to records) to be associated.</param>
        public async Task AssociateAsync(string entityName, Guid entityId, Relationship relationship,
            EntityReferenceCollection relatedEntities, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                string SOAPAction = "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/Associate";

                StringBuilder content = new StringBuilder();
                content.Append(GetEnvelopeHeader());
                content.Append("<s:Body>");
                content.Append("<d:Associate>");
                content.Append("<d:entityName>" + entityName + "</d:entityName>");
                content.Append("<d:entityId>" + entityId.ToString() + "</d:entityId>");
                content.Append(Util.ObjectToXml(relationship, "d:relationship", true));
                content.Append(Util.ObjectToXml(relatedEntities, "d:relatedEntities", true));
                content.Append("</d:Associate>");
                content.Append("</s:Body>");
                content.Append("</s:Envelope>");

                // Send the request asychronously and wait for the response.
                HttpResponseMessage httpResponse;
                httpResponse = await SendRequestAsync(httpClient, SOAPAction, content.ToString(), cancellationToken);

                if (httpResponse.IsSuccessStatusCode)
                {
                    //do nothing
                }
                else
                {
                    OrganizationServiceFault fault = RestoreError(httpResponse);
                    if (!string.IsNullOrEmpty(fault.Message))
                        throw fault;
                    else
                        throw new Exception(httpResponse.Content.ReadAsStringAsync().Result);
                }
            }
        }

        /// <summary>
        /// Creates a record.
        /// </summary>
        /// <param name="entity">An entity instance that contains the properties to set in the newly created record.</param>
        /// <returns>The ID of the newly created record.</returns>
        public async Task<Guid> CreateAsync(Entity entity, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                string SOAPAction = "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/Create";

                StringBuilder content = new StringBuilder();
                content.Append(GetEnvelopeHeader());
                content.Append("<s:Body>");
                content.Append("<d:Create>");
                content.Append(Util.ObjectToXml(entity, "d:entity", true));
                content.Append("</d:Create>");
                content.Append("</s:Body>");
                content.Append("</s:Envelope>");

                // Send the request asychronously and wait for the response.
                HttpResponseMessage httpResponse;
                httpResponse = await SendRequestAsync(httpClient, SOAPAction, content.ToString(), cancellationToken);

                Guid createdRecordId = Guid.Empty;
                if (httpResponse.IsSuccessStatusCode)
                {
                    // Obtain Guid values from result.
                    XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
                    foreach (var result in xdoc.Descendants(Util.ns.d + "CreateResponse"))
                    {
                        createdRecordId = Util.LoadFromXml<Guid>(result);
                    }
                }
                else
                {
                    OrganizationServiceFault fault = RestoreError(httpResponse);
                    if (!string.IsNullOrEmpty(fault.Message))
                        throw fault;
                    else
                        throw new Exception(httpResponse.Content.ReadAsStringAsync().Result);
                }

                return createdRecordId;
            }
        }

        /// <summary>
        /// Deletes a record.
        /// </summary>
        /// <param name="entityName">The logical name of the entity that is specified in the entityId parameter.</param>
        /// <param name="id">The ID of the record that you want to delete.</param>
        public async Task DeleteAsync(string entityName, Guid id, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                string SOAPAction = "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/Delete";

                StringBuilder content = new StringBuilder();
                content.Append(GetEnvelopeHeader());
                content.Append("<s:Body>");
                content.Append("<d:Delete>");
                content.Append("<d:entityName>" + entityName + "</d:entityName>");
                content.Append("<d:id>" + id.ToString() + "</d:id>");
                content.Append("</d:Delete>");
                content.Append("</s:Body>");
                content.Append("</s:Envelope>");

                // Send the request asychronously and wait for the response.
                HttpResponseMessage httpResponse;
                httpResponse = await SendRequestAsync(httpClient, SOAPAction, content.ToString(), cancellationToken);

                if (httpResponse.IsSuccessStatusCode)
                {
                    // Do nothing as it returns void.
                }
                else
                {
                    OrganizationServiceFault fault = RestoreError(httpResponse);
                    if (!string.IsNullOrEmpty(fault.Message))
                        throw fault;
                    else
                        throw new Exception(httpResponse.Content.ReadAsStringAsync().Result);
                }
            }
        }

        /// <summary>
        /// Deletes a link between records.
        /// </summary>
        /// <param name="entityName">The logical name of the entity that is specified in the entityId parameter.</param>
        /// <param name="entityId">The ID of the record from which the related records are disassociated.</param>
        /// <param name="relationship">The name of the relationship to be used to remove the link.</param>
        /// <param name="relatedEntities">A collection of entity references (references to records) to be disassociated.</param>
        public async Task DisassociateAsync(string entityName, Guid entityId, Relationship relationship,
            EntityReferenceCollection relatedEntities, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                string SOAPAction = "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/Disassociate";

                StringBuilder content = new StringBuilder();
                content.Append(GetEnvelopeHeader());
                content.Append("<s:Body>");
                content.Append("<d:Disassociate>");
                content.Append("<d:entityName>" + entityName + "</d:entityName>");
                content.Append("<d:entityId>" + entityId.ToString() + "</d:entityId>");
                content.Append(Util.ObjectToXml(relationship, "d:relationship", true));
                content.Append(Util.ObjectToXml(relatedEntities, "d:relatedEntities", true));
                content.Append("</d:Disassociate>");
                content.Append("</s:Body>");
                content.Append("</s:Envelope>");

                // Send the request asychronously and wait for the response.
                HttpResponseMessage httpResponse;
                httpResponse = await SendRequestAsync(httpClient, SOAPAction, content.ToString(), cancellationToken);

                if (httpResponse.IsSuccessStatusCode)
                {
                    //do nothing
                }
                else
                {
                    OrganizationServiceFault fault = RestoreError(httpResponse);
                    if (!string.IsNullOrEmpty(fault.Message))
                        throw fault;
                    else
                        throw new Exception(httpResponse.Content.ReadAsStringAsync().Result);
                }


            }
        }

        /// <summary>
        /// Executes a message in the form of a request, and returns a response.
        /// </summary>
        /// <param name="request">A request instance that defines the action to be performed.</param>
        /// <returns>The response from the request. You must cast the return value of this method to 
        /// the specific instance of the response that corresponds to the Request parameter.</returns>
        public async Task<OrganizationResponse> ExecuteAsync(OrganizationRequest request, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                string SOAPAction = "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/Execute";

                StringBuilder content = new StringBuilder();
                content.Append(GetEnvelopeHeader());
                content.Append("<s:Body>");
                content.Append("<d:Execute>");
                content.Append(request.GetRequestBody());
                content.Append("</d:Execute>");
                content.Append("</s:Body>");
                content.Append("</s:Envelope>");

                // Send the request asychronously and wait for the response.
                HttpResponseMessage httpResponse;
                httpResponse = await SendRequestAsync(httpClient, SOAPAction, content.ToString(), cancellationToken);

                if (httpResponse.IsSuccessStatusCode)
                {
                    // 1. Request contains instance of its corresponding Response.
                    // 2. Response has override StoreResult method to extract data
                    // from result if necessary.
                    request.ResponseType.StoreResult(httpResponse);
                    return request.ResponseType;
                }
                else
                {
                    // This is the fix for issue that if the response is not an XML, this will throw XML parse error, and hide the original error
                    // May need to redo this when applying new version of this file
                    OrganizationServiceFault fault = RestoreError(httpResponse);
                    if (fault != null)
                    {
                        throw fault;
                    }
                    else
                    {
                        throw new Exception(httpResponse.Content.ReadAsStringAsync().Result);
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves a record.
        /// </summary>
        /// <param name="entityName">The logical name of the entity that is specified in the entityId parameter.</param>
        /// <param name="id">The ID of the record that you want to retrieve.</param>
        /// <param name="columnSet">A query that specifies the set of columns, or attributes, to retrieve.</param>
        /// <returns>The requested entity. If EnableProxyTypes called, returns early bound type.</returns>
        public async Task<Entity> RetrieveAsync(string entityName, Guid id, ColumnSet columnSet, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                string SOAPAction = "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/Retrieve";

                StringBuilder content = new StringBuilder();
                content.Append(GetEnvelopeHeader());
                content.Append("<s:Body>");
                content.Append("<d:Retrieve>");
                content.Append("<d:entityName>" + entityName + "</d:entityName>");
                content.Append("<d:id>" + id.ToString() + "</d:id>");
                content.Append(Util.ObjectToXml(columnSet, "d:columnSet", true));
                content.Append("</d:Retrieve>");
                content.Append("</s:Body>");
                content.Append("</s:Envelope>");

                // Send the request asychronously and wait for the response.
                HttpResponseMessage httpResponse;
                httpResponse = await SendRequestAsync(httpClient, SOAPAction, content.ToString(), cancellationToken);

                Entity Entity = new Entity();

                // Chech the returned code
                if (httpResponse.IsSuccessStatusCode)
                {
                    // Extract Entity from result.
                    XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
                    foreach (var result in xdoc.Descendants(Util.ns.d + "RetrieveResult"))
                    {
                        Entity = Entity.LoadFromXml(result);
                    }
                }
                else
                {
                    OrganizationServiceFault fault = RestoreError(httpResponse);
                    if (!string.IsNullOrEmpty(fault.Message))
                        throw fault;
                    else
                        throw new Exception(httpResponse.Content.ReadAsStringAsync().Result);
                }

                // If Entity if not casted yet, then try to cast to early-bound
                if (Entity.GetType().Equals(typeof(Entity)))
                    Entity = EntityTypes.ConvertToEarlyBound(Entity);

                return Entity;
            }
        }

        /// <summary>
        /// Retrieves a collection of records.
        /// </summary>
        /// <param name="query">A query that determines the set of records to retrieve.</param>
        /// <returns>The collection of entities returned from the query. If EnableProxyTypes called, returns early bound type.</returns>
        public async Task<EntityCollection> RetrieveMultipleAsync(QueryBase query, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                string SOAPAction = "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/RetrieveMultiple";

                StringBuilder content = new StringBuilder();
                content.Append(GetEnvelopeHeader());
                content.Append("<s:Body>");
                content.Append("<d:RetrieveMultiple>");
                content.Append(Util.ObjectToXml(query, "d:query"));
                content.Append("</d:RetrieveMultiple>");
                content.Append("</s:Body>");
                content.Append("</s:Envelope>");

                // Send the request asychronously and wait for the response.
                HttpResponseMessage httpResponse;
                httpResponse = await SendRequestAsync(httpClient, SOAPAction, content.ToString(), cancellationToken);

                EntityCollection entityCollection = null;

                // Check the returned code
                if (httpResponse.IsSuccessStatusCode)
                {
                    // Extract EntityCollection from result.
                    XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
                    foreach (var results in xdoc.Descendants(Util.ns.d + "RetrieveMultipleResult"))
                    {
                        entityCollection = EntityCollection.LoadFromXml(results);
                    }
                }
                else
                {
                    // This is the fix for issue that if the response is not an XML, this will throw XML parse error, and hide the original error
                    // May need to redo this when applying new version of this file
                    OrganizationServiceFault fault = RestoreError(httpResponse);
                    if (fault != null)
                    {
                        throw fault;
                    }
                    else
                    {
                        throw new Exception(httpResponse.Content.ReadAsStringAsync().Result);
                    }
                }

                return entityCollection;
            }
        }

        /// <summary>
        /// Updates an existing record.
        /// </summary>
        /// <param name="entity">An entity instance that has one or more properties set to be updated in the record.</param>
        public async Task UpdateAsync(Entity entity, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                string SOAPAction = "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/Update";

                StringBuilder content = new StringBuilder();
                content.Append(GetEnvelopeHeader());
                content.Append("<s:Body>");
                content.Append("<d:Update>");
                content.Append(Util.ObjectToXml(entity, "d:entity", true));
                content.Append("</d:Update>");
                content.Append("</s:Body>");
                content.Append("</s:Envelope>");

                // Send the request asychronously and wait for the response.
                HttpResponseMessage httpResponse;
                httpResponse = await SendRequestAsync(httpClient, SOAPAction, content.ToString(), cancellationToken);

                if (httpResponse.IsSuccessStatusCode)
                {
                    // Do nothing as it returns void.
                }
                else
                {
                    OrganizationServiceFault fault = RestoreError(httpResponse);
                    if (!string.IsNullOrEmpty(fault.Message))
                        throw fault;
                    else
                        throw new Exception(httpResponse.Content.ReadAsStringAsync().Result);
                }
            }
        }

        #endregion methods
        
        #region helpercode

        /// <summary>
        /// Create HTTPRequest and returns the HTTPRequestMessage.
        /// </summary>
        /// <param name="httpClient">httpClient instance.</param>
        /// <param name="SOAPAction">Action for the endpoint, like Execute, Retrieve, etc.</param>
        /// <param name="content">Request Body</param>
        /// <returns>HTTPRequest</returns>
        private async Task<HttpResponseMessage> SendRequestAsync(HttpClient httpClient, string SOAPAction, string content, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(AccessToken))
            {
                // Set the HTTP authorization header using the access token.
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            }

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.Timeout = Timeout;
            // Finish setting up the HTTP request.
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, ServiceUrl + webEndpoint);
            req.Headers.Add("SOAPAction", SOAPAction);
            req.Method = HttpMethod.Post;
            req.Content = new StringContent(content);
            req.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("text/xml; charset=utf-8");

            // Send the request asychronously and wait for the response.            
            return await httpClient.SendAsync(req, cancellationToken);
        }


        /// <summary>
        /// Create Envelope for SOAP request.
        /// </summary>
        /// <returns>SOAP Envelope with namespaces.</returns>
        /// <summary>
        /// Enable Early Bound by storing all Types in the application.
        /// </summary>
        /// <returns>SOAP Envelope with namespaces.</returns>
        ///       
        private string GetEnvelopeHeader()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<s:Envelope xmlns:s='http://schemas.xmlsoap.org/soap/envelope/' xmlns:a='http://schemas.microsoft.com/xrm/2011/Contracts' xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns:b='http://schemas.datacontract.org/2004/07/System.Collections.Generic' xmlns:c='http://www.w3.org/2001/XMLSchema' xmlns:d='http://schemas.microsoft.com/xrm/2011/Contracts/Services' xmlns:e='http://schemas.microsoft.com/2003/10/Serialization/' xmlns:f='http://schemas.microsoft.com/2003/10/Serialization/Arrays' xmlns:g='http://schemas.microsoft.com/crm/2011/Contracts' xmlns:h='http://schemas.microsoft.com/xrm/2011/Metadata' xmlns:j='http://schemas.microsoft.com/xrm/2011/Metadata/Query' xmlns:k='http://schemas.microsoft.com/xrm/2013/Metadata' xmlns:l='http://schemas.microsoft.com/xrm/2012/Contracts'>");
            sb.Append("<s:Header>");
            if (CallerId != null && CallerId != Guid.Empty)
                sb.Append("<a:CallerId>" + CallerId.ToString() + "</a:CallerId>");
            sb.Append("<a:SdkClientVersion>6.0</a:SdkClientVersion>");
            sb.Append("</s:Header>");
            return sb.ToString();
        }

        private OrganizationServiceFault RestoreError(HttpResponseMessage httpResponse)
        {
            // This is the fix for issue that if the response is not an XML, this will throw XML parse error, and hide the original error
            // May need to redo this when applying new version of this file
            try
            {
                string content = httpResponse.Content.ReadAsStringAsync().Result;
                if (string.IsNullOrEmpty(content))
                {
                    OrganizationServiceFault serviceFault = new OrganizationServiceFault();
                    serviceFault.ErrorCode = (int)httpResponse.StatusCode;
                    return serviceFault;
                }
                else
                {
                    XDocument xdoc = XDocument.Parse(content, LoadOptions.None);
                    return OrganizationServiceFault.LoadFromXml(xdoc.Descendants(Util.ns.a + "OrganizationServiceFault").First());
                }
            }
            catch
            {
                return null;
            }
        }

        #endregion helpercode
    }
}