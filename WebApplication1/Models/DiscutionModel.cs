using Domain.entity;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GUI.Models
{
    public class DiscutionModel
    {   
        [Key ]
        public int DiscutionModelId;
        public String Titre { get; set; }
        [DataType(DataType.Text)]
        public String Text { get; set; }

        public int CollocationGroupId { get; set; }
        public virtual CollocationGroup collocationGroup { get; set; }
    }
}