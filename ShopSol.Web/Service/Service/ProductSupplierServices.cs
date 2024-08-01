using Newtonsoft.Json;
using ShopMonolitica.Web.Data.ProductModel;
using ShopSol.Web.Models;
using ShopSol.Web.Result.ProductSupplier;
using ShopSol.Web.Result.SupplierResult;
using ShopSol.Web.Service.IService;
using System.Text;

namespace ShopSol.Web.Service.Service
{
    public class ProductSupplierServices : IProductService
    {
        private readonly HttpClientHandler httpClientHandler;
        private const string BaseUrl = "http://localhost:5240/api/Suppliers/";
        public ProductSupplierServices()
        {
            this.httpClientHandler = new HttpClientHandler();
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
        }
        public async Task<ProductGetResult> GetById(int id)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{BaseUrl}GetProductById?id={id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<ProductGetResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new ProductGetResult { success = false, message = "Error al obtener el producto." };
                    }
                }
            }
        }

        public async Task<ProductGetListResult> GetList()
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{BaseUrl}GetProducts";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<ProductGetListResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new ProductGetListResult { success = false, message = "Error al obtener el producto." };
                    }
                }
            }
        }

        public async Task<ProductSaveResult> Save(ProductSaveModel productSaveModel)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{BaseUrl}SaveSuppliers";
                var content = new StringContent(JsonConvert.SerializeObject(productSaveModel), Encoding.UTF8, "application/json");
                CreationUser(productSaveModel);

                using (var response = await httpClient.PostAsync(url, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<ProductSaveResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new ProductSaveResult { success = false, message = "Error al guardar el suplidor." };
                    }
                }
            }
        }
        public async Task<ProductUpdateResult> Update(ProductUpdateModel productUpdateModel)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{BaseUrl}UpdateProduct";

                var content = new StringContent(JsonConvert.SerializeObject(productUpdateModel), Encoding.UTF8, "application/json");
                ModifyUser(productUpdateModel);
                using (var response = await httpClient.PutAsync(url, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<ProductUpdateResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new ProductUpdateResult { success = false, message = "Error al obtener el producto." };
                    }
                }
            }
        }
        private void CreationUser(ProductSaveModel saveModel)
        {
            saveModel.creation_date = DateTime.Now;
            saveModel.creation_user = 2;
        }

        private void ModifyUser(ProductUpdateModel updateModel)
        {
            updateModel.modify_date = DateTime.Now;
            updateModel.modify_user = 1;
        }
    }
          
    }
