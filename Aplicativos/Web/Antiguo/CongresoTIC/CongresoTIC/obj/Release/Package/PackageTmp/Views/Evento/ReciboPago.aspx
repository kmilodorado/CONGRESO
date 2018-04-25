<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReciboPago.aspx.cs" Inherits="CongresoTIC.Views.Evento.ReciboPago" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <title>Subir foto</title>
    <script type="text/javascript">

        function cargarId(link) {
            var id = link.id;
            document.getElementById("MainContent_idEC").value = id;
        }

        function validate() {

            $('#validate').modal()

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>Cargar foto residuo electrónico
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Residuo electrónico</a></li>
            <li class="active">Cargar foto</li>
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
                            <li class="active"><a href="#tab_1" data-toggle="tab">Residuo electrónico</a></li>
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
                                                            <div class="col-lg-6">
                                                                <div class="panel-body">
                                                                    <div class="row">
                                                                        <div class="col-lg-12">
                                                                            <div class="form-group">
                                                                                <label>Descripción</label>
                                                                                <asp:TextBox ID="t_referencia" TextMode="MultiLine" Height="100" MaxLength="50" runat="server" CssClass="form-control"></asp:TextBox>

                                                                            </div>
                                                                        </div>

                                                                        <div class="col-lg-12">
                                                                            <div class="form-group">
                                                                                <label>Foto</label>
                                                                                <asp:FileUpload ID="t_fuente" runat="server" CssClass="form-control" />
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-lg-12 text-center">
                                                                            <div class="form-group">
                                                                                <asp:Button ID="Cargar" runat="server" CssClass="btn btn-success" Text="Cargar foto" OnClick="EnviarFuente_Click" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-1 col-md-offset-0">
                                                                <br /><br />
                                                                <i class="fa fa-arrow-circle-right" style="font-size:30pt"></i>
                                                                Ejemplo
                                                            </div>
                                                            <div class="col-lg-4 col-md-offset-0">
                                                                <div class="panel-body">
                                                                    <br /><br />
                                                                    <img src="../../public/assets/images/fondo/residuos.jpg " class="img-responsive" alt="" />
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-12">
                                                                <div class="row">
                                                                    <div class="col-lg-12">
                                                                        <div class="panel panel-default">
                                                                            <div class="panel-heading">
                                                                                Noticias
                                                                            </div>
                                                                            <div class="panel-body">
                                                                                <div class="table-responsive">
                                                                                    <div class="box">
                                                                                        <div class="box-body">
                                                                                            <table id="dataTable" class="table table-bordered table-striped">
                                                                                                <thead>
                                                                                                    <tr>
                                                                                                        <th>N°</th>
                                                                                                        <th>Descripción</th>
                                                                                                        <th>Fecha</th>
                                                                                                        <th>Estado</th>
                                                                                                        <th>Archivo fuente</th>
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
                                                                                                                    if (es.Equals("E"))
                                                                                                                    {
                                                                                                                        es2 = "Inscripción en espera";
                                                                                                                    }
                                                                                                                    else if (es.Equals("T"))
                                                                                                                    {
                                                                                                                        es2 = "Inscripción ACEPTADA";
                                                                                                                    }
                                                                                                                    else if (es.Equals("F"))
                                                                                                                    {
                                                                                                                        es2 = "Inscripción RECHAZADA";
                                                                                                                    }
                                                                                                    %>
                                                                                                    <tr>
                                                                                                        <td><%= (i + 1) %></td>
                                                                                                        <td><%= Fila["NombreTipoPart"].ToString() %></td>
                                                                                                        <td><%= Fila["FechaRecibo"].ToString() %></td>

                                                                                                        <td><span class="<%= es.Equals("T") ? "label label-success" : es.Equals("F") ? "label label-danger" : es.Equals("E") ? "label label-info" : "label label-default" %>"><%= es2 %></span></td>

                                                                                                        <td onclick="cargarId(this)" style="text-align: center" id="<%= Fila["idRecibo"].ToString() %>">
                                                                                                            <asp:ImageButton ID="Source" Width="24px" Height="24px" runat="server" OnClick="Source_Click" ImageUrl="../../public/assets/images/download.png" />
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
