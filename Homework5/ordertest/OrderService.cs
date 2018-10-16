using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest {
    /// <summary>
    /// OrderService:provide ordering service,
    /// like add order, remove order, query order and so on
    /// 实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询)
    /// </summary>
    class OrderService { 

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
        public void AddOrder(Order order) {
            if (orderDict.ContainsKey(order.Id))
                throw new Exception($"order-{order.Id} is already existed!");
            orderDict[order.Id] = order;
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
            List<Order> result = new List<Order>();
            /* foreach(Order order in orderDict.Values)
             {
                 foreach(OrderDetail detail in order.Details)
                 {
                     if (detail.Goods.Name == goodsName)
                     {
                         result.Add(order);
                         break;
                     }

                 }
             }
             */
            //使用Linq
            foreach (Order order in orderDict.Values)
            {
                var a = from b in order.Details where b.Goods.Name == goodsName select b;
                foreach( var b in a)
                {
                    result.Add(order);
                }
            }
                return result;
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
        public List<Order> QueryByValue(double value)//搜索大于1万元的订单
        {
            List<Order> result = new List<Order>();
            foreach(Order order in orderDict.Values)
            {
                double sum = 0;
                var query = from a in order.Details where a.Sum >= 0 select a;
                foreach(var a in query)
                {
                    sum += a.Sum;
                    if (sum > value)
                    {
                        result.Add(order);
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// edit order's customer
        /// </summary>
        /// <param name="orderId"> id of the order whoes customer will be update</param>
        /// <param name="newCustomer">the new customer of the order which will be update</param> 
        public void UpdateCustomer(uint orderId, Customer newCustomer) {
            if (orderDict.ContainsKey(orderId)) {
                orderDict[orderId].Customer = newCustomer;
            } else {
                throw new Exception($"order-{orderId} is not existed!");
            }
        }
        /*other edit function with write in the future.*/
    }
}
