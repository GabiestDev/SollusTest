using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SollusTest.Data;
using SollusTest.Requests;
using SollusTest.Services.Contracts;

namespace SollusTest.Routes
{
    public static class ProductRoute
    {
        public static void ProductRoutes(WebApplication app)
        {
            var route = app.MapGroup("Product");

            route.MapPost("", async (ProductRequest req, IProductService service) =>
            {
                await service.Create(req);

                return Results.Created();
            });

            route.MapGet("", async (IProductService service) =>
            {
                var response = await service.GetAll();
                if (response.Count == 0)
                {
                    return Results.NotFound();
                }


                return Results.Ok(response);
            });

            _ = route.MapPut("{Id:guid}",
                 async (Guid id, ProductRequest req, ProductDbContext context) =>
                {
                    var product = await context.Product
                        .Include(x => x.Storage)
                        .FirstOrDefaultAsync(x => x.Id == id);

                    if (product == null)
                        return Results.NotFound();

                    if (req.Storage is not null)
                    {
                        if (product.Storage is null)
                            product.Storage = new(req.Storage);
                        else
                            product.Storage.Quantity = req.Storage.Quantity;

                    }

                    product.Name = req.Name;
                    await context.SaveChangesAsync();

                    return Results.Ok(product);

                });

            _ = route.MapPut("{Id:guid}/Storage",
                 async (Guid id, StorageRequest req, ProductDbContext context) =>
                 {
                     var product = await context.Product
                         .Include(x => x.Storage)
                         .FirstOrDefaultAsync(x => x.Id == id);

                     if (product?.Storage == null)
                         return Results.NotFound();

                     if (req is not null)
                     {
                         if (product.Storage is null)
                             product.Storage = new(req);
                         else
                             product.Storage.Quantity = req.Quantity;

                     }

                     await context.SaveChangesAsync();

                     return Results.Ok(product);

                 });

        }
    }
}
