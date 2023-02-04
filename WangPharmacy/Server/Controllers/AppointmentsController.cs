using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WangPharmacy.Server.IRepository;
using WangPharmacy.Server.Repository;
using WangPharmacy.Shared.Domain;

namespace WangPharmacy.Server.Controllers
{
    public class AppointmentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAppointments()
        {
            var appointments = await _unitOfWork.Appointments.GetAll();
            return Ok(appointments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointment(int id)
        {
            var appointment = await _unitOfWork.Appointments.Get(q => q.Id == id);

            if (appointment == null)
            {
                return NotFound();
            }
            return Ok(appointment);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAppointment(int id, Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest();
            }
            _unitOfWork.Appointments.Update(appointment);

            try
            {
                await _unitOfWork.Save(HttpContext);
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
        [HttpPost]
        public async Task<ActionResult<Appointment>> PostAppointment(Appointment appointment)
        {
            await _unitOfWork.Appointments.Insert(appointment);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetAppointment", new { id = appointment.Id }, appointment);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            var appointment = await _unitOfWork.Appointments.Get(q => q.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            await _unitOfWork.Appointments.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }
        private async Task<bool> AppointmentExists(int id)
        {
            var appointment = await _unitOfWork.Appointments.Get(q => q.Id == id);
            return appointment != null;
        }

    }
}
