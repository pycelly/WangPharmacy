﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WangPharmacy.Server.Data;
using WangPharmacy.Shared.Domain;
using WangPharmacy.Server.IRepository;
using WangPharmacy.Server.Repository;

namespace WangPharmacy.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;

        public AppointmentsController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        // GET: api/Appointments
        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            var Appointments = await _unitofwork.Appointments.GetAll(includes: q => q.Include(x => x.Customer).Include(x=>x.Staff));
            return Ok(Appointments);
        }

        // GET: api/Appointments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            var Appointments = await _unitofwork.Appointments.Get(q => q.Id == id);
            if (Appointments == null)
            {
                return NotFound();
            }

            return Ok(Appointments);
        }

        // PUT: api/Appointments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, Appointment Appointment)
        {
            if (id != Appointment.Id)
            {
                return BadRequest();
            }

            _unitofwork.Appointments.Update(Appointment);

            try
            {
                await _unitofwork.Save(HttpContext);
            }

            catch (DbUpdateConcurrencyException)
            {

                if (!await AppointmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Appointments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment Appointment)
        {
            await _unitofwork.Appointments.Insert(Appointment);
            await _unitofwork.Save(HttpContext);

            return CreatedAtAction("GetAppointment", new { id = Appointment.Id }, Appointment);
        }

        // DELETE: api/Appointments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var Appointment = await _unitofwork.Appointments.Get(q => q.Id == id);
            if (Appointment == null)
            {
                return NotFound();
            }

            await _unitofwork.Appointments.Delete(id);
            await _unitofwork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> AppointmentExists(int id)
        {
            var Appointment = await _unitofwork.Staffs.Get(q => q.Id == id);
            return Appointment != null;
        }
    }
}
