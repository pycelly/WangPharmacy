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
    public class PrescriptionItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PrescriptionItemsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetPrescriptionItems()
        {
            var prescriptionItems = await _unitOfWork.PrescriptionItems.GetAll();
            return Ok(prescriptionItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescriptionItem(int id)
        {
            var prescriptionItem = await _unitOfWork.PrescriptionItems.Get(q => q.Id == id);

            if (prescriptionItem == null)
            {
                return NotFound();
            }
            return Ok(prescriptionItem);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescriptionItem(int id, PrescriptionItem prescriptionItem)
        {
            if (id != prescriptionItem.Id)
            {
                return BadRequest();
            }
            _unitOfWork.PrescriptionItems.Update(prescriptionItem);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await PrescriptionItemExists(id))
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
        public async Task<ActionResult<PrescriptionItem>> PostPrescriptionItem(PrescriptionItem prescriptionItem)
        {
            await _unitOfWork.PrescriptionItems.Insert(prescriptionItem);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetPrescriptionItem", new { id = prescriptionItem.Id }, prescriptionItem);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescriptionItem(int id)
        {
            var prescriptionItem = await _unitOfWork.PrescriptionItems.Get(q => q.Id == id);
            if (prescriptionItem == null)
            {
                return NotFound();
            }

            await _unitOfWork.PrescriptionItems.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }
        private async Task<bool> PrescriptionItemExists(int id)
        {
            var prescriptionItem = await _unitOfWork.PrescriptionItems.Get(q => q.Id == id);
            return prescriptionItem != null;
        }

    }
}
