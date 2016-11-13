using Domain.entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.modelMap
{
    public class discutionGrouMapd :  EntityTypeConfiguration<DiscutionGroup>
    {
        public discutionGrouMapd()
        {
            this.ToTable("discution", "room");
            this.Property(t => t.UserIden).HasColumnName("UserIden");
            this.HasOptional(t => t.user)
                    .WithMany(t => t.discutionGroup)
                    .HasForeignKey(d => d.UserIden);
        }
    }
}
