using System;

namespace MySuperBank
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("Kendra", 30000);
            Console.WriteLine($"Account  {account.Number} was created for {account.Owner} with {account.Balance}");

            account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
            account.MakeDeposit(1750, DateTime.Now, "Friend paid me back");      
            account.MakeWithdrawal(50, DateTime.Now, "Xbox Game");
         
            Console.WriteLine(account.GetAccountHistory());
            
            /*// Test for a negative balance.
            try
            {
                account.MakeWithdrawal(75000, DateTime.Now, "Attempt to overdraw");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }

            // Test that the initial balances must be positive.
            try
            {
                var invalidAccount = new BankAccount("invalid", -55);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
            }*/
        }
    }
}
