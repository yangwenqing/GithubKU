using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ordertest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods apple = new Goods(1, "apple", 5.59);
            OrderDetail orderDetails1 = new OrderDetail(1, apple, 800);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            Assert.IsTrue(os.Export("s.xml"));
        }
        [TestMethod]
        public void TestMethod2()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods apple = new Goods(1, "apple", 5.59);
            OrderDetail orderDetails1 = new OrderDetail(1, apple, 800);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            List<Order>orders = os.QueryByGoodsName("apple");
            string s = "";
            foreach(Order order in orders)
            {
                s = order.ToString();
            }
            string n = "================================================================================\n";
            n += $"orderId:{apple.Id}, customer:({customer1.Name}),Amount:{apple.Price*orderDetails1.Quantity}";
          n += "\n\t"+ $"orderDetailId:{orderDetails1.Id}:  ";
           n += $"Id:{apple.Id}, Name:{apple.Name}, Value:{apple.Price}" + $", quantity:{orderDetails1.Quantity}";
            n += "\n================================================================================";

            Assert.AreEqual(n,s);
        }
        [TestMethod]
        public void TestMethod3()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Goods apple = new Goods(1, "apple", 5.59);
            OrderDetail orderDetails1 = new OrderDetail(1, apple, 800);
            Order order1 = new Order(1, customer1);
            order1.AddDetails(orderDetails1);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            Assert.IsFalse(os.AddOrder(order1));
            
        }
    }
}
