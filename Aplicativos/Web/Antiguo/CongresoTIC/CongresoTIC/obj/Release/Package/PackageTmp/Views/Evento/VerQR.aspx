<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/MasterPage.Master" AutoEventWireup="true" CodeBehind="VerQR.aspx.cs" Inherits="CongresoTIC.Views.Evento.VerQR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <title>QR - Estudiantes</title>
    <script>
        window.onload = function () {
            document.getElementById("MainContent_t_documento").focus();
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>Consultar información personal
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Evento</a></li>
            <li class="active">Consultar datos</li>
        </ol>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-lg-12">
                <asp:Panel ID="Resultados" Visible="false" runat="server" CssClass="alert alert-danger">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                    <asp:Label ID="LResultado" runat="server" Text=""></asp:Label>
                </asp:Panel>
            </div>
        </div>
        <asp:Panel ID="Contenido" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <!-- Custom Tabs -->
                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#tab_1" data-toggle="tab">Consultar participante</a></li>
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
                                                            <div class="col-lg-3 text-center">
                                                                <div class="panel-body">
                                                                    <div class="form-group">
                                                                        <label>Número de identificación</label>
                                                                        <asp:TextBox ID="t_documento" AutoPostBack="true" MaxLength="50" runat="server" OnTextChanged="t_documento_TextChanged" CssClass="form-control"></asp:TextBox>

                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-lg-3">
                                                                <div class="text-center">
                                                                    <asp:Image ID="QR" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6">
                                                                <div class="col-lg-12 text-center">
                                                                    <div class="form-group">
                                                                        <br />
                                                                        <asp:Label ID="LName" Font-Size="20pt" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                                        <br />
                                                                        <br />

                                                                        <span id="spa" runat="server" class="badge bg-yellow" style="font-size: 20pt">
                                                                            <asp:Label ID="LPart" runat="server" Text=""></asp:Label></span>
                                                                        <br />
                                                                        <br />
                                                                        <asp:Label ID="Cedula" Font-Size="12pt" runat="server" Text=""></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Acceso" Font-Size="12pt" runat="server" Text=""></asp:Label>
                                                                        <br />
                                                                        <asp:Label ID="Estado" Font-Size="10pt" runat="server" Text=""></asp:Label>
                                                                        <br />
                                                                        
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <asp:Label ID="Private" Font-Size="8pt" ForeColor="White" runat="server" Text=""></asp:Label>
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
