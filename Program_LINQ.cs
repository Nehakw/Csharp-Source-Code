Project 4: Using LINQ in a  C# Console Application


This project is about using LINQ extension methods and query operators as discussed in chapter 21 of your textbook. In this assignment, we need information in the three tables of S, P, and SP that you find in SupPart.mdb in Blackboard (also shown below). You will not use these tables or the database directly, but you must manually prepare an exact copy of those tables in the arrays of your program similar to chapter 21. As required by LINQ, your data must be stored in a data structure that implements the IEnumerable<T> interface, as described in Chapter 19, “Enumerable Collections”. We keep it simple by using suppliers, parts, and shipment arrays for holding information in S, P, and SP tables, respectively. In a real-world application, you would populate these arrays by reading the data from a database. Here is a partial filling of suppliers, parts, and shipment arrays:
var suppliers = new[] {
                new {SN = 1, SName = "Smith", Status = 20, City = "London"},
                new {SN = 2, SName = "Jones", Status = 10, City = "Paris" },
                new {SN = 3, SName = "Blake", Status = 30, City = "Paris" }
            };
var parts = new[] {
             new {PN = 1, PName = "Nut", Color = "Red", Weight = 12, City = "London"},
            new {PN = 2, PName = "Bolt", Color = "Green", Weight = 17, City = "Paris"},
            new {PN = 3, PName = "Screw", Color = "Blue", Weight = 17, City = "Rome"}
            };

var shipment = new[] {
                new {SN = 1, PN = 1, Qty = 300},
                new {SN = 1, PN = 2, Qty = 200},
                new {SN = 1, PN = 3, Qty = 400},
                new {SN = 1, PN = 4, Qty = 200},
                new {SN = 1, PN = 5, Qty =100},
                new {SN = 1, PN = 6, Qty = 100},
                new {SN = 2, PN = 1, Qty = 300},
                new {SN = 2, PN = 2, Qty = 400},
                new {SN = 3, PN = 2, Qty =200}
            };


