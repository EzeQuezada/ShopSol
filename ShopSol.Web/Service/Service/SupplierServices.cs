using Newtonsoft.Json;
using ShopSol.Web.Models;
using ShopSol.Web.Result.SupplierResult;
using ShopSol.Web.Services.IServvice;
using System.Text.Json.Serialization;
using System.Text;

namespace ShopSol.Web.Services.Services
{
    public class SupplierServices : ISupplierService
    {
        private HttpClientHandler httpClientHandler;
        private const string BaseUrl = "http://localhost:5240/api/Suppliers/"; 

        public SupplierServices()
        {
            this.httpClientHandler = new HttpClientHandler();
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
        }

        public async Task<SupplierGetResult> GetById(int id)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{BaseUrl}GetSupplierById?id={id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<SupplierGetResult>(apiResponse);
                        return result;
                    }   
                    else
                    {
                        return new SupplierGetResult { success = false, message = "Error al obtener el suplidor." };
                    }
                }
            }              
        }

        public async Task<SupplierGetListResult> GetList()
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{BaseUrl}GetSuppliers";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<SupplierGetListResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new SupplierGetListResult {  success = false, message = "Error al obtener el suplidor."};
                    }
                }
            }
        }

        public async Task<SupplierSaveResult> Save(SupplierSaveModel supplierSaveModel)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{BaseUrl}SaveSuppliers";
                var content = new StringContent(JsonConvert.SerializeObject(supplierSaveModel), Encoding.UTF8, "application/json" );
                CreationUser(supplierSaveModel);

                using (var response = await httpClient.PostAsync(url, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<SupplierSaveResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new SupplierSaveResult { success = false, message = "Error al guardar el suplidor." };
                    }
                }
            }
        }

        public async Task<SupplierUpdateResult> Update(SupplierUpdateModel supplierUpdateModel)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{BaseUrl}UpdateSuppliers";
               
                var content = new StringContent(JsonConvert.SerializeObject(supplierUpdateModel), Encoding.UTF8, "application/json");
                ModifyUser(supplierUpdateModel);
                using (var response = await httpClient.PutAsync(url,content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<SupplierUpdateResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new SupplierUpdateResult { success = false, message = "Error al obtener el suplidor." };
                    }
                }
            }
        }
        private void CreationUser(SupplierSaveModel saveModel)
        {
            saveModel.creation_date = DateTime.Now;
            saveModel.creation_user = 2;
        }

        private void ModifyUser(SupplierUpdateModel updateModel)
        {
            updateModel.modify_date = DateTime.Now;
            updateModel.modify_user = 1;
        }
    }
}
