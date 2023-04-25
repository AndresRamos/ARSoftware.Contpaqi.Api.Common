using Microsoft.EntityFrameworkCore;

namespace ARSoftware.Contpaqi.Api.Common.Persistence;

public interface IApplicationDbContext
{
    DbSet<ApiRequest> Requests { get; }
    DbSet<ApiResponse> Responses { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
