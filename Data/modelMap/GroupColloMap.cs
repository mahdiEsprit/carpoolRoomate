using Domain.entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.modelMap
{
   public class GroupColloMap : EntityTypeConfiguration<CollocationGroup> 
    {
       public GroupColloMap()
        {
            this.ToTable("GroupCollocation", "room");
            

        }
    }
}
