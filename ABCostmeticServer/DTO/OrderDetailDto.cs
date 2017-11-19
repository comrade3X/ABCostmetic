using System.Collections.Generic;
using System.Linq;
using ABCostmeticServer.Models;

namespace ABCostmeticServer.DTO
{
    public class OrderDetailDto
    {
        #region Properties

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual OrderDto Order { get; set; }
        public virtual ProductDto Product { get; set; }

        #endregion Properties

        #region Method

        public static OrderDetailDto ConvertToDto(OrderDetail m)
        {
            if (m == null)
            {
                return new OrderDetailDto();
            }

            var res = new OrderDetailDto
            {
                Id = m.Id,
                OrderId = m.OrderId,
                ProductId = m.ProductId,
                Quantity = m.Quantity,
                Product = ProductDto.ConvertToDto(m.Product),
                //Order = OrderDto.ConvertToDto(m.Order)
            };

            return res;
        }

        public static OrderDetail ConvertToModel(OrderDetailDto m)
        {
            if (m == null)
            {
                return new OrderDetail();
            }

            var res = new OrderDetail
            {
                Id = m.Id,
                OrderId = m.OrderId,
                ProductId = m.ProductId,
                Quantity = m.Quantity,
                Product = ProductDto.ConvertToModel(m.Product)
                //Order = OrderDto.ConvertToDto(m.Order)
            };

            return res;
        }

        public static List<OrderDetail> ConvertToModel(ICollection<OrderDetailDto> list)
        {
            if (list == null)
            {
                return new List<OrderDetail>();
            }
            var res = from m in list
                select new OrderDetail
                {
                    Id = m.Id,
                    OrderId = m.OrderId,
                    ProductId = m.ProductId,
                    Quantity = m.Quantity,
                    Product = ProductDto.ConvertToModel(m.Product)
                };

            return res.ToList();
        }


        public static List<OrderDetailDto> ConvertToDto(ICollection<OrderDetail> list)
        {
            if (list == null)
            {
                return new List<OrderDetailDto>();
            }
            var res = from m in list
                      select new OrderDetailDto
                      {
                          Id = m.Id,
                          OrderId = m.OrderId,
                          ProductId = m.ProductId,
                          Quantity = m.Quantity,
                          Product = ProductDto.ConvertToDto(m.Product)
                      };

            return res.ToList();
        }

        #endregion Method
    }
}