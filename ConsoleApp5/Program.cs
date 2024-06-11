using System;
using System.Collections.Generic;

public class CEO
{
    public Guid GUID { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }

    public void Control()
    {
        Console.WriteLine($"{Name} is controlling the company.");
    }

    public void Organize()
    {
        Console.WriteLine($"{Name} is organizing the company.");
    }

    public void MakeMeeting()
    {
        Console.WriteLine($"{Name} is making a meeting.");
    }

    public void DecreasePercentage(decimal percent)
    {
        Salary -= Salary * percent / 100;
    }
}

public class Worker
{
    public Guid GUID { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public List<Operation> Operations { get; set; } = new List<Operation>();

    public void AddOperation(Operation operation)
    {
        Operations.Add(operation);
    }
}

public class Manager
{
    public Guid GUID { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }

    public void Organize()
    {
        Console.WriteLine($"{Name} is organizing the team.");
    }

    public decimal CalculateSalaries(List<Worker> workers)
    {
        decimal totalSalaries = 0;
        foreach (var worker in workers)
        {
            totalSalaries += worker.Salary;
        }
        return totalSalaries;
    }
}

public class Operation
{
    public Guid GUID { get; set; } = Guid.NewGuid();
    public string ProcessName { get; set; }
    public DateTime Datetime { get; set; }
}

public class Credit
{
    public Guid GUID { get; set; } = Guid.NewGuid();
    public Client Client { get; set; }
    public decimal Amount { get; set; }
    public decimal Percent { get; set; }
    public int Months { get; set; }

    public decimal CalculatePercent()
    {
        return Amount * Percent / 100 * Months;
    }

    public decimal Payment()
    {
        return Amount + CalculatePercent();
    }
}

public class Client
{
    public Guid GUID { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string LiveAddress { get; set; }
    public string WorkAddress { get; set; }
    public decimal Salary { get; set; }
}

public class Bank
{
    public string Name { get; set; }
    public decimal Budget { get; set; }
    public decimal Profit { get; set; }
    public CEO Ceo { get; set; }
    public List<Worker> Workers { get; set; } = new List<Worker>();
    public List<Manager> Managers { get; set; } = new List<Manager>();
    public List<Client> Clients { get; set; } = new List<Client>();

    public decimal CalculateProfit()
    {
        return Profit;
    }

    public Credit ShowClientCredit(string fullName)
    {
        foreach (var client in Clients)
        {
            if (client.Name + " " + client.Surname == fullName)
            {
                return new Credit { Client = client };
            }
        }
        return null;
    }

    public void PayCredit(Client client, decimal money)
    {
        Console.WriteLine($"{client.Name} {client.Surname} paid {money}.");
    }

    public void ShowAllCredit()
    {
        foreach (var client in Clients)
        {
            var credit = ShowClientCredit(client.Name + " " + client.Surname);
            if (credit != null)
            {
                Console.WriteLine($"{client.Name} {client.Surname} has a credit of {credit.Amount} with interest {credit.Percent}% for {credit.Months} months.");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        CEO ceo = new CEO
        {
            Name = "Nezrin",
            Surname = "Hesenli",
            Age = 50,
            Position = "CEO",
            Salary = 150000
        };

        Manager manager1 = new Manager
        {
            Name = "Ulvi",
            Surname = "Besirov",
            Age = 45,
            Position = "Manager",
            Salary = 80000
        };

        Manager manager2 = new Manager
        {
            Name = "Arzu",
            Surname = "Eliyeva",
            Age = 40,
            Position = "Manager",
            Salary = 85000
        };

        Worker worker1 = new Worker
        {
            Name = "Anar",
            Surname = "Abbasov",
            Age = 30,
            Position = "Worker",
            Salary = 50000,
            StartTime = new TimeSpan(9, 0, 0),
            EndTime = new TimeSpan(17, 0, 0)
        };

        Worker worker2 = new Worker
        {
            Name = "Akif",
            Surname = "Abdullayev",
            Age = 28,
            Position = "Worker",
            Salary = 52000,
            StartTime = new TimeSpan(9, 0, 0),
            EndTime = new TimeSpan(17, 0, 0)
        };

        Client client1 = new Client
        {
            Name = "Samir",
            Surname = "Aslanov",
            Age = 35,
            LiveAddress = "123",
            WorkAddress = "456",
            Salary = 60000
        };

        Client client2 = new Client
        {
            Name = "Aysel",
            Surname = "Muradli",
            Age = 32,
            LiveAddress = "789",
            WorkAddress = "101",
            Salary = 65000
        };

        Credit credit1 = new Credit
        {
            Client = client1,
            Amount = 10000,
            Percent = 5,
            Months = 12
        };

        Credit credit2 = new Credit
        {
            Client = client2,
            Amount = 20000,
            Percent = 4,
            Months = 24
        };

        Bank bank = new Bank
        {
            Name = "Global Bank",
            Budget = 1000000,
            Profit = 200000,
            Ceo = ceo
        };

        bank.Managers.Add(manager1);
        bank.Managers.Add(manager2);
        bank.Workers.Add(worker1);
        bank.Workers.Add(worker2);
        bank.Clients.Add(client1);
        bank.Clients.Add(client2);


        bank.PayCredit(client1, 5000);
        ceo.MakeMeeting();
        manager1.Organize();

        Operation operation1 = new Operation
        {
            ProcessName = "Data Entry",
            Datetime = DateTime.Now
        };

        worker1.AddOperation(operation1);

        Console.WriteLine($"{worker1.Name} has the following operations:");
        foreach (var op in worker1.Operations)
        {
            Console.WriteLine($"- {op.ProcessName} at {op.Datetime}");
        }
    }
}

