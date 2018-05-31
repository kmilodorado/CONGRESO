<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Privado/SuperAdmin/PagPrivateMaster.Master" AutoEventWireup="true" CodeBehind="GestionarMenuView.aspx.cs" Inherits="Eventos.Vistas.Privado.SuperAdmin.GestionarMenuView" %>

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
                        <h4 class="card-title">Menú</h4>
                    </div>
                    <div class="card-body "> 
                        <br />    
                        <!-- Registrar --->          
                        <div id="REG" class="row"  runat="server">
                            <div class="col-md-3">
                                <div class="form-group bmd-form-group">
                                    <label for="TXT_DETALLE" class="bmd-label-floating">Nombre</label>
                                    <asp:TextBox ID="TXT_DETALLE" required="required" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group bmd-form-group">
                                    <label for="TXT_URL" class="bmd-label-floating">URL</label>
                                    <asp:TextBox ID="TXT_URL" required="required" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group bmd-form-group">
                                    <label for="TXT_ICONO" class="bmd-label-floating">Icono</label>
                                    <asp:TextBox ID="TXT_ICONO" required="required" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <asp:DropDownList ID="DDL_TIPO" CssClass="selectpicker" data-style="btn select-with-transition" title=" Seleccionar" runat="server">
                                    <asp:ListItem Value="Usuario" Text="Usuario"></asp:ListItem>
                                    <asp:ListItem Value="Participante" Text="Participante"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                             <div class="col-md-2 text-center">
                                <asp:Button ID="BTN_AGREGAR" CssClass="btn btn-success" OnClick="BTN_AGREGAR_Click" runat="server" Text="Agregar" />
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
                                            <headertemplate>
                                            <table id="datatables" class="table table-striped table-no-bordered table-hover" style="width: 100%">
                                                <thead>
                                                    <tr>
                                                        <th>N°</th>
                                                        <th>Nombre del menú</th>
                                                        <th>URL</th>
                                                        <th>Icono</th>
                                                        <th>Tipo</th>
                                                        <th>Actualizar</th>
                                                        <th>Eliminar</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                        </headertemplate>
                                            <itemtemplate>
                                            <tr>
                                                <td><%# Container.ItemIndex+1 %></td>
                                                <td><%# Eval("MENU_NOMBRE") %></td>
                                                <td><%# Eval("MENU_URL") %></td>
                                                <td><i class="material-icons"><%# Eval("MENU_ICONO") %></i></td>
                                                <td><%# Eval("MENU_TIPO") %></td>
                                                <td>
                                                    <asp:LinkButton ID="BTN_ACTUALIZAR" CssClass="btn btn-warning" OnCommand="BTN_ACTUALIZAR_Command" CommandArgument='<%# Eval("IDMENU") %>'  runat="server"><i class="material-icons">edit</i></asp:LinkButton>
                                                </td>
                                                 <td>
                                                    <asp:LinkButton ID="BTN_ELIMINAR" CssClass="btn btn-danger" OnCommand="BTN_ELIMINAR_Command" CommandArgument='<%# Eval("IDMENU") %>' runat="server"><i class="material-icons">delete</i></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </itemtemplate>
                                            <footertemplate>
                                            </tbody>
                                    </table>
                                        </footertemplate>
                                        </asp:Repeater>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                         <!-- Modificar --->
                        <div id="MOD"  class="row" style="visibility:hidden" runat="server">
                            <div class="col-md-1">
                                <div class="form-group bmd-form-group">
                                    <label for="TXT_ID" class="bmd-label-floating">ID</label>
                                    <input id="TXT_ID" readonly="readonly" class="form-control" type="text" runat="server" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group bmd-form-group">
                                    <label for="TXT_DETALLE_MOD" class="bmd-label-floating">Nombre</label>
                                    <input id="TXT_DETALLE_MOD" class="form-control" type="text" runat="server" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group bmd-form-group">
                                    <label for="TXT_URL_MOD" class="bmd-label-floating">URL</label>
                                    <input id="TXT_URL_MOD" class="form-control" type="text" runat="server" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group bmd-form-group">
                                    <label for="TXT_ICONO_MOD" class="bmd-label-floating">Icono</label>
                                    <input id="TXT_ICONO_MOD" class="form-control" type="text" runat="server" />
                                </div>
                            </div>
                            <div class="col-md-2">
                                <select id="SEL_TIPO" class="selectpicker" title=" Seleccionar" data-style="btn select-with-transition" runat="server">
                                    <option value="Usuario" selected="selected">Usuario</option>
                                    <option value="Participante">Participante</option>
                                </select>
                            </div>
                             <div class="col-md-2 text-center">
                                 <asp:LinkButton ID="BTN_ACTUALIZAR" CssClass="btn btn-warning" OnClick="BTN_ACTUALIZAR_Click" runat="server"><i class="material-icons">edit</i> Actualizar</asp:LinkButton> 
                            </div>
                            <div class="col-md-1 text-center">
                                 <asp:LinkButton ID="BTN_CANCELAR" CssClass="btn btn-danger btn-fab" OnClick="BTN_CANCELAR_Click" runat="server"><i class="material-icons">cancel</i></asp:LinkButton>
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
