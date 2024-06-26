using System;
using System.Collections.Generic;
using System.IO;
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
                string base64Image = null;

                if (rData.addInfo.ContainsKey("IMAGE"))
                {
                    var filePath = rData.addInfo["IMAGE"].ToString();
                    
                    // Check if the file exists
                    if (File.Exists(filePath))
                    {
                        byte[] imageData = File.ReadAllBytes(filePath);
                        base64Image = Convert.ToBase64String(imageData);
                    }
                    else
                    {
                        throw new FileNotFoundException("Image file not found at the specified path.");
                    }
                }
                else
                {
                    throw new KeyNotFoundException("IMAGE key not found in addInfo.");
                }

                MySqlParameter[] insertParams = new MySqlParameter[]
                {
                    new MySqlParameter("@IMAGE", MySqlDbType.LongText) { Value = base64Image },
                    new MySqlParameter("@HEADING", rData.addInfo["HEADING"].ToString()),
                    new MySqlParameter("@DETAILS", rData.addInfo["DETAILS"].ToString()),
                    new MySqlParameter("@BLOCK1", rData.addInfo["BLOCK1"].ToString()),
                    new MySqlParameter("@BLOCK2", rData.addInfo["BLOCK2"].ToString()),
                    new MySqlParameter("@VIEW_MORE", rData.addInfo["VIEW_MORE"].ToString())
                };

                var sq = @"INSERT INTO detailsdb.destination_card (IMAGE, HEADING, DETAILS, BLOCK1, BLOCK2, VIEW_MORE) 
                           VALUES (@IMAGE, @HEADING, @DETAILS, @BLOCK1, @BLOCK2, @VIEW_MORE)";

                var insertResult = ds.executeSQL(sq, insertParams);

                if (insertResult != null && insertResult.Count > 0 && insertResult[0] != null && insertResult[0].Count > 0)
                {
                    resData.rData["rCode"] = 0;
                    resData.rData["rMessage"] = "Inserted successfully";
                }
                else
                {
                    resData.rData["rCode"] = 1;
                    resData.rData["rMessage"] = "Failed to insert";
                }
            }
            catch (FileNotFoundException ex)
            {
                resData.rData["rCode"] = 1;
                resData.rData["rMessage"] = "File not found: " + ex.Message;
            }
            catch (KeyNotFoundException ex)
            {
                resData.rData["rCode"] = 1;
                resData.rData["rMessage"] = "Key not found in addInfo: " + ex.Message;
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
