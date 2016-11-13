using Domain.entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GUI.Models
{
    public class GoupColloModel
    {
        public int CollocationGroupId { get; set; }

        public DateTime DateCreation { get; set; }

        public String Title { get; set; }
        public IEnumerable<SelectListItem> GroupeTypes { get; set; }
        public string GroupeType { get; set; }
        public virtual ICollection<Student> StudentsList { get; set; }
        public virtual ICollection<DiscutionGroup> DiscutionGroupList { get; set; }
        public virtual ICollection<CollocationOffre> CollocationOffreList { get; set; }
        public int NombreDeMebre { get; set; }
    }
}