using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class homeView
    {
        dbServices ds = new dbServices();
        public async Task<responseData>HomeView(requestData req)

 {
            responseData resData = new responseData();

             try
            {
                // var query = @"SELECT * FROM detailsdb.destination_card WHERE id=@id";
                var query = @"SELECT * FROM detailsdb.home_page";
                // Add WHERE clause if filtering by email
                // query += " WHERE email = @Email";

                // MySqlParameter[] myParam = new MySqlParameter[] {
                //     new MySqlParameter("@id",req.addInfo["id"]),
                // };

                var dbData = ds.executeSQL(query, null); // pass myParam if filtering by email

                List<object> itemsList = new List<object>();
                

                foreach (var rowSet in dbData)
                {
                    foreach (var row in rowSet)
                    {
                        List<string> rowData = new List<string>();

                        foreach (var column in row)
                        {
                            rowData.Add(column.ToString());
                        }

                        // Construct item object
                        var item = new
                        {
                            id = rowData[0],
                            image = rowData[1],
                            heading = rowData[2],
                            details = rowData[3],
                            link = rowData[4],
                            
                        };

                        itemsList.Add(item);
                    }
                }

                resData.rData["items"] = itemsList;
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









