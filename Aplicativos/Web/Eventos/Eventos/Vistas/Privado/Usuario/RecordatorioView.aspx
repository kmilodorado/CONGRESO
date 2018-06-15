<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Privado/Usuario/PagPublicMaster.Master" AutoEventWireup="true" CodeBehind="RecordatorioView.aspx.cs" Inherits="Eventos.Vistas.Privado.Usuario.RecordatorioView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card ">
                <div class="card-header card-header-danger card-header-icon">
                    <h4 class="card-title">Enviar Correo a todos los participantes del evento</h4>
                </div>
                <div class="card-body ">
                    <div class="row">
                        <div class="col-md-12 ml-auto mr-auto  text-center">
                            <asp:Button ID="EnviarCorreo" OnClick="EnviarCorreo_Click" CssClass="btn btn-success" Text="Enviar Correo Maxivo" runat="server" />
                            <br />
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Pie" runat="server">
</asp:Content>
