using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entity
{
    public class AppartementOwner : User
    {
        public string TypeOfRental { get; set; }

        public virtual ICollection<Appartement> AppartementsList { get; set; }

    }
}
