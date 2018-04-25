<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Home/MasterPage.Master" AutoEventWireup="true" CodeBehind="Export.aspx.cs" Inherits="CongresoTIC.Views.Evento.Export" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <title>Escarapelas</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content-header">
        <h1>Inscripciones al Congreso TIC
        </h1>
        <ol class="breadcrumb">
            <li><a href="#"><i class="fa fa-dashboard"></i>Logística</a></li>
            <li class="active">Escarapelas</li>
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
                    <!-- Custom Tabs -->
                    <div class="nav-tabs-custom">
                        <ul class="nav nav-tabs">
                            <li class="active"><a href="#tab_1" data-toggle="tab">Escarapelas</a></li>
                            <%--<li><a href="#tab_2" data-toggle="tab">Cargar ejercicios</a></li>--%>
                        </ul>
                        <div class="tab-content">
                            <div class="tab-pane active" id="tab_1">
                                <div class="row">

                                    <div class="col-lg-12">
                                        <div class="panel panel-default">
                                            <div class="panel-body">
                                                <div class="table-responsive">
                                                    <div class="box">
                                                        <div class="box-body" id="iv_table">
                                                            <table id="dataTable" class="table table-bordered table-striped">
                                                                <thead>
                                                                    <tr>
                                                                        <th>N°</th>
                                                                        <th>Descripción</th>
                                                                        <th>Identificación</th>
                                                                        <th></th>
                                                                    </tr>
                                                                </thead>
                                                                <tbody>
                                                                    <tr>
                                                                        <td>1</td>
                                                                        <td>Escarapelas de todos los participantes en el Simposio Internacional</td>
                                                                        <td></td>
                                                                        <td>
                                                                            <asp:Button ID="GenerarTodos" CssClass="btn btn-success btn-xs" runat="server" Text="Descargar" OnClick="GenerarTodos_Click" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>2</td>
                                                                        <td>Escarapela por estudiante</td>
                                                                        <td>
                                                                            <asp:TextBox ID="t_cedula" CssClass="form-control" placeholder="Ej.: 123456" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="GenerarUno" CssClass="btn btn-success btn-xs" runat="server" Text="Descargar" OnClick="GenerarUno_Click" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>3</td>
                                                                        <td>Generar QR para todos los participantes</td>
                                                                        <td></td>
                                                                        <td>
                                                                            <asp:Button ID="QR_Generate" CssClass="btn btn-success btn-xs" runat="server" Text="Generar" OnClick="QR_Generate_Click" />
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>2</td>
                                                                        <td>Certificados de asistencia</td>
                                                                        <td>
                                                                            <asp:TextBox ID="t_documento" CssClass="form-control" placeholder="Ej.: 123456789" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="Certificado" CssClass="btn btn-success btn-xs" runat="server" Text="Descargar" OnClick="Certificado_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
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
