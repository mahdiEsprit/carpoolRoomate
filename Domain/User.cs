using Domain.entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public  class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }

        public string RIB { get; set; }
        public string Gender { get; set; }
         public virtual ICollection< DiscutionGroup> discutionGroup { get; set; }
        public virtual ICollection<CollocationGroup> collocationGroups { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
        public class CustomUserRole : IdentityUserRole<int>
        {
            public int Id { get; set; }

        }

    }
}
