using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class dcInsert
    {
        dbServices ds = new dbServices();
        public async Task<responseData> DcInsert(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
               
                    // var sq=@"insert into detailsdb.enquiryForm(IMAGE,HEADING,DETAILS,BLOCK1,BLOCK2,VIEW_MORE) values(@IMAGE,@HEADING,@DETAILS,@BLOCK1,@BLOCK2,@VIEW_MORE)";
                    var sq=@"update detailsdb.destination_card set(IMAGE=@IMAGE,HEADING=@HEADING,DETAILS=@DETAILS,BLOCK1=@BLOCK1,BLOCK2=@BLOCK2,VIEW_MORE=@VIEW_MORE) where id=@id";

                     MySqlParameter[] insertParams = new MySqlParameter[]
                    {
                        new MySqlParameter("@id", rData.addInfo["id"]) ,
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