using System;
using Wiki.DataBase.DataBaseClasses;
using Wiki.Common.Classes;

namespace Wiki.Logic.LogicClasses
{
    public class LoginLogic : BaseLogic
    {

        private LoginDataBase loginDB = new LoginDataBase();

        public User Login(User user)
        {
            User result = new User();
            try
            {
                result = loginDB.GetUserByUserName(user.UserName);
                if (result.UserId != 0)
                {
                    if (result.Password.Equals(user.Password))
                    {
                        result.LoginResult = true;
                        result.LoginResultMessage = "Ok.";
                    }
                    else
                    {
                        result.LoginResult = false;
                        result.LoginResultMessage = "Contraseña incorrecta.";
                    }
                }
                else
                {
                    result.LoginResult = false;
                    result.LoginResultMessage = "Usuario o contraseña incorrecta.";
                }
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            return result;
        }

    }
}
