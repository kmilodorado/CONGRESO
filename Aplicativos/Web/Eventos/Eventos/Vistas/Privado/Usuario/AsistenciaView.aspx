<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Privado/Usuario/PagPublicMaster.Master" AutoEventWireup="true" CodeBehind="AsistenciaView.aspx.cs" Inherits="Eventos.Vistas.Privado.Usuario.AsistenciaView" %>

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
                        <i class="material-icons">group</i>
                    </div>
                    <h4 class="card-title">Listado de la asistencia del evento</h4>
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
                                            <th>Fecha de Entrada</th>
                                            <th>Fecha de Salida</th>
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
                                                    <td><%# DateTime.Parse(Eval("ASIS_FECHA_ENTRADA").ToString()).ToString("dd/MM/yyyy HH:mm") %></td>
                                                    <td><%# DateTime.Parse(Eval("ASIS_FECHA_SALIDA").ToString()).ToString("dd/MM/yyyy HH:mm")%>
                                                    </td>
                                                    <td><%# Eval("ASIS_ESTADO") %></td>
                                                    <td><%# Eval("SESI_NOMBRE") %></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <hr />

                    <div class="row">
                        <div class="col-md-4">
                            <label>Día de la Asistencia (*)</label>
                            <asp:TextBox ID="TXT_FECHA" required="required" CssClass="form-control" placeholder="Fecha Nacimiento..." title="Fecha Nacimiento" TextMode="Date" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label>Hatas el día</label>
                            <asp:TextBox ID="TXT_HASTA"  CssClass="form-control" placeholder="Fecha Nacimiento..." title="Fecha Nacimiento" TextMode="Date" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            <label>Sesión</label>
                            <asp:DropDownList ID="DDL_SESION" CssClass="form-control  select2" data-style="btn select-with-transition" title=" Seleccionar Tipo Documento" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-md-2">
                            
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <iframe class="preview-pane" type="application/pdf" width="100%" height="650" frameborder="0" style="position:relative;z-index:999"></iframe>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Pie" runat="server">
    <script src="../../../Estilo/select2/select2.full.min.js"></script>
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
        $(function () {
            //Initialize Select2 Elements
            $('.select2').select2();
        });
    </script>
  
</asp:Content>
