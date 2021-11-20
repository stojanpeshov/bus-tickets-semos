using System;
using BusinessLogicLayer;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            usersBLL testUser = new usersBLL();
            Console.WriteLine(testUser.GetUsernameById(2));
            Console.ReadLine();
        }
    }
}