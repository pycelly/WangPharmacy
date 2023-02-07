using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WangPharmacy.Shared.Domain;

namespace WangPharmacy.Server.Configurations.Entities
{
    public class CustomerSeedConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(
                new Customer
                {
                    Id = 1,
                    CustomerName = "Wpy",
                    CustomerEmail = "123@123.com",
                    CustomerContact = "1234123213",
                    CustomerDOB = "123/123/123",
                    CustomerGender = "male",
                    CustomerAddress ="1321123"

                },
                new Customer
                {
                    Id = 2,
                    CustomerName = "Wpy1",
                    CustomerEmail = "123@123.com1",
                    CustomerContact = "12341123213",
                    CustomerDOB = "1213/123/123",
                    CustomerGender = "1male",
                    CustomerAddress = "1321123"

                }

                
                );

        }
    }
}
