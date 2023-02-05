using System;
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
    public class PrescriptionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;

        public PrescriptionsController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        // GET: api/Prescriptions
        [HttpGet]
        public async Task<IActionResult> GetPrescriptions()
        {
            var prescriptions = await _unitofwork.Prescriptions.GetAll(includes: q => q.Include(x => x.Appointment));
            return Ok(prescriptions);
        }

        // GET: api/Prescriptions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescription(int id)
        {
            var prescriptions = await _unitofwork.Prescriptions.Get(q => q.Id == id);
            if (prescriptions == null)
            {
                return NotFound();
            }

            return Ok(prescriptions);
        }

        // PUT: api/Prescriptions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescription(int id, Prescription prescriptions)
        {
            if (id != prescriptions.Id)
            {
                return BadRequest();
            }

            _unitofwork.Prescriptions.Update(prescriptions);

            try
            {
                await _unitofwork.Save(HttpContext);
            }

            catch (DbUpdateConcurrencyException)
            {

                if (!await PrescriptionExists(id))
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

        // POST: api/Prescriptions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Prescription>> PostPrescription(Prescription Prescription)
        {
            await _unitofwork.Prescriptions.Insert(Prescription);
            await _unitofwork.Save(HttpContext);

            return CreatedAtAction("GetPrescription", new { id = Prescription.Id }, Prescription);
        }

        // DELETE: api/Prescriptions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescription(int id)
        {
            var Prescription = await _unitofwork.Prescriptions.Get(q => q.Id == id);
            if (Prescription == null)
            {
                return NotFound();
            }

            await _unitofwork.Prescriptions.Delete(id);
            await _unitofwork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> PrescriptionExists(int id)
        {
            var Prescription = await _unitofwork.Staffs.Get(q => q.Id == id);
            return Prescription != null;
        }
    }
}
