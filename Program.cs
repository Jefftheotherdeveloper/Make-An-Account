// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Net.Security;
using System.Threading.Channels;
//using System.Runtime.CompilerServices;
//using System.Numerics;
//using System.Security.Cryptography.X509Certificates;

namespace myApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Title = "FirstRun";
            Console.ForegroundColor = ConsoleColor.White;
            Console.WindowHeight = 50;


            Console.WriteLine("----------------------------------------------\n\n\n");

            Random rnd = new Random();
            int num = rnd.Next(1,6);
            string [] randomUSERnames = {"Juan", "Manny", "Daniel", "Pablo", "Andy"};
            string yes = "yes";
            string confirm = "";
            string help = "help";

            Console.WriteLine("--- BANK OF COOPER ---");
            Console.WriteLine("Welcome to the Bnk of Jeff where all your money can be trustet\n" +
            "so you can live a little more easier. We thank you for joining with us!\n");

            while(confirm != yes)
            {
            //Username and Email system
            Console.WriteLine("To enter the main site and use all our features, you need to create\n" +
            "an account. Please enter all the infomation required.\n");

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Now " + firstName + ", just a few more steps\n");
            Console.Write("Email: ");
            string userEmail = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Username: ");
            string userName = Console.ReadLine();

            //Password system
            Console.Write("Password: ");
            string password = Console.ReadLine();

            if(password == password)
            {
                Console.Write("Retype to confirm password:");
                string password2 = Console.ReadLine();
                if(password == password2)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Now please just make all the information you have put\n" +
                    "in is correct. DO NOT SKIP THIS PART!\n");
                    Console.WriteLine(" ---");
                    Console.WriteLine("The email we can contact you is: " + userEmail);
                    Console.WriteLine("Your username is " + userName);
                    Console.WriteLine("Your offcial password is: " + password2);
                    Console.WriteLine(" ---\n");
                    Console.WriteLine("If everything is correct just type \"yes or y\" to comfirm and read the\n" +
                    "term of services!");
                    confirm = Console.ReadLine();
                    if(confirm == yes)
                    {
                        Console.WriteLine("- TERMS OF SERVICE -");
                        Console.WriteLine("In making an account with Bank of Cooper, you are agreeing to our terms of\n" +
                        "service of knowing that we will have sensitive connected you which we will keep safe at all times\n");
                        Console.WriteLine("Type \"yes\" to officially confirm now");
                        confirm = Console.ReadLine();
                        if(confirm == yes)
                        {
                        Console.WriteLine("Welcome " + firstName + ", you are now part of our family now!\n");
                        break;
                        }
                    }
                }
            }

            }//end of while loop
            Console.ReadKey();
        }
    }
}