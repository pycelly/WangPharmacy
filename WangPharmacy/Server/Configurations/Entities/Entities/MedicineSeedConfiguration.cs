using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WangPharmacy.Shared.Domain;

namespace WangPharmacy.Server.Configurations.Entities.Entities
{
    public class MedicineSeedConfiguration : IEntityTypeConfiguration<Medicine>
    {
        public void Configure(EntityTypeBuilder<Medicine> builder)
        {
            builder.HasData(
                new Medicine
                {
                    Id = 1,
                    MedicineName = "panadol",
                    MedicineType = "general",
                    MedicineDescription = "To treat fever",
                    MedicinePrice = 2.23

                },
                new Medicine
                {
                    Id = 2,
                    MedicineName = "protein",
                    MedicineType = "gym",
                    MedicineDescription = "To gain muscle",
                    MedicinePrice = 223.23

                }
                );
            
        }
    }
}
