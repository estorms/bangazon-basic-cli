using System;

namespace Bangazon.Customers
{
  public class Customer //hover over, look at the links, essentially setting properties/methods on larger props/methods
  {
    public string firstName { get; set; }

    //string = explicit typing// similar to var, we'll see this with objects, methods, etc ... other places where you could declare var 
    //but instead choose to be explication
    public string lastName { get; set; } 

    //built in "descriptors (aka mini-methods) that allow retrieval, definition of data

    public void greet() 
    {
      Console.WriteLine($"Welcome {this.firstName} {this.lastName}!");
    }
  }
}