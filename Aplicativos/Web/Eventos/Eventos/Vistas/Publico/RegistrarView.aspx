<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Publico/PagPublic.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="RegistrarView.aspx.cs" Inherits="Eventos.Vistas.Publico.RegistrarView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
        <div class="col-md-12 ml-auto mr-auto">
            <div class="card card-signup">
                <h3 class="card-title text-center">Registrar su asistencia</h3>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Panel ID="Alerta" CssClass="alert alert-success" Visible="false" runat="server">
                                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                    <i class="material-icons">close</i>
                                </button>
                                <span><b id="Afirm" runat="server"></b>
                                    <asp:Label ID="Alert" runat="server"></asp:Label></span>
                            </asp:Panel>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-4 ml-auto">
                            <!-- Identificación -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group has-default">
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="material-icons">perm_identity</i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="TXT_IDENTIFICACION" required="required" CssClass="form-control" placeholder="N° Identificación..." pattern="^[0-9]+" MaxLength="12" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <!-- tipo Identificación -->
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-10">
                                    <asp:DropDownList ID="DDL_TIPO_DOC" CssClass="selectpicker" data-style="btn select-with-transition" title=" Seleccionar Tipo Documento" runat="server"></asp:DropDownList>
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
                                            <asp:TextBox ID="TXT_NOMBRE" required="required" CssClass="form-control" placeholder="Nombre..." MaxLength="50" runat="server"></asp:TextBox>
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
                                            <asp:TextBox ID="TXT_APELLIDO" required="required" CssClass="form-control" placeholder="Apellido..." MaxLength="50" runat="server"></asp:TextBox>
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
                                            <asp:TextBox ID="TXT_CELULAR" required="required" CssClass="form-control" placeholder="Telefono o Celular..." pattern="^[0-9]+" MaxLength="10" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 ml-auto">
                            <br />
                            <!-- Departamento -->
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-10">
                                    <asp:DropDownList ID="DDL_DEPARTAMENTO" OnSelectedIndexChanged="DDL_DEPARTAMENTO_SelectedIndexChanged" AutoPostBack="true" CssClass="selectpicker" data-style="btn select-with-transition" title=" Seleccionar Departamento" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <!-- Municipio -->
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-10">
                                    <asp:DropDownList ID="DDL_MUNICIPIO" CssClass="selectpicker" data-style="btn select-with-transition" title=" Seleccionar Municipio" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <!-- Dirección -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group has-default">
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="material-icons">place</i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="TXT_DIRECCION" CssClass="form-control" required="required" placeholder="Dirección..." MaxLength="100" runat="server"></asp:TextBox>
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
                                            <asp:TextBox ID="TXT_INSTITUCION" required="required" CssClass="form-control" placeholder="Institución..." MaxLength="50" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <!-- Nivel de formación -->
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-10">
                                    <asp:DropDownList ID="DDL_FORMACION" CssClass="selectpicker" data-style="btn select-with-transition" title=" Seleccionar Nivel de Formación" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <!-- Ocupación -->
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-10">
                                    <asp:DropDownList ID="DDL_OCUPACION" CssClass="selectpicker" data-style="btn select-with-transition" title=" Seleccionar Ocupación" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 ml-auto">
                            <!-- Usuario -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group has-default">
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="material-icons">person</i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="TXT_USER" required="required" CssClass="form-control" placeholder="Usuario..." MaxLength="50" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- Contraseña -->
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group has-default">
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="material-icons">lock_outline</i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="TXT_PASS" TextMode="Password" required="required" CssClass="form-control" placeholder="Contraseña..." MaxLength="20" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <br />
                            <!-- Participante -->
                            <div class="row">
                                <div class="col-md-2"></div>
                                <div class="col-md-10">
                                    <asp:DropDownList ID="DDL_PARTICIPACION" CssClass="selectpicker" data-style="btn select-with-transition" title=" Seleccionar Tipo de Participación" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <br />
                             <div class="row">
                                <div class="col-md-12 text-center">
                                    <asp:Image ID="Image1" ImageUrl="~/Imagen/Evento/logo cacao tic.png" Width="250" Height="150" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12 text-center">
                            <asp:Button ID="Registrar" OnClick="Registrar_Click" CssClass="btn btn-success"  Text="Registrar" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
