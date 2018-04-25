<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/MasterPage.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="CongresoTIC.Views.Home.Main" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <title>Congreso TIC</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content">

        <div class="row">
            <div class="panel-body">
                <div class="col-md-12 col-md-offset-0">
                    <div class="box box-success">
                        <div class="box-body box-profile">
                            <div class="col-md-6 col-md-offset-0 text-center" style="border-width: 0px 1px 0px 0px; border-color: black; border-style: dashed;">
                                <div class="box-body">
                                    <br />
                                    <br />
                                    <span class="badge bg-yellow" style="font-size: 20pt">¡Bienvenido!</span><br />
                                    <h3>Estás inscrito como </h3>
                                    <span class="badge bg-green" style="font-size: 20pt">
                                        <asp:Label ID="LPart" runat="server" Text=""></asp:Label></span>
                                    <br />
                                    <h3>
                                        <b>Simposio Internacional de Investigación 2017</b></h3>
                                    <h5>Universidad de la Amazonia</h5>
                                    <br />
                                </div>
                            </div>
                            <div class="col-md-6 text-center">
                                <br />
                                <br />
                                <center>
                                <%--<img src="../../public/assets/images/fondo/banner.png " class="img-responsive" alt="" />--%>
                                <asp:Image ID="Image2" CssClass="img-responsive" Width="200" runat="server" /><br />
                                <asp:Panel ID="PResult" runat="server" CssClass="alert alert-danger">
                                    <asp:Label ID="Result" Font-Size="14pt" runat="server" Text=""></asp:Label>
                                </asp:Panel>
                                    </center>
                            </div>
                            <asp:Panel ID="Notif" runat="server">
                                <div class="col-md-12 text-center">
                                    <hr />
                                    <asp:Label ID="Notificación" Font-Size="15pt" runat="server" Text="<b>Importante: </b>Para que tu inscripción sea aceptada debes llevar un residuo electrónico. Así podrás participar totalmente gratis en el simposio y además aportas al cuidado del medio ambiente. Sube una foto del residuo que vas a llevar el día del evento."></asp:Label><br />
                                    <br />
                                    <a href="../Evento/Inscripcion.aspx?id=4" runat="server" id="boton" class="btn btn-success">Subir foto</a>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
                <div class="col-md-12">
                    <br />
                    <br />
                    <br />

                </div>
            </div>

        </div>
    </section>

</asp:Content>
