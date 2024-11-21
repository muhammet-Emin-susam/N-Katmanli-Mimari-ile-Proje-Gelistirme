using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchitecture.Entities.Abstractions
{
    public abstract class Entity
    {
        public Guid ID { get; set; }
        protected Entity()
        {
            ID = Guid.NewGuid();
        }
    }
}
