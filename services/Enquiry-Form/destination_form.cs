using System.Collections.Generic;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace COMMON_PROJECT_STRUCTURE_API.services
{
    public class destination_form
    {
        dbServices ds = new dbServices();
        public async Task<responseData> Destination_form(requestData rData)
        {
            responseData resData = new responseData();
            try
            {
               
                    var sq=@"insert into detailsdb.enquiryForm(FULLNAME,TOURDESCRIPTION,DEPARTUREDATE,NUMBEROFDAYS,EMAIL,CONTACTNO) values(@FULLNAME,@TOURDESCRIPTION,@DEPARTUREDATE,@NUMBEROFDAYS,@EMAIL,@CONTACTNO)";
                     MySqlParameter[] insertParams = new MySqlParameter[]
                    {
                        new MySqlParameter("@FULLNAME",rData.addInfo["FULLNAME"]),
                        new MySqlParameter("@TOURDESCRIPTION",rData.addInfo["TOURDESCRIPTION"]),
                        new MySqlParameter("@DEPARTUREDATE",rData.addInfo["DEPARTUREDATE"]),
                        new MySqlParameter("@NUMBEROFDAYS",rData.addInfo["NUMBEROFDAYS"]),
                        new MySqlParameter("@EMAIL",rData.addInfo["EMAIL"]),
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