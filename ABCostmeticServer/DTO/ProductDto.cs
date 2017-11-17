using System.Collections.Generic;
using System.Linq;
using ABCostmeticServer.Models;

namespace ABCostmeticServer.DTO
{
    public class ProductDto
    {
        #region Properties

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Descriptions { get; set; }
        public virtual CategoryDto Category { get; set; }
        public virtual ICollection<OrderDetailDto> OrderDetails { get; set; }

        #endregion Properties

        #region Method

        public static ProductDto ConvertToDto(Product m)
        {
            if (m == null)
            {
                return new ProductDto();
            }

            var res = new ProductDto
            {
                Id = m.Id,
                CategoryId = m.CategoryId,
                Name = m.Name,
                Price = m.Price,
                Descriptions = m.Descriptions,
                Category = CategoryDto.ConvertToDto(m.Category),
                //OrderDetails = OrderDetailDto.ConvertToDto(m.OrderDetails)
            };

            return res;
        }

        public static Product ConvertToModel(Product m)
        {
            if (m == null)
            {
                return new Product();
            }

            var res = new Product
            {
                Id = m.Id,
                CategoryId = m.CategoryId,
                Name = m.Name,
                Price = m.Price,
                Descriptions = m.Descriptions,
                Category = m.Category,
                //OrderDetails = OrderDetailDto.ConvertToDto(m.OrderDetails)
            };

            return res;
        }

        public static List<ProductDto> ConvertToDto(IEnumerable<Product> list)
        {
            if (list == null)
            {
                return new List<ProductDto>();
            }
            var res = from m in list
                      select new ProductDto()
                      {
                          Id = m.Id,
                          CategoryId = m.CategoryId,
                          Name = m.Name,
                          Price = m.Price,
                          Descriptions = m.Descriptions,
                          Category = CategoryDto.ConvertToDto(m.Category),
                      };
            return res.ToList();
        }

        #endregion Method
    }
}