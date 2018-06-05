<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Privado/SuperAdmin/PagPrivateMaster.Master" AutoEventWireup="true" CodeBehind="GestionarResponsableView.aspx.cs" Inherits="Eventos.Vistas.Privado.SuperAdmin.GestionarResponsableView" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h3 class="title text-center">
                <asp:Label ID="Titulo" runat="server" Text=""></asp:Label></h3>
            <div class="card ">
                <div class="card-header">
                    <h4 class="card-title">Registrar Responsable</h4>
                </div>
                <div class="card-body ">
                    <div class="row">
                        <div class="col-md-8">
                            <div class="form-group bmd-form-group">
                                <label for="TXT_IDENTIFICACION_Consultar" class="bmd-label-floating">Consultar Identificación</label>
                                <asp:TextBox ID="TXT_CONSULTAR" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <asp:LinkButton ID="LinkButton1" OnClick="TXT_IDENTIFICACION_TextChanged" CssClass="btn btn-success" NavigateUrl="#Identificacion" runat="server"><i class="fa fa-search"></i> Consultar</asp:LinkButton>
                        </div>
                        <div class="col-md-2">
                            <asp:Label ID="Label1" runat="server" CssClass="text-danger" Text=""></asp:Label>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group bmd-form-group">
                                <label for="TXT_IDENTIFICACION" class="bmd-label-floating">Identificación</label>
                                <asp:TextBox ID="TXT_IDENTIFICACION" CssClass="form-control" required="true" MaxLength="12" aria-required="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="DDL_TIPO_DOCUMENTO" class="selectpicker" data-style="btn select-with-transition" title="Tipo de Documento" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group bmd-form-group">
                                <label for="TXT_NOMBRE" class="bmd-label-floating">Nombre</label>
                                <asp:TextBox ID="TXT_NOMBRE" CssClass="form-control" required="true" MaxLength="50" aria-required="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group bmd-form-group">
                                <label for="TXT_APELLIDO" class="bmd-label-floating">Apellido</label>
                                <asp:TextBox ID="TXT_APELLIDO" CssClass="form-control" required="true" MaxLength="50" aria-required="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group bmd-form-group">
                                <label for="TXT_CORREO" class="bmd-label-floating">Correo</label>
                                <asp:TextBox ID="TXT_CORREO" CssClass="form-control" email="true" required="true" MaxLength="100" aria-required="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group bmd-form-group">
                                <label for="TXT_CELULAR" class="bmd-label-floating">Celular</label>
                                <asp:TextBox ID="TXT_CELULAR" CssClass="form-control" number="true" required="true" MaxLength="10" aria-required="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:DropDownList ID="DDL_DEPARTAMENTO" class="selectpicker" data-style="btn select-with-transition" title="Departamento" OnSelectedIndexChanged="DDL_DEPARTAMENTO_SelectedIndexChanged" AutoPostBack="true" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList ID="DDL_MUNICIPIO" class="selectpicker" data-style="btn select-with-transition" title="Municipio" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group bmd-form-group">
                                <label for="TXT_DIRECCION" class="bmd-label-floating">Dirección</label>
                                <asp:TextBox ID="TXT_DIRECCION" CssClass="form-control" required="true" MaxLength="50" aria-required="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group bmd-form-group">
                                <label for="TXT_INSTITUCION" class="bmd-label-floating">Institución</label>
                                <asp:TextBox ID="TXT_INSTITUCION" CssClass="form-control" required="true" MaxLength="200" aria-required="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-6">
                            <asp:DropDownList ID="DDL_OCUPACION" class="selectpicker" data-style="btn select-with-transition" title="Ocupación" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-6">
                            <asp:DropDownList ID="DDL_FORMACION" class="selectpicker" data-style="btn select-with-transition" title="Nivel de formación" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group bmd-form-group">
                                <label for="TXT_USUARIO" class="bmd-label-floating">Usuario</label>
                                <asp:TextBox ID="TXT_USUARIO" CssClass="form-control" required="true" MaxLength="50" aria-required="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group bmd-form-group">
                                <label for="TXT_PASS" class="bmd-label-floating">Contraseña</label>
                                <asp:TextBox ID="TXT_PASS" CssClass="form-control" MaxLength="20" TextMode="Password" required="true" aria-required="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-md-6 ml-auto mr-auto  text-center">
                            <asp:Button ID="BTN_REGISTRAR" CssClass="btn btn-danger" runat="server" OnClick="BTN_REGISTRAR_Click" Text="Registrar" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="card ">
                <div class="card-header">
                    <h4 class="card-title">Responsable</h4>
                </div>
                <div class="card-body ">
                    <div class="toolbar">
                        <!--        Here you can write extra buttons/actions for the toolbar              -->
                    </div>
                    <div class="material-datatables">

                        <table id="datatables" class="table table-striped table-no-bordered table-hover" cellspacing="0" width="100%" style="width: 100%">
                            <thead>
                                <tr>
                                    <th>N°</th>
                                    <th>Nombre Completo</th>
                                    <th>Correo</th>
                                    <th>Celular</th>
                                    <th>Fecha Registro</th>
                                    <th>Eliminar</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="Repeater1" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Container.ItemIndex+1 %></td>
                                            <td><%# Eval("PERS_NOMBRES") %>  <%# Eval("PERS_APELLIDOS") %></td>
                                            <td><%# Eval("PERS_CORREO") %></td>
                                            <td><%# Eval("PERS_CELULAR") %></td>
                                            <td><%# Eval("PART_FECHA") %></td>
                                            <td><a href="GestionarResponsableView.aspx?id=<%#Eval("IDPARTICIPANTE")%>" class="btn btn-danger"><i class="fa fa-remove"></i></a></td>
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
