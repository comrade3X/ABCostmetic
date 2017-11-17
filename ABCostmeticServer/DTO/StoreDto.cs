using System.Collections.Generic;
using System.Linq;
using ABCostmeticServer.Models;

namespace ABCostmeticServer.DTO
{
    public class StoreDto
    {
        #region Properties

        public int Id { get; set; }
        public int Nationality { get; set; }
        public string Address { get; set; }

        public virtual NationalDto Nationality1 { get; set; }

        public virtual ICollection<EmployeeDto> Employees { get; set; }

        #endregion Properties

        #region Method

        public static StoreDto ConvertToDto(Store m)
        {
            if (m == null)
            {
                return new StoreDto();
            }

            var res = new StoreDto
            {
                Id = m.Id,
                Nationality = m.Nationality,
                Address = m.Address,
                //Nationality1 = NationalDto.ConvertToDto(m.Nationality1),
                //Employees = EmployeeDto.ConvertToDto(m.Employees)
            };

            return res;
        }

        public static Store ConvertToModel(StoreDto m)
        {
            if (m == null)
            {
                return new Store();
            }

            var res = new Store
            {
                Id = m.Id,
                Nationality = m.Nationality,
                Address = m.Address,
                //Nationality1 = NationalDto.ConvertToDto(m.Nationality1),
                //Employees = EmployeeDto.ConvertToDto(m.Employees)
            };

            return res;
        }

        public static ICollection<StoreDto> ConvertToDto(ICollection<Store> list)
        {
            if (list == null)
            {
                return new List<StoreDto>();
            }

            var res = from m in list
                      select new StoreDto
                      {
                          Id = m.Id,
                          Nationality = m.Nationality,
                          Address = m.Address
                      };

            return res.ToList();
        }

        #endregion Method
    }
}