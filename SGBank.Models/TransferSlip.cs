using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Models
{
    public class TransferSlip
    {
        public int CurrentAccountNumber { get; set; }
        public string CurrentAccountName { get; set; }
        public int TargetAccountNumber { get; set; }
        public string TargetAccountName { get; set; }
        public decimal TransferAmount { get; set; }
        public decimal NewBalanceCurrentAccount { get; set; }
        public decimal NewBalanceTargetAccount { get; set; }
    }
}
