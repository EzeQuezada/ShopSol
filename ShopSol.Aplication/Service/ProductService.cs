

using Microsoft.Extensions.Logging;
using ShopMonolitica.Web.Data.Entities;
using ShopSol.Aplication.Core;
using ShopSol.Aplication.Dto.Product;
using ShopSol.Aplication.Extension;
using ShopSol.Aplication.Interfaces;
using ShopSol.Domain.Interfaces;
using ShopSol.Persistence.Context;
using ShopSol.Persistence.Exceptions;
using ShopSol.Persistence.Extension;

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

        public ServiceResult GetProduct(int productid)
        {
            var result = new ServiceResult();

            try
            {
                if (productid <= 0)
                {
                    result.Success = false;
                    result.Message = "ID del cliente inválido";
                    return result;
                }

                var products = productRepository.GetEntityBy(productid);

                if (products == null)
                {
                    result.Success = false;
                    result.Message = "producto no encontrado";
                    return result;
                }

                result.Data = products;
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Error obteniendo el producto. ";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }

        public ServiceResult GetProducts()
        {
            ServiceResult result = new ServiceResult();

            try
            {   
                result.Data = productRepository.GetAll();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los productos";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult RemoveProducts(ProductRemoveDto productsRemove)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (productsRemove == null)
                {
                    result.Success = false;
                    result.Message = "Este campo es requerido. ";
                    return result;
                }
                var productos = productsRemove.Toentity();
                this.productRepository.Remove(productos);
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = "Ocurrió un error eliminando los datos.";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult SaveProducts(ProductSaveDto productSave)
        {
            var result = new ServiceResult();

            try
            {
                result = EntityValidator<ProductSaveDto>.Validate(productSave);
                if (!result.Success)
                {
                    return result;
                }

                var producto = productSave.ToEntity();
                productRepository.save(producto);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error guardando los datos";
                logger.LogError(result.Message, ex.ToString());
            }

            return result;
        }

        public ServiceResult UpdateProducts(ProductUpdateDto productUpdate)
        {
            var result = EntityValidator<ProductUpdateDto>.Validate(productUpdate);
            if (!result.Success)
            {
                return result;
            }

            try
            {
                Products producto = productRepository.GetEntityBy(productUpdate.productid);

                if (producto == null)
                {
                    result.Success = false;
                    result.Message = "No se encontró el producto especificado.";
                    return result;
                }

                producto.ConvertProductUpdateModel(productUpdate);

                productRepository.Update(producto);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error actualizando los datos.";
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }
    }
}
