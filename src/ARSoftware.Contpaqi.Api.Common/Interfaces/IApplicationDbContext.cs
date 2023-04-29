using ARSoftware.Contpaqi.Api.Common.Domain;
using Microsoft.EntityFrameworkCore;

namespace ARSoftware.Contpaqi.Api.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<ApiRequest> Requests { get; }
    DbSet<ApiResponse> Responses { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
