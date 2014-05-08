<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EditPost.aspx.cs" Inherits="Wiki.Web.pagesPost.EditPost" EnableEventValidation="false"
    ValidateRequest="false" EnableViewState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <aside class="right-side">
        <section class="content-header">
            <h1>
                Editar post! <small>Que paso?</small>
            </h1>
            <ol class="breadcrumb">
                <li><a href="#"><i class="fa fa-dashboard"></i>Home</a></li>
                <li><a href="#">Forms</a></li>
                <li class="active">Editors</li>
            </ol>
        </section>
        <section class="content">
            <div class='row'>
                <div class='col-md-12'>
                    <div class='box box-info'>
                        <div class='box-body pad'>
                            <form id="form1" runat="server">
                            <div id="operationResult" runat="server">                                
                            </div>
                            <div class="form-group">
                                <label>
                                    Título</label>
                                <input type="text" class="form-control" id="txtTitle" name="txtTitle" runat="server" placeholder="Enter ..." />
                            </div>
                            <div class="form-group">
                                <label>
                                    Contenido</label>
                                <asp:TextBox ID="txtContent" runat="server" TextMode="MultiLine" Rows="50" Columns="100" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-4">
                                        <label>
                                            Topic</label>
                                        <asp:DropDownList CssClass="form-control" runat="server" DataSourceID="odsTopics" ID="cboTopic" DataTextField="Name"
                                            DataValueField="TopicId">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odsTopics" runat="server" SelectMethod="GetTopics" TypeName="Wiki.Web.pagesPost.EditPost" />
                                    </div>
                                    <div class="col-xs-4">
                                        <label>
                                            Sub topic</label>
                                        <asp:DropDownList CssClass="form-control" runat="server" ID="cboSubTopics" DataTextField="Name" DataValueField="SubTopicId">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-xs-4">
                                        <label>
                                            Nivel</label>
                                        <asp:DropDownList CssClass="form-control" runat="server" DataSourceID="odsLevels" ID="cboLevel" DataTextField="Description"
                                            DataValueField="DifficultyLevelId" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:ObjectDataSource ID="odsLevels" runat="server" SelectMethod="GetLevels" TypeName="Wiki.Web.pagesPost.EditPost" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <label>
                                    Tags <small>(separados por ",")</small></label>
                                <textarea class="form-control" rows="3" id="txtTags" name="txtTags" runat="server" placeholder="Ingrese los tags mas descriptivos que se le ocurran"></textarea>
                            </div>
                            <div class="form-group">
                                <div class="row">
                                    <div class="col-xs-12">
                                    <div class="pull-right">                                        
                                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" OnClientClick="return ValidateForm('form1');" Text="Guardar"
                                            class="btn btn-success" />
                                    </div>
                                    </div>
                                </div>
                            </div>
                            <asp:HiddenField runat="server" ID="encryptedKey" />
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </aside>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentFooter" runat="server">
    <script src="<%=this.ApplicationRoot %>template/js/plugins/ckeditor/ckeditor.js"
        type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace('txtContent');
        });        
    </script>
    <script type="text/javascript">
        $(document).on("ready", function () {
            $("#<%=cboTopic.ClientID%>").change(function () {
                idSelected = $(this).val();
                $.ajax({
                    url: "<%=this.ApplicationRoot %>Ajax/GetSubTopicsByTopicId.ashx?topicId=" + idSelected,
                    type: "POST",
                    success: function (data) {
                        $("#<%=cboSubTopics.ClientID%>").html(data);
                    }
                    //,
                    //error: function () {
                    //    alert("error...");
                    //}
                });
            });
        });
    </script>
</asp:Content>
