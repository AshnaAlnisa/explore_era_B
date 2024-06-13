using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class destination1
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Destination1(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
               
                    var sq=@"insert into detailsdb.destination1(IMAGE,MAIN_HEADING,SUB_HEADING,BOX_HEADING1,BOX_DETAILS1,BOX_HEADING2, BOX_DETAILS2,BOX_HEADING3,BOX_DETAILS3,BEST_TIME_TO_VISIT,IDEAL_DURATION,VISA) values(@IMAGE,@MAIN_HEADING,@SUB_HEADING,@BOX_HEADING1,@BOX_DETAILS1,@BOX_HEADING2,@BOX_DETAILS2,@BOX_HEADING3,@BOX_DETAILS3,@BEST_TIME_TO_VISIT,@IDEAL_DURATION,@VISA)";
                     MySqlParameter[] insertParams = new MySqlParameter[]
                    {
                        new MySqlParameter("@IMAGE",rData.addInfo["IMAGE"]),
                        new MySqlParameter("@MAIN_HEADING",rData.addInfo["MAIN_HEADING"]),
                        new MySqlParameter("@SUB_HEADING",rData.addInfo["SUB_HEADING"]),
                        new MySqlParameter("@BOX_HEADING1",rData.addInfo["BOX_HEADING1"]),
                        new MySqlParameter("@BOX_DETAILS1",rData.addInfo["BOX_DETAILS1"]),
                        new MySqlParameter("@BOX_HEADING2",rData.addInfo["BOX_HEADING2"]),
                        new MySqlParameter("@BOX_DETAILS2",rData.addInfo["BOX_DETAILS2"]),
                        new MySqlParameter("@BOX_HEADING3",rData.addInfo["BOX_HEADING3"]),
                        new MySqlParameter("@BOX_DETAILS3",rData.addInfo["BOX_DETAILS3"]),
                        new MySqlParameter("@BEST_TIME_TO_VISIT",rData.addInfo["BEST_TIME_TO_VISIT"]),
                        new MySqlParameter("@IDEAL_DURATION",rData.addInfo["IDEAL_DURATION"]),
                        new MySqlParameter("@VISA",rData.addInfo["VISA"]),
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