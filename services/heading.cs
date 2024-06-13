using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class heading
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Heading(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
               
                    var sq=@"insert into detailsdb.heading(HEADING) values(@HEADING)";
                     MySqlParameter[] insertParams = new MySqlParameter[]
                    {
                        new MySqlParameter("@HEADING",rData.addInfo["HEADING"]),
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