using System.Collections.Generic;
using ABCostmeticServer.Models;
using System.Linq;

namespace ABCostmeticServer.DTO
{
    public class CustomerDto
    {
        #region Properties

        public int Id { get; set; }
        public string FullName { get; set; }
        public string IdentityCard { get; set; }
        public string Gender { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<OrderDto> Orders { get; set; }

        #endregion Properties

        #region Method

        public static CustomerDto ConvertToDto(Customer m)
        {
            if (m == null)
            {
                return new CustomerDto();
            }

            var res = new CustomerDto
            {
                Id = m.Id,
                FullName = m.FullName,
                IdentityCard = m.IdentityCard,
                Gender = m.Gender,
                DateOfBirth = m.DateOfBirth,
                Address = m.Address,
                Phone = m.Phone,
                Email = m.Email,
                //Orders = OrderDto.ConvertToDto(m.Orders)
            };

            return res;
        }

        public static Customer ConvertToModel(CustomerDto m)
        {
            if (m == null)
            {
                return new Customer();
            }

            var res = new Customer
            {
                Id = m.Id,
                FullName = m.FullName,
                IdentityCard = m.IdentityCard,
                Gender = m.Gender,
                DateOfBirth = m.DateOfBirth,
                Address = m.Address,
                Phone = m.Phone,
                Email = m.Email
                //Orders = OrderDto.ConvertToDto(m.Orders)
            };

            return res;
        }

        public static IEnumerable<CustomerDto> ConvertToDto(IEnumerable<Customer> list)
        {
            if (list == null)
            {
                return new List<CustomerDto>();
            }

            var res = from m in list
                      select new CustomerDto
                      {
                          Id = m.Id,
                          FullName = m.FullName,
                          IdentityCard = m.IdentityCard,
                          Gender = m.Gender,
                          DateOfBirth = m.DateOfBirth,
                          Address = m.Address,
                          Phone = m.Phone,
                          Email = m.Email
                      };

            return res;
        }

        #endregion Method
    }
}