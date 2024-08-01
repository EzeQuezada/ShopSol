    

using Microsoft.EntityFrameworkCore;
using ShopMonolitica.Web.Data.Entities;
using ShopSol.Domain.Interfaces;
using ShopSol.Persistence.Context;
using ShopSol.Persistence.DbObject;
using ShopSol.Persistence.Exceptions;
using ShopSol.Persistence.Extension;
using ShopSol.Persistence.Models;
using System.Linq.Expressions;

namespace ShopSol.Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopContext context;

        public ProductRepository(ShopContext context)
        {
            this.context = context;
        }
        public bool Exists(Expression<Func<Products, bool>> filter)
        {
            return this.context.Products.Any(filter);
        }

        public List<Products> GetAll()
        {                                                       
            return this.context.Products.ToList();
        }

        public List<Products> GetProductsById(int productId)
        {
            var productos = context.ValidateProductExist(productId);

            if (productos is null)
            {
                throw new ProductsExceptions($"No se pudo encontrar el empleado con el id{productId}");
            }
            var ProductsList = new List<Products> {productos};

            return ProductsList;
        }

        public Products GetEntityBy(int id)
        {
            var products = context.ValidateProductExist(id);

            if (products != null)
            {
                throw new ProductsExceptions($"El producto no se encontro el producto con el id {id}");
            }

            return products;
        }


        public void Remove(Products entity)
        {
            var existingProducts = context.ValidateProductExist(entity.Id);
            if (existingProducts != null)
            {
                context.Products.Remove(existingProducts);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("El producto no existe.");
            }
        }

        public void save(Products entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ProductsExceptions(nameof(entity));
                }

                context.Products.Add(entity);
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw new ProductsExceptions("Error al guardar el producto.");
            }
        }
         
        public void Update(Products entity)
        {
            

            try
            {
                Products productsToUpdate = GetEntityBy(entity.Id);
                if (productsToUpdate != null)
                {
                    productsToUpdate.ConvertProductUpdateModel(entity);
                    context.Products.Update(productsToUpdate);
                    context.SaveChanges();
                }
                else
                {
                    throw new ArgumentNullException(nameof(entity), "La entidad no puede ser nula.");
                }
            }
            catch (Exception)
            {

                throw new ProductsExceptions("Error al actualizar el empleado.");
            }

            

        }

       
    }
}
