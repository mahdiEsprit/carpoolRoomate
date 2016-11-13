using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entity
{
  public  class CollocationGroup
    {
        public int CollocationGroupId { get; set; }
        public DateTime DateCreation { get; set; }
        public int NombreDeMebre { get; set; }
        public String Title { get; set; }
        public string GroupeType { get; set; }

        public virtual ICollection<User> users { get; set; }
        public virtual ICollection<DiscutionGroup> DiscutionGroupList { get; set; }
        public virtual ICollection<CollocationOffre> CollocationOffreList { get; set; }
    }
}
