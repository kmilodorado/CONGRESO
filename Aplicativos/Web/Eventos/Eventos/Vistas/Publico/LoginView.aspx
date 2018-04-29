<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Publico/PagPublic.Master" AutoEventWireup="true" CodeBehind="LoginView.aspx.cs" Inherits="Eventos.Vistas.Publico.LoginView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="col-md-4 ml-auto mr-auto">
        <div class="card card-login card-plain">
            <div class="card-header ">
                <div class="logo-container">
                    <img src="../../Imagen/LogoUA.png" height="80" alt="">
                </div>
                <h4 class="control-label text_align-center text-center" style="text-align: center; vertical-align: central">Sistema de eventos Universidad de la Amazonia</h4>
            </div>

            <div class="card-body ">
                <div class="input-group no-border form-control-lg">
                    <span class="input-group-addon">
                        <i class="fa fa-user"></i>
                    </span>
                    <asp:TextBox ID="TXTUSUARIO" placeholder="Usuario..." CssClass="form-control" MaxLength="50" ValidateRequestMode="Disabled" runat="server"></asp:TextBox>
                </div>

                <div class="input-group no-border form-control-lg">
                    <span class="input-group-addon">
                        <i class="fa fa-unlock-alt"></i>
                    </span>
                    <asp:TextBox ID="TXTPASS" placeholder="Contraseña..." CssClass="form-control" MaxLength="20" ValidateRequestMode="Disabled" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="card-footer ">
                <asp:Button ID="BTN_INGRESAR" CssClass="btn btn-primary btn-round btn-lg btn-block mb-3" runat="server" Text="Ingresar" />
            </div>

        </div>
    </div>
</asp:Content>
