<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/MasterPage.Master" AutoEventWireup="true" CodeBehind="Certificado.aspx.cs" Inherits="CongresoTIC.Views.Evento.Certificado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <title>Certificados</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>Certificados
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Certificados</a></li>
            <li class="active">Asistencia</li>
        </ol>
    </section>

    <section class="content">
        <div class="row">
        </div>
        <asp:Panel ID="Contenido" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#tab_1" data-toggle="tab">Certificado de asistencia</a></li>
                        </ul>
                        <div class="tab-content">
                            <div class="tab-pane active" id="tab_1">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="panel panel-default">
                                            <div class="panel-body">
                                                <div class="box">
                                                    <div class="box-body">
                                                        <div class="row">
                                                            <div class="panel-body">
                                                                <div class="col-lg-12 text-center">
                                                                    <asp:Panel ID="Resultados" Font-Size="16pt" Visible="true" runat="server" CssClass="alert alert-danger">
                                                                        <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                                                                        <asp:Label ID="LResultado" runat="server" Text=""></asp:Label>
                                                                    </asp:Panel>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-12 text-center">
                                                                        <asp:Button ID="Generar" runat="server" Text="Generar certificado" CssClass="btn btn-success" OnClick="Generar_Click" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

    </section>

</asp:Content>
