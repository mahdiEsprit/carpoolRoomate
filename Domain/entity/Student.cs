using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entity
{
    public class Student : User
    {
        public string Country { get; set; }

        public string Street { get; set; }
        public string MainActivity { get; set; }
        public string Hobbies { get; set; }
        public bool Smoker { get; set; }
        public string Picture { get; set; }
        public int ZipCode { get; set; }
        public int CollocationOffreId { get; set; }
        public virtual ICollection<Alert> AlertsList { get; set; }
        public virtual CollocationOffre collocationOffre { get; set; }
        public virtual ICollection<CollocationGroup> CollocationGroupsList { get; set; }


    }
}
