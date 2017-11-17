using System.Collections.Generic;
using ABCostmeticServer.Models;

namespace ABCostmeticServer.DTO
{
    public class StaffTypeDto
    {
        #region Properties

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<EmployeeDto> Employees { get; set; }

        #endregion Properties

        #region Method

        public static StaffTypeDto ConvertToDto(StaffType m)
        {
            if (m == null)
            {
                return new StaffTypeDto();
            }
            var res = new StaffTypeDto()
            {
                Id = m.Id,
                Type = m.Type,
                //Employees = EmployeeDto.ConvertToDto(m.Employees)
            };

            return res;
        }

        public static StaffType ConvertToModel(StaffTypeDto m)
        {
            if (m == null)
            {
                return new StaffType();
            }
            var res = new StaffType
            {
                Id = m.Id,
                Type = m.Type
                //Employees = EmployeeDto.ConvertToDto(m.Employees)
            };

            return res;
        }

        #endregion Method
    }
}