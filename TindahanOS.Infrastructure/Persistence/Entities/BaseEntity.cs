using System;
using System.Collections.Generic;
using System.Text;

namespace TindahanOS.Infrastructure.Persistence.Entities
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
