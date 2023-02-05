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
    public class PrescriptionItemsController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork;

        public PrescriptionItemsController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        // GET: api/PrescriptionItems
        [HttpGet]
        public async Task<IActionResult> GetPrescriptionItems()
        {
            var prescriptionItems = await _unitofwork.PrescriptionItems.GetAll(includes: q => q.Include(x => x.Medicine).Include(x => x.Prescription));
            return Ok(prescriptionItems);
        }

        // GET: api/PrescriptionItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescriptionItem(int id)
        {
            var prescriptionItems = await _unitofwork.PrescriptionItems.Get(q => q.Id == id);
            if (prescriptionItems == null)
            {
                return NotFound();
            }

            return Ok(prescriptionItems);
        }

        // PUT: api/PrescriptionItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrescriptionItem(int id, PrescriptionItem prescriptionItems)
        {
            if (id != prescriptionItems.Id)
            {
                return BadRequest();
            }

            _unitofwork.PrescriptionItems.Update(prescriptionItems);

            try
            {
                await _unitofwork.Save(HttpContext);
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

        // POST: api/PrescriptionItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PrescriptionItem>> PostPrescriptionItem(PrescriptionItem prescriptionItem)
        {
            await _unitofwork.PrescriptionItems.Insert(prescriptionItem);
            await _unitofwork.Save(HttpContext);

            return CreatedAtAction("GetPrescriptionItem", new { id = prescriptionItem.Id }, prescriptionItem);
        }

        // DELETE: api/PrescriptionItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescriptionItem(int id)
        {
            var prescriptionItem = await _unitofwork.PrescriptionItems.Get(q => q.Id == id);
            if (prescriptionItem == null)
            {
                return NotFound();
            }

            await _unitofwork.PrescriptionItems.Delete(id);
            await _unitofwork.Save(HttpContext);

            return NoContent();
        }

        private async Task<bool> PrescriptionItemExists(int id)
        {
            var prescriptionItem = await _unitofwork.Staffs.Get(q => q.Id == id);
            return prescriptionItem != null;
        }
    }
}
