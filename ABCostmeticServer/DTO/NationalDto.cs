using System.Collections.Generic;
using ABCostmeticServer.Models;

namespace ABCostmeticServer.DTO
{
    public class NationalDto
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<EmployeeDto> Employees { get; set; }

        public virtual ICollection<StoreDto> Stores { get; set; }

        #endregion Properties

        #region Method

        public static NationalDto ConvertToDto(Nationality m)
        {
            if (m == null)
            {
                return new NationalDto();
            }

            var res = new NationalDto
            {
                Id = m.Id,
                Name = m.Name,
                ZipCode = m.ZipCode
                //Employees = EmployeeDto.ConvertToDto(m.Employees),
                //Stores = StoreDto.ConvertToDto(m.Stores)
            };

            return res;
        }

        public static Nationality ConvertToModel(NationalDto m)
        {
            if (m == null)
            {
                return new Nationality();
            }

            var res = new Nationality
            {
                Id = m.Id,
                Name = m.Name,
                ZipCode = m.ZipCode
                //Employees = EmployeeDto.ConvertToDto(m.Employees),
                //Stores = StoreDto.ConvertToDto(m.Stores)
            };

            return res;
        }

        #endregion Method
    }
}