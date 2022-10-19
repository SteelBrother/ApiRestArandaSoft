using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiArandaSoftware.Abstractions;

namespace WebApiArandaSoftware.Entities
{
    public abstract class Entity : IEntity
    {
        public int id { get; set; }
    }
}
