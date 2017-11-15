using System;
using System.Collections.Generic;
using System.Linq;
using ABCostmeticServer.Models;

namespace ABCostmeticServer.DTO
{
    public class OrderDto
    {
        #region Properties

        public int Id { get; set; }
        public string OrderCode { get; set; }
        public int Seller { get; set; }
        public int Customer { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual CustomerDto Customer1 { get; set; }
        public virtual EmployeeDto Employee { get; set; }

        public virtual ICollection<OrderDetailDto> OrderDetails { get; set; }

        public virtual ICollection<PaymentDto> Payments { get; set; }

        #endregion Properties

        #region Method

        public static OrderDto ConvertToDto(Order m)
        {
            if (m == null)
            {
                return new OrderDto();
            }

            var res = new OrderDto
            {
                Id = m.Id,
                OrderCode = m.OrderCode,
                Seller = m.Seller,
                Customer = m.Customer,
                OrderDate = m.OrderDate,
                //Customer1 = CustomerDto.ConvertToDto(m.Customer1),
                //Employee = EmployeeDto.ConvertToDto(m.Employee),
                //OrderDetails = OrderDetailDto.ConvertToDto(m.OrderDetails),
                //Payments = PaymentDto.ConvertToDto(m.Payments)
            };
            return res;
        }

        public static List<OrderDto> ConvertToDto(ICollection<Order> list)
        {
            if (list == null)
            {
                return new List<OrderDto>();
            }

            var res = from m in list
                      select new OrderDto
                      {
                          Id = m.Id,
                          OrderCode = m.OrderCode,
                          Seller = m.Seller,
                          Customer = m.Customer,
                          OrderDate = m.OrderDate,
                      };
            return res.ToList();
        }

        #endregion Method
    }
}