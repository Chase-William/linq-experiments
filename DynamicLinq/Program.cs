﻿using System.Linq;
using System.Collections.Generic;
using System;
using System.Reflection;

namespace DynamicLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            // Normal static collection
            var customers = Data.Get()
                .Where(x => x.IsActive)
=======
            // Normal like query collection
            Data.Get()
                .Where(x => x.IsActive == true)
>>>>>>> 83be007c7a63066da15c59165b1682c3f9c5225b
                .OrderBy(x => x.Name)
                .Select(x => new { x.Name }); // using infered prop Name from x for new type

            // Kinda of useless dynamic linq query as a thought experiment
            {
                var whereBy = WhereByOptions.NameContains; // option for first query
                var orderBy = OrderByOptions.NameAscending;
                var propOfInterest = PropertyOfInterest.Id;

                var rawList = Data.Get();

                // Stage #1 -- Where Query
                IEnumerable<Customer> queriedData = 
                    whereBy == WhereByOptions.NameContains ? rawList.Where(x => x.Name.Contains("G")) : rawList.Where(x => x.IsActive);

                foreach (var customer in queriedData)                
                    Console.WriteLine(customer);                

                // Stage #2 -- OrderBy Query
                //queriedData = new Lazy<IEnumerable<Customer>>(() => // Essentially an IIFE
                //{
                //    return orderBy switch // C# 8.0 switch https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8
                //    {
                //        OrderByOptions.NameAscending => queriedData.OrderBy(x => x.Name),
                //        OrderByOptions.NameDescending => queriedData.OrderByDescending(x => x.Name),
                //        OrderByOptions.LoginDateAscending => queriedData.OrderBy(x => x.LastLogin),
                //        OrderByOptions.LoginDateDescending => queriedData.OrderByDescending(x => x.LastLogin),
                //        _ => throw new Exception("DECKER GO BOOM"),
                //    };
                //}).Value;

                //queriedData = new Lazy<IEnumerable<Customer>>(Example).Value;
                queriedData = Example();

                IEnumerable<Customer> Example()
                {
                    return orderBy switch // C# 8.0 switch https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8
                    {
                        OrderByOptions.NameAscending => queriedData.OrderBy(x => x.Name),
                        OrderByOptions.NameDescending => queriedData.OrderByDescending(x => x.Name),
                        OrderByOptions.LoginDateAscending => queriedData.OrderBy(x => x.LastLogin),
                        OrderByOptions.LoginDateDescending => queriedData.OrderByDescending(x => x.LastLogin),
                        _ => throw new Exception("DECKER GO BOOM"),
                    };
                }

                foreach (var customer in queriedData)                
                    Console.WriteLine(customer);                

                // Stage #3 -- Select Props
                var result = new Lazy<IEnumerable<object>>(() =>
                {
                    return propOfInterest switch
                    {
                        PropertyOfInterest.Name => queriedData.Select(x => new { x.Name }),
                        PropertyOfInterest.LoginDateAndName => queriedData.Select(x => new { x.LastLogin, x.Name }),
                        PropertyOfInterest.Description => queriedData.Select(x => new { x.Name }),
                        PropertyOfInterest.Id => queriedData.Select(x => new { x.Name, x.CustomerID }),
                        _ => throw new Exception("DECKER GO BOOM v2")
                    };
                }).Value;

                foreach (var customer in result)                
                    Console.WriteLine(customer);                

                // Get an element from results
                var obj = result.FirstOrDefault();
                
                if (obj == null) // Check collection not empty
                {
                    Console.WriteLine("Query returned empty collection...");
                    return;
                }

                // Print out each property using reflection to get them dynamically like a list (reminds me of JS)
                foreach (var prop in obj.GetType().GetRuntimeProperties()) {
                    Console.WriteLine($"Has Name: {prop.Name} with value of: {prop.GetValue(obj)}");
                }
            }
        }
    }

    enum WhereByOptions
    {
        NameContains,
        IsActive
    }

    enum OrderByOptions
    {
        NameAscending,
        NameDescending,
        LoginDateAscending,
        LoginDateDescending
    }

    enum PropertyOfInterest
    {
        Name,
        LoginDateAndName,
        Description,
        Id
    }
}
