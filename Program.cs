using System;

namespace Delegates_in_C_
{
    internal class Program
    {
        static void Main(string[] args)
        {
       
           
            Action k = () =>
            {
                Outer:
                string? name;
                string? password;
                Console.Write("Enter the username");
                name=Console.ReadLine();
                Console.Write("Enter the password");
                password=Console.ReadLine();
                
 
                Func<string, string, Tuple<string, string>> pt = (string t1, string t2) => {
                    Tuple<string, string> t = Tuple.Create<string, string>(t1, t2);
                    return t;

                };
                if ((name!=null) && (password!=null))
                {
                    Console.WriteLine("Successfully Registered");
                    Inner:
                    Console.WriteLine("Login");
                    Tuple<string, string> th = pt(name, password);
                    Console.Write("Enter your username to Login");
                    string? name1 = Console.ReadLine();
                    Console.Write("Enter your password to Login");
                    string? password1 = Console.ReadLine();
                    Predicate<Tuple<string, string>> predicate = (Tuple<string, string> t3) =>
                    {
                        if (name1 == t3.Item1 && password1 == t3.Item2)
                        {
                            return true;
                        }
                        return false;

                    };
                    bool kt = predicate(th);
                    if (kt)
                    {
                        Console.WriteLine("You have successfully logged in");
                        Console.WriteLine("Continue operations");
                        ExampleDelegates();

                    }
                    else
                    {
                        Console.WriteLine("Login failed");
                       
                        goto Inner;
                    }
                }
                else
                {
                    Console.WriteLine("Register again");
                   
                    goto Outer;
                }
               

            };

            k();
           
            

            Console.ReadLine();
        }
        public delegate void ArithmeticOps(int x,int y);
         public static void ExampleDelegates()
        {
           Console.Write("Enter the first number: ");
           int x=Convert.ToInt32(Console.ReadLine());   
           Console.Write("Enter the second number: ");
           int y=Convert.ToInt32(Console.ReadLine());

            ArithmeticOps ps = new ArithmeticOps(Add);
            ps += Sub;
            ps += Mul;
            ps+= Div;
            ps(x, y);
           
        }
        public static void Add(int x,int y)
        {
            Console.WriteLine($"Addition of two numbers are {x+y}");
        }
        public static void Sub(int x ,int y)
        {
            if (x > y) Console.WriteLine($"Subtraction of x from y {x-y}");
            else Console.WriteLine($"Subtraction of y from x {y-x}");
        }
        public static void Mul(int x,int y)
        {
            Console.WriteLine($"Multiplication of x and y {x*y}");
        }
        public static void Div(int x,int y)
        {
            if (y!= 0)
            {
                Console.WriteLine($"Division from x by y {x/y}");

            }
            else
            {
                Console.WriteLine("Divide by 0 not possible");
            }
        }
    }
}