using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Select an exercise to run (1 or 2):");
        Console.WriteLine("1: Custom Validation Exception");
        Console.WriteLine("2: Bank Account Exception Handling");

        switch (Console.ReadLine())
        {
            case "1":
                RunCustomValidationException();
                break;
            case "2":
                RunBankAccountExceptionHandling();
                break;
            default:
                Console.WriteLine("Invalid selection. Please enter 1 or 2.");
                break;
        }
    }

    static void RunCustomValidationException()
    {
        try
        {
            Console.WriteLine("Enter the student's age:");
            int age = int.Parse(Console.ReadLine());
            ValidateAge(age);
            Console.WriteLine("Student is eligible for admission.");
        }
        catch (AgeOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
        }
    }

    static void ValidateAge(int age)
    {
        if (age < 18 || age > 25)
        {
            throw new AgeOutOfRangeException("Age must be between 18 and 25.");
        }
    }

    static void RunBankAccountExceptionHandling()
    {
        BankAccount account = new BankAccount();
        try
        {
            Console.WriteLine("Enter amount to deposit:");
            account.Deposit(decimal.Parse(Console.ReadLine()));
            Console.WriteLine("Enter amount to withdraw:");
            account.Withdraw(decimal.Parse(Console.ReadLine()));
            Console.WriteLine($"Current balance: {account.Balance}");
        }
        catch (NegativeAmountException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter a valid decimal number.");
        }
    }

    class AgeOutOfRangeException : Exception
    {
        public AgeOutOfRangeException(string message) : base(message) { }
    }

    class BankAccount
    {
        public decimal Balance { get; private set; }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new NegativeAmountException("Amount to deposit cannot be negative.");
            }
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                throw new NegativeAmountException("Amount to withdraw cannot be negative.");
            }
            if (Balance - amount < 0)
            {
                throw new InsufficientFundsException("Insufficient funds.");
            }
            Balance -= amount;
        }
    }

    class NegativeAmountException : Exception
    {
        public NegativeAmountException(string message) : base(message) { }
    }

    class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }
    }
}
