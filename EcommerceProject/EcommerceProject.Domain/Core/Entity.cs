using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.Domain.Core
{
    public abstract class Entity<TId>
    {
        public TId Id { get;set; }
    }
}
