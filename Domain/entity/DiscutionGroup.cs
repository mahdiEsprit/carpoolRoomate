using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entity
{
  public  class DiscutionGroup
    {
        [Key]
        public int DiscutionGroupId { get; set; }
        public string Titre { get; set; }
        public string Text { get; set; }
        public string CollocationGroupId { get; set; }
        public virtual CollocationGroup collocationGroup { get; set; }
    }
}
