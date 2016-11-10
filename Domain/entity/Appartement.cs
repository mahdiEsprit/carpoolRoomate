using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entity
{
   public enum RentalType
    {
        Single,
        Collocation
    }
  public  class Appartement
    {   [Key]
        public int AppartementId { get; set; }
        public Adress adresseAppartement { get; set; }
        public int RoomNumber { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public bool Islocated { get; set; }
        public string rentaltype { get; set; }
        public string AppartementOwnerId { get; set; }
       public virtual AppartementOwner appartementOwner { get; set; }

    }
}
