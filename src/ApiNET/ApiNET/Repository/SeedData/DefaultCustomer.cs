using ApiNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNET.Repository
{
    public class DefaultCustomer
    {
        public static List<Customer> All()
        {
            return new List<Customer>
            {
                Customer1,
                Customer2,
                Customer3
            };
        }

        public static readonly Customer Customer1 = new Customer
        {
            Id = 1,
            Name = "Yunus Emre",
            SurName = "Keskin",
            Age = 25,
            CustomerRank = CustomerRank.Gold,

            CreateUser = "SYSTEM",
            DateCreated = DateTime.Now,
            ModifyUser = "SYSTEM",
            DateModified = DateTime.Now
        };

        public static readonly Customer Customer2 = new Customer
        {
            Id = 2,
            Name = "Yusuf Eren",
            SurName = "Keskin",
            Age = 18,
            CustomerRank = CustomerRank.Bronze,

            CreateUser = "SYSTEM",
            DateCreated = DateTime.Now,
            ModifyUser = "SYSTEM",
            DateModified = DateTime.Now
        };

        public static readonly Customer Customer3 = new Customer
        {
            Id = 3,
            Name = "Ayşe Hacer",
            SurName = "Keskin",
            Age = 45,
            CustomerRank = CustomerRank.Diamond,

            CreateUser = "SYSTEM",
            DateCreated = DateTime.Now,
            ModifyUser = "SYSTEM",
            DateModified = DateTime.Now
        };
    }
}
