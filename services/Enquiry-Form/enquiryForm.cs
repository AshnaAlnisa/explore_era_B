using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class enquiryForm
    {
        dbServices ds = new dbServices();

        public async Task<responseData> EnquiryForm(string details)
        {
            responseData resData = new responseData();
            try
            {
                var query = @"SELECT id, fullName, tourDescription, departureDate, numberOfDays, email, contactNo FROM detailsdb.enquiryForm";
                // Add WHERE clause if filtering by email
                // query += " WHERE email = @Email";

                // MySqlParameter[] myParam = new MySqlParameter[] {
                //     new MySqlParameter("@Email", email)
                // };

                var dbData = ds.executeSQL(query, null); // pass myParam if filtering by email

                List<object> usersList = new List<object>();

                foreach (var rowSet in dbData)
                {
                    foreach (var row in rowSet)
                    {
                        List<string> rowData = new List<string>();

                        foreach (var column in row)
                        {
                            rowData.Add(column.ToString());
                        }

                        // Construct user object
                        var user = new
                        {
                            id = rowData[0],
                            fullName = rowData[1],
                            tourDescription = rowData[2],
                            departureDate = rowData[3],
                            numberOfDays = rowData[4],
                            email = rowData[5],
                            contactNo = rowData[6]
                        };

                        usersList.Add(user);
                    }
                }

                resData.rData["users"] = usersList;
                resData.rData["rMessage"] = "Successful";
            }
            catch (Exception ex)
            {
                resData.rData["rMessage"] = "Exception occurred: " + ex.Message;
            }

            return resData;
        }
    }
}
