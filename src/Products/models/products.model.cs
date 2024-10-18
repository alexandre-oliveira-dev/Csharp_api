
public class Products
{
    public int? id { get; set; }
    public string? price { get; set; }
    public string? type { get; set; }
    public string? title { get; set; }
    public int? qtdStock { get; set; }
    public int? categoryId { get; set; }
    public string? createdAt { get; set; }
    public bool? isNewsLister { get; set; }
    public string? description { get; set; }

}

public class ProductsCreateOrUpdateOutput
{
    public int id { get; }
}

public class ProductsCreateBody : Products { }


