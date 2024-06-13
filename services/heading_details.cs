using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class heading_details
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Heading_details(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
               
                    var sq=@"insert into detailsdb.heading_details(HEADING1,DETAILS1,HEADING2,DETAILS2,HEADING3,DETAILS3, HEADING4,DETAILS4,HEADING5,DETAILS5,HEADING6,DETAILS6,HEADING7,DETAILS7,HEADING8,DETAILS8,HEADING9,DETAILS9,HEADING10,DETAILS10) values(@HEADING1,@DETAILS1,@HEADING2,@DETAILS2,@HEADING3,@DETAILS3,@HEADING4,@DETAILS4,@HEADING5,@DETAILS5,@HEADING6,@DETAILS6,@HEADING7,@DETAILS7,@HEADING8,@DETAILS8,@HEADING9,@DETAILS9,@HEADING10,@DETAILS10)";
                     MySqlParameter[] insertParams = new MySqlParameter[]
                    {
                        new MySqlParameter("@HEADING1",rData.addInfo["HEADING1"]),
                        new MySqlParameter("@DETAILS1",rData.addInfo["DETAILS1"]),
                        new MySqlParameter("@HEADING2",rData.addInfo["HEADING2"]),
                        new MySqlParameter("@DETAILS2",rData.addInfo["DETAILS2"]),
                        new MySqlParameter("@HEADING3",rData.addInfo["HEADING3"]),
                        new MySqlParameter("@DETAILS3",rData.addInfo["DETAILS3"]),
                        new MySqlParameter("@HEADING4",rData.addInfo["HEADING4"]),
                        new MySqlParameter("@DETAILS4",rData.addInfo["DETAILS4"]),
                        new MySqlParameter("@HEADING5",rData.addInfo["HEADING5"]),
                        new MySqlParameter("@DETAILS5",rData.addInfo["DETAILS5"]),
                        new MySqlParameter("@HEADING6",rData.addInfo["HEADING6"]),
                        new MySqlParameter("@DETAILS6",rData.addInfo["DETAILS6"]),
                        new MySqlParameter("@HEADING7",rData.addInfo["HEADING7"]),
                        new MySqlParameter("@DETAILS7",rData.addInfo["DETAILS7"]),
                        new MySqlParameter("@HEADING8",rData.addInfo["HEADING8"]),
                        new MySqlParameter("@DETAILS8",rData.addInfo["DETAILS8"]),
                        new MySqlParameter("@HEADING9",rData.addInfo["HEADING9"]),
                        new MySqlParameter("@DETAILS9",rData.addInfo["DETAILS9"]),
                        new MySqlParameter("@HEADING10",rData.addInfo["HEADING10"]),
                        new MySqlParameter("@DETAILS10",rData.addInfo["DETAILS10"]),
                        
                      
                        
                    };
                    var insertResult = ds.executeSQL(sq, insertParams);

                    resData.rData["rMessage"] = "Successful";
                    
            }
            catch (Exception ex)
            {

                throw;
            }
            return resData;
        }
    }
}