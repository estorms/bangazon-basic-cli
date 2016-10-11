using Xunit;
using Bangazon.Orders;
using System;
using System.Collections.Generic;

namespace Bangazon.Tests
{

    public class OrderTests
    {
        //name tests verbosely
        [Fact]
        //Fact is an assertion of truth
        public void TestTheTestingFramework()
        {
            Assert.True(true);
        }

        [Fact]

        public void OrdersCanExist()
        {
            Order ord = new Order();
            Assert.NotNull(ord);
        }


        [Fact]

        public void NewOrdersHaveAGuid()
        {
            Order ord = new Order();
            Assert.NotNull(ord.orderNumber);
            Assert.IsType<Guid>(ord.orderNumber);
        }

        [Fact]

        public void NewOrderShouldHaveAnEmptyProductList()
        {
            Order ord = new Order();
            Assert.NotNull(ord.products);
            Assert.IsType<List<string>>(ord.products);
        }

        [Theory]
        [InlineDataAttribute("banana")]
        [InlineDataAttribute("342236")]
        [InlineDataAttribute("A product with spaces")]
        [InlineDataAttribute("Product, that has a, comma?")]
        public void OrdersCanHaveProductsAddedToThem(string product)
        {
            Order ord = new Order();
            ord.addProduct(product);
            Assert.Equal(1, ord.products.Count);
            //string product that we pass in makes it into the products list on ord
            Assert.Contains<string>(product, ord.products);
        }

        [Theory]
        [InlineDataAttribute("Product")]
        [InlineDataAttribute("product,another product")]
        [InlineDataAttribute("a first product,a second product,yetanother")]
        [InlineDataAttribute("prod 1,prod 2,prod 3,prod 4")]
        public void OrdersCanHaveMultipleProductsAddedToThem(string productsStr)

        {
            string[] products = productsStr.Split(new char[] { ',' }); //making a new array of one character, SINGLE QUOTES SAY THIS IS A CHARACTER, DOUBLE QUOTES MEAN THIS IS A STRING, MAKING A CHARACTER ARRAY ALLOWS PASSING MULTIPLE CHARACTERS TO SPLIT ON
            Order ord = new Order();
            foreach (string product in products)
            {
                ord.addProduct(product);
            }
            Assert.Equal(products.Length, ord.products.Count); //array of products sent in should be the same as the length of the list we send in.
            foreach (string product in products)
            {
                Assert.Contains<string>(product, ord.products);
            }
        }
        [Theory]
        [InlineDataAttribute("Product")]
        [InlineDataAttribute("product,another product")]
        [InlineDataAttribute("a first product,a second product,yetanother")]
        [InlineDataAttribute("prod 1,prod 2,prod 3,prod 4")]
        public void OrdersCanListProductsForTerminalDisplay(string productsStr)

        {
            string[] products = productsStr.Split(new char[] { ',' }); //making a new array of one character, SINGLE QUOTES SAY THIS IS A CHARACTER, DOUBLE QUOTES MEAN THIS IS A STRING, MAKING A CHARACTER ARRAY ALLOWS PASSING MULTIPLE CHARACTERS TO SPLIT ON
            Order ord = new Order();
            foreach (string product in products)
            {
                ord.addProduct(product);
            }
            foreach (string product in products)
            {
                Assert.Contains($"\nYou ordered {product}", ord.listProducts());
            }
        }

        [Fact]
        public void OrdersCanHaveAProductRemovedFromThem()
        {
            Order ord = new Order();
            ord.addProduct("secondproduct second");
            ord.addProduct("product");
            ord.addProduct("secondproduct");
            ord.addProduct("third melon");
            ord.removeProduct("secondproduct");
            Assert.Equal(3, ord.products.Count);
            Assert.DoesNotContain<string>("secondproduct", ord.products);
        }
        [Fact]
        public void OrdersCanNotReemoveaProductTheyDontHave()
        {
            Order ord = new Order();
            ord.addProduct("secondproduct second");
            ord.addProduct("product");
            ord.addProduct("secondproduct");
            ord.addProduct("third melon");
            ord.removeProduct("fourthproduct");
            Assert.Equal(4, ord.products.Count);
        }

        [TheoryAttribute]
        [InlineDataAttribute("product")]
        [InlineDataAttribute("fourthproduct")]

        public void RemoveMethodReturnsBooleanIndicatingIfProductWasRemoved(string product)
        {
            Order ord = new Order();
            ord.addProduct("secondproduct second");
            ord.addProduct("product");
            ord.addProduct("secondproduct");
            ord.addProduct("third melon");

            bool removed = ord.removeProduct(product);
            if (product == "product") {
                Assert.True(removed);
            }

            if (product == "fourthproduct" ) {
                Assert.False(removed);
            
            }

        }

        [FactAttribute]

        public void DeleteAllProductsFromOrder() {
            Order ord = new Order();
            ord.addProduct("secondproduct second");
            ord.addProduct("product");
            ord.addProduct("secondproduct");
            ord.addProduct("third melon");
            ord.removeProduct();
            Assert.Empty(ord.products);
        }
    }
}
