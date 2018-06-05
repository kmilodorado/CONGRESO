<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Privado/PagMaster.Master" AutoEventWireup="true" CodeBehind="GestionarTiposView.aspx.cs" Inherits="Eventos.Vistas.Privado.SuperAdmin.GestionarTiposView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card card-stats card-raised">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12">
                            <label class="control-label">Seleccionar tipo</label>
                            <asp:DropDownList ID="DDL_TIPO" CssClass="selectpicker" data-style="btn btn-default btn-round" title="Seleccionar Tipo" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDL_TIPO_SelectedIndexChanged">
                                <asp:ListItem Value="SELECCIONAR" Text=" -- SELECCIONAR TIPO -- " Selected="True" Enabled="false"></asp:ListItem>
                                <asp:ListItem Value="T_PERSONA" Text="TIPO DE PERSONA"></asp:ListItem>
                                <asp:ListItem Value="T_PARTICIPANTE" Text="TIPO DE PARTICIPANTE"></asp:ListItem>
                                <asp:ListItem Value="T_COSTO" Text="TIPO COSTO"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-10">
                            <label class="control-label">Detalle</label>
                            <div class="form-group">
                                <asp:TextBox ID="TXT_DETALLE" MaxLength="50" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <asp:Button ID="BTN_REGISTRAR" CssClass="btn btn-fill btn-default" OnClick="BTN_REGISTRAR_Click" runat="server" Text="Registrar" />
                            </div>
                        </div>
                    </div>
                    <br />
                    <hr />
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <div class="toolbar">
                                <!--        Here you can write extra buttons/actions for the toolbar              -->
                            </div>
                            <asp:GridView ID="datatable" CssClass="table table-striped table-bordered" AutoGenerateColumns="false" OnSelectedIndexChanged="datatable_SelectedIndexChanged" runat="server">
                                <HeaderStyle BackColor="#2196f3" CssClass="text-center" Font-Bold="true" HorizontalAlign="Center" ForeColor="White" />
                                <Columns>
                                     <asp:BoundField HeaderText="Código" DataField="ID" ReadOnly="true" />
                                    <asp:BoundField HeaderText="Detalle" DataField="TIPO_DETALLE" />
                                    <asp:HyperLinkField Text="<i class='btn btn-warning fa fa-edit'></i>" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="~/Views/PrivateViews/MenuView.aspx?id={0}" ControlStyle-CssClass="md-btn md-btn-warning" HeaderText="Modificar" HeaderStyle-Width="100"></asp:HyperLinkField>
                                    <asp:CommandField ShowSelectButton="True" SelectText="<i class='btn btn-danger fa fa-trash'></i>" ControlStyle-CssClass="md-btn md-btn-danger" HeaderText="Eliminar" HeaderStyle-Width="50" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Pie" runat="server">
    <script>
        $(document).ready(function () {
            $('#Contenido_datatable').DataTable({
                "pagingType": "full_numbers",
                "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                responsive: true,
                language: {
                    search: "_INPUT_",
                    searchPlaceholder: "Search records",
                }

            });

            var table = $('#Contenido_datatable').DataTable();

            // Edit record
            table.on('click', '.edit', function () {
                $tr = $(this).closest('tr');

                var data = table.row($tr).data();
                alert('You press on Row: ' + data[0] + ' ' + data[1] + ' ' + data[2] + '\'s row.');
            });

            // Delete a record
            table.on('click', '.remove', function (e) {
                $tr = $(this).closest('tr');
                table.row($tr).remove().draw();
                e.preventDefault();
            });

            //Like record
            table.on('click', '.like', function () {
                alert('You clicked on Like button');
            });
        });
    </script>
</asp:Content>
