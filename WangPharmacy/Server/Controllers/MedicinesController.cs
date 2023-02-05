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
    public class MedicinesController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;

        public MedicinesController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        // GET: api/Medicines
        [HttpGet]
        public async Task<IActionResult> GetMedicines()
        {
            var medicines = await _unitofwork.Medicines.GetAll();
            return Ok(medicines);
        }

        // GET: api/Medicines/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicine(int id)
        {
            var medicine = await _unitofwork.Medicines.Get(q => q.Id == id); 
            if (medicine == null)               
            {
                return NotFound();
            }

            return Ok(medicine);
        }

        // PUT: api/Medicines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedicine(int id, Medicine medicine)
        {
            if (id != medicine.Id)
            {
                return BadRequest();
            }

            _unitofwork.Medicines.Update(medicine);

            try
            {
                await _unitofwork.Save(HttpContext);
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

        // POST: api/Medicines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Medicine>> PostMedicine(Medicine medicine)
        {
            await _unitofwork.Medicines.Insert(medicine);
            await _unitofwork.Save(HttpContext);

            return CreatedAtAction("GetMedicine", new { id = medicine.Id }, medicine);
        }

        // DELETE: api/Medicines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicine(int id)
        {
            var medicine = await _unitofwork.Medicines.Get(q => q.Id == id);
            if (medicine == null)
            {
                return NotFound();
            }

           await _unitofwork.Medicines.Delete(id);
            await _unitofwork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> MedicineExists(int id)
        {
            var medicine = await _unitofwork.Staffs.Get(q => q.Id == id);
            return medicine != null;
        }
    }
}
