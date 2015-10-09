using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Models
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Account AccountInfo { get; set; }
        public DepositSlip DepositInfo { get; set; }
        public WithdrawalSlip WithdrawalInfo { get; set; }
        public TransferSlip TransferInfo { get; set; }
    }
}
