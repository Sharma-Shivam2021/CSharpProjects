using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;

public class OverbookingError
{
    public string ErrorMessage { get; }
    public OverbookingError()
    {
        ErrorMessage = "The number of seats available is less than the number of booking being done";
    }
}
