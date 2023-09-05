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
    }
}