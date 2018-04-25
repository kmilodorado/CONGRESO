<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/MasterPage.Master" AutoEventWireup="true" CodeBehind="Refrigerios.aspx.cs" Inherits="CongresoTIC.Views.Evento.Refrigerios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <title>Asistencias</title>
    <script>
        window.onload = function () {
            document.getElementById("MainContent_t_documento").focus();
        };
    </script>
    <script type="text/javascript">
        function cargarId(link) {
            var id = link.id;
            document.getElementById("MainContent_idEC").value = id;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>Refrigerios - Simposio Internacional de Investigación
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Evento</a></li>
            <li class="active">Refrigerios</li>
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
                            <li class="active"><a href="#tab_1" data-toggle="tab">Refrigerios</a></li>
                            <li><a href="#tab_2" data-toggle="tab">Consumo en el Simposio</a></li>
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

                                                                        <%--<div class="col-lg-12 text-center">
                                                                            <div class="form-group">
                                                                                <asp:Button ID="Registrar" runat="server" CssClass="btn btn-success" Text="Registrar asistencia al evento" OnClick="Registrar_Click" />
                                                                            </div>
                                                                        </div>--%>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="col-lg-9">
                                                                <div class="row">
                                                                    <div class="col-lg-12">
                                                                        <div class="panel panel-default">
                                                                            <div class="panel-heading">
                                                                                Listado de asistentes
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="table-responsive">
                                                                                    <div class="box">
                                                                                        <div class="box-body">
                                                                                            <table id="dataTable" class="table table-bordered table-striped">
                                                                                                <thead>
                                                                                                    <tr>
                                                                                                        <th>N°</th>
                                                                                                        <th>Identificación</th>
                                                                                                        <th>Estudiante</th>
                                                                                                        <th>Fecha</th>
                                                                                                        <th>Sesion</th>
                                                                                                        <th>Estado</th>
                                                                                                        <th></th>
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
                                                                                                        <td><%= row["idPersona"].ToString() %></td>
                                                                                                        <td><%= row["Nombres"].ToString() + " " + row["Apellidos"].ToString() %></td>
                                                                                                        <td><%= row["Fecha"].ToString() %></td>
                                                                                                        <td><%= row["Sesion"].ToString() %></td>
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
                                                                                                        <td onclick="cargarId(this)" id="<%= row["idRefrigerio"].ToString() %>">
                                                                                                            <asp:Button ID="Eliminar" CssClass="btn btn-danger btn-xs" runat="server" Text="Eliminar" OnClick="Eliminar_Click" />
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
                            <div class="tab-pane active" id="tab_2">
                                <div class="row">

                                    <div class="col-lg-12">
                                        <div class="panel panel-default">
                                            <div class="panel-body">

                                                <div class="box">
                                                    <div class="box-body">
                                                        <div class="row">
                                                            <div class="col-lg-12">
                                                                <div class="row">
                                                                    <div class="col-lg-12">
                                                                        <div class="panel panel-default">
                                                                            <div class="panel-heading">
                                                                                Listado de asistentes
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="table-responsive">
                                                                                    <div class="box">
                                                                                        <div class="box-body">
                                                                                            <table id="example1" class="table table-bordered table-striped">
                                                                                                <thead>
                                                                                                    <tr>
                                                                                                        <th>N°</th>
                                                                                                        <th>Identificación</th>
                                                                                                        <th>Estudiante</th>
                                                                                                        <th colspan="2">Miércoles</th>
                                                                                                        <th colspan="2">Jueves</th>
                                                                                                        <th colspan="2">Viernes</th>
                                                                                                        <th>Porcentaje</th>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <th colspan="3"></th>
                                                                                                        <th>Mañana</th>
                                                                                                        <th>Tarde</th>
                                                                                                        <th>Mañana</th>
                                                                                                        <th>Tarde</th>
                                                                                                        <th>Mañana</th>
                                                                                                        <th>Tarde</th>
                                                                                                        <th></th>
                                                                                                    </tr>
                                                                                                </thead>
                                                                                                <tbody>
                                                                                                    <%for (int i = 0; i < dt2.Rows.Count; i++)
                                                                                                        {
                                                                                                            row2 = dt2.Rows[i];
                                                                                                    %>
                                                                                                    <tr>
                                                                                                        <td><%= (i+1) %></td>
                                                                                                        <td><%= row2["idPersona"].ToString()%></td>
                                                                                                        <td><%= row2["Nombres"].ToString() + " "+ row2["Apellidos"].ToString() %></td>
                                                                                                        <td><%= row2["M1"].ToString()%></td>
                                                                                                        <td><%= row2["M2"].ToString()%></td>
                                                                                                        <td><%= row2["J1"].ToString()%></td>
                                                                                                        <td><%= row2["J2"].ToString()%></td>
                                                                                                        <td><%= row2["V1"].ToString()%></td>
                                                                                                        <td><%= row2["V2"].ToString()%></td>
                                                                                                        <td><span class="label label-warning"><%= row2["Porcentaje"].ToString()%></span></td>
                                                                                                    </tr>
                                                                                                    <%} %>
                                                                                                </tbody>
                                                                                            </table>
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
    </section>
</asp:Content>
