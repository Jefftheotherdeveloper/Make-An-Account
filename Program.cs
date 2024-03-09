// See https://aka.ms/new-console-template for more information
using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using System.Net.Security;
using System.Threading.Channels;
using System.Text.Json;
using System.ComponentModel.DataAnnotations;
using System.Windows.Markup;
//using System.Runtime.CompilerServices;
//using System.Numerics;
//using System.Security.Cryptography.X509Certificates;

namespace myApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static string userName;
        static string password2;
        static Dictionary<string, string> accounts = readFile();
        //static Dictionary<string, string> accountBalances = readFile();

        static void writeToFile(Dictionary<string, string> accounts){
            File.WriteAllText("accounts.txt", JsonSerializer.Serialize(accounts));
        }
        // open the file and try to convert it to dictionary variable
        // Dictionary is a key value pair 
        static Dictionary<string, string> readFile(){
            Dictionary<string, string> accounts = new Dictionary<string, string>();
            try { 
                var fileInput = JsonSerializer.Deserialize<Dictionary<string, string>>(File.ReadAllText("accounts.txt"));
                if (fileInput != null){
                    accounts = fileInput;
                }
            }
            catch {
                // Heres were we might say we could not read the error or something but we dont need to do that
            }
            return accounts;
        }



//Pop up Page
        static void Main(string[] args)
        {

            Console.Title = "Make an Account juan was here";
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("-----------------------------------------------\n\n\n");
            int[] confirmNumber = {1, 2};

            Console.WriteLine("--- BANK OF COOPER ---");
            Console.WriteLine("Welcome to the Bank of Cooper where all your money can be trusted\n" +
            "so you can live a little more easier!\n");
            Console.WriteLine("If you don't have an account with us, please write \"1\" to make an\n" +
            "account or if you have an account just write \"2\" to log in.");
            string numchoice = Console.ReadLine();
            if(numchoice == Convert.ToString(confirmNumber[0]))
            {
                Signup();
            }
            if(numchoice == Convert.ToString(confirmNumber[1]))
            {
                Login();
            }
        }

//-------------------------------------------------------------------------------------------------------

//Sign Up System
        static void Signup()
        {
        string confirm = "";

        while(confirm != "yes")
        {
            Console.WriteLine("\n" + "Redircting...\n");
            Console.WriteLine("- Sign up Page -\n");
            Console.WriteLine("To sign up, we will need some basic infomation. So please just\n" +
            "follow the instructions below.\n");
            Console.Write("Please only enter your first name: ");
            string userRealfirstname = Console.ReadLine();
            Console.Write("Now enter your last name: ");
            string userReallastname = Console.ReadLine();
            Console.Write("Please enter a personal email we can reach you at: ");
            string userEmail = Console.ReadLine();
            Console.WriteLine("Now we are moving to the last important steps so please enter the rest of\n" +
            "infomation carefully now. Please don't use your real name as your username or a easy paassword! You are\n" +
            "allowed to change your these in the future but only after 30day(s) using our site.");

            Console.Write("Official username: ");
            userName = Console.ReadLine();
            
            if(userName == userRealfirstname)
            {
                Console.WriteLine("\n" + "For security reasons, please don't use your real name\n");
            }

            while(userName != userRealfirstname)
            {
            Console.Write("Official password: ");
            string password = Console.ReadLine();
            Console.Write("Please retype your password to confirm: ");
            password2 = Console.ReadLine();
                if(password == password2)
                {
                    Console.WriteLine("\nNow " + userRealfirstname + ", please check if everything seems correct. DO NOT RUSH THROUGH THIS PART!\n");
                    Console.WriteLine(" --- ");
                    Console.WriteLine("The email we can contact you is: " + userEmail);
                    Console.WriteLine("Your username is: " + userName);
                    Console.WriteLine("Your password is: " + password2);
                    Console.WriteLine(" ---\n ");
                    Console.WriteLine("If everything seems correct, type \"yes\" to confirm and read our terms of service.");
                    confirm = Console.ReadLine();
                    if(confirm == "yes")
                    {
                        Console.WriteLine("\n" + "- TERMS OF SERVICE -\n");
                        Console.WriteLine("In making a account with Bank of Cooper, you are fully understanding that we have your sensitive\n" +
                        "and priavte infomation. New users will have to pay a fee to delete their account if their account isn't 365 days (one year)\n" + 
                        "old. If you fully understand and would like to agree then, please type \"yes\" then.");
                        confirm = Console.ReadLine();
                        if(confirm == "yes")
                        {
                            Console.WriteLine("\n" + "Welcome " + userName + ", to the Bank of Cooper!\n");
                            // add to local dictionary 
                            accounts.Add(userName, password2);
                            
                
                            //save file
                            writeToFile(accounts);
                            // how to delete user
                            // accounts.Remove(userName);
                            // writeToFile(accounts);
                            Console.WriteLine("Redircting...\n");
                            Login();
                        }
                        else
                        {
                            Console.WriteLine("It's understandable, maybe let's try again some other time!");
                            break;
                        }
                    }                
                }
                if(password != password2)
                {
                    Console.WriteLine("\n" + "Passwords do not match. Please retype it.\n");
                }
            }
        }
        }

//-------------------------------------------------------------------------------------------------------

//Log in System
                static void Login() 
        {
            Console.WriteLine("- Login Page -\n");
            Console.Write("Username: ");
             string userNameInput = Console.ReadLine();
             // how to check for a user
            if(accounts.ContainsKey(userNameInput) == true)
            {
                Console.WriteLine("Enter password");
                string userPasswordInput = Console.ReadLine();
                // how to check specific user password
                if (accounts[userNameInput].Equals(userPasswordInput)){
                    Console.WriteLine("Welcome back\n");
                } else {
                    Console.WriteLine("Wrong password dummy\n");
                    Login();
                }
            } else {
                Console.WriteLine("User does not exist\n");
                Signup();
            }
            
        }
        
    }
}