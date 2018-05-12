<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Publico/PagPublic.Master" AutoEventWireup="true" CodeBehind="LoginView.aspx.cs" Inherits="Eventos.Vistas.Publico.LoginView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
        <div class="col-md-4 col-sm-6 ml-auto mr-auto">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <div class="card card-login card-hidden">
                <div class="card-header card-header-warning text-center" style="background:linear-gradient(60deg,#e28b0c,#965605);">
                    <h4 class="card-title">Iniciar Sesión</h4>
                </div>

                <div class="card-body ">
                    <div class="row">
                        <div class="col-md-12 text-center">
                            <asp:Image ID="Image1" Width="100" Height="50" ImageUrl="~/Imagen/Evento/logo cacao tic.png" runat="server" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12 text-center">
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">
                                        <i class="material-icons">person</i>
                                    </span>
                                </div>
                                <asp:TextBox ID="TXT_USER" class="form-control" placeholder="Usuario o Correo..." MaxLength="100" runat="server"></asp:TextBox>
                            </div>
                            <br />
                            <div class="input-group">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">
                                        <i class="material-icons">lock_outline</i>
                                    </span>
                                </div>
                                <asp:TextBox ID="TXT_PASS" TextMode="Password" class="form-control" placeholder="Contraseña..." MaxLength="20" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
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
                        <div class="col-md-12 text-center">
                            <asp:Button ID="BTN_INGRESAR" OnClick="BTN_INGRESAR_Click" CssClass="btn btn-default" style="background:linear-gradient(60deg,#a06104,#623905);" runat="server" Text="Ingresar" />
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-12">
                            <a href="#">Recuperar Contraseña</a>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
    </div>
</asp:Content>
