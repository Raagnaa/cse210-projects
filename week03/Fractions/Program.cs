using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction(); // 1/1
        Fraction f2 = new Fraction(6); // 6/1
        Fraction f3 = new Fraction(3, 4); // 3/4
        Fraction f4 = new Fraction(1, 3);

        Console.WriteLine(f1.GetFractionString() + " = " + f1.GetDecimalValue());
        Console.WriteLine(f2.GetFractionString() + " = " + f2.GetDecimalValue());
        Console.WriteLine(f3.GetFractionString() + " = " + f3.GetDecimalValue());
        Console.WriteLine(f4.GetFractionString() + " = " + f4.GetDecimalValue());
    }
}
