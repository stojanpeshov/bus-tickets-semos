using System;
using BusinessLogicLayer;
using DataAccessLayer.EntitiesDAL;

namespace TestApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetUsernameById(2));
        }
    }
}
