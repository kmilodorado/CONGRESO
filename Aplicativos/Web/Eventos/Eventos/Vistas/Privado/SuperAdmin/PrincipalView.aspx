<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Privado/SuperAdmin/PagPrivateMaster.Master" AutoEventWireup="true" CodeBehind="PrincipalView.aspx.cs" Inherits="Eventos.Vistas.Privado.SuperAdmin.PrincipalView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card ">
                <div class="card-header card-header-danger card-header-icon">
                    <div class="card-icon">
                        <i class="material-icons">event</i>
                    </div>
                    <h4 class="card-title">Eventos</h4>
                </div>
                <div class="card-body ">
                    <div class="row">
                        <div class="col-md-12">
                            <div class="toolbar">
                                <!--        Here you can write extra buttons/actions for the toolbar              -->
                            </div>
                            <div class="material-datatables">

                                <table id="datatables" class="table table-striped table-no-bordered table-hover" cellspacing="0" width="100%" style="width: 100%">
                                    <thead>
                                        <tr>
                                            <th>N°</th>
                                            <th>Nombre</th>
                                            <th>Fecha inicio</th>
                                            <th>Fecha final</th>
                                            <th>Cupos</th>
                                            <th>Valor inscripción</th>
                                            <th>Estado</th>
                                            <th>Agregar Responsable</th>
                                            <th>Modificar Lugares</th>
                                            <th>Modificar</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="Repeater1" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Container.ItemIndex+1 %></td>
                                                    <td><%# Eval("NOMBRE") %></td>
                                                    <td><%# DateTime.Parse(Eval("F_INI").ToString()).ToString("dd/MM/yyyy") %></td>
                                                    <td><%# DateTime.Parse(Eval("F_FIN").ToString()).ToString("dd/MM/yyyy") %></td>
                                                    <td><%# Eval("CUPOS") %></td>
                                                    <td><%# Eval("COSTO") %></td>
                                                    <td><%# Eval("ESTADO") %></td>
                                                    <td><a href="GestionarResponsableView.aspx?id=<%#Eval("ID")%>"><i class="fa fa-user-plus"></i>Agregar Responsable</a></td>
                                                    <td><a href="GestionarLugaresView.aspx?id=<%#Eval("ID")%>" class="btn btn-warning"><i class="fa fa-plane"></i></a></td>
                                                    <td><a href="GestionarResponsableView.aspx?id=<%#Eval("ID")%>" class="btn btn-warning"><i class="fa fa-edit"></i></a></td>
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
            $('#datatables').DataTable({
                "pagingType": "full_numbers",
                "lengthMenu": [
                    [10, 25, 50, -1],
                    [10, 25, 50, "All"]
                ],
                responsive: true,
                language: {
                    search: "_INPUT_",
                    searchPlaceholder: "Search records",
                }

            });


            var table = $('#datatables').DataTable();

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

            $('.card .material-datatables label').addClass('form-group');
        });

    </script>
</asp:Content>
