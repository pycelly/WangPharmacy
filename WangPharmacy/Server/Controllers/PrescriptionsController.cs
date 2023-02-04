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
    public class PrescriptionsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PrescriptionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetPrescriptions()
        {
            var prescriptions = await _unitOfWork.Prescriptions.GetAll();
            return Ok(prescriptions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescription(int id)
        {
            var prescriptions = await _unitOfWork.Prescriptions.Get(q => q.Id == id);

            if (prescriptions == null)
            {
                return NotFound();
            }
            return Ok(prescriptions);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescription(int id, Prescription prescriptions)
        {
            if (id != prescriptions.Id)
            {
                return BadRequest();
            }
            _unitOfWork.Prescriptions.Update(prescriptions);

            try
            {
                await _unitOfWork.Save(HttpContext);
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
        [HttpPost]
        public async Task<ActionResult<Prescription>> PostPrescription(Prescription prescriptions)
        {
            await _unitOfWork.Prescriptions.Insert(prescriptions);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetPrescription", new { id = prescriptions.Id }, prescriptions);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescription(int id)
        {
            var prescriptions = await _unitOfWork.Prescriptions.Get(q => q.Id == id);
            if (prescriptions == null)
            {
                return NotFound();
            }

            await _unitOfWork.Prescriptions.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }
        private async Task<bool> PrescriptionExists(int id)
        {
            var prescriptions = await _unitOfWork.Prescriptions.Get(q => q.Id == id);
            return prescriptions != null;
        }

    }
}
