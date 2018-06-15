<%@ Page Title="" Language="C#" MasterPageFile="~/Vistas/Privado/Usuario/PagPublicMaster.Master" AutoEventWireup="true" CodeBehind="GenerarReporteView.aspx.cs" Inherits="Eventos.Vistas.Privado.Usuario.GenerarReporteView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-md-8 ml-auto mr-auto">
            <div class="page-categories">
                <h3 class="title text-center">Reportes</h3>
                <br />
                <ul class="nav nav-pills nav-pills-danger nav-pills-icons justify-content-center" role="tablist">
                    <li class="nav-item"><a class="nav-link active" data-toggle="tab" href="#link7" role="tablist"> <i class="material-icons">info</i> Participante</a></li>
                </ul>
                <div class="tab-content tab-space tab-subcategories">
                    <div class="tab-pane active" id="link7">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">Reporte de los participantes</h4>
                            </div>
                            <div class="card-body">
                                <asp:DropDownList ID="DDL_EVENTO" CssClass="form-control select2" data-style="btn select-with-transition" title=" Seleccionar Tipo de Participación" runat="server">
                                    <asp:ListItem Selected="True" Value="0" Text="Seleccionar Evento"></asp:ListItem>
                                    <asp:ListItem  Value="1" Text="Congreso"></asp:ListItem>
                                    <asp:ListItem  Value="2" Text="Curso"></asp:ListItem>
                                    <asp:ListItem  Value="3" Text="Workshop"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane" id="link8">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">Location of the product</h4>
                                <p class="card-category">
                                    More information here
             
                                </p>
                            </div>
                            <div class="card-body">
                                Efficiently unleash cross-media information without cross-media value. Quickly maximize timely deliverables for real-time schemas.
             
                                <br>
                                <br>
                                Dramatically maintain clicks-and-mortar solutions without functional solutions.
         
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane" id="link9">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">Legal info of the product</h4>
                                <p class="card-category">
                                    More information here
             
                                </p>
                            </div>
                            <div class="card-body">
                                Completely synergize resource taxing relationships via premier niche markets. Professionally cultivate one-to-one customer service with robust ideas.
             
                                <br>
                                <br>
                                Dynamically innovate resource-leveling customer service for state of the art customer service.
         
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane" id="link10">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">Help center</h4>
                                <p class="card-category">
                                    More information here
             
                                </p>
                            </div>
                            <div class="card-body">
                                From the seamless transition of glass and metal to the streamlined profile, every detail was carefully considered to enhance your experience. So while its display is larger, the phone feels just right.
             
                                <br>
                                <br>
                                Another Text. The first thing you notice when you hold the phone is how great it feels in your hand. The cover glass curves down around the sides to meet the anodized aluminum enclosure in a remarkable, simplified design.
         
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Pie" runat="server">
    <script type="text/javascript">
    $(function () {
        //Initialize Select2 Elements
        $('.select2').select2();
    });
</script>
</asp:Content>
