<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Privado/SuperAdmin/PagPrivateMaster.Master" AutoEventWireup="true" CodeBehind="GestionarPermisoUsuarioView.aspx.cs" Inherits="Eventos.Vistas.Privado.SuperAdmin.GestionarPermisoUsuarioView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card ">
                <div class="card-header card-header-danger card-header-icon">
                    <div class="card-icon">
                        <i class="material-icons">menu</i>
                    </div>
                    <h4 class="card-title">Permiso</h4>
                </div>
                <div class="card-body ">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:DropDownList ID="DDL_ROL" CssClass="selectpicker" data-style="btn select-with-transition" OnSelectedIndexChanged="DDL_ROL_SelectedIndexChanged" AutoPostBack="true" title=" Seleccionar Rol" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="table-responsive">
                                <div class="toolbar">
                                    <!--        Here you can write extra buttons/actions for the toolbar              -->
                                </div>
                                <div class="material-datatables">
                                    <asp:Repeater ID="Repeater1" runat="server">
                                        <HeaderTemplate>
                                            <table id="datatables" class="table table-striped table-no-bordered table-hover" style="width: 100%">
                                                <thead>
                                                    <tr>
                                                        <th>Seleccionar</th>
                                                        <th>Menú</th>
                                                        <th>URL</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <div class="togglebutton">
                                                        <label>
                                                            <asp:CheckBox ID="CB_VALIDACION"  Text='<%# Eval("IDMENU"); %>' Checked='<%# "".ToString(); if(Eval("IDMENU").ToString()=="null") { "true".ToString(); } else { "false".ToString(); } %>' AutoPostBack="true" OnCheckedChanged="CB_VALIDACION_CheckedChanged" runat="server" />
                                                            <span class="toggle"></span>
                                                        </label>
                                                    </div>
                                                </td>
                                                <td><%# Eval("MENU_NOMBRE") %></td>
                                                <td><%# Eval("MENU_URL") %></td>
                                            </tr>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            </tbody>
                                    </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
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
            $('#datatables').DataTable({
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
            var table = $('#datatables').DataTable();
            $('.card .material-datatables label').addClass('form-group');
        });
    </script>
</asp:Content>
