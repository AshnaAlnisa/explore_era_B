using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class imageInsert
    {
        dbServices ds = new dbServices();
        public async Task<responseData> ImageInsert(requestData rData)
        {
            responseData resData = new responseData();
             try
            {
                byte[] imageData = null;

                if (rData.addInfo.ContainsKey("IMAGE"))
                {
                    var filePath = rData.addInfo["IMAGE"].ToString();
                    imageData = File.ReadAllBytes(filePath);
                }
                MySqlParameter[] insertParams = new MySqlParameter[]
              {
                        new MySqlParameter("@IMAGE", MySqlDbType.Blob) { Value = imageData },
                        new MySqlParameter("@HEADING", rData.addInfo["HEADING"].ToString()),
                        new MySqlParameter("@DETAILS", rData.addInfo["DETAILS"].ToString()),
                        new MySqlParameter("@BLOCK1", rData.addInfo["BLOCK1"].ToString())  ,
                        new MySqlParameter("@BLOCK2", rData.addInfo["BLOCK2"].ToString()),
                        new MySqlParameter("@VIEW_MORE", rData.addInfo["VIEW_MORE"].ToString()),
              };
                var sq = @"insert into detailsdb.destination_card(IMAGE,HEADING,DETAILS,BLOCK1,BLOCK2,VIEW_MORE) values(@IMAGE,@HEADING,@DETAILS,@BLOCK1,@BLOCK2,@VIEW_MORE)";

                var insertResult = ds.executeSQL(sq, insertParams);
                if (insertResult[0].Count() == null)
                {
                    resData.rData["rCode"] = 1;
                    resData.rData["rMessage"] = "Failed to insert";
                }
                else
                {
                    resData.rData["rCode"] = 0;
                    resData.rData["rMessage"] = "Inserted successfully";

                }
            }
            catch (Exception ex)
            {
                resData.rData["rCode"] = 1;
                resData.rData["rMessage"] = "An error occurred: " + ex.Message;
            }
            return resData;
        }
    }
}