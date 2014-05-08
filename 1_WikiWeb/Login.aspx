<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Wiki.Web.Login" MasterPageFile="~/MasterLogin.master" %>

<asp:Content ID="MainContent" runat="server" ContentPlaceHolderID="BodyContent">
    <form id="form1" runat="server">
    <div class="form-box" id="login-box">
        <div class="header bg-blue">
            Entrar!</div>
        <div class="body bg-gray">
            <div class="form-group">
                <input type="text" name="txtUserName" id="txtUserName" runat="server" value="angelom" class="form-control"
                    placeholder="Usuario" data-required="true" data-type="text" />
            </div>
            <div class="form-group">
                <input type="password" name="txtPassword" id="txtPassword" runat="server" value="Info1212" class="form-control"
                    placeholder="Password" data-required="true" data-type="text" />
            </div>
            <div class="form-group">
                <input type="checkbox" name="remember_me" />
                Recuerdame
            </div>
            <div id="loginResult" runat="server">
            </div>
        </div>
        <div class="footer">
            <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" OnClientClick="return ValidateForm('form1');"
                Text="Iniciar" class="btn bg-blue btn-block" />
            <p>
                <a href="#">Olvide mi contraseña</a>
            </p>
            <a href="#" class="text-center">Registrarme</a>
        </div>
    </div>
    </form>
</asp:Content>
