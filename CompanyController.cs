using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MyProject.models;
using System.Threading.Tasks;

[ApiController]
[Route("api/companies")]
public class CompanyController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CompanyController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Company>>> GetCompanies()
    {
        Console.WriteLine("GetCompanies method called."); // Log when the method is hit
        return await _context.Companies.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Company>> CreateCompany(Company company)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Companies.Add(company);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetCompanies), new { id = company.Id }, company);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        var company = await _context.Companies.FindAsync(id);
        if (company == null)
        {
            return NotFound();
        }

        _context.Companies.Remove(company);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
