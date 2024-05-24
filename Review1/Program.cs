using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Review1
{
    public class Node
    {
        public int data;
        public Node? Next;
        public Node(int val)
        {
            this.data = val;
        }
    }
    class Customer
    {
        public string? Name { get; set; }
        public int Price { get; set; }
    }
    class Customer1
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int OrdersId { get; set; }
    }
    class Orders
    {
        public int Id { get; set; }
        public string? ItemName { get; set; }
        public double Price { get; set; }
    }
    public class Program
    {
        public Node? First;
        public Node? Last;
        
        static void Main()
        {
            //2)Given a list of strings, use LINQ to find and remove duplicate elements, preserving the original order.
            List<string> list = ["chiru", "Dileep", "chiru", "gopi", "Dileep", "Badri"];
            var unique = from i in list group i by i into j select j.Key;
            var unique1 = list.Distinct().ToList();
            unique1.ForEach(x => Console.WriteLine(x));

            foreach(string i in  unique)
            {
                Console.WriteLine(i);
            }
            
            //Given a list of customer records, filter out customers who have
            //made purchases in the last month, and create a new list with their names
            //and total purchase amounts.
            GroupByNameWithPrice();
            //Join two collections of data, such as a list of customers and their orders,
            //to create a result set with combined information.
            InnerJoinCustomerWithOrders();
            //Implement a C# program that reads the contents of a text file and
            //displays them to the console. Handle cases where the file may not exist
            //and provide appropriate error messages.
            FileHandlingMethod1();
            //add and fetch data from dictionary
            DictionaryMethod();
            //write a calculator program using generic.
            GenericCalc();
            //Write a C# program that calculates the price of a movie ticket based on the age of the customer and the time of the movie.
            //Implement different pricing rules for children (under 12), adults (12-64), and seniors (65+), and consider matinee discounts.
            ProblemForTicket();
            //Design a simple login system in C# where users provide their username and password. Use conditional statements to check the credentials and
            //provide appropriate feedback, such as successful login, incorrect username, incorrect password, or account lock
            Login();
        }
        //find if a given number is prime number and perform Mstesting on it.
        public static bool Prime(int number)
        {
            if(number <= 1) return false;
            for(int i = 2;i<=number/2;i++)
            {
                if(number%i==0) return false;
            }
            return true;
        }
        private static void FileHandlingMethod1()
        {
            string Path = @"C:\Users\pagad\source\repos\Review1\Review1\textFile.txt";
            if (File.Exists(Path))
            {
                string lines = File.ReadAllText(Path);
                Console.WriteLine(lines);
            }
            else
            {
                Console.WriteLine("File not existed.");
            }
        }

        private static void InnerJoinCustomerWithOrders()
        {
            List<Orders> items =
            [
                new Orders() {Id=1,ItemName="briyani",Price=120},
                new Orders() {Id=2,ItemName="veg meals",Price=100},
                new Orders() {Id = 3, ItemName = "fired rice", Price = 120}
            ];
            List<Customer1> customer1 =
            [
                new Customer1() {Id=1,Name="chiru",OrdersId=2},
                new Customer1() {Id=2,Name="Dileep",OrdersId=1},
                new Customer1() {Id=3,Name="badri",OrdersId=3},
                new Customer1() {Id=2,Name="Dileep",OrdersId=2}
            ];
            var combine = from i in customer1
                          join j in items on i.OrdersId equals j.Id
                          select new
                          {
                              Name1 = i.Name,
                              ItemName1 = j.ItemName,
                              Price1 = j.Price
                          };
            foreach (var i in combine)
            {
                Console.WriteLine($"Name of customer {i.Name1},Order item {i.ItemName1}" +
                    $"price is {i.Price1}");
            }
        }

        private static void GroupByNameWithPrice()
        {
            List<Customer> list =
            [
                new Customer() { Name="Chiru",Price=50},
                new Customer() { Name="Dileep",Price=45},
                new Customer() { Name="Chiru",Price=30},
                new Customer() { Name="Dileep",Price=75},
                new Customer() { Name="Badri",Price=60},
            ];
            var total = list.GroupBy(x => x.Name).Select(
            y => new
            {
                NameCustomer = y.Key,
                totalprice = y.Select(y => y.Price).Sum()
            });
            var linq = from i in list
                       group i by i.Name into j
                       select new
                       {
                           j.Key,
                           total = from k in j select k.Price
                       };
            foreach (var j in total)
            {
                Console.WriteLine($"customer name is {j.NameCustomer} and total price {j.totalprice}");
            }
        }

        private static void DictionaryMethod()
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic.Add(1, "Sunday");
            dic.Add(2, "Monday");
            dic.Add(3, "Tuesday");
            dic.Add(4, "Wednesday");
            foreach (KeyValuePair<int, string> item in dic)
            {
                Console.WriteLine("key {0} and value is {1}", item.Key, item.Value);
            }
        }

        private static void GenericCalc()
        {
            Calc<long> calc = new LongData();
            Console.WriteLine(calc.Add(5, 6));
            Calc<double> calc1 = new DoubleData();
            Console.WriteLine(calc1.Multiply(4.6, 5.8));
        }

        //3) write the insertfront and insertlast methods in linkedlist
        public void InsertFront(int data)
        {
            if(First == null)
            {
                First = Last = new Node(data);
                return;
            }
            Node curr = First;
            First = new Node(data);
            First.Next = curr;
            Last = curr;
        }
        public void InsertLast(int data)
        {
            if(Last == null)
            {
                First=Last = new Node(data);
            }
            Last.Next = new Node(data);
            Last = Last.Next;
        }
        private static void ProblemForTicket()
        {
            try
            {
                //int price = 0;
                int age = Convert.ToInt32(Console.ReadLine());
                if (age <= 0)
                {
                    throw new NegativeValueException();
                }
                else if (age < 12)
                {
                    Console.WriteLine("ticket for children");
                }
                else if (age >= 12 && age <= 64)
                {
                    Console.WriteLine("ticket for adults");
                }
                else
                {
                    Console.WriteLine("ticket for seniors");
                }
            }
            catch (NegativeValueException)
            {
                Console.WriteLine("Invalid age please try again");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void Login()
        {
            string username = "chirudeep";
            string password = "password";
            Console.WriteLine("enter the username");
            string? check_username = Console.ReadLine();
            Console.WriteLine("enter the password");
            string? check_password = Console.ReadLine();
            if (username.Equals(check_username) && password.Equals(check_password))
            {
                Console.WriteLine("successful login");
            }
            else if (username.Equals(check_username))
            {
                Console.WriteLine("incorrect password");
            }
            else if (password.Equals(check_password))
            {
                Console.WriteLine("incorrect username");
            }
            else
            {
                Console.WriteLine("account lock");
            }
        }
    }
    public class NegativeValueException : Exception 
    {
        public NegativeValueException()
        {
            Console.WriteLine("age is not in negative.");
        }
    }
}
