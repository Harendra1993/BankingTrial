using System;
using System.Diagnostics;
using Trail.Client.DTOs;

namespace Trail.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //await Task.Delay(5000);

            Stopwatch stopwatch = Stopwatch.StartNew();

            List<TransactionDTO> transactionslst = new List<TransactionDTO>();

            Random random = new Random();

            int accountNumber = 10000001;

            for (int i = 0; i < 100; i++)
            {               
                int number = random.Next(1,4);
                accountNumber += i;

                if (number == 1)
                {
                    await RestHelper.Deposit(new TransactionDTO()
                    {
                        AccountNumber = accountNumber,
                        Amount = random.Next(50, 50001),
                        Currency = "INR",
                    });
                }

                if (number == 2)
                {
                    await RestHelper.Withdraw(new TransactionDTO()
                    {
                        AccountNumber = accountNumber,
                        Amount = random.Next(50, 50001),
                        Currency = "INR",
                    });
                }

                if (number==3)
                {
                    await RestHelper.Balance(accountNumber);
                }
            }

            Console.WriteLine($"Operation Completed in {stopwatch.ElapsedMilliseconds} ms.");

            Console.ReadKey();
        }
    }
}