using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TxtChecker.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TxtChecker
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }
        int num = 0;

        sentimentModel.RootObject AnalyseText(string doc)
        {
            string ServiceUrl = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment";
            string _subscriptionKey = "f6b8e4563fd14fef98b443c9f49839cd";


            var sentimentJsonData = "{\"documents\": [{\"language\":\"en\",\"id\":\"0\",\"text\":" + "\"" + doc + "\"}]}";
            byte[] byteArray = Encoding.UTF8.GetBytes(sentimentJsonData);
            num += 1;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);

                HttpContent jsonContent = new ByteArrayContent(byteArray);

                var response = Task.Run(() => client.PostAsync(ServiceUrl, jsonContent));
                //var response = await client.PostAsync(ServiceUrl, jsonContent);
                var responseString = response.Result.Content.ReadAsStringAsync();
                var resultObject = Newtonsoft.Json.JsonConvert.DeserializeObject<sentimentModel.RootObject>(responseString.Result);
                return resultObject;
            }
            
            
        }


        async void OnButtonClicked(object sender, EventArgs args)
        {
            Button button = (Button)sender;
            var userText = input.Text; // sender is cast to an Editor to enable reading the `Text` property of the view.
            

            sentimentModel.RootObject result = AnalyseText(userText);
            var score = result.documents[0];


            var sentiment = score.score;

            if (sentiment > 0.6) {
                await DisplayAlert("Done", "Sentiment of text is positive.", "Sentiment is saved.");
            }
            if (sentiment <= 0.6 && sentiment > 0.4) {
                await DisplayAlert("Done", "Sentiment of text is neutral.", "Sentiment is saved.");
            }
            if (sentiment <= 0.4)
            {
                await DisplayAlert("Done", "Sentiment of text is negative.", "Sentiment is saved.");
            }


        }

        async void CheckTable(object sender, EventArgs args) {
            

            

            Button button = (Button)sender;
            await DisplayAlert("Your Previous result was:","Positive","Done");
        }





    }
}
