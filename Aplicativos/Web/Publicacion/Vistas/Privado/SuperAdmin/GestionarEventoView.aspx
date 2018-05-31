<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Privado/SuperAdmin/PagPrivateMaster.Master" AutoEventWireup="true" CodeBehind="GestionarEventoView.aspx.cs" Inherits="Eventos.Vistas.Privado.SuperAdmin.GestionarEventoView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Encabezado" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="card ">
                <div class="card-header card-header-danger card-header-icon">
                    <div class="card-icon">
                        <i class="material-icons">event</i>
                    </div>
                    <h4 class="card-title">Registrar Evento</h4>
                </div>
                <div class="card-body ">
                    <div class="row">
                        <div class="col-md-9">
                            <div class="form-group bmd-form-group">
                                <label for="TXT_NOMBRE" class="bmd-label-floating">Nombre </label>
                                <asp:TextBox ID="TXT_NOMBRE" CssClass="form-control" required="true" MaxLength="100" aria-required="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group bmd-form-group">
                                <label for="TXT_SIGLAS" class="bmd-label-floating">Siglas</label>
                                <asp:TextBox ID="TXT_SIGLAS" CssClass="form-control" MaxLength="10" required="true" aria-required="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group bmd-form-group">
                                <label for="TXT_FECHA_INI" class="bmd-label-floating">Fecha inicial</label>
                                <asp:TextBox ID="TXT_FECHA_INI" CssClass="form-control datepicker" required="true" aria-required="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group bmd-form-group">
                                <label for="TXT_FECHA_FIN" class="bmd-label-floating">Fecha final</label>
                                <asp:TextBox ID="TXT_FECHA_FIN" CssClass="form-control datepicker" required="true" aria-required="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-5">
                            <div class="form-group bmd-form-group">
                                <label for="TXT_CORREO" class="bmd-label-floating">Correo</label>
                                <asp:TextBox ID="TXT_CORREO" CssClass="form-control" MaxLength="100" email="true" required="true" aria-required="true" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group bmd-form-group">
                                <label for="TXT_CUPOS" class="bmd-label-floating">Cupos</label>
                                <asp:TextBox ID="TXT_CUPOS" CssClass="form-control" MaxLength="10" number="true" required="true" aria-required="true" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <asp:DropDownList ID="DDL_VALOR" CssClass="selectpicker" data-style="btn btn-default btn-round" title="Valor de inscripción" runat="server">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4 ml-auto mr-auto text-center">
                            <div class="form-group bmd-form-group">
                                <h4 class="title">Logo</h4>
                                <div class="fileinput fileinput-new text-center" data-provides="fileinput">
                                    <div class="fileinput-new thumbnail">
                                        <asp:Image ID="Image1" ImageUrl="~/Estilo/Private/assets/img/image_placeholder.jpg" AlternateText="..." runat="server" />
                                    </div>
                                    <div class="fileinput-preview fileinput-exists thumbnail"></div>
                                    <div>
                                        <span class="btn btn-rose btn-round btn-file">
                                            <span class="fileinput-new">Select image</span>
                                            <span class="fileinput-exists">Change</span>
                                            <asp:FileUpload ID="FILE_LOGO" name="..." runat="server" />
                                        </span>
                                        <a href="#pablo" class="btn btn-success btn-round fileinput-exists" data-dismiss="fileinput"><i class="fa fa-times"></i>Remove</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 ml-auto mr-auto text-center">
                            <div class="form-group bmd-form-group">
                                <h4 class="title">Poster</h4>
                                <div class="fileinput fileinput-new text-center" data-provides="fileinput">
                                    <div class="fileinput-new thumbnail">
                                        <asp:Image ID="Image2" ImageUrl="~/Estilo/Private/assets/img/image_placeholder.jpg" AlternateText="..." runat="server" />
                                    </div>
                                    <div class="fileinput-preview fileinput-exists thumbnail"></div>
                                    <div>
                                        <span class="btn btn-rose btn-round btn-file">
                                            <span class="fileinput-new">Select image</span>
                                            <span class="fileinput-exists">Change</span>
                                            <asp:FileUpload ID="FILE_POSTER" name="..." runat="server" />
                                        </span>
                                        <a href="#pablo" class="btn btn-success btn-round fileinput-exists" data-dismiss="fileinput"><i class="fa fa-times"></i>Remove</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-md-6 ml-auto mr-auto  text-center">
                            <asp:Button ID="BTN_REGISTRAR" CssClass="btn btn-danger" OnClick="BTN_REGISTRAR_Click" runat="server" Text="Registrar" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Pie" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            //init DateTimePickers
            md.initFormExtendedDatetimepickers();
            // Sliders Init
            md.initSliders();
        });
</script>
</asp:Content>
