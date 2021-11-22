using System;
using BusinessLogicLayer;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            UsersBLL testUser = new UsersBLL();
            Console.WriteLine(testUser.GetUsernameById(2));
            Console.ReadLine();
        }
    }
}