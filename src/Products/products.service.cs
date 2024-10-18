
using System.Data;
using Dapper;


namespace ProductsServiceNameSpace {
  public class ProductsService()
  {
    private IDbConnection connection = DataContext.CreateConnection();

    public List<Products> GetProducts()
    {
      List<Products> products = connection.Query<Products>(@"select * from public.""Products""").ToList() ?? [];

      return products;
    }

    public Products? GetProduct(int id)
    {
      try
      {
        Products? product = connection.QuerySingleOrDefault<Products>(@$"select * from public.""Products"" where id = {id}") ?? null;

        return product;
      }
      catch (Exception error)
      {

        Console.WriteLine(error.Message);
        throw new Exception(error.Message, error);

      }
    }
    public ProductsCreateOrUpdateOutput CreateProduct(ProductsCreateBody body)

    {
      try
      {
        var prod = body;
        var vsql = @"
                 ""qtdStock"",
              ""categoryId"",
              ""isNewsLister"",
              description
              )
              values (@title,@price,@type,@qtdStock,@categoryId,@isNewsLister,@description) returning id";

        var res = connection.QuerySingle<ProductsCreateOrUpdateOutput>(vsql, body);
        // Console.WriteLine(JsonSerializer.Serialize(res));
        return res;
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        throw;
      }
    }

    public ProductsCreateOrUpdateOutput UpdateProduct(ProductsCreateBody body, int id)
    {
      try
      {
        string query = @$"
      update public.""Products"" set price = '{body.price}' where id={id} returning id; 
      ";

        ProductsCreateOrUpdateOutput response = connection.QuerySingle<ProductsCreateOrUpdateOutput>(query);

        return response;
      }
      catch (Exception error)
      {
        Console.WriteLine(error.Message);
        throw;
      }
    }
  }

}