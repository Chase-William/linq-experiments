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
			new Customer() { CustomerID = 1, Name = "Terri Lee Duffy", IsActive = true, Description="Group 1"},
			new Customer() { CustomerID = 2, Name = "Gail A Erickson", Description="Group 1"},
			new Customer() { CustomerID = 3, Name = "Gigi N Matthew", IsActive = true, Description="Group 1"},
			new Customer() { CustomerID = 4, Name = "Michael Raheem", Description="Group 1"},
			new Customer() { CustomerID = 5, Name = "Janice Galvin", Description="Group 2"},
			new Customer() { CustomerID = 6, Name = "Michael Sullivan", IsActive = true, Description="Group 2"},
			new Customer() { CustomerID = 7, Name = "David Bradley", Description="Group 2"},
			new Customer() { CustomerID = 8, Name = "David Benshoof", Description="Group 2"},
			new Customer() { CustomerID = 9, Name = "Peter Gilbert", IsActive = true, Description="Group 3"},
			new Customer() { CustomerID = 10, Name = "Rebecca Bradley", Description="Group 3"},
		};
	}

	public class Customer
	{
		public int CustomerID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime LastLogin { get; set; }
		public Boolean IsActive { get; set; }

        public override string ToString()
        {
			return Name;
        }
    }
}
