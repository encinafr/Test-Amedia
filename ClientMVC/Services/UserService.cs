using ClientMVC.Common.Dto;
using ClientMVC.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Client.Services
{
    public class UserService : IUserService
    {
        private HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserModel>> Get()
        {
            var response = await _httpClient.GetAsync("/user");
            return JsonConvert.DeserializeObject<List<UserModel>>(await response.Content.ReadAsStringAsync());
        }


        public async Task<UserModel> Get(int id)
        {
            var response = await _httpClient.GetAsync("/user/" + id);
            return JsonConvert.DeserializeObject<UserModel>(await response.Content.ReadAsStringAsync());
        }
        
        public async Task<int> Add(UserModel user)
        {
            var myContent = JsonConvert.SerializeObject(user);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync("/user/", byteContent);
            return response.StatusCode == System.Net.HttpStatusCode.OK ? 1 : 0;
        }


        public async Task<UserModel> Login(LoginDto model)
        {
            var myContent = JsonConvert.SerializeObject(model);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync("/account/login", byteContent);
            return JsonConvert.DeserializeObject<UserModel>(await response.Content.ReadAsStringAsync());
        }

        public async Task<int> Update(int userId, UserModel user)
        {
            var myContent = JsonConvert.SerializeObject(user);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync("/user/" + userId, byteContent);
            return response.StatusCode == System.Net.HttpStatusCode.OK ? 1 : 0;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await _httpClient.GetAsync("/user/" + id);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
    }
}
