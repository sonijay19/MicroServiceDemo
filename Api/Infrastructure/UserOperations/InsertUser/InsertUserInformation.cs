using Api.Domain.Dtos.InsertUser;
using Api.Domain.Enums;
using Api.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infrastructure.UserOperations.InsertUser
{
    public class InsertUserInformation : IUserDetailsInsert
    {
        private SqlConnection conn;
        public InsertUserInformation()
        {
            string connectionstring =
                "Data Source=DESKTOP-02T0GUH\\SQLEXPRESS;Initial Catalog = UserDetails; User ID = DESKTOP-02T0GUH\\sonij; Password='';Integrated Security=true;";
            conn = new SqlConnection(connectionstring);
        }
        public async Task<bool> InsertUserDetailsAsync(InsertUserRequest UserDetails)
        {
            string query = "INSERT INTO UserDetails (UserId,FirstName,LastName,UserEmail,UserTypeId,PhoneNumber) VALUES (@userid,@firstname,@lastname,@useremail,@userTypeId,@phonenumber)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                //@phonenumber
                cmd.CommandType = CommandType.Text;
                conn.Open();

                cmd.Parameters.AddWithValue("@userTypeId", (int)Enum.Parse(typeof(UserAccessType), UserDetails.UserStatus) + 1);
                cmd.Parameters.AddWithValue("@firstname", UserDetails.FirstName.ToString());
                cmd.Parameters.AddWithValue("@userid", Convert.ToInt32(UserDetails.UserId));
                cmd.Parameters.AddWithValue("@lastname", UserDetails.LastName.ToString());
                cmd.Parameters.AddWithValue("@useremail", UserDetails.UserEmail.ToString());
                cmd.Parameters.AddWithValue("@phonenumber", UserDetails.PhoneNumber.ToString());
                try
                {
                    var reader = await cmd.ExecuteNonQueryAsync();
                    conn.Close();
                    return true;
                    //return false;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    conn.Close();
                    return false;
                }
            }
        }
    }
}
