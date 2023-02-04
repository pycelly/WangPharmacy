using WangPharmacy.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WangPharmacy.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Appointment> Appointments { get; }
        IGenericRepository<Medicine> Medicines { get; }
        IGenericRepository<Order> Orders { get; }
        IGenericRepository<OrderItem> OrderItems { get; }
        IGenericRepository<Prescription> Prescriptions { get; }
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Staff> Staffs { get; }
        IGenericRepository<PrescriptionItem> PrescriptionItems { get; }
    }
}