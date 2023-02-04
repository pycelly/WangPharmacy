using WangPharmacy.Server.Data;
using WangPharmacy.Server.IRepository;
using WangPharmacy.Server.Models;
using WangPharmacy.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WangPharmacy.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Appointment> _appointments;
        private IGenericRepository<Medicine> _medicines;
        private IGenericRepository<Order> _orders;
        private IGenericRepository<OrderItem> _orderItems;
        private IGenericRepository<Prescription> _prescriptions;
        private IGenericRepository<Customer> _customers;
        private IGenericRepository<Staff> _staffs;
        private IGenericRepository<PrescriptionItem> _prescriptionItems;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Appointment> Appointments
            => _appointments ??= new GenericRepository<Appointment>(_context);
        public IGenericRepository<PrescriptionItem> PrescriptionItems
            => _prescriptionItems ??= new GenericRepository<PrescriptionItem>(_context);
        public IGenericRepository<Staff> Staffs
            => _staffs ??= new GenericRepository<Staff>(_context);
        public IGenericRepository<OrderItem> OrderItems
            => _orderItems ??= new GenericRepository<OrderItem>(_context);
        public IGenericRepository<Customer> Customers
            => _customers ??= new GenericRepository<Customer>(_context);
        public IGenericRepository<Medicine> Medicines
            => _medicines ??= new GenericRepository<Medicine>(_context);
        public IGenericRepository<Order> Orders
            => _orders ??= new GenericRepository<Order>(_context);
        public IGenericRepository<Prescription> Prescriptions
            => _prescriptions ??= new GenericRepository<Prescription>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);

            

            await _context.SaveChangesAsync();
        }
    }
}