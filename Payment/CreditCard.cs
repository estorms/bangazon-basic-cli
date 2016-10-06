using Bangazon.Orders;

namespace Bangazon.Payments
{

  //syntax below, e.g., CreditCard: Payment simply establishes classinherentance, similar to = new () in prototypal inheritance, Here, we say that CreditCard 
  //is a derived class and Payment is the base

  public class CreditCard: Payment 
    public string bankName { get; set; }
    public string accountNumber { get; set; }

    //below we are calling on a private property on a public class (Order) so have to explicitly refer back to base because public data 
    //only carries over during inheritance--specifically private info must be "requested" from the base
    //also, CreditCard is a property on the CreditCard class
    public CreditCard(Order order): base(order) 
    
    
    {

    }
    //overriding the string process defined in Payment and then calling it back by using base.process
    public override string process() 
    {
      return $"You are using a {this.bankName} card, with the account number {this.accountNumber}\n{base.process()}";
      
    }
  }
}