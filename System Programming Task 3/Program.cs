using System;
using System.Threading;

namespace System_Programming_Task_3
{
    internal class Program
    {
        static object lockObject = new object();

        static string cardNumber = "4169 7388 1230 3636";
        static string fullName = "Nurlan Jafarov";
        static decimal balance = 500.0m;

        static void ProcessTransaction(string source, decimal amount)
        {
            lock (lockObject)
            {
                Console.WriteLine($"\n--- {source} Muraciet ---");
                Console.WriteLine($"Kart No: {cardNumber} | Kartin Yiyesi: {fullName}");
                Console.WriteLine($"Teleb olunan mebleg: {amount} AZN | Movcud Balans: {balance} AZN");



                if (balance >= amount)
                {
                    balance -= amount;
                    Console.WriteLine($"[UGURLU] {source} terefinden {amount} AZN cixarildi. Qaliq balans: {balance} AZN");
                }
                else
                {
                    Console.WriteLine($"[XETA] {source} ucun balans kifayet etmedi! Movcud balans: {balance} AZN");
                }
            }
        }

        static void Main(string[] args)
        {
            Thread YDMThread = new Thread(() => ProcessTransaction("YDM", 150.0m));
            Thread atmThread = new Thread(() => ProcessTransaction("ATM", 200.0m));

            YDMThread.Start();
            atmThread.Start();

            YDMThread.Join();
            atmThread.Join();


            Console.WriteLine($"\nEmeliyyatlar bitdi. Balans: {balance} AZN");
        }
    }
}