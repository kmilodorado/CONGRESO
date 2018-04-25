<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/MasterPage.Master" AutoEventWireup="true" CodeBehind="GestionarLogistica.aspx.cs" Inherits="CongresoTIC.Views.Evento.GestionarLogistica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <title>Gestionar Logística</title>
    <script>
        window.onload = function () {
            document.getElementById("MainContent_t_documento").focus();
        };
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>Registrar personas en Logística
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Evento</a></li>
            <li class="active">Logística</li>
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
                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#tab_1" data-toggle="tab">Registrar</a></li>
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
                                                            <div class="col-lg-3">
                                                                <div class="panel-body">
                                                                    <div class="row">
                                                                        <div class="col-lg-12">
                                                                            <div class="form-group">
                                                                                <label>Número de identificación</label>
                                                                                <asp:TextBox ID="t_documento" AutoPostBack="true" MaxLength="50" runat="server" OnTextChanged="t_documento_TextChanged" CssClass="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-lg-12 text-center">
                                                                            <div class="form-group">
                                                                                <br />
                                                                                <asp:Label ID="LName" Font-Size="20pt" Font-Bold="true" runat="server" Text=""></asp:Label>
                                                                                <br />
                                                                                <br />

                                                                                <span id="spa" runat="server" class="badge bg-yellow" style="font-size: 20pt">
                                                                                    <asp:Label ID="LPart" runat="server" Text=""></asp:Label></span>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-lg-9">
                                                                <div class="row">
                                                                    <div class="col-lg-12">
                                                                        <div class="panel panel-default">
                                                                            <div class="panel-heading">
                                                                                Listado de lectores
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="table-responsive">
                                                                                    <div class="box">
                                                                                        <div class="box-body">
                                                                                            <table id="dataTable" class="table table-bordered table-striped">
                                                                                                <thead>
                                                                                                    <tr>
                                                                                                        <th>N°</th>
                                                                                                        <th>Estudiante</th>
                                                                                                        <th>Fecha</th>
                                                                                                        <th>Rol</th>
                                                                                                        <th>Estado</th>
                                                                                                    </tr>
                                                                                                </thead>
                                                                                                <tbody>
                                                                                                    <%if (dt != null)
                                                                                                        {
                                                                                                            if (dt.Rows.Count > 0)
                                                                                                            {
                                                                                                                for (int i = 0; i < dt.Rows.Count; i++)
                                                                                                                {
                                                                                                                    row = dt.Rows[i];

                                                                                                    %>
                                                                                                    <tr>
                                                                                                        <td><%= (i + 1) %></td>
                                                                                                        <td><%= row["Nombres"].ToString() + " " + row["Apellidos"].ToString() %></td>
                                                                                                        <td><%= row["Fecha"].ToString() %></td>
                                                                                                        <td>Lector QR</td>
                                                                                                        <td>
                                                                                                            <%if (row["Estado"].ToString().Equals("T"))
                                                                                                                { %>
                                                                                                            <span class="badge bg-green">
                                                                                                                <i class="fa fa-check"></i>
                                                                                                            </span>
                                                                                                            <%}
                                                                                                                else
                                                                                                                {%>
                                                                                                            <span class="badge bg-red">
                                                                                                                <i class="fa fa-remove"></i>
                                                                                                            </span>
                                                                                                            <%} %>
                                                                                                        </td>

                                                                                                    </tr>
                                                                                                    <% }%>
                                                                                                    <%}
                                                                                                        } %>
                                                                                                </tbody>

                                                                                            </table>
                                                                                            <div style="display: none">
                                                                                                <asp:TextBox ID="idEC" runat="server"></asp:TextBox>
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
