<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Privado/Usuario/PagPublicMaster.Master" AutoEventWireup="true" CodeBehind="PrincipalView.aspx.cs" Inherits="Eventos.Vistas.Privado.Usuario.PrincipalView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card ">
                <div class="card-header card-header-succes card-header-icon">
                </div>
                <div class="card-body ">
                    <div class="row">
                        <div class="col-md-12 text-center">
                            <h2 id="titulo_evento" class="font-weight-bold" runat="server">Simposio Internacional de Investigación 2017</h2>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 text-center font-weight-bold">
                            <span style="font-size:24pt;">¡Bienvenido!</span><br />
                        </div>
                    </div>
                    <br />
                     <div class="row">
                        <div class="col-md-12 text-center font-weight-bold">
                            <span style="font-size:18pt;"> <asp:Label ID="Label2" runat="server" CssClass="font-weight-bold" Text="Asistente"></asp:Label></span>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-md-12 text-center">
                            <h4>Estás inscrito como </h4>
                            <span style="font-size: 16pt">
                                <asp:Label ID="Label1" runat="server" Text="Asistente"></asp:Label></span>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-md-12 text-center">
                            <asp:Image ID="Image1" ImageUrl="~/Imagen/Codigo/GetFileAttachment.jpg" runat="server" />
                            <p class="font-weight-bold">NOTA IMPORTANTE: El código QR aquí adjunto deberá ser presentado al momento del ingreso al evento, la recomendación es guardar una captura de pantalla, imprimirlo o guardarlo como imagen para agilizar el proceso de entrada al recinto.</p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
