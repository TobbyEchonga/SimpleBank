using System;
using System.Collections.Generic;
using System.Text;

namespace MySuperBank
{
    //create  new account
    class BankAccount
    {
        //form fields to fill the bank account
        public string Number { get; }
        public string Owner { get; set; }
        public decimal Balance 
        { 
            get 
            { 
                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    //balance = balance + item.Amount;
                    //is the same as 
                    balance += item.Amount;
                }
                return balance;
            }
        }

        private static int accountNumberSeed = 123456789;

        private List<Transaction> allTransactions = new List<Transaction>();

        public BankAccount(string name, decimal initialBalance)
        {
            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;
        }
        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                //makes sure value is not less than 0
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var withdrawal = new Transaction(-amount, date, note);
            allTransactions.Add(withdrawal);
        }

        public string GetAccountHistory()
        {
            //generating a string report within a stringbuilder
            var report = new StringBuilder();

            decimal balance = 0;
            //creates a string line table
            //headers
            report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in allTransactions)
            {
                //rows
                balance += item.Amount;
                report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }
            
            return report.ToString();
        }
    }
}
