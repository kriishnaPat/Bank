using System;
using System.Collections.Generic;
using System.Threading;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount Jerry = new BankAccount("Jerry", 50, 5000, 1.5);
            Jerry.takeLoan();
            Jerry.requestNewRate();
            Jerry.withdraw();
            Jerry.deposit();
            Jerry.makeLoanPayment();
        }
        class BankAccount
        {
            public string owner;
            public int balance;
            public int loans;
            public double interestRate;

            public BankAccount(string owner, int balance, int loans, double interestRate)
            {
                this.owner = owner;
                this.balance = balance;
                this.loans = loans;
                this.interestRate = interestRate;
            }
            public void takeLoan()
            {
                Console.WriteLine("What amount would you like as a loan: ");
                int amount = Convert.ToInt32(Console.ReadLine());
                amount = Convert.ToInt32((amount * (this.interestRate / 100)) + amount);
                this.loans = this.loans + amount;
                Console.WriteLine($"Your new total loan payment is {this.loans}.");
            }
            public void requestNewRate()
            {
                this.interestRate = Math.Round(GetRandomNumber(0.01, 2.50), 2);
                Console.WriteLine($"Your new interest rate is %{this.interestRate}.");
            }
            public void withdraw()
            {
                Console.WriteLine("What amount would you like to withdraw: ");
                int amount = Convert.ToInt32(Console.ReadLine());
                this.balance = this.balance - amount;
                Console.WriteLine($"Your new balance is {this.balance}.");
            }
            public void deposit()
            {
                Console.WriteLine("What amount would you like to deposit: ");
                int amount = Convert.ToInt32(Console.ReadLine());
                this.balance = this.balance + amount;
                Console.WriteLine($"Your new balance is {this.balance}.");
            }
            public double GetRandomNumber(double minimum, double maximum)
            {
                Random random = new Random();
                return random.NextDouble() * (maximum - minimum) + minimum;
            }
            public void makeLoanPayment(){
                Console.WriteLine("What amount would you like to pay towards your loan: ");
                int amount = Convert.ToInt32(Console.ReadLine());
                this.loans = this.loans - amount;
                Console.WriteLine($"You now owe ${this.loans}.");
            }
        }
    }
}
