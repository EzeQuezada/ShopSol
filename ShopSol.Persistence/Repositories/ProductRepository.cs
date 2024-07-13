

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
            return context.Products.Select(products =>products.ConvertProductEntitieModel()).ToList();
        }

        public Products GetEntityBy(int id)
        {
            var products = context.Products.Find(id).ConvertProductEntitieModel();

            if (products != null)
            {
                throw new ProductsExceptions($"El producto no se encontro el producto con el id {id}");
            }

            return products;
        }

        //public List<Products> GetProducts()
        //{
        //    return context.Products.Select(products => products.ConvertProductEntitieModel()).ToList();
        //}

        public void Remove(Products entity)
        {
            Products productToDelete = this.context.Products.Find(entity.productid);

            productToDelete.deleted = entity.deleted;
            productToDelete.delete_date = entity.delete_date;
            productToDelete.delete_user = entity.delete_user;

            this.context.Products.Update(productToDelete);
        }

        public void save(Products entity)
        {
            Products saveEntity = products.ConvertProductSaveModel();

            context.Products.Add(saveEntity);
            context.SaveChanges();
        }

        public void Update(Products entity)
        {
            throw new NotImplementedException();
        }
    }
}
