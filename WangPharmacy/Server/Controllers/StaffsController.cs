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
    public class StaffsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public StaffsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetStaffs()
        {
            var staffs = await _unitOfWork.Staffs.GetAll();
            return Ok(staffs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaff(int id)
        {
            var staff = await _unitOfWork.Staffs.Get(q => q.Id == id);

            if (staff == null)
            {
                return NotFound();
            }
            return Ok(staff);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, Staff staff)
        {
            if (id != staff.Id)
            {
                return BadRequest();
            }
            _unitOfWork.Staffs.Update(staff);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await StaffExists(id))
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
        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
            await _unitOfWork.Staffs.Insert(staff);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetStaff", new { id = staff.Id }, staff);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            var staff = await _unitOfWork.Staffs.Get(q => q.Id == id);
            if (staff == null)
            {
                return NotFound();
            }

            await _unitOfWork.Staffs.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }
        private async Task<bool> StaffExists(int id)
        {
            var staff = await _unitOfWork.Staffs.Get(q => q.Id == id);
            return staff != null;
        }

    }
}
