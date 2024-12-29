using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.DTO;
using ProductsAPI.Models;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductsContexts _productsContexts;
        public ProductsController(ProductsContexts productsContexts)
        {
            _productsContexts = productsContexts;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await  _productsContexts.
            Products.Select( p=> ProductToDTO(p))
            .ToListAsync();
            return Ok(products);
        } 
        
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var p = await _productsContexts
            .Products
            .Where(i =>i.ProductId
             == id)
            .Select(p=> ProductToDTO(p))
            .FirstOrDefaultAsync();
            
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        } 

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product entity)
        {
            _productsContexts.Products.Add(entity);
            await _productsContexts.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct),new {id = entity.ProductId}, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id , Product entity)
        {
            if (id != entity.ProductId)
            {
                return BadRequest();
            }
            
            var product = await _productsContexts.Products.FirstOrDefaultAsync(i=>i.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            product.ProductName = entity.ProductName;   
            product.Price = entity.Price;
            product.IsActive = entity.IsActive;

            try
            {
                await _productsContexts.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (e != null)
                {
                    return NotFound();
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productsContexts.Products.FirstOrDefaultAsync(i=>i.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            _productsContexts.Products.Remove(product);

            try
            {
                await _productsContexts.SaveChangesAsync();
            }
            catch (Exception e)
            {
                if (e != null)
                {
                    return NotFound();
                }
            }
            return NoContent();
        }

        private static ProductDTO ProductToDTO(Product p)
        {

            var entity = new ProductDTO();
            if (p!=null)
            {
                entity.ProductId = p.ProductId;
                entity.ProductName = p.ProductName;
                entity.Price = p.Price;
            }
            return entity;
        }
    
    }
}