The Supplier/Parts problem is a typical database problem. The problem statement goes like this. The ABC Manufacturing Company wants to keep track of outstanding shipments of the many parts that they order from their various parts suppliers. A shipment consists of a quantity of a part that has been ordered from a supplier. 
Each part has a unique part# and is ordered from one of several suppliers located in various cities. There might be several shipments for each type of part.
Each supplier has a name and a supplier# and a rating or status code. There might be several outstanding shipments for a particular part from different suppliers; however, new shipments for a part are never requested from a supplier if there is an outstanding shipment for that part from that supplier. A supplier can supply many different parts and several suppliers can supply a part.
Some of the information that is needed for parts is the color, name, weight of a part and city where the part is located.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shippment_Parts
{
    class Program
    {
        static void Main(string[] args)
        {
            char contNext = 'y';
            while (contNext == 'y')
            {
                try
                {
                    string operationSelection;
                   
                        var suppliers = new[]
                    {
                new { SupplierNo = 1, SupplierName = "Smith", Status = 20, SupplierCity = "London"},
                new { SupplierNo = 2, SupplierName = "Jones", Status = 10, SupplierCity = "Paris"},
                new { SupplierNo = 3, SupplierName = "Blake", Status = 30, SupplierCity = "Paris"},
                new { SupplierNo = 4, SupplierName = "Clark", Status = 20, SupplierCity = "London"},
                new { SupplierNo = 5, SupplierName = "Adams", Status = 30, SupplierCity = "Athens"}
                    };

                        var parts = new[]
                    {
                new { PartsNo = 1, PartsName = "Nut", Color = "Red", Weight = 12, PartsCity = "London"},
                new { PartsNo = 2, PartsName = "Bolt", Color = "Green", Weight = 17, PartsCity = "Paris"},
                new { PartsNo = 3, PartsName = "Screw", Color = "Blue", Weight = 17, PartsCity = "Rome"},
                new { PartsNo = 4, PartsName = "Screw", Color = "Red", Weight = 14, PartsCity = "London"},
                new { PartsNo = 5, PartsName = "Cam", Color = "Blue", Weight = 12, PartsCity = "Paris"},
                new { PartsNo = 6, PartsName = "Cog", Color = "Red", Weight = 19, PartsCity = "London"}
                    };

                        var shipment = new[]
                    {
                new { SupplierNo = 1, PartsNo = 1, Quantity = 300},
                new { SupplierNo = 1, PartsNo = 2, Quantity = 200},
                new { SupplierNo = 1, PartsNo = 3, Quantity = 400},
                new { SupplierNo = 1, PartsNo = 4, Quantity = 200},
                new { SupplierNo = 1, PartsNo = 5, Quantity = 100},
                new { SupplierNo = 1, PartsNo = 6, Quantity = 100},
                new { SupplierNo = 2, PartsNo = 1, Quantity = 300},
                new { SupplierNo = 2, PartsNo = 2, Quantity = 400},
                new { SupplierNo = 3, PartsNo = 2, Quantity = 200},
                new { SupplierNo = 4, PartsNo = 2, Quantity = 200},
                new { SupplierNo = 4, PartsNo = 4, Quantity = 300},
                new { SupplierNo = 4, PartsNo = 5, Quantity = 400},
                    };

                    Console.WriteLine("\n Select items to View: Supplier, Parts, Shipment");
                    operationSelection = Console.ReadLine();

                    if (operationSelection == "Supplier")
                    {
                        Console.WriteLine("All Suppliers");
                        var allSuppliers = from s in suppliers
                                           select s;

                        foreach (var sup in allSuppliers)
                        {
                            Console.WriteLine(sup);
                        }
                    }

                    else if (operationSelection == "Parts")
                    {
                        Console.WriteLine("All Parts");
                        var allParts = from p in parts
                                       select p;

                        foreach (var par in allParts)
                        {
                            Console.WriteLine(par);
                        }
                    }

                    else if (operationSelection == "Shipment")
                    {
                        Console.WriteLine("All Suppliers and Parts");
                        var allSuppliersParts = from sp in shipment
                                                select sp;

                        foreach (var supart in allSuppliersParts)
                        {
                            Console.WriteLine(supart);
                        }
                    }

                    Console.WriteLine("\n Select cities according to color: Red, Green, Blue");
                    operationSelection = Console.ReadLine();

                    if (operationSelection == "Red")
                    {
                        Console.WriteLine("\n Cities belonging to the Red color");
                        IEnumerable<string> redCity = (parts.Where(rc => String.Equals(rc.Color, "Red"))
                            .Select(rci => rci.PartsCity)).Distinct();
                        
                        foreach (string rcolor in redCity)
                        {
                            Console.WriteLine(rcolor);
                        }
                    }

                    else if (operationSelection == "Green")
                    {
                        Console.WriteLine("\n Cities belonging to the Green color");
                        IEnumerable<string> greenCity = (parts.Where(gc => String.Equals(gc.Color, "Green"))
                            .Select(gci => gci.PartsCity)).Distinct();
                       
                        foreach (string gcolor in greenCity)
                        {
                            Console.WriteLine(gcolor);
                        }
                    }

                    else if (operationSelection == "Blue")
                    {
                        Console.WriteLine("\n Cities belonging to the Blue color");
                        IEnumerable<string> blueCity = (parts.Where(bc => String.Equals(bc.Color, "Blue"))
                            .Select(gci => gci.PartsCity)).Distinct();

                        foreach (string bcolor in blueCity)
                        {
                            Console.WriteLine(bcolor);
                        }
                    }
                        Console.WriteLine("\n Supplier Name in Ascending Order:");
                        IEnumerable<string> supplierName = suppliers.OrderBy(sname => sname.SupplierName).Select(sup => sup.SupplierName);

                        foreach (string name in supplierName)
                        {
                            Console.WriteLine(name);
                        }

                    Console.WriteLine("\n Select Supplier Number: 1, 2, 3, 4, 5:");
                    operationSelection = Console.ReadLine();

                        if (operationSelection == 1.ToString())
                        {

                            Console.WriteLine("\n Parts provided by supplier number 1:");
                        var oneNoSuppliers = from pone in parts
                                                join sone in shipment
                                                on pone.PartsNo equals sone.PartsNo
                                                where int.Equals(sone.SupplierNo, 1)
                                                select new { pone.PartsName, sone.Quantity };

                        foreach (var smp in oneNoSuppliers)
                          {
                            Console.WriteLine(smp);
                          }
                        }

                        else if (operationSelection == 2.ToString())
                        {

                            Console.WriteLine("\n Parts provided by supplier number 2:");
                            var twoNoSuppliers = from ptwo in parts
                                                 join stwo in shipment
                                                 on ptwo.PartsNo equals stwo.PartsNo
                                                 where int.Equals(stwo.SupplierNo, 2)
                                                 select new { ptwo.PartsName, stwo.Quantity };

                        foreach (var sjp in twoNoSuppliers)
                            {
                                Console.WriteLine(sjp);
                            }
                        }

                        else if (operationSelection == 3.ToString())
                        {

                            Console.WriteLine("\n Parts provided by supplier number 3:");
                            var threeNoSuppliers = from pthr in parts
                                                 join sthr in shipment
                                                 on pthr.PartsNo equals sthr.PartsNo
                                                 where int.Equals(sthr.SupplierNo, 3)
                                                 select new { pthr.PartsName, sthr.Quantity };

                        foreach (var sbp in threeNoSuppliers)
                            {
                                Console.WriteLine(sbp);
                            }
                        }

                        else if (operationSelection == 4.ToString())
                        {

                            Console.WriteLine("\n Parts provided by supplier number 4:");
                            var fourNoSuppliers = from pfor in parts
                                                   join sfor in shipment
                                                   on pfor.PartsNo equals sfor.PartsNo
                                                   where int.Equals(sfor.SupplierNo, 4)
                                                   select new { pfor.PartsName, sfor.Quantity };

                        foreach (var scp in fourNoSuppliers)
                            {
                                Console.WriteLine(scp);
                            }
                        }

                    else if (operationSelection == 5.ToString())
                    {

                        Console.WriteLine("\n There are no parts exists for Supplier No 5");
                    }
                }
                catch(FormatException fEx)
                {
                    Console.WriteLine(fEx.Message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("\n Do you want to continue? (y/n)");
                contNext = Convert.ToChar(Console.ReadLine());
            }
        }
    }
}
