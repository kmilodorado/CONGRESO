<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/MasterPage.Master" AutoEventWireup="true" CodeBehind="Masivos.aspx.cs" Inherits="CongresoTIC.Views.Evento.Masivos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <title>Asistencias masivas</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>Registrar asistencias MASIVAS en el Simposio Internacional de Investigación
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Evento</a></li>
            <li class="active">Asistencias masivas</li>
        </ol>
    </section>
    <section class="content">
        <div class="row">
        </div>
        <asp:Panel ID="Contenido" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#tab_1" data-toggle="tab">Registrar asistencia masiva</a></li>
                        </ul>
                        <div class="tab-content">
                            <div class="tab-pane active" id="tab_1">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="panel panel-default">
                                            <div class="panel-body">
                                                <div class="box">
                                                    <div class="box-body">
                                                        <div class="row">
                                                            <div class="col-lg-12">
                                                                <div class="panel-body">
                                                                    <div class="row">
                                                                        <div class="col-lg-3">
                                                                            <div class="form-group">
                                                                                <label>Fecha</label>
                                                                                <asp:TextBox ID="t_fecha" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-lg-3">
                                                                            <div class="form-group">
                                                                                <label>Hora</label>
                                                                                <asp:TextBox ID="t_hora" TextMode="Time" runat="server" CssClass="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-lg-3">
                                                                            <div class="form-group">
                                                                                <label>Sesión</label>
                                                                                <asp:DropDownList ID="t_sesion" CssClass="form-control" runat="server">
                                                                                    <asp:ListItem Text="Seleccione..." Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="Mañana" Value="1"></asp:ListItem>
                                                                                    <asp:ListItem Text="Tarde" Value="2"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-lg-3">
                                                                            <div class="form-group">
                                                                                <label>Tipo</label>
                                                                                <asp:DropDownList ID="t_tipo" CssClass="form-control" runat="server">
                                                                                    <asp:ListItem Text="Seleccione..." Value="0"></asp:ListItem>
                                                                                    <asp:ListItem Text="Entrada" Value="Entrada"></asp:ListItem>
                                                                                    <asp:ListItem Text="Salida" Value="Salida"></asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-lg-4 col-md-offset-4">
                                                                            <div class="form-group">
                                                                                <br />
                                                                                <asp:Button ID="Consultar" runat="server" CssClass="btn btn-block btn-warning" Text="Consultar" OnClick="Consultar_Click" />
                                                                                <asp:Button ID="Registrar" runat="server" CssClass="btn btn-block btn-success" Text="Registrar asistencias masivas" OnClick="Registrar_Click" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 text-center">
                                        <asp:Panel ID="Resultados" Visible="false" runat="server" CssClass="alert alert-danger">
                                            <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                            <asp:Label ID="LResultado" Font-Size="14pt" runat="server" Text=""></asp:Label>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <div id="validate" class="modal fade" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                        <h4 class="modal-title"><b>Error al cargar el comprobante de pago</b></h4>
                    </div>
                    <div class="modal-body">
                        <div class="row">

                            <div class="col-lg-12 text-center">
                                <h3>Debes colocar la referencia de pago
                                </h3>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-success" data-dismiss="modal">Aceptar</button>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
