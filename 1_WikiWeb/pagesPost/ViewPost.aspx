<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPost.aspx.cs"
    Inherits="Wiki.Web.pagesPost.ViewPost" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="<%=this.ApplicationRoot %>template/syntaxhighlighter_3.0.83/styles/shCoreDefault.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <aside class="right-side">
        <section class="content-header">
            <h1>
                Detalle del post! <small>sera lo que buscas?</small>
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
                            <form id="Form1" runat="server">
                            <div class="row">
                                <div class="col-xs-12">
                                    <h2 runat="server" id="lblTitle">
                                    </h2>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-4">
                                    <h4>
                                        Tema: <small runat="server" id="lblTopic"></small>
                                    </h4>
                                    <h4>
                                        Sub tema: <small runat="server" id="lblSubTopic"></small>
                                    </h4>
                                    <h4>
                                        Nivel: <small runat="server" id="lblLevel"></small>
                                    </h4>
                                </div>
                                <div class="col-xs-8">
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <div class="pull-right">
                                                <a runat="server" id="btnFavorite" class="btn btn-warning"><i class="fa fa-fw fa-heart"></i>Favorito!</a>
                                                <a runat="server" id="btnEdit" class="btn btn-success"><i class="fa fa-fw fa-pencil"></i>Editar</a>
                                                <a runat="server" id="btnDelete" class="btn btn-danger"><i class="fa fa-fw fa-trash-o"></i>Eliminar</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-xs-12">
                                    <span class="label label-info">Tags asdasdsad</span> <span class="label label-info">Tags asd</span>
                                    <span class="label label-info">Tags322tgfg</span> <span class="label label-info">Tags322tgfg</span>
                                    <span class="label label-info">Tags322tgfg</span> <span class="label label-info">Tags asdasd</span>
                                    <span class="label label-info">Tags 234234</span> <span class="label label-info">Tags322tgfg</span>
                                    <span class="label label-info">Tags asda</span> <span class="label label-info">Tags asda</span> <span
                                        class="label label-info">Tags322tgfg</span> <span class="label label-info">Tags322tgfg</span>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-xs-12" id="operationResult" runat="server">
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-xs-12">
                                    <h2>
                                        Comentarios...
                                    </h2>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col-xs-12">
                                    <ul class="timeline">
                                        <%--<li class="time-label"><span class="bg-red">10 Feb. 2014 </span></li>--%>
                                        <li><i class="fa fa-comment bg-blue"></i>
                                            <div class="timeline-item">
                                                <span class="time"><i class="fa fa-clock-o"></i>20/04/2014 12:05</span>
                                                <h3 class="timeline-header">
                                                    <a href="#">Nombre del usuario</a></h3>
                                                <div class="timeline-body">
                                                    Contenido del comentario {original}
                                                </div>
                                                <div class='timeline-footer'>
                                                    <a class="btn btn-primary btn-xs">Responder</a>
                                                </div>
                                            </div>
                                            <ul class="subtimeline">
                                                <li><i class="fa fa-comments bg-aqua"></i>
                                                    <div class="subtimeline-item">
                                                        <span class="subtime"><i class="fa fa-clock-o"></i>20/04/2014 12:05</span>
                                                        <h3 class="subtimeline-header">
                                                            <a href="#">Nombre del usuario</a>
                                                        </h3>
                                                        <div class="subtimeline-body">
                                                            Contenido del comentario {respuesta}
                                                        </div>
                                                        <div class='subtimeline-footer'>
                                                            <a class="btn btn-primary btn-xs">Responder</a>
                                                        </div>
                                                    </div>
                                                    <div class="subtimeline-item">
                                                        <span class="subtime"><i class="fa fa-clock-o"></i>20/04/2014 12:05</span>
                                                        <h3 class="subtimeline-header">
                                                            <a href="#">Nombre del usuario</a></h3>
                                                        <div class="subtimeline-body">
                                                            Contenido del comentario {respuesta}
                                                        </div>
                                                        <div class='subtimeline-footer'>
                                                            <a class="btn btn-primary btn-xs">Responder</a>
                                                        </div>
                                                    </div>
                                                </li>
                                            </ul>
                                        </li>
                                        <li><i class="fa fa-comment bg-blue"></i>
                                            <div class="timeline-item">
                                                <span class="time"><i class="fa fa-clock-o"></i>20/04/2014 12:05</span>
                                                <h3 class="timeline-header">
                                                    <a href="#">Nombre del usuario</a></h3>
                                                <div class="timeline-body">
                                                    Contenido del comentario {original}
                                                </div>
                                                <div class='timeline-footer'>
                                                    <a class="btn btn-primary btn-xs">Responder</a>
                                                </div>
                                            </div>
                                            <ul class="subtimeline">
                                                <li><i class="fa fa-comments bg-aqua"></i>
                                                    <div class="subtimeline-item">
                                                        <span class="subtime"><i class="fa fa-clock-o"></i>20/04/2014 12:05</span>
                                                        <h3 class="subtimeline-header">
                                                            <a href="#">Nombre del usuario</a></h3>
                                                        <div class="subtimeline-body">
                                                            Contenido del comentario {respuesta}
                                                        </div>
                                                        <div class='subtimeline-footer'>
                                                            <a class="btn btn-primary btn-xs">Responder</a>
                                                        </div>
                                                    </div>
                                                </li>
                                            </ul>
                                        </li>
                                    </ul>
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
    <script src="<%=this.ApplicationRoot %>template/syntaxhighlighter_3.0.83/scripts/shCore.js" type="text/javascript"></script>
    <script src="<%=this.ApplicationRoot %>template/syntaxhighlighter_3.0.83/scripts/shBrushSql.js" type="text/javascript"></script>
    <script src="<%=this.ApplicationRoot %>template/syntaxhighlighter_3.0.83/scripts/shBrushCSharp.js" type="text/javascript"></script>
    <script type="text/javascript">
        SyntaxHighlighter.config.bloggerMode = true;
        SyntaxHighlighter.all();
    </script>
</asp:Content>
