using Java.Util;
using MiPrimeraApp.Clases;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MiPrimeraApp.Generic
{
    public class GenericList
    {
        public static async Task<bool> Post<T>(string _url, T _object)
        {
            HttpClient cliente = new HttpClient();
            string objeto = JsonConvert.SerializeObject(_object);
            var body = new StringContent(objeto, Encoding.UTF8, "application/json");
            var rpta = await cliente.PostAsync(_url, body);
            if (!rpta.IsSuccessStatusCode)
                return false;
            else
                return Convert.ToBoolean(await rpta.Content.ReadAsStringAsync());
        }

        public static async Task<int> Delete(string _url, int _id)
        {
            HttpClient cliente = new HttpClient();
            var rpta = await cliente.DeleteAsync($"{_url}?_id={_id}");
            if (!rpta.IsSuccessStatusCode)
                return 0;
            else
                return Convert.ToInt32(await rpta.Content.ReadAsStringAsync());
        }

        public static async Task<List<T>> GetAll<T>(string _url)
        {
            HttpClient cliente = new HttpClient();
            var respuesta = await cliente.GetAsync(_url);
            if (!respuesta.IsSuccessStatusCode) return new List<T>();
            else
            {
                var resultado = await respuesta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<T>>(resultado);
            }
        }
    }
}
