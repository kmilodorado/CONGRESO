<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Privado/Usuario/PagPublicMaster.Master" AutoEventWireup="true" CodeBehind="RefrigerioView.aspx.cs" Inherits="Eventos.Vistas.Privado.Usuario.RefrigerioView" %>
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
                    <h4 class="card-title">Listado de la entrega de refrigerio</h4>
                </div>
                <div class="card-body ">
                    <ul class="nav nav-pills nav-pills-warning" role="tablist">
                        <li class="nav-item">
                            <a class="nav-link active" data-toggle="tab" href="#link1" role="tablist">Congreso</a>
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
                                            <th>Reclamo</th>
                                            <th>Estado</th>
                                            <th>Sesión</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Container.ItemIndex+1 %></td>
                                                    <td><%# Eval("PERS_IDENTIFICACION") %></td>
                                                    <td><%# Eval("PERS_NOMBRES")+" "+Eval("PERS_APELLIDOS") %></td>
                                                    <td><%# DateTime.Parse(Eval("REFR_FECHA_RECLAMO").ToString()).ToString("dd/MM/yyyy HH:mm") %></td>
                                                    <td><%# Eval("REFR_ESTADO") %></td>
                                                    <td><%# Eval("SESI_NOMBRE") %></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
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
    </script>
</asp:Content>
