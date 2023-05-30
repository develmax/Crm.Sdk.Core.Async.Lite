using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Xrm.Sdk;

public interface IOrganizationService
{
    Task<Guid> CreateAsync(Entity entity, CancellationToken cancellationToken);

    Task<Entity> RetrieveAsync(
        string entityName,
        Guid id,
        ColumnSet columnSet,
        CancellationToken cancellationToken);

    Task UpdateAsync(Entity entity, CancellationToken cancellationToken);

    Task DeleteAsync(string entityName, Guid id, CancellationToken cancellationToken);

    Task<OrganizationResponse> ExecuteAsync(
        OrganizationRequest request,
        CancellationToken cancellationToken);

    Task AssociateAsync(
        string entityName,
        Guid entityId,
        Relationship relationship,
        EntityReferenceCollection relatedEntities,
        CancellationToken cancellationToken);

    Task DisassociateAsync(
        string entityName,
        Guid entityId,
        Relationship relationship,
        EntityReferenceCollection relatedEntities,
        CancellationToken cancellationToken);

    Task<EntityCollection> RetrieveMultipleAsync(
        QueryBase query,
        CancellationToken cancellationToken);
}