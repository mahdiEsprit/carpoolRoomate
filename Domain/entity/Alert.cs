using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entity
{
    public class Alert
    {
        [Key]
        public int AlertId { get; set; }
        public string Frequency { get; set; }
        public Boolean IsEnable { get; set; }
        //[ForeignKey("StudentId")]
        public virtual Student student { get; set; }
        
        public string StudentId { get; set; }

    }
}
