using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class destination_card
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Destination_card(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
               
                    var sq=@"insert into detailsdb.destination_card(IMAGE,HEADING,DETAILS,BLOCK1,BLOCK2,VIEW_MORE) values(@IMAGE,@HEADING,@DETAILS,@BLOCK1,@BLOCK2,@VIEW_MORE)";
                     MySqlParameter[] insertParams = new MySqlParameter[]
                    {
                        new MySqlParameter("@IMAGE",rData.addInfo["IMAGE"]),
                        new MySqlParameter("@HEADING",rData.addInfo["HEADING"]),
                        new MySqlParameter("@DETAILS",rData.addInfo["DETAILS"]),
                        new MySqlParameter("@BLOCK1",rData.addInfo["BLOCK1"]),
                        new MySqlParameter("@BLOCK2",rData.addInfo["BLOCK2"]),
                        new MySqlParameter("@VIEW_MORE",rData.addInfo["VIEW_MORE"]),
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