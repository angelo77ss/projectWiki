using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wiki.DataBase.DataBaseClasses;
using Wiki.Common.Classes;

namespace Wiki.Logic.LogicClasses
{
    public class ComentLogic : BaseLogic
    {

        private ComentDataBase comentDB = new ComentDataBase();

        public bool InsertComent(Coment coment)
        {
            bool result = false;
            try
            {
                result = comentDB.InsertComent(coment);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            return result;
        }

        public Coment DeleteComent(Coment coment, User user)
        {
            try
            {
                if (IsUserOwnerComent(coment, user))
                {
                    coment.OperationResult = comentDB.DeleteComent(coment);
                }
                else
                {
                    coment.OperationResult = false;
                    coment.OperationMessage = "El usuario no es propietario.";
                }
            }
            catch (Exception ex)
            {
                this.LogError(ex);
                coment.OperationResult = false;
                coment.OperationMessage = "Ocurrió un error realizando la operación.";
            }
            return coment;
        }

        public bool IsUserOwnerComent(Coment coment, User user)
        {
            bool result = false;
            try
            {
                result = comentDB.IsUserOwnerComent(coment, user);
            }
            catch (Exception ex)
            {
                this.LogError(ex);
            }
            return result;
        }
    }
}
