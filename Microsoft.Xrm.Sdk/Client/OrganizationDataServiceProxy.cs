using Microsoft.Xrm.Sdk.Query;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Xrm.Sdk.Client
{
    public class OrganizationDataServiceProxy : OrganizationServiceProxyBase, IOrganizationDataService
    {
        #region class members

        private const string restEndpoint = "/XRMServices/2011/OrganizationData.svc/";

        public OrganizationDataServiceProxy(string serviceUrl) : base(serviceUrl)
        {
        }

        public OrganizationDataServiceProxy(string serviceUrl, NetworkCredential credential) : base(serviceUrl, credential)
        {
        }
        
        #endregion class members
        
        #region Rest Methods

        /// <summary>
        /// create record
        /// </summary>
        /// <param name="entity">record to create</param>
        /// <returns></returns>
        public async Task<Guid> CreateAsync(Entity entity, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                DataContractJsonSerializer jasonSerializer = new DataContractJsonSerializer(entity.GetType());
                string json;
                using (MemoryStream ms = new MemoryStream())
                {
                    jasonSerializer.WriteObject(ms, entity);
                    json = Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
                }
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                string ODataAction = entity.GetType().GetRuntimeField("SchemaName").ToString() + "Set";

                if (!string.IsNullOrEmpty(AccessToken))
                {
                    // Build and send the HTTP request.
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", AccessToken);
                }

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Use PostAsync to Post data.
                HttpResponseMessage response = await httpClient.PostAsync(ServiceUrl + restEndpoint + ODataAction, content, cancellationToken);

                // Check the response result.
                if (response.IsSuccessStatusCode)
                {
                    Entity result;
                    // Deserialize response to JToken 
                    byte[] resultbytes = Encoding.UTF8.GetBytes(response.Content.ReadAsStringAsync().Result);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        result = (Entity)jasonSerializer.ReadObject(ms);
                    }
                    return result.Id;
                }
                else
                    throw new Exception("REST Create failed.");
            }
        }

        /// <summary>
        /// Deletes a record.
        /// </summary>
        /// <param name="schemaName">The Schema name of the entity that is specified in the entityId parameter.</param>
        /// <param name="id">The ID of the record that you want to delete.</param>
        public async Task DeleteAsync(string schemaName, Guid id, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                string ODataAction = schemaName + "Set(guid'" + id + "')";

                if (!string.IsNullOrEmpty(AccessToken))
                {
                    // Build and send the HTTP request.
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", AccessToken);
                }

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Use DeleteAsync to Post data.
                HttpResponseMessage response = await httpClient.DeleteAsync(ServiceUrl + restEndpoint + ODataAction, cancellationToken);

                if (!response.IsSuccessStatusCode)
                    throw new Exception("REST Delete failed.");
            }
        }

        /// <summary>
        /// Retrieve a record
        /// </summary>
        /// <param name="schemaName">Entity SchemaName.</param>
        /// <param name="id">id of record to be retireved</param>
        /// <param name="columnSet">retrieved columns</param>
        /// <returns></returns>
        public async Task<Entity> RetrieveAsync(string schemaName, Guid id, ColumnSet columnSet, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                StringBuilder select = new StringBuilder();
                foreach (string column in columnSet.Columns)
                {
                    select.Append("," + column);
                }

                // The URL for the OData organization web service.
                string ODataAction = schemaName + "Set(guid'" + id + "')?$select=" + select.ToString().Remove(0, 1) + "";

                if (!string.IsNullOrEmpty(AccessToken))
                {
                    // Build and send the HTTP request.            
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", AccessToken);
                }

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Wait for the web service response.
                HttpResponseMessage response = await httpClient.GetAsync(ServiceUrl + restEndpoint + ODataAction, cancellationToken);

                // Check the response result.
                if (response.IsSuccessStatusCode)
                {
                    // Check type.
                    TypeInfo currentType;
                    if (EntityTypes.types == null)
                        throw new Exception("Early-bound types must be enabled for a REST Retrieve.");
                    else
                    {
                        currentType = EntityTypes.types.Where(x => x.Name.ToLower() == schemaName.ToLower()).FirstOrDefault();
                        if (currentType == null)
                            throw new Exception("Early-bound types must be enabled for a REST Retrieve.");
                    }
                    // Deserialize response to JToken 
                    JToken jtoken = JObject.Parse(response.Content.ReadAsStringAsync().Result)["d"];
                    return (Entity)JsonConvert.DeserializeObject(jtoken.ToString(), currentType.AsType());
                }
                else
                    throw new Exception("REST Retrieve failed.");
            }
        }

        /// <summary>
        /// Need to consider how to implement this. Let developer create URL or implement convert method form QueryBase to URL?
        /// For now, just let user pass schemaName and ColumnSet.
        /// </summary>
        /// <param name="schemaName"></param>
        /// <param name="columnSet"></param>
        /// <returns></returns>
        public async Task<EntityCollection> RetrieveMultipleAsync(string schemaName, ColumnSet columnSet, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                StringBuilder select = new StringBuilder();
                foreach (string column in columnSet.Columns)
                {
                    select.Append("," + column);
                }

                // The URL for the OData organization web service.
                string ODataAction = schemaName + "Set?$select=" + select.ToString().Remove(0, 1) + "";

                if (!string.IsNullOrEmpty(AccessToken))
                {
                    // Build and send the HTTP request.
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", AccessToken);
                }

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Wait for the web service response.
                HttpResponseMessage response = await httpClient.GetAsync(ServiceUrl + restEndpoint + ODataAction, cancellationToken);

                // Check the response result.
                if (response.IsSuccessStatusCode)
                {
                    EntityCollection results = new EntityCollection();
                    results.EntityName = schemaName.ToLower();

                    // Check type.
                    TypeInfo currentType;
                    if (EntityTypes.types == null)
                        throw new Exception("Early-bound types must be enabled for a REST RetrieveMultiple.");
                    else
                    {
                        currentType = EntityTypes.types.Where(x => x.Name.ToLower() == schemaName.ToLower()).FirstOrDefault();
                        if (currentType == null)
                            throw new Exception("Early-bound types must be enabled for a REST RetrieveMultiple.");
                    }

                    // Deserialize response to JToken IList
                    IList<JToken> jTokens = JObject.Parse(response.Content.ReadAsStringAsync().Result)["d"]["results"].Children().ToList();
                    foreach (JToken jToken in jTokens)
                    {
                        // Deserialize result to Type T
                        results.Entities.Add((Entity)JsonConvert.DeserializeObject(jToken.ToString(), currentType.AsType()));
                    }
                    results.TotalRecordCount = jTokens.Count();
                    return results;
                }
                else
                    throw new Exception("REST RetrieveMultiple failed.");
            }
        }

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="entity">record to update</param>
        /// <returns></returns>
        public async Task UpdateAsync(Entity entity, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                DataContractJsonSerializer jasonSerializer = new DataContractJsonSerializer(entity.GetType());
                MemoryStream ms = new MemoryStream();
                jasonSerializer.WriteObject(ms, entity);
                string json = Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                // The URL for the OData organization web service.
                string ODataAction = entity.GetType().GetRuntimeField("SchemaName").ToString() + "Set(guid'" + entity.Id + "')";

                // Build and send the HTTP request.
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                // Specify MERGE to update record
                httpClient.DefaultRequestHeaders.Add("X-HTTP-Method", "MERGE");

                // Use PostAsync to Post data.
                HttpResponseMessage response = await httpClient.PostAsync(ServiceUrl + restEndpoint + ODataAction, content, cancellationToken);

                // Check the response result.
                if (!response.IsSuccessStatusCode)
                    throw new Exception("REST Update failed.");
            }
        }
        #endregion
    }
}