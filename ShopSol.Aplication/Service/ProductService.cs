

using Microsoft.Extensions.Logging;
using ShopMonolitica.Web.Data.Entities;
using ShopSol.Aplication.Core;
using ShopSol.Aplication.Dto.Product;
using ShopSol.Aplication.Extension;
using ShopSol.Aplication.Interfaces;
using ShopSol.Domain.Interfaces;
using ShopSol.Persistence.Context;

namespace ShopSol.Aplication.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly ILogger<ProductService> logger;

        public ProductService(IProductRepository productRepository, 
                    ILogger<ProductService>logger)
        {
            this.productRepository = productRepository;
            this.logger = logger;
        }
        public ServiceResult Get()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var product = this.productRepository.GetAll();
                result.Data = product;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los productos";
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }

        public ServiceResult GetById(int id)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                var product = this.productRepository.GetEntityBy(id);
                result.Data = product;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo los productos";
                this.logger.LogError($"{result.Message}", ex.ToString());

            }
            return result;
        }

        public ServiceResult Remove(ProductRemoveDto model)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Save(ProductSaveDto model)
        {
            ServiceResult result = new ServiceResult();

            try
            {

                if (!model.IsValidProduct().Success)
                    return result;

                Products products = model.ConvertProductSaveModel();

                this.productRepository.save(products);

                result.Message = "Producto guardado correctamente.";

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error guardando el producto";
                this.logger.LogError($"{result.Message}", ex.ToString());
            }
            return result;


        }

        public ServiceResult Update(ProductUpdateDto model)
        {
            ServiceResult result = new ServiceResult();

            if (!model.IsValidProduct().Success)
                return result;

            try
            {
                Products products = model.ConvertProductUpdateModel();

                products.modify_date = DateTime.Now;
                products.creation_user = 1;
               

                this.productRepository.Update(products);

                result.Message = "product actualizado correctamente.";
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Error actualizando el producto";
                this.logger.LogError($" {result.Message} ", ex.ToString());
            }

            return result;
        }
    }
}
