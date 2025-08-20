using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;

public class BookingNotFoundError
{
    public string ErrorMessage { get; }
    public BookingNotFoundError()
    {
        ErrorMessage = "Could not found booking for this passenger";
    }
}
