using ApiLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KodtestRelationBrand
{
    class Program
    {
        private const string uri = "https://awesomecorp.relationbrand.com/api/";
        private const string getSubscribers = "GetSubscribers";
        private const string getUnsubscribers = "GetUnsubscribers";

        static void Main(String[] args)
        {
            List<Subscriber> subscribers = new List<Subscriber>();
            List<Subscriber> unSubscribed = new List<Subscriber>();
            List<Subscriber> updatedSubscribers = new List<Subscriber>();

            ApiHelper Api = new ApiHelper(uri);

            try
            {
                subscribers = Api.GetRequest(getSubscribers, true);
                unSubscribed = Api.GetRequest(getUnsubscribers, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                Console.WriteLine("Error, se error message for details. Canceling operation.");
                Environment.Exit(0);
            }

            updatedSubscribers = subscribers.Except(unSubscribed, new CustomComparer()).ToList();

            try
            {
                Excel.NewExcelWoorkbook("SubscribersDB");
                Excel.SubscribersToExcel(updatedSubscribers, "SubscribersDB");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + ex.StackTrace);
                Console.WriteLine("Error, se error message for details. Canceling operation.");
                Environment.Exit(0);
            }
        }

    }
}
