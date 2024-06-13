using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class myLogin
    {
        dbServices ds = new dbServices();
        public async Task<responseData> MyLogin(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
                var query = @"SELECT * FROM detailsdb.signuplogin where EMAILID=@EMAILID AND PASSWORD=@PASSWORD";
                MySqlParameter[] myParam = new MySqlParameter[]
                {
                new MySqlParameter("@EMAILID",rData.addInfo["EMAILID"]),
                new MySqlParameter("@PASSWORD",rData.addInfo["PASSWORD"]),
                
            
                };
                var dbData = ds.executeSQL(query, myParam);
                if (dbData[0].Count() > 0)
                {
                    resData.rData["rMessage"] = "Login Successfull";
                }
                else
                {

                    resData.rData["rMessage"] = "Invalid Credentials";
                    
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return resData;
        }

        private string GetStringFromAddInfo(requestData rData, string key)
        {
            if (rData.addInfo.ContainsKey(key))
            {
                return rData.addInfo[key].ToString();
            }
            else
            {
                return "N/A";
            }
        }
    }
}