using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ProjectUsers
{
    internal class DatabaseManager
    {
        public SqlConnection conn()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
            return new SqlConnection(connectionString);
        }
        public void PeopleUpdate(int id, string name, string surname, string birthdate, string email, string phoneNumber, string address, string city, string country)
        {
            try
            {
                using (SqlConnection connection = conn())
                {
                    connection.Open();

                    string updateQuery = @"UPDATE People
                                          SET Name = @Name, Surname = @Surname, Birthdate = @Birthdate, Email = @Email, PhoneNumber = @PhoneNumber, Address = @Address, City = @City, Country = @Country
                                          WHERE ID = @ID";

                    using (SqlCommand command = new SqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ID", id);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Surname", surname);
                        command.Parameters.AddWithValue("@Birthdate", birthdate);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@Address", address);
                        command.Parameters.AddWithValue("@City", city);
                        command.Parameters.AddWithValue("@Country", country);

                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                }

                MessageBox.Show("Kayıt güncellendi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme hatası: " + ex.Message);
            }
        }
        public void PeopleDelete(int id)
        {
            try
            {
                using (SqlConnection connection = conn())
                {
                    connection.Open();

                    string query = "DELETE FROM People WHERE ID = @id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    MessageBox.Show("Kişi Silindi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public List<MyData> GetDataFromDatabase(string query)
        {
            List<MyData> dataList = new List<MyData>();
            SqlConnection connection = conn();
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string name = reader["Name"].ToString();
                    string surname = reader["Surname"].ToString();
                    DateTime birthdate;
                    try
                    {
                        birthdate = Convert.ToDateTime(reader["Birthdate"]);
                    }
                    catch (Exception)
                    {
                        birthdate = new DateTime(1, 1, 1);

                    }
                    string email = reader["Email"].ToString();
                    string phoneNumber = reader["PhoneNumber"].ToString();
                    string address = reader["Address"].ToString();
                    string city = reader["City"].ToString();
                    string country = reader["Country"].ToString();
                    string photoUrl = reader["PhotoUrl"].ToString();

                    dataList.Add(new MyData { ID = id, Name = name, Surname = surname, Birthdate = birthdate, Email = email, PhoneNumber = phoneNumber, Address = address, City = city, Country = country, PhotoUrl = photoUrl });
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Veritabanından veri çekerken bir hata oluştu: " + ex.Message);
            }

            return dataList;
        }

        public void InsertDataToDatabase(string name, string surname, string birthdate, string email, string phoneNumber, string address, string city, string country, string photoUrl)
        {
            try
            {
                using (SqlConnection connection = conn())
                {
                    connection.Open();
                    string query = "INSERT INTO People (Name, Surname, Birthdate, Email, PhoneNumber, Address, City, Country, PhotoUrl) VALUES (@Name, @Surname, @Birthdate, @Email, @PhoneNumber, @Address, @City, @Country, @PhotoUrl)";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Surname", surname);
                    command.Parameters.AddWithValue("@Birthdate", birthdate);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@City", city);
                    command.Parameters.AddWithValue("@Country", country);
                    command.Parameters.AddWithValue("@PhotoUrl", photoUrl);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı.");
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("hata." + ex.Message);
            }
        }

    }
    public class MyData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }
    }


}
