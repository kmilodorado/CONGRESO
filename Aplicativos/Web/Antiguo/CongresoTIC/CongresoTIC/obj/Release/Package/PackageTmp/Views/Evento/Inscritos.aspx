<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/MasterPage.Master" AutoEventWireup="true" CodeBehind="Inscritos.aspx.cs" Inherits="CongresoTIC.Views.Evento.Inscritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <title>Listado inscritos</title>
    <script type="text/javascript">

        function cargarId(link) {
            var id = link.id;
            document.getElementById("MainContent_idEC").value = id;
        }
        function cargarIdp(link) {
            var id = link.id;
            document.getElementById("MainContent_idP").value = id;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>Listado de Inscritos
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Partipantes</a></li>
            <li class="active">Listado inscritos</li>
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
                            <li class="active"><a href="#tab_1" data-toggle="tab">Solicitudes recibidas</a></li>
                            <li><a href="#tab_2" data-toggle="tab">Reportes</a></li>
                            <%--<li><a href="#tab_2" data-toggle="tab">Cargar ejercicios</a></li>--%>
                        </ul>
                        <div class="tab-content">
                            <div class="tab-pane active" id="tab_1">
                                <div class="row">

                                    <div class="col-lg-12">
                                        <div class="panel panel-default">
                                            <div class="panel-body">
                                                <div class="table-responsive">
                                                    <div class="box">
                                                        <div class="box-body" id="div_table">
                                                            <table id="example1" class="table table-bordered table-striped">
                                                                <thead>
                                                                    <tr>
                                                                        <th>N°</th>
                                                                        <th>Cédula</th>
                                                                        <th>Usuario</th>
                                                                        <th>Rol</th>
                                                                        <th>Correo</th>
                                                                        <th>Fecha inscripción</th>
                                                                        <th>Estado</th>
                                                                        <th>Respuesta dada por</th>
                                                                        <th>Descripción</th>
                                                                        <th>Foto</th>
                                                                        <th></th>
                                                                        <th></th>
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
                                                                                    Fila = dt.Rows[i];
                                                                                    string es = Fila["EstadoPart"].ToString(), es2 = "";
                                                                                    string habil = Fila["Habil"].ToString();
                                                                                    if (es.Equals("E"))
                                                                                    {
                                                                                        es2 = "En espera";
                                                                                    }
                                                                                    else if (es.Equals("T"))
                                                                                    {
                                                                                        es2 = "ACEPTADA";
                                                                                    }
                                                                                    else if (es.Equals("F"))
                                                                                    {
                                                                                        es2 = "RECHAZADA";
                                                                                    }
                                                                    %>
                                                                    <tr>
                                                                        <td><%= (i + 1) %></td>
                                                                        <td><%= Fila["idPersona"].ToString() %></td>
                                                                        <td><%= Fila["Nombres"].ToString() + " " + Fila["Apellidos"].ToString() %></td>
                                                                        <td><%= Fila["NombreTipoPart"].ToString() %></td>
                                                                        <td><%= Fila["Correo"].ToString() %></td>
                                                                        <td><%= Fila["Fecha"].ToString() %></td>

                                                                        <td><span class="<%= es.Equals("T") ? "label label-success" : es.Equals("F") ? "label label-danger" : es.Equals("E") ? "label label-info" : "label label-default" %>"><%= es2 %></span></td>
                                                                        <td><%= Fila["Calificador"].ToString() %></td>
                                                                        <td><%= Fila["Referencia"].ToString() %></td>
                                                                        <td onclick="cargarId(this)" style="text-align: center" id="<%= Fila["idRecibo"].ToString() %>">
                                                                            <%if (habil.Equals("T"))
                                                                                { %>
                                                                            <asp:ImageButton ID="Source" Width="24px" Height="24px" runat="server" OnClick="Source_Click" ImageUrl="../../public/assets/images/download.png" />
                                                                            <%}
                                                                                else
                                                                                { %>
                                                                            No ha subido
                                                                            <%} %>
                                                                        </td>

                                                                        <td onclick="cargarId(this)" id="<%= Fila["idRecibo"].ToString() %>">

                                                                            <%if (habil.Equals("T"))
                                                                                {
                                                                                    if (es.Equals("E") || es.Equals("F"))
                                                                                    { %>
                                                                            <asp:Button ID="Aceptar" CssClass="btn btn-success btn-xs" runat="server" Text="Aceptar" OnClick="Aceptar_Click" />
                                                                            <%}
                                                                                }%>
                                                                        </td>
                                                                        <td onclick="cargarId(this)" id="<%= Fila["idRecibo"].ToString() %>">
                                                                            <%if (habil.Equals("T"))
                                                                                {
                                                                                    if (es.Equals("E") || es.Equals("T"))
                                                                                    { %>
                                                                            <asp:Button ID="Rechazar" CssClass="btn btn-danger btn-xs" runat="server" Text="Rechazar" OnClick="Rechazar_Click" />
                                                                            <%}
                                                                                } %>
                                                                        </td>
                                                                        <td onclick="cargarIdp(this)" id="<%= Fila["idPartic"].ToString() %>">
                                                                            <asp:Button ID="Activar" CssClass="btn btn-success btn-xs" runat="server" Text="Activar" OnClick="Activar_Click" />
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
                                                            <div style="display: none">
                                                                <asp:TextBox ID="idP" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="tab-pane" id="tab_2">
                                <div class="row">

                                    <div class="col-lg-12">
                                        <div class="panel panel-default">
                                            <div class="panel-body">
                                                <div class="table-responsive">
                                                    <div class="box">
                                                        <div class="box-body" id="iv_table">
                                                            <table id="dataTable" class="table table-bordered table-striped">
                                                                <thead>
                                                                    <tr>
                                                                        <th>N°</th>
                                                                        <th>Descripción</th>
                                                                        <th></th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <tr>
                                                                        <td>1</td>
                                                                        <td>Listado de estudiantes inscritos al Simposio Internacional (Activos)</td>
                                                                        <td>
                                                                            <asp:Button ID="GenerarActivos" CssClass="btn btn-success btn-xs" runat="server" Text="Descargar" OnClick="GenerarActivos_Click" />
                                                                        </td>
                                                                    </tr>
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
            <div id="myModal" class="modal fade" role="dialog">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                            <h4 class="modal-title"><b>Respuesta - Inscripción Congreso TIC</b></h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">Usuario</label>
                                        <div class="col-sm-10">
                                            <asp:Label ID="LAutor" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                    <br />

                                    <br />
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">Respuesta</label>
                                        <div class="col-sm-5">
                                            <asp:DropDownList ID="TRespuesta" CssClass="form-control" runat="server">
                                                <asp:ListItem Value="T" Text="Aceptar"></asp:ListItem>
                                                <asp:ListItem Value="F" Text="Rechazar"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <br />
                                    <br />
                                    <div class="form-group">
                                        <label class="col-sm-2 control-label">Comentario</label>
                                        <div class="col-sm-10">
                                            <asp:TextBox ID="TComentario" CssClass="form-control" TextMode="MultiLine" Height="100" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                            </div>

                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                            <%--<asp:Button ID="Responder" runat="server" Text="Responder" OnClick="Responder_Click" class="btn btn-success" />--%>
                            <%--<button type="button" >Aceptar</button>--%>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </section>
</asp:Content>
