using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF.ContaBancaria.Domain.Models
{
    public abstract class Entity
    {
        // foi adotado o uso do Guid ao invés do numeric
        // o guid é gerado na instância do objeto e tem algumas vantagens em relação ao numeric        
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
