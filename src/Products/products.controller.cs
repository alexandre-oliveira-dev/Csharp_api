using Microsoft.AspNetCore.Mvc;
using ProductsServiceNameSpace;




[ApiController]
[Produces("application/json")]
public class ProductsController
{

    [HttpGet("/getAll")]
    public List<Products> FindManyProducts()
    {
        return new ProductsService().GetProducts();
    }
    [HttpPost("/create")]
    public ProductsCreateOrUpdateOutput Create([FromBody] ProductsCreateBody body)
    {
        return new ProductsService().CreateProduct(body);
    }
    [HttpPut("/update")]
    public ProductsCreateOrUpdateOutput update([FromBody] ProductsCreateBody body, [FromQuery] int id)
    {
        return new ProductsService().UpdateProduct(body, id);
    }

    [HttpGet("/findUnique")]
    public Products? GetProduct([FromQuery] int id)
    {
        return new ProductsService().GetProduct(id);
    }

}