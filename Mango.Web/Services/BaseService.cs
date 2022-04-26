using Mango.Web.Models;
using Mango.Web.Models.Dtos;
using Mango.Web.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mango.Web.Services
{
    public class BaseService : IBaseService
    {
        #region Properties

        public ResponseDto ResponseDto { get; set; }
        public IHttpClientFactory HttpClient { get; set; }

        #endregion

        #region Constructor

        public BaseService(IHttpClientFactory httpClient)
        {
            this.ResponseDto = new ResponseDto();
            this.HttpClient = httpClient;
        }

        #endregion

        #region Methods

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = HttpClient.CreateClient("MangoAPI");

                HttpRequestMessage message = new();
                message.RequestUri = new Uri(apiRequest.Url);
                message.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                client.DefaultRequestHeaders.Clear();
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
                }

                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.Post:
                        message.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.Put:
                        message.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.Delete:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                HttpResponseMessage apiResponse = null;
                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);

                return apiResponseDto;
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    DisplayMessage = "Error!!",
                    ErrorMessages = new List<string> { ex.Message },
                    IsSuccess = false
                };

                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);

                return apiResponseDto;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }

        #endregion
    }
}
