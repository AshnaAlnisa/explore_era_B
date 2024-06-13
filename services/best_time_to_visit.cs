using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class best_time_to_visit
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Best_time_to_visit(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
               
                    var sq=@"insert into detailsdb.best_time_to_visit(IMAGE,SUB_HEADING,DETAILS) values(@IMAGE,@SUB_HEADING,@DETAILS)";
                     MySqlParameter[] insertParams = new MySqlParameter[]
                    {
                        new MySqlParameter("@IMAGE",rData.addInfo["IMAGE"]),
                        new MySqlParameter("@SUB_HEADING",rData.addInfo["SUB_HEADING"]),
                        new MySqlParameter("@DETAILS",rData.addInfo["DETAILS"]),
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