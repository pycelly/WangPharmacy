using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WangPharmacy.Shared.Domain;

namespace WangPharmacy.Server.Configurations.Entities
{
    public class StaffSeedConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasData(
                new Staff
                {
                    Id = 1,
                    StaffName = "tr",
                    StaffGender = "male",
                    StaffContact = "12312",
                    StaffEmail = "123@123.com"

                },
                new Staff
                {
                    Id = 2,
                    StaffName = "tr1",
                    StaffGender = "male",
                    StaffContact = "2131232",
                    StaffEmail = "1213@123.com"

                }
                );

        }
    }
}
