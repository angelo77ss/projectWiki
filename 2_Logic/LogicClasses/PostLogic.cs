using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wiki.DataBase.DataBaseClasses;
using Wiki.Common.Classes;
using Wiki.Common.Util;

namespace Wiki.Logic.LogicClasses
{
    public class PostLogic : BaseLogic
    {
        private PostDataBase postDB = new PostDataBase();

        public bool InsertPost(Post post)
        {
            bool result = false;
            try
            {
                result = postDB.InsertPost(post);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            return result;
        }
		
		public Post UpdatePost(Post post, User user)
        {
            try
            {
				if(IsUserOwnerPost(post, user)){
					post.OperationResult = postDB.UpdatePost(post);
				}else{
					post.OperationResult = false;
					post.OperationMessage = "El usuario no es propietario.";
				}     
            }
            catch (Exception ex)
            {
                this.LogError(ex);
				post.OperationResult = false;
                post.OperationMessage = "Ocurrió un error realizando la operación.";
            }
            return post;
        }
		
		public Post DeletePost(Post post, User user)
        {
            try
            {
				if(IsUserOwnerPost(post, user)){
					post.OperationResult = postDB.DeletePost(post);
				}else{
					post.OperationResult = false;
					post.OperationMessage = "El usuario no es propietario.";
				}               
            }
            catch (Exception ex)
            {
                this.LogError(ex);
				post.OperationResult = false;
                post.OperationMessage = "Ocurrió un error realizando la operación.";
            }
            return post;
        }

		public bool IsUserOwnerPost(Post post, User user)
        {
            bool result = false;
            try
            {
                result = postDB.IsUserOwnerPost(post, user);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            return result;
        }
		
        public Post GetPostById(Post post)
        {
            Post result = new Post();
            try
            {
                result = postDB.GetPostById(post);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            return result;
        }

        public List<Post> GetPostBySubTopicId(SubTopic subTopic)
        {
            List<Post> result = new List<Post>();
            try
            {
                result = postDB.GetPostBySubTopicId(subTopic);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            return result;
        }
		
		 public List<Post> GetPostByUserId(User user)
        {
            List<Post> result = new List<Post>();
            try
            {
                result = postDB.GetPostByUserId(user);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            return result;
        }
    }
}
