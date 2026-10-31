using Microsoft.EntityFrameworkCore;

namespace BuildingBlocks.EFCore.Auditing;

public interface IAuditable
{
    DateTime CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
}
