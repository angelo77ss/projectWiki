using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wiki.Web.Classes;
using Wiki.Common.Classes;
using Wiki.Common.Util;
using Wiki.Logic.LogicClasses;

namespace Wiki.Web
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                User user = new User();
                user.Password = Encryption.GetSHA512Hash(this.txtPassword.Value);
                user.UserName = this.txtUserName.Value;

                user = new LoginLogic().Login(user);
                if (user.LoginResult)
                {
                    this.WebProfile.User = user;
                    Response.Redirect("~/pagesPost/ViewPost.aspx?postId=" + this.URLParams.EncodeParam("12".ToString()), false);
                }
                else
                {
                    this.loginResult.InnerHtml = this.MessageDanger(user.LoginResultMessage);
                }
            }
        }
    }
}