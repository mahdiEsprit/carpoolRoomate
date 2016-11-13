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
        
        public int DiscutionGroupId { get; set; }
        public string Titre { get; set; }
        public string Text { get; set; }
        public int CollocationGroupId { get; set; }


        public virtual CollocationGroup collocationGroup { get; set; }

        public string UserIden { get; set; }
        public virtual User user  { get; set; }
}
}
