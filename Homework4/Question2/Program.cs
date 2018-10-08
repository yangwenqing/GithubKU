using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    public class Order
    {
        public string MycustomerName = "空";
        public string MyorderNumber = "空";
        public string MyGoodsName = "空";
        public string CustomerName
        {
            get
            {
                return MycustomerName;
            }
            set
            {
                MycustomerName = value;
            }
        }
        public string OrderNumber
        {
            get
            {
                return MyorderNumber;
            }
            set
            {
                MyorderNumber = value;
            }
        }
        public string GoodsName
        {
            get
            {
                return MyGoodsName;
            }
            set
            {
                MyGoodsName = value;
            }
        }
    }
    public class OrderService
    {
        public List<string> OrderList = new List<string>();
        public void AddOrder()
        {
            Order NewOrder = new Question2.Order();
            string s = "";
            Console.WriteLine("Please input the CustomerName");
            s = Console.ReadLine();
            NewOrder.CustomerName = s;
            Console.WriteLine("Please input the OrderNumber");
            s = Console.ReadLine();
            NewOrder.OrderNumber = s;
            Console.WriteLine("Please input your GoodsName");
            s = Console.ReadLine();
            NewOrder.GoodsName = s;
            OrderList.Add(NewOrder.CustomerName);
            OrderList.Add(NewOrder.OrderNumber);
            OrderList.Add(NewOrder.GoodsName);
            Console.WriteLine("订单添加操作结束");
        }
        public void DeleteOrder()
        {
            int n = 0;
            string s = "";
            Console.WriteLine("Please input what you want to delete by");
            s = Console.ReadLine();
            try
            {
                for (int i = 0; i < OrderList.Count; i++)
                {
                    if (OrderList[i] == s)
                    {
                        n = i;

                        if ((n + 1) % 3 == 0)
                        {
                            OrderList.Remove(OrderList[n]);
                            OrderList.Remove(OrderList[n - 1]);
                            OrderList.Remove(OrderList[n - 2]);
                        }
                        else if ((n + 1) % 3 == 1)
                        {
                            OrderList.Remove(OrderList[n]);
                            OrderList.Remove(OrderList[n]);
                            OrderList.Remove(OrderList[n]);
                        }
                        else
                        {
                            OrderList.Remove(OrderList[n]);
                            OrderList.Remove(OrderList[n]);
                            OrderList.Remove(OrderList[n - 1]);
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("未能找到匹配的订单，删除失败");
            }
            Console.WriteLine("订单删除操作结束");
        }
        public void SearchOeder()
        {
            int n = 0;
            string s = "";
            Console.WriteLine("Please input what you want to Search by");
            s = Console.ReadLine();
            try
            {
                for (int i = 0; i < OrderList.Count; i++)
                {
                    if (OrderList[i] == s)
                    {
                        n = i;
                        if ((n + 1) % 3 == 0)
                        {
                            Console.WriteLine(OrderList[n - 2] + " " + OrderList[n - 1] + " " + OrderList[n]);
                        }
                        else if ((n + 1) % 3 == 1)
                        {
                            Console.WriteLine(OrderList[n] + " " + OrderList[n + 1] + " " + OrderList[n + 2]);
                        }
                        else
                        {
                            Console.WriteLine(OrderList[n - 1] + " " + OrderList[n] + " " + OrderList[n + 1]);
                        }
                    }
                }
            }
            catch
            {
                Console.WriteLine("未能找到匹配的订单，搜索失败");
            }
            Console.WriteLine("订单搜索操作结束");
        }
        public void RewriteOrder()
        {
            int n = 0;
            string s = "";
            Console.WriteLine("Please input the message before you rewrite");
            s = Console.ReadLine();
            try
            {
                for (int i = 0; i < OrderList.Count; i++)
                {
                    if (OrderList[i] == s)
                    {
                        n = i;

                        Console.WriteLine("Please input the massage after you rewrite");
                        s = Console.ReadLine();
                        OrderList[n] = s;
                    }
                }
            }
            catch
            {
                Console.WriteLine("未能找到匹配的订单，修改失败");
            }
            Console.WriteLine("订单修改操作结束");
        }
    }


    public class OrderDetails
    {
        public void Details(OrderService dt)
        {
            foreach (string order in dt.OrderList)
            {
                Console.WriteLine(order + " ");
            }
        }
    }
    class Test
    {
        static void Main(string[] args)
        {
            OrderService dt = new OrderService();
            OrderDetails da = new OrderDetails();
            dt.AddOrder();
            dt.AddOrder();
            da.Details(dt);
            dt.SearchOeder();
            dt.RewriteOrder();
            da.Details(dt);
            dt.DeleteOrder();
            da.Details(dt);
        }
    }
}

