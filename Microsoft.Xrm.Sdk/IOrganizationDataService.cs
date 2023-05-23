﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Xrm.Sdk;

interface IOrganizationDataService
{
    Task<Guid> CreateAsync(Entity entity, CancellationToken cancellationToken);

    Task<Entity> RetrieveAsync(
        string entityName,
        Guid id,
        ColumnSet columnSet,
        CancellationToken cancellationToken);

    Task UpdateAsync(Entity entity, CancellationToken cancellationToken);

    Task DeleteAsync(string entityName, Guid id, CancellationToken cancellationToken);

    Task<EntityCollection> RetrieveMultipleAsync(
        string schemaName,
        ColumnSet columnSet,
        CancellationToken cancellationToken);
}