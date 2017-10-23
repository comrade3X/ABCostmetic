using System.Collections.Generic;
using System.Linq;
using ABCostmeticServer.Models;

namespace ABCostmeticServer.DTO
{
    public class PaymentDto
    {
        #region Properties

        public int Id { get; set; }
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public int TotalQuanlity { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal ReceivedAmount { get; set; }
        public decimal Change { get; set; }

        public virtual OrderDto Order { get; set; }

        #endregion Properties

        #region Method

        public static ICollection<PaymentDto> ConvertToDto(ICollection<Payment> list)
        {
            if (list == null)
            {
                return new List<PaymentDto>();
            }

            var res = from m in list
                      select new PaymentDto
                      {
                          Id = m.Id,
                          OrderId = m.OrderId,
                          PaymentMethod = m.PaymentMethod,
                          TotalQuanlity = m.TotalQuanlity,
                          TotalAmount = m.TotalAmount,
                          ReceivedAmount = m.ReceivedAmount,
                          Change = m.Change
                      };

            return res.ToList();
        }

        #endregion Method
    }
}