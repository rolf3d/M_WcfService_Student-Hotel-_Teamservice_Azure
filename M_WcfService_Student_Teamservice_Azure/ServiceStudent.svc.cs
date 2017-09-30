using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace M_WcfService_Student_Teamservice_Azure
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceStudent" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceStudent.svc or ServiceStudent.svc.cs at the Solution Explorer and start debugging.
    public class ServiceStudent : IServiceStudent
    {
        private string ConnectionString = GetConnectionStringFromAppConfig();
        //private const string ConnectionString = "Server=tcp:hotelserverrolf.database.windows.net,1433;Initial Catalog=HotelDB;Persist Security Info=False;User ID=Rolles;Password=Holles28462846;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private static string GetConnectionStringFromAppConfig()
        {
            // https://msdn.microsoft.com/en-us/library/ms254494.aspx
            ConnectionStringSettingsCollection connectionStringSettingsCollection = ConfigurationManager.ConnectionStrings;
            ConnectionStringSettings connStringSettings = connectionStringSettingsCollection["HoteldatabaseAzure"];
            string connString = connStringSettings.ConnectionString;
            return connString;
        }

        public IList<Guest> GetAllGuest()
        {
            const string selectAllStudents = "select * from Guest";



            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectAllStudents, databaseConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        List<Guest> guestList = new List<Guest>();
                        while (reader.Read())
                        {
                            //guestList.Add(new Guest(){ Guest_No = (int)reader[0], Name = (string)reader[1],Address = (string)reader[2]});
                            Guest guest = ReadGuest(reader);

                            guestList.Add(guest);
                        }
                        return guestList;
                    }
                }
            }
        }

        private static Guest ReadGuest(IDataRecord reader)
        {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            string address = reader.GetString(2);
            Guest guest = new Guest()
            {
                Guest_No = id,
                Name = name,
                Address = address
            };
            return guest;
        }

        public Guest GetGuestById(int id)
        {
            const string selectGuest = "select * from guest where Guest_No=@id";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectGuest, databaseConnection))
                {
                    selectCommand.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            return null;
                        }
                        reader.Read(); // Advance cursor to first row
                        Guest guest = ReadGuest(reader);
                        return guest;
                    }
                }
            }
        }

        public IList<Guest> GetGuestsByName(string name)
        {
            string selectStr = "select * from guest where name LIKE @name";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectStr, databaseConnection))
                {
                    selectCommand.Parameters.AddWithValue("@name", "%" + name + "%");
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        IList<Guest> guestList = new List<Guest>();
                        while (reader.Read())
                        {
                            Guest gl = ReadGuest(reader);
                            guestList.Add(gl);
                        }
                        return guestList;
                    }
                }
            }
        }

        public IList<Guest> GetGuestByAddress(string address)
        {
            string selectStr = "select * from guest where address LIKE @address";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(selectStr, databaseConnection))
                {
                    selectCommand.Parameters.AddWithValue("@address", "%" + address + "%");
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        IList<Guest> guestList = new List<Guest>();
                        while (reader.Read())
                        {
                            Guest gl = ReadGuest(reader);
                            guestList.Add(gl);
                        }
                        return guestList;
                    }
                }
            }
        }

        public int AddGuest(string name, string address)
        {
            const string insertGuest = "insert into guest (Name, Address) values (@name, @address)";
            using (SqlConnection databaseConnection = new SqlConnection(ConnectionString))
            {
                databaseConnection.Open();

                using (SqlCommand insertCommand = new SqlCommand(insertGuest, databaseConnection))
                {
                    insertCommand.Parameters.AddWithValue("@name", name);
                    insertCommand.Parameters.AddWithValue("@address", address);
                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected;

                }
            }
        }

    }
}
