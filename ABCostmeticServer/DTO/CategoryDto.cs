using ABCostmeticServer.Models;
using System.Collections.Generic;

namespace ABCostmeticServer.DTO
{
    public class CategoryDto
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public virtual ICollection<ProductDto> Products { get; set; }

        #endregion Properties

        #region Method

        public static CategoryDto ConvertToDto(Category m)
        {
            if (m == null)
            {
                return new CategoryDto();
            }

            var res = new CategoryDto
            {
                Id = m.Id,
                Name = m.Name,
                Descriptions = m.Descriptions
            };

            return res;
        }

        public static Category ConvertToModel(CategoryDto m)
        {
            if (m == null)
            {
                return new Category();
            }

            var res = new Category
            {
                Id = m.Id,
                Name = m.Name,
                Descriptions = m.Descriptions
            };

            return res;
        }

        #endregion Method
    }
}