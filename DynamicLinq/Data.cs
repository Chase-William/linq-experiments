using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLinq
{
    public static class Data
    {
        public static List<Customer> Get() => new List<Customer>()
		{
			new Customer() { CustomerID = 1, Name = "Terri	Lee	Duffy"},
			new Customer() { CustomerID = 2, Name = "Gail A Erickson"},
			new Customer() { CustomerID = 3, Name = "Gigi N Matthew"},
			new Customer() { CustomerID = 4, Name = "Michael Raheem"},
			new Customer() { CustomerID = 5, Name = "Janice Galvin"},
			new Customer() { CustomerID = 6, Name = "Michael Sullivan"},
			new Customer() { CustomerID = 7, Name = "David Bradley"},
			new Customer() { CustomerID = 8, Name = "David	Benshoof"},
			new Customer() { CustomerID = 9, Name = "Peter	Gilbert"},
			new Customer() { CustomerID = 10, Name = "Rebecca Bradley"},
		};
	}

	public class Customer
	{
		public int CustomerID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime LastLogin { get; set; }
		public Boolean IsActive { get; set; }
	}
}
