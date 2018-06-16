<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Privado/Usuario/PagPublicMaster.Master" AutoEventWireup="true" CodeBehind="ParticipanteView.aspx.cs" Inherits="Eventos.Vistas.Privado.Usuario.ParticipanteView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card ">
                <div class="card-header card-header-danger card-header-icon">
                    <div class="card-icon">
                        <i class="material-icons">group</i>
                    </div>
                    <h4 class="card-title">Participantes del Evento</h4>
                </div>
                <div class="card-body ">

                    <ul class="nav nav-pills nav-pills-warning" role="tablist">
                        <li class="nav-item">
                            <a class="nav-link active" data-toggle="tab" href="#link1" role="tablist">Congreso</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="tab" href="#link2" role="tablist">Cursos</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="tab" href="#link3" role="tablist">WorkShop</a>
                        </li>
                    </ul>
                    <div class="tab-content tab-space">
                        <div class="tab-pane active" id="link1">
                            <div class="toolbar">
                                <!--        Here you can write extra buttons/actions for the toolbar              -->
                            </div>
                            <div class="material-datatables">
                                <table id="datatables3" class="table table-striped table-no-bordered table-hover" style="width: 100%">
                                    <thead>
                                        <tr>
                                            <th>N°</th>
                                            <th>Identificación</th>
                                            <th>Nombre Completo</th>
                                            <th>Correo</th>
                                            <th>Celular</th>
                                            <th>Participación</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Container.ItemIndex+1 %></td>
                                                    <td><%# Eval("PERS_IDENTIFICACION") %></td>
                                                    <td><%# Eval("PERS_NOMBRES")+" "+Eval("PERS_APELLIDOS") %></td>
                                                    <td><%# Eval("PERS_CORREO") %></td>
                                                    <td><%# Eval("PERS_CELULAR") %></td>
                                                    <td><%# Eval("TIPO_DETALLE") %></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                                <hr />
                                <div class="row">
                                    <div class="col-md-6 ml-auto mr-auto  text-center"">
                                        <br />
                                        <asp:Button ID="Reporte" CssClass="btn btn-info" OnClick="Reporte_Click" runat="server" Text="Reporte" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="tab-pane" id="link2">
                            <div class="toolbar">
                                <!--        Here you can write extra buttons/actions for the toolbar              -->
                            </div>
                            <div class="material-datatables">
                                <table id="datatables1" class="table table-striped table-no-bordered table-hover" style="width: 100%">
                                    <thead>
                                        <tr>
                                            <th>N°</th>
                                            <th>Identificación</th>
                                            <th>Nombre Completo</th>
                                            <th>Correo</th>
                                            <th>Celular</th>
                                            <th>Participación</th>
                                            <th>Curso del 18 Junio</th>
                                            <th>Curso del 19 Junio</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="Repeater2" runat="server">
                                            <ItemTemplate>
                                                <%# CONSULTA = Cursos(DataBinder.Eval(Container.DataItem, "IDPARTICIPANTE").ToString())%>
                                                <tr>
                                                    <td><%# Container.ItemIndex+1 %>
                                                    </td>
                                                    <td><%# Eval("PERS_IDENTIFICACION") %></td>
                                                    <td><%# Eval("PERS_NOMBRES")+" "+Eval("PERS_APELLIDOS") %></td>
                                                    <td><%# Eval("PERS_CORREO") %></td>
                                                    <td><%# Eval("PERS_CELULAR") %></td>
                                                    <td><%# Eval("TIPO_DETALLE") %></td>
                                                    <td><%# CONSULTA.Rows[0]["CURS_ITEM"].ToString() %></td>
                                                    <td><%# CONSULTA.Rows[1]["CURS_ITEM"].ToString() %></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                            <hr />
                                <div class="row">
                                    <div class="col-md-6 ml-auto mr-auto  text-center"">
                                        <br />
                                        <asp:Button ID="Button1" CssClass="btn btn-info" OnClick="Button1_Click" runat="server" Text="Reporte" />
                                    </div>
                                </div>
                        </div>
                        <div class="tab-pane" id="link3">
                            <div class="toolbar">
                                <!--        Here you can write extra buttons/actions for the toolbar              -->
                            </div>
                            <div class="material-datatables">
                                <table id="datatables2" class="table table-striped table-no-bordered table-hover" style="width: 100%">
                                    <thead>
                                        <tr>
                                            <th>N°</th>
                                            <th>Identificación</th>
                                            <th>Nombre Completo</th>
                                            <th>Correo</th>
                                            <th>Celular</th>
                                            <th>Participación</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="Repeater3" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Container.ItemIndex+1 %></td>
                                                    <td><%# Eval("PERS_IDENTIFICACION") %></td>
                                                    <td><%# Eval("PERS_NOMBRES")+" "+Eval("PERS_APELLIDOS") %></td>
                                                    <td><%# Eval("PERS_CORREO") %></td>
                                                    <td><%# Eval("PERS_CELULAR") %></td>
                                                    <td><%# Eval("TIPO_DETALLE") %></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                            <hr />
                                <div class="row">
                                    <div class="col-md-6 ml-auto mr-auto  text-center"">
                                        <br />
                                        <asp:Button ID="Button2" CssClass="btn btn-info" OnClick="Button2_Click" runat="server" Text="Reporte" />
                                    </div>
                                </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Pie" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#datatables3').DataTable({
                "pagingType": "full_numbers",
                "lengthMenu": [
                    [10, 25, 50, -1],
                    [10, 25, 50, "All"]
                ],
                responsive: true,
                language: {
                    search: "_INPUT_",
                    searchPlaceholder: "Buscar",
                }
            });
            var table = $('#datatables3').DataTable();
            $('.card .material-datatables label').addClass('form-group');
        });
        $(document).ready(function () {
            $('#datatables1').DataTable({
                "pagingType": "full_numbers",
                "lengthMenu": [
                    [10, 25, 50, -1],
                    [10, 25, 50, "All"]
                ],
                responsive: true,
                language: {
                    search: "_INPUT_",
                    searchPlaceholder: "Buscar",
                }
            });
            var table = $('#datatables1').DataTable();
            $('.card .material-datatables label').addClass('form-group');
        });
        $(document).ready(function () {
            $('#datatables2').DataTable({
                "pagingType": "full_numbers",
                "lengthMenu": [
                    [10, 25, 50, -1],
                    [10, 25, 50, "All"]
                ],
                responsive: true,
                language: {
                    search: "_INPUT_",
                    searchPlaceholder: "Buscar",
                }
            });
            var table = $('#datatables2').DataTable();
            $('.card .material-datatables label').addClass('form-group');
        });
    </script>
</asp:Content>
