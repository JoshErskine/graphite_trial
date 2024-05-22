using System;

namespace ATMConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ATM atm = new ATM();
            atm.Start();
        }
    }

    class ATM
    {
        private decimal balance;

        public ATM()
        {
            // Initial balance for demonstration purposes
            balance = 1000.00m;
        }

        public void Start()
        {
            while (true)
            {
                ShowMenu();
                int choice = GetChoice();

                switch (choice)
                {
                    case 1:
                        CheckBalance();
                        break;
                    case 2:
                        Deposit();
                        break;
                    case 3:
                        Withdraw();
                        break;
                    case 4:
                        Console.WriteLine("Thank you for using the ATM. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void ShowMenu()
        {
            Console.WriteLine("\nWelcome to the ATM");
            Console.WriteLine("1. Check Balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Exit");
            Console.Write("Please select an option: ");
        }

        private int GetChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Invalid input. Please enter a number between 1 and 4: ");
            }
            return choice;
        }

        private void CheckBalance()
        {
            Console.WriteLine($"Your current balance is: {balance:C}");
        }

        private void Deposit()
        {
            Console.Write("Enter the amount to deposit: ");
            decimal amount;
            while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.Write("Invalid amount. Please enter a positive number: ");
            }

            balance += amount;
            Console.WriteLine($"You have successfully deposited {amount:C}. Your new balance is {balance:C}");
        }

        private void Withdraw()
        {
            Console.Write("Enter the amount to withdraw: ");
            decimal amount;
            while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.Write("Invalid amount. Please enter a positive number: ");
            }

            if (amount > balance)
            {
                Console.WriteLine("Insufficient funds. Transaction denied.");
            }
            else
            {
                balance -= amount;
                Console.WriteLine($"You have successfully withdrawn {amount:C}. Your new balance is {balance:C}");
            }
        }
    }
}