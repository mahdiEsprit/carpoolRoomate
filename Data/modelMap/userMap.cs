using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.modelMap
{
    public class userMap : EntityTypeConfiguration<User>
    {
        public userMap()
        {
            this.ToTable("user", "room");
            this.HasMany(t => t.collocationGroups)
               .WithMany(t => t.users)
               .Map(m =>
               {
                   m.ToTable("ColloGroups_users");
                   m.MapLeftKey("user_fk");
                   m.MapRightKey("group_fk");
               });
        }
    }
}
