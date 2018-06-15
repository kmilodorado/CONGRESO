<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Privado/Usuario/PagPublicMaster.Master" AutoEventWireup="true" CodeBehind="RegistrarSoporteView.aspx.cs" Inherits="Eventos.Vistas.Privado.Usuario.RegistrarSoporteView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Select2 -->
    <link rel="stylesheet" href="../../../Estilo/select2/select2.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-12">
            <div class="card ">
                <div class="card-header card-header-danger card-header-icon">
                    <div class="card-icon">
                        <i class="material-icons">person_add</i>
                    </div>
                    <h4 class="card-title">Registrar Soporte</h4>
                </div>
                <div class="card-body ">
                    <div class="row">
                        <div class="col-md-6 ml-auto">
                            <!-- Identificación -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="material-icons">perm_identity</i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="TXT_IDENTIFICACION" required="required" CssClass="form-control" placeholder="N° Identificación..." MaxLength="10" MinLength="7" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- tipo Identificación -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group has-default">
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="material-icons">contact_mail</i>
                                                </span>
                                            </div>
                                            <asp:DropDownList ID="DDL_TIPO_DOC" CssClass="form-control  select2" data-style="btn select-with-transition" title=" Seleccionar Tipo Documento" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <!-- Nombre -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group has-default">
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="material-icons">face</i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="TXT_NOMBRE" required="required" CssClass="form-control" MinLength="3" placeholder="Nombre..." MaxLength="50" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- Apellido -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group has-default">
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="material-icons">face</i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="TXT_APELLIDO" required="required" CssClass="form-control" MinLength="3" placeholder="Apellido..." MaxLength="50" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- Genero -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group has-default">
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="material-icons">brightness_1</i>
                                                </span>
                                            </div>
                                            <asp:DropDownList ID="DDL_GENERO" CssClass="form-control  select2" data-style="btn select-with-transition" title=" Seleccionar Genero" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="col-md-6 ml-auto">
                            <!-- Fecha Nacimiento -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group has-default">
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="material-icons">calendar_today</i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="TXT_FECHA_NAC" required="required" CssClass="form-control" placeholder="Fecha Nacimiento..." title="Fecha Nacimiento" TextMode="Date" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- Pais Nacimiento -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group has-default">
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="material-icons">flag</i>
                                                </span>
                                            </div>
                                            <asp:DropDownList ID="DDL_PAIS_NAC" CssClass="form-control  select2" data-style="btn select-with-transition" title=" Seleccionar Pais Nacimiento" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <!-- Correo -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group has-default">
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="material-icons">email</i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="TXT_CORREO" required="required" CssClass="form-control" placeholder="Correo..." TextMode="Email" MaxLength="100" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- Celular -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group has-default">
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="material-icons">phone</i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="TXT_CELULAR" required="required" CssClass="form-control" MinLength="7" placeholder="Telefono o Celular..." pattern="^[0-9]+" MaxLength="10" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- Institución -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group has-default">
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="material-icons">account_balance</i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="TXT_INSTITUCION" required="required" CssClass="form-control valid" placeholder="Institución..." MaxLength="50" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-6 ml-auto mr-auto  text-center">
                            <asp:Button ID="Registrar" OnClick="Registrar_Click" CssClass="btn btn-success" Text="Registrar" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="card ">
                <div class="card-header card-header-danger card-header-icon">
                    <h4 class="card-title">Listado de los soporte del evento</h4>
                </div>
                <div class="card-body ">
                    <div class="toolbar">
                        <!--        Here you can write extra buttons/actions for the toolbar              -->
                    </div>
                    <div class="material-datatables">
                        <table id="datatables" class="table table-striped table-no-bordered table-hover" style="width: 100%">
                            <thead>
                                <tr>
                                    <th>N°</th>
                                    <th>Identificación</th>
                                    <th>Nombre Completo</th>
                                    <th>Correo</th>
                                    <th>Celular</th>
                                    <th>Usuario</th>
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
                                            <td><%# Eval("USUA_USERNAME") %></td>
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
    <!-- Select2 -->
    <script src="../../../Estilo/select2/select2.full.min.js"></script>
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
            var table = $('#datatables2').DataTable();
            $('.card .material-datatables label').addClass('form-group');
        });

        $(function () {
            //Initialize Select2 Elements
            $('.select2').select2();
        });
    </script>
</asp:Content>
