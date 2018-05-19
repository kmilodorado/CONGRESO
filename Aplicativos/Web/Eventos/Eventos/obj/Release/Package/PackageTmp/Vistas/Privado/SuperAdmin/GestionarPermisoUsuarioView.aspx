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
                                    <asp:GridView ID="datatables" CssClass="table table-striped table-no-bordered table-hover" GridLines="None" runat="server" AutoGenerateColumns="false">
                                        <HeaderStyle BackColor="#e53935" CssClass="text-center" Font-Bold="true" ForeColor="White" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Seleccionar" ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CB_SELECIONAR" Text='<%#Eval("IDMENU") %>' ForeColor="#ffffff" OnCheckedChanged="CB_SELECIONAR_CheckedChanged" AutoPostBack="true" Checked="false" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Código" DataField="IDMENU" ReadOnly="true" />
                                            <asp:BoundField HeaderText="Nombre" DataField="MENU_NOMBRE" />
                                            <asp:BoundField HeaderText="Url" DataField="MENU_URL" />
                                        </Columns>
                                    </asp:GridView>
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
