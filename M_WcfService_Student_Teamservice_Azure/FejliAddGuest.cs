using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace M_WcfService_Student_Teamservice_Azure
{
    public class FejliAddGuest : Exception
    {
        public FejliAddGuest()
        {
            
        }

        public FejliAddGuest(string message) : base(message)
        {
            
        }

        public FejliAddGuest(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}