<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Privado/SuperAdmin/PagPrivateMaster.Master" AutoEventWireup="true" CodeBehind="GestionarResponsableView.aspx.cs" Inherits="Eventos.Vistas.Privado.SuperAdmin.GestionarResponsableView" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card ">
                <div class="card-header">
                    <h4 class="card-title">Registrar Responsable</h4>
                </div>
                <div class="card-body ">
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

                  <table id="datatables" class="table table-striped table-no-bordered table-hover" cellspacing="0" width="100%" style="width:100%">
                      <thead>
                          <tr>
                              <th></th>
                              <th>Position</th>
                              <th>Office</th>
                              <th>Age</th>
                              <th>Date</th>
                              <th class="disabled-sorting text-right">Actions</th>
                          </tr>
                      </thead>
                      <tbody>
                          <tr>
                              <td>Tiger Nixon</td>
                              <td>System Architect</td>
                              <td>Edinburgh</td>
                              <td>61</td>
                              <td>2011/04/25</td>
                              <td class="text-right">
                                  <a href="#" class="btn btn-link btn-info btn-just-icon like"><i class="material-icons">favorite</i></a>
                                  <a href="#" class="btn btn-link btn-warning btn-just-icon edit"><i class="material-icons">dvr</i></a>
                                  <a href="#" class="btn btn-link btn-danger btn-just-icon remove"><i class="material-icons">close</i></a>
                              </td>
                          </tr>
                      </tbody>
                  </table>
                  </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Pie" runat="server">
</asp:Content>
