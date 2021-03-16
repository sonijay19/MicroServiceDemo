using Api.Domain.Dtos.InsertUser;
using Api.Domain.Entities.Models;
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
        public async Task<bool> InsertUserDetailsAsync(InsertUserRequest UserDetails)
        {
            try
            {
                var context = new UserDetailsContext();
                var UserInformation = new UserDetail();
                UserInformation.UserEmail = UserDetails.UserEmail;
                UserInformation.FirstName = UserDetails.FirstName;
                UserInformation.LastName = UserDetails.LastName;
                UserInformation.PhoneNumber = UserDetails.PhoneNumber;
                UserInformation.UserTypeId = (int)Enum.Parse(typeof(UserAccessType), UserDetails.UserStatus) + 1;
                var result = await context.AddAsync(UserInformation);
                await context.SaveChangesAsync();
                Debug.Write(result);
                return true;
                /*string connectionstring =
                "Data Source=DESKTOP-02T0GUH\\SQLEXPRESS;Initial Catalog = UserDetails; User ID = DESKTOP-02T0GUH\\sonij; Password='';Integrated Security=true;";
                SqlConnection conn = new SqlConnection(connectionstring);
                string query = "INSERT INTO UserDetails (FirstName,LastName,UserEmail,UserTypeId,PhoneNumber) VALUES (@firstname,@lastname,@useremail,@userTypeId,@phonenumber)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    //@phonenumber
                    cmd.CommandType = CommandType.Text;
                    conn.Open();

                    cmd.Parameters.AddWithValue("@userTypeId", (int)Enum.Parse(typeof(UserAccessType), UserDetails.UserStatus) + 1);
                    cmd.Parameters.AddWithValue("@firstname", UserDetails.FirstName.ToString());
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
                }*/

            }
            catch (Exception e)
            { 
                Debug.Write(e);
                return false;
            }
        }
    }
}
