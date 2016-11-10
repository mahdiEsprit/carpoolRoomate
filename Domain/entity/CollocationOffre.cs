using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entity
{
   public class CollocationOffre
    {
        [Key]
        public int CollocationOffreId { get; set; }
        public string Titre { get; set; }

        public DateTime DateCreation { get; set; }
        public string Region { get; set; }
        public Adress adress { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Student> StudentsList { get; set; }
        public virtual ICollection<CollocationGroup> CollocationGroupList { get; set; }
    }
}
