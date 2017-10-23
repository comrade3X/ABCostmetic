using System.Collections.Generic;
using System.Linq;
using ABCostmeticServer.Models;

namespace ABCostmeticServer.DTO
{
    public class UserDto
    {
        #region Properties

        public EmployeeDto Employee { get; set; }
        public int Id { get; set; }
        public string Password { get; set; }
        public int StaffId { get; set; }
        public string Username { get; set; }

        #endregion Properties

        #region Method

        public static UserDto ConvertToDto(User user)
        {
            if (user == null)
            {
                return new UserDto();
            }

            var res = new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                StaffId = user.StaffId,
                Employee = EmployeeDto.ConvertToDto(user.Employee)
            };

            return res;
        }

        public static ICollection<UserDto> ConvertToDto(ICollection<User> list)
        {
            if (list == null)
            {
                return new List<UserDto>();
            }

            var res = from m in list
                      select new UserDto
                      {
                          Id = m.Id,
                          Username = m.Username,
                          Password = m.Password,
                          StaffId = m.StaffId,
                      };

            return res.ToList();
        }

        #endregion Method
    }
}