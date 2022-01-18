using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ApisCallingApis.Models;
using ApisCallingApis.Util;

namespace ApisCallingApis.Data
{
    public class ApiComandosRepo : IComandosRepo
    {
        private readonly string _commandBaseAddress = "http://localhost:5000";

        public ApiComandosRepo()
        {
            ClientUtil.InitializeClientUtil();
            ClientUtil.Client.BaseAddress = new Uri(_commandBaseAddress);
        }

        public async Task<Comando> CreateAsync(Comando cmd)
        {
            var cmdSerialized = JsonSerializer.Serialize(cmd);
            var content = new StringContent(cmdSerialized, Encoding.UTF8, "application/json");

            using (var response = await ClientUtil.Client.PostAsync("api/commands", content))
            {
                response.EnsureSuccessStatusCode();

                var respContent = await response.Content.ReadAsStreamAsync();
                var comandoCreated = await JsonSerializer.DeserializeAsync<Comando>(respContent);

                return comandoCreated;
            }
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Comando>> GetAllAsync()
        {
            using (var response = await ClientUtil.Client.GetAsync("api/Commands"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStreamAsync();
                    var comandos = await JsonSerializer.DeserializeAsync<IEnumerable<Comando>>(content);
                    return comandos;
                }
            }
            return null;
        }

        public async Task<Comando> GetByIdAsync(int id)
        {
            using (var response = await ClientUtil.Client.GetAsync($"api/commands/{id}"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStreamAsync();
                    var comando = await JsonSerializer.DeserializeAsync<Comando>(content);
                    return comando;
                }
            }
            return null;
        }

        public async Task UpdateAsync(Comando cmd)
        {
            var cmdSerialized = JsonSerializer.Serialize(cmd);
            var content = new StringContent(cmdSerialized, Encoding.UTF8, "application/json");

            using (var response = await ClientUtil.Client.PutAsync($"api/Commands/{cmd.Id} ", content))
            {
                response.EnsureSuccessStatusCode();
            }
        }
    }
}
