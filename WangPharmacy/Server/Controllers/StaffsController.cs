using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WangPharmacy.Server.Data;
using WangPharmacy.Server.IRepository;
using WangPharmacy.Server.Repository;
using WangPharmacy.Shared.Domain;

namespace WangPharmacy.Server.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly IUnitOfWork _unitofwork; 
        public StaffsController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }  
        
        [HttpGet]
        public async Task<IActionResult> GetStaffs()
        {
            //return NotFound();
            var staffs = await _unitofwork.Staffs.GetAll();
            return Ok(staffs);
        }
        
        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetStaff(int id)
        {             
            var staff = await _unitofwork.Staffs.Get(q => q.Id == id); 
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
            _unitofwork.Staffs.Update(staff); 
            try
            {
                
                await _unitofwork.Save(HttpContext);
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
            
            await _unitofwork.Staffs.Insert(staff);
            await _unitofwork.Save(HttpContext); 
            return CreatedAtAction("GetStaff", new { id = staff.Id }, staff);
        } 
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            //var staff = await _context.Staffs.FindAsync(id);
            var staff = await _unitofwork.Staffs.Get(q => q.Id == id);
            if (staff == null)
            {
                return NotFound();
            }             
            
            await _unitofwork.Staffs.Delete(id);
            await _unitofwork.Save(HttpContext);
            return NoContent();
        }         
        private async Task<bool> StaffExists(int id)
        {
            
            var staff = await _unitofwork.Staffs.Get(q => q.Id == id);
            return staff != null;
        }
    }
}