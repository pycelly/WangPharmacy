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
    public class OrdersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _unitOfWork.Orders.GetAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrder(int id)
        {
            var order = await _unitOfWork.Orders.Get(q => q.Id == id);

            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }
            _unitOfWork.Orders.Update(order);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await OrderExists(id))
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
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            await _unitOfWork.Orders.Insert(order);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _unitOfWork.Orders.Get(q => q.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            await _unitOfWork.Orders.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }
        private async Task<bool> OrderExists(int id)
        {
            var order = await _unitOfWork.Orders.Get(q => q.Id == id);
            return order != null;
        }

    }
}
