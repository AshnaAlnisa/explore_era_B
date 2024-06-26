using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class plan_your_trip
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Plan_your_trip(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
               
                     var sq=@"insert into detailsdb.details(NAME,COUNTRY,EMAILID,TOURDESCRIPTIONS,TRAVELDATES,DURATIONOFTHESTAY,NOOFPERSON,CONTACTNO) values(@NAME,@COUNTRY,@EMAILID,@TOURDESCRIPTIONS,@TRAVELDATES,@DURATIONOFTHESTAY,@NOOFPERSON,@CONTACTNO)";
                     MySqlParameter[] insertParams = new MySqlParameter[]
                    {
                        new MySqlParameter("@NAME",rData.addInfo["NAME"]),
                        new MySqlParameter("@COUNTRY",rData.addInfo["COUNTRY"]),
                        new MySqlParameter("@EMAILID",rData.addInfo["EMAILID"]),
                        new MySqlParameter("@TOURDESCRIPTIONS",rData.addInfo["TOURDESCRIPTIONS"]),
                        new MySqlParameter("@TRAVELDATES",rData.addInfo["TRAVELDATES"]),
                        new MySqlParameter("@DURATIONOFTHESTAY",rData.addInfo["DURATIONOFTHESTAY"]),
                        new MySqlParameter("@NOOFPERSON",rData.addInfo["NOOFPERSON"]),
                        new MySqlParameter("@CONTACTNO",rData.addInfo["CONTACTNO"]),
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