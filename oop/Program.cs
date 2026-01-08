
#region  __MAIN__

// Testing abstract
Console.WriteLine("\n* Testing abstract");
Animal minino = new Cat();
minino.Speak();

// Testing virtual methods
Console.WriteLine("\n* Testing virtual methods");
Figure2D circle = new Circle { Radious = 5.0 };
Console.WriteLine($"Circle area: {circle.Area()}");

Figure2D rectangle = new Rectangle { Width = 4.0, Height = 6.0 };
Console.WriteLine($"Rectangle area: {rectangle.Area()}");

// Testing Generics
Console.WriteLine("\n* Testing Generics");
Printer<int> intPrinter = new Printer<int>(42);
intPrinter.Print();

Printer<string> stringPrinter = new Printer<string>("Hello, Generics!");
stringPrinter.Print();

// Testing OOP - Inherit, Polymorphism, Encapsulation
Console.WriteLine("\n* Testing OOP - Inherit, Polymorphism, Encapsulation");
List<PaymentType> payments = new List<PaymentType>
{
    new CreditCard("Alice", 100.0f, "1234-5678-9012-3456"),
    new PayPal("Bob", 50.0f,"bob@bobby.com")
};

BankProcess.ProcessAllPayments(payments);


#endregion




#region Abstract classes

public abstract class Animal
{
    public abstract void Speak();
}

public class Cat : Animal
{
    public override void Speak()
    {
        Console.WriteLine("Cat meowing...");
    }
}

#endregion


#region Virtual methods

public class Figure2D
{
    public virtual double Area()
    {
        // default implementation
        return 0.0;
    }
}

public class Circle : Figure2D
{
    public double Radious { get; set; } = 0.0;

    public override double Area()
    {
        return Math.PI * Radious * Radious;
    }
}

public class Rectangle : Figure2D
{
    public double Width { get; set; } = 0.0;
    public double Height { get; set; } = 0.0;

    public override double Area()
    {
        return Width * Height;
    }
}


#endregion


#region Generic Classes

public class  Printer<T>
{
    public T Value { get; set; }

    public Printer(T value)
    {
        Value = value;
    }

    public void Print()
    {
        Console.WriteLine($"Value: {Value}");
    }
    
}

#endregion


#region OOP - Inherit, Polymorphism, Encapsulation, SOLID principles

public abstract class PaymentType
{
    public string clientName { get; set; }
    public float amount { get; set; }

    public PaymentType(string _clientName, float _amount)
    {
        amount = _amount;
        clientName = _clientName;
    }

    public abstract void ProcessPaymeny();
}

public class CreditCard : PaymentType
{
    private string cardNumber { get; set; }

    public CreditCard(string _clientName, float _amount, string _cardNumber) : base(_clientName, _amount)
    {
        cardNumber = _cardNumber;
    }

    public override void ProcessPaymeny()
    {
        // Specific implementation for credit card payment
        Console.WriteLine($"\tProcessing credit card payment of {amount} for {clientName} with card number {cardNumber}");
    }
}

public class PayPal : PaymentType
{
    private string email { get; set; }
    public PayPal(string _clientName, float _amount, string _email) : base(_clientName, _amount)
    {
        email = _email;
    }

    public override void ProcessPaymeny()
    {
        // Specific implementation for PayPal payment
        Console.WriteLine($"\tProcessing PayPal payment of {amount} for {clientName} to {email}");
    }
}

public static class BankProcess{

    public static void ProcessAllPayments(IEnumerable<PaymentType> _payments)
    {
        Console.WriteLine("Processing all payments...");
        foreach (var payment in _payments)
        {
            payment.ProcessPaymeny();
        }
        Console.WriteLine("All payments processed successfully.");
    }
}

#endregion