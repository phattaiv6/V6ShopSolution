using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using V6Shop.Data.Entities;

namespace V6Shop.Data.Configuaration
{
    public class AppconfigConfiguration : IEntityTypeConfiguration<AppConfig>
    {
        public void Configure(EntityTypeBuilder<AppConfig> builder)
        {
            builder.ToTable("Appconfigs"); //tên bản 
            builder.HasKey(x => x.Key); //primarykey
            builder.Property(x => x.Value).IsRequired(true); // isRequired : bắt phải nhập
        }
    }
}
