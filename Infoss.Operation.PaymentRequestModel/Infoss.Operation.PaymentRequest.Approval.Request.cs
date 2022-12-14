using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoss.Operation.PaymentRequestModel
{
    public class PaymentRequestApproval
    {
        public int Id { get; set; } = 0;
        public int Flag { get; set; } = 0;
        public bool IsApprove { get; set; } = false;
        public int CountryId { get; set; } = 0;
        public int CompanyId { get; set; } = 0;
        public int BranchId { get; set; } = 0;
        public string ApprovedRemarks { get; set; } = string.Empty;
        public List<listId> ids { get; set; } = new List<listId>();
    }

    public class listId
    {
        public int id { get; set; }
    }
}
