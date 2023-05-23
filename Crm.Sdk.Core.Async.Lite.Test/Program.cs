using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Crm.Sdk.Core.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultCredentials; //System.Net.CredentialCache.DefaultNetworkCredentials
                WebRequest.DefaultWebProxy = null;

                var _crmUrl = "https://xx.yy.zz.ww/";
                var _organizationName = "Org";

                var clientCredentials = new System.ServiceModel.Description.ClientCredentials();

                clientCredentials.Windows.ClientCredential.UserName = "user";//
                clientCredentials.Windows.ClientCredential.Password = "pass";

                var t1 = new Stopwatch();
                var t2 = new Stopwatch();
                var t3 = new Stopwatch();
                var t7 = new Stopwatch();

                t1.Start();
                var web = new OrganizationServiceProxy($"{_crmUrl}{_organizationName}", clientCredentials.Windows.ClientCredential);
                var web2 = new OrganizationDataServiceProxy($"{_crmUrl}{_organizationName}", clientCredentials.Windows.ClientCredential);
                t1.Stop();

                t2.Start();
                //var req = new Microsoft.Xrm.Sdk.Entity("phonecall");

                var q1 = new QueryExpression("role")
                {
                    ColumnSet = { Columns = { "name", "businessunitid", "roleid" } },
                    Orders =
                    {
                        new OrderExpression("name", OrderType.Ascending)
                    },
                    LinkEntities =
                    {
                        new LinkEntity
                        {
                            LinkFromEntityName = "role",
                            LinkFromAttributeName = "roleid",
                            LinkToEntityName = "systemuserroles",
                            LinkToAttributeName = "roleid",
                            JoinOperator = JoinOperator.Inner,
                            LinkEntities =
                            {
                                new LinkEntity
                                {
                                    LinkFromEntityName = "systemuserroles",
                                    LinkFromAttributeName = "systemuserid",
                                    LinkToEntityName = "systemuser",
                                    LinkToAttributeName = "systemuserid",
                                    JoinOperator = JoinOperator.Inner,
                                    LinkCriteria =
                                    {
                                        Filters =
                                        {
                                            new FilterExpression
                                            {
                                                FilterOperator = LogicalOperator.And,
                                                Conditions =
                                                {
                                                    new ConditionExpression("systemuserid",
                                                        ConditionOperator.EqualUserId)
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                };
                t2.Stop();

                t3.Start();
                var result1 = await web.RetrieveMultipleAsync(q1, CancellationToken.None);
                t3.Stop();

                //return result.Entities.Select(i => i.GetAttributeValue<string>("name"));
                Console.WriteLine($"test 1: {t1.Elapsed}");
                Console.WriteLine($"test 2: {t2.Elapsed}");
                Console.WriteLine($"test 3: {t3.Elapsed}");
                foreach (var role in result1.Entities)
                {
                    Console.WriteLine(role.GetAttributeValue<string>("name"));
                }

                /*var result11 = await web.RetrieveMultipleAsync(q1, CancellationToken.None);

                foreach (var role in result11.Entities)
                {
                    Console.WriteLine(role.GetAttributeValue<string>("name"));
                }*/

                var entity = new Entity("phonecall");

                entity["ownerid"] = new EntityReference("systemuser", Guid.Parse("32DDB2B1-2FDD-4A65-B53A-E0DA58F3D475"));
                entity["new_created_by"] = new EntityReference("systemuser", Guid.Parse("32DDB2B1-2FDD-4A65-B53A-E0DA58F3D475"));
                entity["directioncode"] = true;
                entity["subject"] = "Проверка Звонок.1";
                entity["description"] = "Краткое содержание звонка";
                entity["phonenumber"] = "9659691658";
                entity["scheduledstart"] = DateTime.Parse("2022-10-10T10:00:00Z");
                entity["regardingobjectid"] = new EntityReference("lead", Guid.Parse("E34AE6F7-86FC-E511-80F2-005056971789"));

                //var aa = await web.RestCreateAsync(entity, CancellationToken.None);
                var bb = await web.CreateAsync(entity, CancellationToken.None);

                t7.Start();
                var result2 = await web2.RetrieveMultipleAsync("new_metro_station", new ColumnSet("new_name"), CancellationToken.None);
                t7.Stop();
                Console.WriteLine($"test 7: {t7.Elapsed}");
                foreach (var role in result2.Entities)
                {
                    Console.WriteLine(role.GetAttributeValue<string>("name"));
                }



                //client.CallerId = new Guid("5c073647-da06-e611-80f9-005056971789");


                /*var n = new Microsoft.Crm.Sdk.Messages.SetStateRequest
                {
                    EntityMoniker =
                        new Microsoft.Xrm.Sdk.EntityReference("lead", new Guid("c5dc1b6f-1712-e811-8229-005056977311")),
                    State = new Microsoft.Xrm.Sdk.OptionSetValue(0),
                    Status = new Microsoft.Xrm.Sdk.OptionSetValue(100000003)
                };

                var r = client.Execute(n);*/

                //var rr = await web.RetrieveMultipleAsync(q, CancellationToken.None);

                //var rr2 = await web.RestRetrieveMultipleAsync(q, CancellationToken.None);

                //return result.Entities.Select(i => i.GetAttributeValue<string>("name"));
                //Console.WriteLine($"test 5: {t5.Elapsed}");
                /*foreach (var role in result.Entities)
                {
                    Console.WriteLine(role.GetAttributeValue<string>("name"));
                }*/
                /*var result2 = await client.RetrieveMultipleAsync(q, CancellationToken.None);

                foreach (var role in result.Entities)
                {
                    Console.WriteLine(role.GetAttributeValue<string>("name"));
                }*/
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Press key");
            Console.ReadKey();
        }
    }
}
