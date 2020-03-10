using System;
using System.Collections.Generic;
using System.Text;
using RentailInvoice.Models;

namespace RentailInvoice.Interfaces
{
    public interface IDataReader
    {
        IList<InitialData> Read();
    }
}
