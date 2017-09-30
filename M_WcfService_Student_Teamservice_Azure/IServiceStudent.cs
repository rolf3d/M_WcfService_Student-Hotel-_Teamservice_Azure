using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace M_WcfService_Student_Teamservice_Azure
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IServiceStudent
    {
        [OperationContract]
        IList<Guest> GetAllGuest();

        [OperationContract]
        Guest GetGuestById(int id);

        [OperationContract]
        IList<Guest> GetGuestsByName(string name);

        [OperationContract]
        int AddGuest(string name, string address);
    }

    [DataContract]
    public class Guest
    {
        [DataMember]
        private int guest_No;

        public int Guest_No
        {
            get { return guest_No; }
            set { guest_No = value; }
        }
        [DataMember]
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                if (name == "")
                {
                    throw new FejliAddGuest("Fejl i navn til gæest " + name);
                }

            }
        }
        [DataMember]
        private string address;

        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                if (address == "")
                {
                    throw new FejlIAdresse("Fejl i adresse feltet " + address);
                }
            }
        }

        public Guest()
        {

        }

        public Guest(int guest_no, string name, string address)
        {
            this.Guest_No = guest_no;
            this.Name = name;
            this.Address = address;
        }


    }



}
