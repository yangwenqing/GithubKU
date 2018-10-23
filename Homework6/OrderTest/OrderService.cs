using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ordertest {
    /// <summary>
    /// OrderService:provide ordering service,
    /// like add order, remove order, query order and so on
    /// 实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询)
    /// </summary>
    public class OrderService { 

        private Dictionary<uint, Order> orderDict;
        /// <summary>
        /// OrderService constructor
        /// </summary>
        public OrderService() {
            orderDict = new Dictionary<uint, Order>();
        }

        /// <summary>
        /// add new order
        /// </summary>
        /// <param name="order">the order will be added</param>
        public bool AddOrder(Order order) {
            if (orderDict.ContainsKey(order.Id))
                throw new Exception($"order-{order.Id} is already existed!");
            orderDict[order.Id] = order;
            return false;
        }

        /// <summary>
        /// cancel order
        /// </summary>
        /// <param name="orderId">id of the order which will be canceled</param> 
        public void RemoveOrder(uint orderId) {
              orderDict.Remove(orderId);
        }

        /// <summary>
        /// query all orders
        /// </summary>
        /// <returns>List<Order>:all the orders</returns> 
        public List<Order> QueryAllOrders() {
            return orderDict.Values.ToList();
        }

        /// <summary>
        /// query by orderId
        /// </summary>
        /// <param name="orderId">id of the order to find</param>
        /// <returns>List<Order></returns> 
        public Order GetById(uint orderId) {
            return orderDict[orderId];
        }

        /// <summary>
        /// query by goodsName
        /// </summary>
        /// <param name="goodsName">the name of goods in order's orderDetail</param>
        /// <returns></returns> 
        public List<Order> QueryByGoodsName(string goodsName) {
            var query = orderDict.Values.Where(order =>
                    order.Details.Where(d => d.Goods.Name == goodsName)
                    .Count() > 0
                );
            return query.ToList();
   
        }

        /// <summary>
        /// query by customerName
        /// </summary>
        /// <param name="customerName">customer name</param>
        /// <returns></returns> 
        public List<Order> QueryByCustomerName(string customerName) {
            var query=orderDict.Values
                .Where(order => order.Customer.Name == customerName);
            return query.ToList();
        }

        public List<Order> QueryByPrice(double price)
        {
            var query = orderDict.Values
                .Where(order => order.Amount> price);
            return query.ToList();
        }


        /// <summary>
        /// edit order's customer
        /// </summary>
        /// <param name="orderId"> id of the order whoes customer will be update</param>
        /// <param name="newCustomer">the new customer of the order which will be update</param> 
        public void UpdateCustomer(uint orderId, Customer newCustomer)
        {
            if (orderDict.ContainsKey(orderId))
            {
                orderDict[orderId].Customer = newCustomer;
            }
            else
            {
                throw new Exception($"order-{orderId} is not existed!");
            }
        }
        //xml序列化
        public bool Export(string a)
        {
            try
            {
                XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
                String xmlFileName = a;
                FileStream fs = new FileStream(xmlFileName, FileMode.Create);
                xmlser.Serialize(fs, orderDict.Values.ToList());
                fs.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("序列化未成功。");
                return false;
            }
            Console.WriteLine("已序列化成功。");
            return true;
        }
        //xml反序列化
        public bool Import(string a)
        {
            List<Order> MyOrder = new List<Order>();
            try
            {
                XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
                String xmlFileName = a;
                FileStream fs = new FileStream(xmlFileName, FileMode.Open);
                MyOrder = (List<Order>)xmlser.Deserialize(fs);
              foreach(Order order in MyOrder)
                {
                    this.AddOrder(order);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("反序列化失败");
                return false;
            }
            Console.WriteLine("反序列化成功");
            return true;
        }
        /*other edit function with write in the future.*/
    }
}
