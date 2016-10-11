using System;
using Bangazon.Customers;
using Bangazon.Orders;
using Bangazon.Payments;

//using existing modules, including those preexisting (e.g., System) and those we have defined (Bangazon.Customers, Bangazon.Orders
// Bangazon.Payments)

namespace Bangazon
{
    public class Program //base class /entry points for other classes, green syntax indicates that this class is a property on Bangazon,
    //which is our namespace object 
    
    //red equals descriptors/methods
    {
        public static void Main(string[] args)
        {
            // Create a customer and grab first/last name from first argument. Not sure why it appears that we can just slap in a new
            //strict type with "Customer", seen here for the first time ... isn't this the entry point==maybe thinking about it incorrectly
            //it could just be the entry point for the dev who uses it, not the compiler's entry point? Yup, thinking about it the wrong way

            Customer firstCustomer = new Customer(); //instantiating new object from Customer class
            firstCustomer.firstName = args[0].Split(new Char[] { ' ' })[0]; //defining the characteristics specific to this new object (firstCustomer) 
            //and defined as empty properties that can be retrieved and gotten
            firstCustomer.lastName = args[0].Split(new Char[] { ' ' })[1];
            firstCustomer.greet(); //calling a method defined in Customer class


            // Create an order and add product from argument list
            Order firstOrder = new Order(); //instantiating new object from Order class
            for(int i = 1; i < args.Length - 1; i++)
            {
                firstOrder.addProduct(args[i]); //based on logic provided by the newly instatiated object, which is manipulating args passed in by main obj,
                //explicitly stating what we want the addProduct method defined in the Order class to do
            }

            Console.WriteLine(firstOrder.listProducts()); //using the result of manipulation on args passed in to Main to write to console

            // Create a payment
            Payment payment = null; //creating a new type/variable
            string mainEmailAddress = "steve@stevebrownlee.com"; //creating a new type/variable

            // Depending on the value of the last argument, assign
            // the payment variable to the correct derived class
            switch (args[args.Length - 1]) //looking at the last item in the arguments array passed in and determining which case to use
            {
                case "credit":
                    payment = new CreditCard(firstOrder)
                    {
                        bankName = "Amex",
                        accountNumber = "948587245092"
                    };
                    break;
                case "paypal":
                    payment = new Paypal(firstOrder)
                    {
                        email = mainEmailAddress,
                        password = "1234512345"
                    };
                    break;
                default:
                    break;
            }

            // Simplistic operation to calculate total order cost
            payment.amount = firstOrder.products.Count * 9.99;

            // Process the payment
            Console.WriteLine(payment.process());

            // Send confirmation email
            payment.confirm(mainEmailAddress);
        }
    }
}
