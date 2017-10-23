using System.Collections.Generic;
using System.Linq;
using ABCostmeticServer.Models;

namespace ABCostmeticServer.DTO
{
    public class EmployeeDto
    {
        #region Properties

        public int Id { get; set; }
        public int StaffTypeId { get; set; }
        public int StoreId { get; set; }
        public string FullName { get; set; }
        public string IdentityCard { get; set; }
        public int Nationality { get; set; }
        public string Address { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual NationalDto Nationality1 { get; set; }
        public virtual StaffTypeDto StaffType { get; set; }

        public virtual StoreDto Store { get; set; }

        public virtual ICollection<OrderDto> Orders { get; set; }

        public virtual ICollection<UserDto> Users { get; set; }

        #endregion Properties

        #region Method

        public static ICollection<EmployeeDto> ConvertToDto(ICollection<Employee> list)
        {
            if (list == null)
            {
                return new List<EmployeeDto>();
            }

            var res = from m in list
                      select new EmployeeDto
                      {
                          Id = m.Id,
                          StaffTypeId = m.StaffTypeId,
                          StoreId = m.StoreId,
                          FullName = m.FullName,
                          IdentityCard = m.IdentityCard,
                          Nationality = m.Nationality,
                          Address = m.Address,
                          DateOfBirth = m.DateOfBirth,
                          Gender = m.Gender,
                          Phone = m.Phone,
                          Email = m.Email
                      };
            return res.ToList();
        }

        public static EmployeeDto ConvertToDto(Employee m)
        {
            if (m == null)
            {
                return new EmployeeDto();
            }

            var res = new EmployeeDto
            {
                Id = m.Id,
                StaffTypeId = m.StaffTypeId,
                StoreId = m.StoreId,
                FullName = m.FullName,
                IdentityCard = m.IdentityCard,
                Nationality = m.Nationality,
                Address = m.Address,
                DateOfBirth = m.DateOfBirth,
                Gender = m.Gender,
                Phone = m.Phone,
                Email = m.Email,
                Nationality1 = NationalDto.ConvertToDto(m.Nationality1),
                StaffType = StaffTypeDto.ConvertToDto(m.StaffType),
                Store = StoreDto.ConvertToDto(m.Store),
                Orders = OrderDto.ConvertToDto(m.Orders),
                Users = UserDto.ConvertToDto(m.Users)
            };

            return res;
        }

        #endregion Method
    }
}