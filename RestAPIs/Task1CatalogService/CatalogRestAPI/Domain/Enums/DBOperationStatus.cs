using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum DBOperationStatus
    {
        Success = 0,
        Fail = 1,
        NotFound = 2,
        Error = 3
    }
}
