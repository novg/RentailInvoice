using RentailInvoice.Errors;
using System;
using System.IO;
//using Microsoft.Extensions.Logging;
using RentailInvoice.Models;
using RentailInvoice.Interfaces;
using System.Collections.Generic;

namespace RentailInvoice.DataWriter
{
    public class Payment : IDataWriter
    {
        //private readonly ILogger<Payment> logger;
        private readonly string template;

        public Payment(IList<InitialData> initialDatas)
        {
            //this.template = template;
            template = @"Template\total.txt";
            //this.logger = logger;
        }

        public string ReadTemplate()
        {
            try
            {
                string total = File.ReadAllText(this.template);
                return total;
            }
            catch (Exception ex)
            {
                throw new MyException($"The file nor found: '{this.template}'", ex);
            }

        }

        public void Save(string filePath)
        {
            //throw new NotImplementedException();
        }

        public void Write()
        {
            //throw new NotImplementedException("From Payment");
        }

        



        //public void WriteTemplate(string text)
        //{
        //    try
        //    {
        //        File.WriteAllText(template, text);
        //    }
        //    catch (Exception ex)
        //    {
        //        //this.logger.LogError(ex, "FILE NOT FOUND");
        //        throw new MyException($"The file not found: '{this.template}'", ex);
        //    }
        //}
    }
}
