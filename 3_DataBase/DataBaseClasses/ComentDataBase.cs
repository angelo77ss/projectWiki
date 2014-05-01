using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wiki.Common.Classes;
using System.Data;

namespace Wiki.DataBase.DataBaseClasses
{
    public class ComentDataBase : BaseDataBase
    {

        public bool InsertComent(Coment coment)
        {
            var parameters = new DataAccessParameter[4];
            parameters[0] = new DataAccessParameter("@PostId", coment.Post.PostId, typeof(int), null, ParameterDirection.Input);
            parameters[1] = new DataAccessParameter("@ComentReferenceId", coment.ComentReferenceId, typeof(int), null, ParameterDirection.Input);
            parameters[2] = new DataAccessParameter("@ComentText", coment.ComentText, typeof(int), null, ParameterDirection.Input);
            parameters[3] = new DataAccessParameter("@UserId", coment.User.UserId, typeof(int), null, ParameterDirection.Input);

            return (1 == WikiDBAdapter.ExecuteStoredProcedure("InsertComent", parameters));
        }

        public bool DeleteComent(Coment coment)
        {
            var parameters = new DataAccessParameter[1];
            parameters[0] = new DataAccessParameter("@ComentId", coment.ComentId, typeof(int), null, ParameterDirection.Input);

            return (1 == WikiDBAdapter.ExecuteStoredProcedure("DeleteComent", parameters));
        }

        public bool IsUserOwnerComent(Coment coment, User user)
        {
            DataAccessParameter[] parameters = new DataAccessParameter[2];
            parameters[0] = new DataAccessParameter("@ComentId", coment.ComentId, typeof(int), null, ParameterDirection.Input);
            parameters[1] = new DataAccessParameter("@UserId", user.UserId, typeof(int), null, ParameterDirection.Input);

            DataTable dt = WikiDBAdapter.GetDataTable("IsUserOwnerComent", parameters);
            bool result = false;

            if (dt != null && dt.Rows.Count > 0)
            {
                result = true;
            }
            return result;
        }

    }
}
