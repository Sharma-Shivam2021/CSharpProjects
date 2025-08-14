using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace CurrencyConverter_Online
{
    public class HttpRequesterForCurrencyData
    {
        public static async Task<Root> GetData<T>(string url)
        {
            Root myRoot = new Root();
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    HttpResponseMessage responseMessage = await client.GetAsync(url);
                    if (responseMessage.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string ResponseString = await responseMessage.Content.ReadAsStringAsync();
                        var ResponseObject = JsonConvert.DeserializeObject<Root>(ResponseString);

                        MessageBox.Show("TimeStamp: " + ResponseObject.timestamp,
                            "Information", MessageBoxButton.OK,
                            MessageBoxImage.Information);

                        return ResponseObject;
                    }
                    return myRoot;
                }
            }
            catch
            {

                return myRoot;
            }
        }
    }
}
