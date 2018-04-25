<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/MasterPage.Master" AutoEventWireup="true" CodeBehind="Correos.aspx.cs" Inherits="CongresoTIC.Views.Evento.Correos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <title>Correos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>Inscritos al Simposio Internacional
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Partipantes</a></li>
            <li class="active">Inscritos</li>
        </ol>
    </section>
    <section class="content">
        <div class="row">
            <div class="col-lg-12">
                <asp:Panel ID="Resultados" Visible="false" runat="server" CssClass="alert alert-danger">
                    <button type="button" class="close" data-dismiss="alert" aria-hidden="true">×</button>
                    <asp:Label ID="LResultado" runat="server" Text=""></asp:Label>
                </asp:Panel>
            </div>
        </div>
        <asp:Panel ID="Contenido" runat="server">
            <div class="row">
                <div class="col-md-12">
                    Generar correos
<asp:Button runat="server" Text="Generar correos masivos" CssClass="btn btn-success" OnClick="Unnamed_Click"></asp:Button>
                    
                </div>
            </div>
            
        </asp:Panel>
    </section>
</asp:Content>
