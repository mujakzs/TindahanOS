using System;
using System.Collections.Generic;
using System.Text;

namespace TindahanOS.Infrastructure.Persistence.Entities;

public class BaseAuditEntity : BaseEntity
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }

    // CreatedBy is required in EF configurations; make non-nullable to keep model consistent.
    public string CreatedBy { get; set; } = string.Empty;
    public string? UpdatedBy { get; set; }
}
    
