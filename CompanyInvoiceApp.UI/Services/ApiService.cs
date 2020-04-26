

using System.Net.Http;
using CompanyInvoiceApp.UI.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;

namespace CompanyInvoiceApp.UI.Services
{
    public class ApiService<T> where T : class
    {
        private static string baseApiUrl = "http://localhost:5001/";
        public static async Task<List<T>> GetList(string apiMethodPath, string id = null)
        {
            List<T> list = new List<T>();

            apiMethodPath = id == null ? apiMethodPath : $"{apiMethodPath}?{nameof(id)}={id}";
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(new System.Uri($"{baseApiUrl}{apiMethodPath}"));                
                
                if(response.IsSuccessStatusCode)
                {
                    list = JsonConvert.DeserializeObject<List<T>>(await response.Content.ReadAsStringAsync());
                }
            }
            return list;
        }

        public static async Task<(bool, string)> Create(string apiMethodPath, T model)
        {
            using (var httpClient = new HttpClient())
            {
                string jsonContent = JsonConvert.SerializeObject(model);
            
                using (var stringContent = new StringContent(jsonContent, Encoding.UTF8, "application/json"))
                {
                    var httpResponse = await httpClient.PostAsync($"{baseApiUrl}{apiMethodPath}", stringContent);
                    if(httpResponse.IsSuccessStatusCode)
                    {                        
                        return (true, string.Empty);
                    }
                    else
                        return (false, httpResponse.ReasonPhrase);
                }
            }
        }
    

        public static async Task<T> GetById(string apiMethodPath, string id)
        {
            T model = default(T);

            apiMethodPath = string.IsNullOrEmpty(id) ? apiMethodPath : $"{apiMethodPath}/{id}";
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(new System.Uri($"{baseApiUrl}{apiMethodPath}"));                
                
                if(response.IsSuccessStatusCode)
                {
                    model = JsonConvert.DeserializeObject<T>(await response.Content.ReadAsStringAsync());
                }
            }
            return model;
        }


    }    
}