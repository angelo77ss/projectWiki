using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Wiki.Common.Classes;

namespace Wiki.DataBase.DataBaseClasses
{
    public class LoginDataBase : BaseDataBase
    {

        public User GetUserByUserName(string userName)
        {
            DataAccessParameter[] parameters = new DataAccessParameter[1];
            parameters[0] = new DataAccessParameter("@UserName", userName, typeof(string), null, ParameterDirection.Input);

            DataTable dt = WikiDBAdapter.GetDataTable("GetUserByUserName", parameters);
            User user = new User();

            if (dt != null && dt.Rows.Count > 0)
            {
                var dsm = new DataSetMapper<User>();
                user = dsm.ConvertSingleFromBackend(dt.Rows[0]);
            }
            return user;
        }

        //**********************************************************************************
        //**********************************************************************************
        //**********************************************************************************

        //EJEMPLOS


        public User Login()
        {
            DataTable dt = WikiDBAdapter.GetDataTable("GetNewsConfiguration");
            User user = new User();
            if (dt != null && dt.Rows.Count > 0)
            {
                var dsm = new DataSetMapper<User>();
                user = dsm.ConvertSingleFromBackend(dt.Rows[0]);
            }
            return user;
        }

        public List<User> GetNewsItems()
        {
            DataSet ds = WikiDBAdapter.GetDataSet("GetNewsItems");
            List<User> newsItems = new List<User>();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable myTable = ds.Tables[0];
                if (myTable != null && myTable.Rows.Count > 0)
                {
                    var dsm = new DataSetMapper<User>();
                    newsItems = dsm.ConvertFromBackend<List<User>>(myTable);
                }
            }
            return newsItems;
        }

        public bool UpdatePushNotificationNews(User user)
        {
            var inputParameters = new DataAccessParameter[1];
            inputParameters[0] = new DataAccessParameter("@NewsItemId", user.UserId, typeof(int));

            return (1 == WikiDBAdapter.ExecuteStoredProcedure("UpdatePushNotificationNews", inputParameters));
        }

        public int CountCompanyActiveUsersInvArea(string search_column, string search_data)
        {
            var outputParameter = new DataAccessParameter("@count", null, typeof(string), null, ParameterDirection.Output);

            WikiDBAdapter.ExecuteStoredProcedure("CountCompanyActiveUsersInvArea", outputParameter,
                  new DataAccessParameter("@search_column", search_column, typeof(int), ParameterDirection.Input),
                  new DataAccessParameter("@search_data", search_data, typeof(string), ParameterDirection.Input));
            return Convert.ToInt32(outputParameter.Value);
        }

    }
}
