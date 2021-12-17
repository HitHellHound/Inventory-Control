﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarehouseAccountingSystem;
using System.Collections;

namespace Model.Repositories.DAO
{
    public class ListOrderDao : IOrderDao
    {
        private long currentId = 1;
        private List<Order> orderList;
        private static ListOrderDao INSTANCE;

        static public ListOrderDao getInstance()
        {
            if (INSTANCE == null)
                INSTANCE = new ListOrderDao();
            return INSTANCE;
        }

        private ListOrderDao()
        {
            orderList = new List<Order>();
            
        }

        public void addOrder(Order order)
        {
           order.Id = currentId++;
           orderList.Add(order);
        }

        public void deleteOrder(long id)
        {
            orderList.Remove(GetOrder(id));
        }

        public List<Order> getAllOrders()
        {
            return new List<Order>(orderList);
        }

        public Order GetOrder(long id)
        {
           
            return orderList.Where(order => order.Id == id).First();
        }



    }
}
