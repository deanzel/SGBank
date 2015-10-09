using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Models
{
    public class WithdrawalSlip
    {
        public int AccountNumber { get; set; }
        public decimal WithdrawalAmount { get; set; }
        public decimal NewBalance { get; set; }
    }
}
