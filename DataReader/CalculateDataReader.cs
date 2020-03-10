using System.Collections.Generic;
using RentailInvoice.Interfaces;
using RentailInvoice.Models;

namespace RentailInvoice.DataReader
{
    public class CalculateDataReader : IDataReader
    {
        private string folderPath;

        public CalculateDataReader(string folderPath)
        {
            this.folderPath = folderPath;
        }

        public IList<InitialData> Read()
        {
            //throw new System.NotImplementedException("From DataReader");
            //IList<InitialData> initialDatas = new Li
            //InitialData initialData = new InitialData();
            return new List<InitialData>();
        }
    }
}
