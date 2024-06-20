using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class register
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Register(String details)
        {
            responseData resData = new responseData();
             try
            {
                var query = @"SELECT id, name, country, emailId, tourDescriptions, travelDates, durationOfTheStay, noOfPerson, contactNo FROM detailsdb.details";
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
                            name = rowData[1],
                            country = rowData[2],
                            emailId = rowData[3],
                            tourDescriptions = rowData[4],
                            travelDates = rowData[5],
                            durationOfTheStay = rowData[6],
                            noOfPerson = rowData[7],
                            contactNo = rowData[8]
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