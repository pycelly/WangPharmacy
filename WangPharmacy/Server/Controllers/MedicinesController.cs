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
    public class MedicinesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public MedicinesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetMedicines()
        {
            var medicines = await _unitOfWork.Medicines.GetAll();
            return Ok(medicines);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicine(int id)
        {
            var medicine = await _unitOfWork.Medicines.Get(q => q.Id == id);

            if (medicine == null)
            {
                return NotFound();
            }
            return Ok(medicine);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicine(int id, Medicine medicine)
        {
            if (id != medicine.Id)
            {
                return BadRequest();
            }
            _unitOfWork.Medicines.Update(medicine);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MedicineExists(id))
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
        public async Task<ActionResult<Medicine>> PostMedicine(Medicine medicine)
        {
            await _unitOfWork.Medicines.Insert(medicine);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetMedicine", new { id = medicine.Id }, medicine);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            var medicine = await _unitOfWork.Medicines.Get(q => q.Id == id);
            if (medicine == null)
            {
                return NotFound();
            }

            await _unitOfWork.Medicines.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }
        private async Task<bool> MedicineExists(int id)
        {
            var medicine = await _unitOfWork.Medicines.Get(q => q.Id == id);
            return medicine != null;
        }

    }
}
