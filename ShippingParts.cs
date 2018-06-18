
This is a simple refreshment exercise as a precursor to project four.

Locate the Supplier /Parts, SupPart.mdb, database file in the Blackboard
Open the file in Access
From the Tables Object
Examine the contents of the tables (double click on the table name)
Examine the relationships (click on the relationship icon)
From the Query Object
Open the Red Parts query (in Datasheet view)
Examine the Red Parts query in Design view
For the statement: “ Find the Supplier Name, Part Name and Quantity for all Green parts supplied in quantity less than 300”
Construct a query
Run the query
Find and examine the SQL statement for the query
Adjust the query to display only the Supplier and Part names
Save the query as “Green parts”


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shippment_Parts
{
    class ShippingParts<SPItem> : IEnumerable<SPItem>
    {
        public string SupplierName { get; set; }
        public int Status { get; set; }
        public string SupplierCity { get; set; }
        public string Color { get; set; }
        public int Weight { get; set; }
        public string PartsCity { get; set; }
        public int Quantity { get; set; }
        public ShippingParts<SPItem> SupplierNo { get; set; }
        public ShippingParts<SPItem> PartsNo { get; set; }
        public string PartsName { get; set; }


        public override string ToString()
        {
            return $"SNo: {this.SupplierNo}, SupplierName: {this.SupplierName}, Status: {this.Status}, SupplierCity: {this.SupplierCity}, PartsName: {this.PartsName}, Color: {this.Color}, Weight: {this.Weight}, PartsCity: {this.PartsCity}, PNo: {this.PartsNo}, Quantity: {this.Quantity}";
        }

        IEnumerator<SPItem> IEnumerable<SPItem>.GetEnumerator()
        {
            if (this.SupplierNo != null)
            {
                foreach (SPItem item in this.SupplierNo)
                {
                    yield return item;
                }
            }
            if (this.PartsNo != null)
            {
                foreach (SPItem item in this.PartsNo)
                {
                    yield return item;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
