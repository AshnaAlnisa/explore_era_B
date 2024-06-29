using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class destination_card
    {
        dbServices ds = new dbServices();
        public async Task<responseData>Destination_card(requestData req)

 {
            responseData resData = new responseData();

             try
            {
                // var query = @"SELECT * FROM detailsdb.destination_card WHERE id=@id";
                var query = @"SELECT * FROM detailsdb.destination_card";
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
                            block1 = rowData[4],
                            block2 = rowData[5],
                            view_more = rowData[6],
                            link = rowData[7]
                            
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









// resData.rData["rCode"] = 0;
            // try
            // {
            //     var list = new ArrayList();
            //     MySqlParameter[] myParams = new MySqlParameter[] {
            //     new MySqlParameter("@id", req.addInfo["id"]),
            //     };
            //     var sq = $"SELECT * FROM detailsdb.destination_card WHERE id=@id";
            //     var data = ds.ExecuteSQLName(sq, myParams);

            //     if (data == null || data[0].Count() == 0)
            //     {
            //         resData.rData["rCode"] = 1;
            //         resData.rData["rMessage"] = "No user is present...";
            //     }
            //     else
            //     {

            //         resData.rData["id"] = data[0][0]["id"];
            //         resData.rData["image"] = data[0][0]["IMAGE"];
            //         resData.rData["heading"] = data[0][0]["HEADING"];
            //         resData.rData["details"] = data[0][0]["DETAILS"];
            //         resData.rData["block1"] = data[0][0]["BLOCK1"];
            //         resData.rData["block2"] = data[0][0]["BLOCK2"];
            //         resData.rData["view_more"] = data[0][0]["VIEW_MORE"];
                    
            //     }

            // }
            // catch (Exception ex)
            // {
            //     resData.rData["rCode"] = 1;
            //     resData.rData["rMessage"] = ex.Message;

            // }