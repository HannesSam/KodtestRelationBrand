using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ApiLibrary
{
    public class ApiHelper
    {
        public HttpClient ApiClient { get; private set; }
        public ApiHelper(string uri)
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ApiClient.BaseAddress = new Uri(uri);
        }
        public List<Subscriber> GetRequest(string apiAdress, bool list)
        {
            HttpResponseMessage response = ApiClient.GetAsync(apiAdress).Result;
            List<Subscriber> result = new List<Subscriber>();

            if (response.IsSuccessStatusCode)
            {
                if (list == true)
                {
                    result = JsonToList(response);
                }
                else
                {
                    //kalla på funktion som returnerar Json som inte är i en lista
                    //result = JsonToObject(response);
                }
            }
            else
            {
                throw new Exception($"The api call returned statusCode: {response.StatusCode} with message: {response.ReasonPhrase}");
            }
            return result;
        }

        private List<Subscriber> JsonToList(HttpResponseMessage response)
        {
            RootObject SubscriberList = response.Content.ReadAsAsync<RootObject>().Result;
            List<Subscriber> result = new List<Subscriber>();
            foreach (var Subscriber in SubscriberList.list)
            {
                Subscriber subscriber = new Subscriber(Subscriber.FirstName, Subscriber.LastName, Subscriber.Email, Subscriber.Mobile);
                result.Add(subscriber);
            }
            return result;
        }

        public void JsonToObject(HttpResponseMessage response)
        {
            //funktion för ifall man använder ett api som inte returnerar en lista.
        }
    }
}
