using System;
using System.Collections.Generic;
using System.Text;

namespace TindahanOS.Infrastructure.Persistence.Entities;

public class BaseAuditEntity : BaseEntity
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
}

