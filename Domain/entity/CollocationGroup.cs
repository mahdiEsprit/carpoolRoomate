using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entity
{
  public  class CollocationGroup
    {
        [Key]
        public int CollocationGroupId { get; set; }
        public DateTime DateCreation { get; set; }
        public virtual ICollection<Student> StudentsList { get; set; }
        public virtual ICollection<DiscutionGroup> DiscutionGroupList { get; set; }
        public virtual ICollection<CollocationOffre> CollocationOffreList { get; set; }
    }
}
