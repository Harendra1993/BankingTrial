using Newtonsoft.Json;
using Trail.Client.DTOs;

namespace Trail.Client
{
    internal static class RestHelper
    {
        private static readonly HttpClient client = new HttpClient();
        internal static async Task Deposit(TransactionDTO transactionDTO)
        {
            Console.WriteLine("Deposit");

            string json = JsonConvert.SerializeObject(transactionDTO);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");


            client.DefaultRequestHeaders.Accept.Clear();

            var stringTask = client.PostAsync("http://localhost:5203/deposit", httpContent);

            var response = await stringTask;
            var contents = await response.Content.ReadAsStringAsync();

            Console.WriteLine(contents);
            Console.WriteLine();
        }

        internal static async Task Withdraw(TransactionDTO transactionDTO)
        {
            Console.WriteLine("Withdraw");

            string json = JsonConvert.SerializeObject(transactionDTO);
            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");


            client.DefaultRequestHeaders.Accept.Clear();

            var stringTask = client.PostAsync("http://localhost:5203/withdraw", httpContent);

            var response = await stringTask;
            var contents = await response.Content.ReadAsStringAsync();

            Console.WriteLine(contents);
            Console.WriteLine();
        }

        internal static async Task Balance(int accountNumber)
        {
            Console.WriteLine("Check Balance");

            client.DefaultRequestHeaders.Accept.Clear();

            var stringTask = client.GetAsync("http://localhost:5203/balance/"+accountNumber);

            var response = await stringTask;
            var contents = await response.Content.ReadAsStringAsync();

            Console.WriteLine(contents);
            Console.WriteLine();
        }
    }
}
