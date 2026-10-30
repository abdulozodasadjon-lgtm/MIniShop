using Domain.Models;
using Infrastructure.Repositories;

ProductRepository prepo = new ProductRepository(){};
CategoryRepository crepo = new CategoryRepository(){};



while (true)
{
    System.Console.WriteLine("""
    |================================================================================|
    |                                                                                |
    |-                           PLEASE SELECT THE OPTION                            |
    |                                                                                |
    |================================================================================|
    |                            1.  Show all products.                              |
    |--------------------------------------------------------------------------------|
    |                           2.  Show product by id.                              |
    |--------------------------------------------------------------------------------|
    |                               3.  Add product.                                 |
    |--------------------------------------------------------------------------------|
    |                              4.  Update product.                               |
    |--------------------------------------------------------------------------------|
    |                           5. Delete product by id.                             |
    |--------------------------------------------------------------------------------|
    |                                    0. Exit.                                    |
    |                                                                                |
    =================================================================================|

    """);


    var choise = Convert.ToInt32(Console.ReadLine());
    switch (choise)
    {
        case 1:
        System.Console.WriteLine("\n======================================================================\n");
        List<Product_for_getting> pfg = await prepo.GetAllProductsAsync();
        foreach(var product in pfg)
            {
                System.Console.WriteLine($"---------------------------------------------------------\n| {product.Id}  |  {product.Name}  |  {product.Price}  |  {product.Category}\n---------------------------------------------------------");
            }
            System.Console.WriteLine("\n======================================================================\n");
        break;


        case 2:
        System.Console.Write($"Enter id of product: ");
        var idforgetting = Convert.ToInt32(Console.ReadLine());
        Product_for_getting pfg_for_getting = await prepo.GetProductAsync(idforgetting);
        System.Console.WriteLine($"---------------------------------------------------------\n| {pfg_for_getting.Id}  |  {pfg_for_getting.Name}  |  {pfg_for_getting.Price}  |  {pfg_for_getting.Category}\n---------------------------------------------------------");
        break;


        case 0:
        System.Console.WriteLine($"Exiting...");
        return;
    }
}