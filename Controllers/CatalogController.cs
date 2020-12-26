  
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Catalog.API.Models;
using System.Threading.Tasks;

namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("api/CatalogApi")]
    public class CatalogController : ControllerBase
    {
        private readonly CatalogContext _db;
        public CatalogController(CatalogContext db)
        {
            _db = db;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var catalogItems = await _db.CatalogItems.ToListAsync();
            return new JsonResult(catalogItems);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var catalogItem = await _db.CatalogItems.FirstOrDefaultAsync(c => c.Id == id);
            return new JsonResult(catalogItem);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CatalogItem catalogItem)
        {
            _db.CatalogItems.Add(catalogItem);
            await _db.SaveChangesAsync();
            return new JsonResult(catalogItem.Id);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, CatalogItem catalogItem)
        {
            var existingCatalogItem = await _db.CatalogItems.FirstOrDefaultAsync(c => c.Id == id);
            existingCatalogItem = catalogItem;
            var success = (await _db.SaveChangesAsync()) > 0;
            return new JsonResult(success);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var catalogItem = await _db.CatalogItems.FirstOrDefaultAsync(c => c.Id == id);
            _db.Remove(catalogItem);
            var success = (await _db.SaveChangesAsync()) > 0;
            return new JsonResult(success);
        }
    }
}