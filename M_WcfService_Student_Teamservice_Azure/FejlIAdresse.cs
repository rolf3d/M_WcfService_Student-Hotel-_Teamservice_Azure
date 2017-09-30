using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_WcfService_Student_Teamservice_Azure
{
    public class FejlIAdresse : Exception
    {
        public FejlIAdresse()
        {

        }

        public FejlIAdresse(string message) : base(message)
        {

        }

        public FejlIAdresse(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}