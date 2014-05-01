using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wiki.Common.Classes;
using System.Data;

namespace Wiki.DataBase.DataBaseClasses
{
    public class PostDataBase : BaseDataBase
    {

        public bool InsertPost(Post post)
        {
            var parameters = new DataAccessParameter[7];
            parameters[0] = new DataAccessParameter("@TopicId", post.Topic.TopicId, typeof(int), null, ParameterDirection.Input);
            parameters[1] = new DataAccessParameter("@SubTopicId", post.SubTopic.SubTopicId, typeof(int), null, ParameterDirection.Input);
            parameters[2] = new DataAccessParameter("@UserId", post.User.UserId, typeof(int), null, ParameterDirection.Input);
            parameters[3] = new DataAccessParameter("@DifficultyLevelId", post.DifficultyLevel.DifficultyLevelId, typeof(int), null, ParameterDirection.Input);
            parameters[4] = new DataAccessParameter("@Tags", post.Tags, typeof(string), null, ParameterDirection.Input);
            parameters[5] = new DataAccessParameter("@ContentPost", post.ContentPost, typeof(string), null, ParameterDirection.Input);
            parameters[6] = new DataAccessParameter("@Title", post.Title, typeof(string), null, ParameterDirection.Input);

            return (1 == WikiDBAdapter.ExecuteStoredProcedure("InsertPost", parameters));
        }
		
		public bool UpdatePost(Post post)
        {
            var parameters = new DataAccessParameter[8];
            parameters[0] = new DataAccessParameter("@PostId", post.PostId, typeof(int), null, ParameterDirection.Input);
			parameters[1] = new DataAccessParameter("@TopicId", post.Topic.TopicId, typeof(int), null, ParameterDirection.Input);
            parameters[2] = new DataAccessParameter("@SubTopicId", post.SubTopic.SubTopicId, typeof(int), null, ParameterDirection.Input);
            parameters[3] = new DataAccessParameter("@UserId", post.User.UserId, typeof(int), null, ParameterDirection.Input);
            parameters[4] = new DataAccessParameter("@DifficultyLevelId", post.DifficultyLevel.DifficultyLevelId, typeof(int), null, ParameterDirection.Input);
            parameters[5] = new DataAccessParameter("@Tags", post.Tags, typeof(string), null, ParameterDirection.Input);
            parameters[6] = new DataAccessParameter("@ContentPost", post.ContentPost, typeof(string), null, ParameterDirection.Input);
            parameters[7] = new DataAccessParameter("@Title", post.Title, typeof(string), null, ParameterDirection.Input);

            return (1 == WikiDBAdapter.ExecuteStoredProcedure("UpdatePost", parameters));
        }
		
		public bool DeletePost(Post post)
        {
            var parameters = new DataAccessParameter[1];
            parameters[0] = new DataAccessParameter("@PostId", post.PostId, typeof(int), null, ParameterDirection.Input);

            return (1 == WikiDBAdapter.ExecuteStoredProcedure("DeletePost", parameters));
        }

		 public bool IsUserOwnerPost(Post post, User user)
        {
            DataAccessParameter[] parameters = new DataAccessParameter[2];
            parameters[0] = new DataAccessParameter("@PostId", post.PostId, typeof(int), null, ParameterDirection.Input);
			parameters[1] = new DataAccessParameter("@UserId", user.UserId, typeof(int), null, ParameterDirection.Input);

            DataTable dt = WikiDBAdapter.GetDataTable("IsUserOwnerPost", parameters);
            bool result = false;

            if (dt != null && dt.Rows.Count > 0)
            {
                result = true;
            }
            return result;
        }		
		
        /// <summary>
        /// Obtiene la información de un post por id
        /// </summary>
        /// <param name="post">Post con el id</param>
        /// <returns></returns>
        public Post GetPostById(Post post)
        {
            DataAccessParameter[] parameters = new DataAccessParameter[1];
            parameters[0] = new DataAccessParameter("@PostId", post.PostId, typeof(int), null, ParameterDirection.Input);

            DataTable dt = WikiDBAdapter.GetDataTable("GetPostById", parameters);
            Post result = new Post();

            if (dt != null && dt.Rows.Count > 0)
            {
                var dsm = new DataSetMapper<Post>();
                result = dsm.ConvertSingleFromBackend(dt.Rows[0]);
            }
            return result;
        }

        /// <summary>
        /// Retornna todos los post relacionados a un subtopic
        /// </summary>
        /// <param name="subTopic">Sub topic del cual se quieren obtener los post</param>
        /// <returns></returns>
        public List<Post> GetPostBySubTopicId(SubTopic subTopic)
        {
            DataSet ds = WikiDBAdapter.GetDataSet("GetPostBySubTopicId",
                    new DataAccessParameter("@SubTopicId", subTopic.SubTopicId, typeof(int), null, ParameterDirection.Input));

            List<Post> postResult = new List<Post>();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable myTable = ds.Tables[0];
                if (myTable != null && myTable.Rows.Count > 0)
                {
                    var dsm = new DataSetMapper<Post>();
                    postResult = dsm.ConvertFromBackend<List<Post>>(myTable);
                }
            }
            return postResult;
        }

		public List<Post> GetPostByUserId(User user)
        {
            DataSet ds = WikiDBAdapter.GetDataSet("GetPostByUserId",
                    new DataAccessParameter("@UserId", user.UserId, typeof(int), null, ParameterDirection.Input));

            List<Post> postResult = new List<Post>();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable myTable = ds.Tables[0];
                if (myTable != null && myTable.Rows.Count > 0)
                {
                    var dsm = new DataSetMapper<Post>();
                    postResult = dsm.ConvertFromBackend<List<Post>>(myTable);
                }
            }
            return postResult;
        }

    }
}
