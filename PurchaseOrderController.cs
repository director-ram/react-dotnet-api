using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MyProject.models;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class PurchaseOrderController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PurchaseOrderController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PurchaseOrder>>> GetOrders()
    {
        return await _context.PurchaseOrders.Include(o => o.Company).Include(o => o.Items).ToListAsync();
    }
}