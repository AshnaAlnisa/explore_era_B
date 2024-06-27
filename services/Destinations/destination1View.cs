using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class destination1View
    {
        dbServices ds = new dbServices();
        public async Task<responseData>Destination1View(requestData req)

 {
            responseData resData = new responseData();

             try
            {
                // var query = @"SELECT * FROM detailsdb.destination_card WHERE id=@id";
                var query = @"SELECT * FROM detailsdb.destination1";
                // Add WHERE clause if filtering by email
                // query += " WHERE email = @Email";

                // MySqlParameter[] myParam = new MySqlParameter[] {
                //     new MySqlParameter("@id",req.addInfo["id"]),
                // };

                var dbData = ds.executeSQL(query, null); // pass myParam if filtering by email

                List<object> itemsList1 = new List<object>();
                

                foreach (var rowSet in dbData)
                {
                    foreach (var row in rowSet)
                    {
                        List<string> rowData = new List<string>();

                        foreach (var column in row)
                        {
                            rowData.Add(column.ToString());
                        }

                        // Construct destination1 object
                        var item1 = new
                        {
                            id = rowData[0],
                            image = rowData[1],
                            main_heading = rowData[2],
                            sub_heading = rowData[3],
                            box_heading1 = rowData[4],
                            box_details1 = rowData[5],
                            box_heading2 = rowData[6],
                            box_details2 = rowData[7],
                            box_heading3 = rowData[8],
                            box_details3 = rowData[9],
                            best_time_to_visit = rowData[10],
                            ideal_duration = rowData[11],
                            visa = rowData[12]
                        };

                        itemsList1.Add(item1);
                    }
                }

                resData.rData["items1"] = itemsList1;
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




