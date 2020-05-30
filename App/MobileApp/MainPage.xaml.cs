using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace MobileApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public const string URL = "<LINK_TO_ADD>";
        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This method executes the request to the API hosted in Azure.
        /// </summary>
        /// <param name="sender">Object that sending the request</param>
        /// <param name="e">Parameters that are sent as an arguments</param>
        async void OnSendRequest(System.Object sender, System.EventArgs e)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var obj = new
                    {
                        text = TextEntry.Text
                    };

                    var content = new StringContent(
                        JsonConvert.SerializeObject(obj),
                        Encoding.UTF8,
                        @"application/json");

                    var response = await client.PostAsync(URL, content);
                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var phrases = createKeyPhrasesList(responseBody);
                        string result = string.Empty;
                        foreach (var phrase in phrases)
                        {
                            result += phrase + "\n";
                        }
                        await DisplayAlert("Success",
                            "The list of key phrases\n\n" + result,
                            "OK");
                    }
                    else throw new InvalidOperationException();
                }
            }
            catch
            {
                await DisplayAlert("Ooops!","Something went wrong. Please, try again later", "OK");
            }
        }

        /// <summary>
        /// Function that creates an array of key phrases
        /// </summary>
        /// <param name="response">Response string from API</param>
        /// <returns></returns>
        private string[] createKeyPhrasesList(string response)
        {
            response = response.Replace("[", string.Empty)
                .Replace("]", string.Empty)
                .Replace("\"", string.Empty);

            return response.Split(',');
        }
    }
}
