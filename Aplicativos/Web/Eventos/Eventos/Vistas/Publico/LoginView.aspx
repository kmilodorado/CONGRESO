<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginView.aspx.cs" Inherits="Eventos.Vistas.Publico.LoginView1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link id="icono" rel="icon" href="../../Imagen/Evento/LogoGIECOM.png" runat="server" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title id="titulo" runat="server"></title>
    <!---------------------------------------- Estilos ----------------------------------------->
    <!--     Fonts and icons     -->
    <link rel="stylesheet" type="text/css" href="../../Estilo/Private/assets/css/material.css" />
    <link rel="stylesheet" href="../../Estilo/Private/assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../Estilo/Private/assets/css/material-dashboard.min.css?v=2.0.1" />
    <link href="../../Estilo/Public/assets/css/font-awesome.min.css" rel="stylesheet" />
    <!-- Documentation extras -->
    <!-- CSS Just for demo purpose, don't include it in your project -->
    <link href="../../Estilo/Private/assets/assets-for-demo/demo.css" rel="stylesheet" />

    <!-- iframe removal -->
    <script type="text/javascript">
        if (document.readyState === 'complete') {
            if (window.location != window.parent.location) {
                const elements = document.getElementsByClassName("iframe-extern");
                while (elemnts.lenght > 0) elements[0].remove();
                // $(".iframe-extern").remove();
            }
        };
    </script>
    <!---------------------------------------- End Estilos ----------------------------------------->
</head>
<body onload="nobackbutton()" class="off-canvas-sidebar register-page">
    <!-- Navbar -->
    <nav class="navbar navbar-expand-lg bg-primary navbar-transparent navbar-absolute" color-on-scroll="500">
        <div class="container">
            <div class="navbar-wrapper">
                <a id="Evento" class="navbar-brand" href="#Evento" runat="server"></a>
            </div>
            <div class="collapse navbar-collapse justify-content-end" id="navbar">
                <ul class="navbar-nav">
                    <li class="nav-item ">
                        <a id="login" href="#" class="nav-link" runat="server">
                            <i class="material-icons">fingerprint</i>
                            Iniciar sesión
                        </a>
                    </li>
                    <li class="nav-item  active ">
                        <a id="inscribir" href="#" class="nav-link" runat="server">
                            <i class="material-icons">person_add</i>
                            Registrarse
                        </a>
                    </li>
                    <li class="nav-item">
                        <a id="programa" href="#" class="nav-link" runat="server">
                            <i class="material-icons">dashboard</i>
                            Programación del evento
                        </a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    <!-- End Navbar -->

    <form id="form1" runat="server">
        <div class="wrapper wrapper-full-page">
            <div class="page-header register-page header-filter" filter-color="black" style="background-image: url('../../Estilo/Public/assets/img/bg14.jpg'); background-size: cover; background-position: top center;">
                <div class="container">
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
                                <div class="card-header card-header-warning text-center" style="background: linear-gradient(60deg,#c5230c,#68120b);">
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
                                            <asp:Button ID="BTN_INGRESAR" OnClick="BTN_INGRESAR_Click" CssClass="btn btn-default" Style="background: linear-gradient(60deg,#c5230c,#68120b);" runat="server" Text="Ingresar" />
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-12">
                                            <a href="#" class="text text-danger font-weight-bold" data-toggle="modal" data-target="#Recuperar">Recuperar Contraseña</a>
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
                </div>
                <footer class="footer ">
                    <div class="container">
                        <div class="copyright pull-right">
                            &copy;
                        <script>document.write(new Date().getFullYear())</script>
                            , Desarrollado por el grupo de Investigación <a href="http://giecom.co/" target="_blank">Giecom</a>.
                        </div>
                    </div>
                </footer>
            </div>
        </div>
        <div id="Recuperar" class="modal" tabindex="-1" role="dialog">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Recuperar Contraseña</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-md-12">
                                <div class="form-group has-default">
                                    <div class="input-group">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">
                                                <i class="material-icons">email</i>
                                            </span>
                                        </div>
                                        <asp:TextBox ID="TXT_CORREO" CssClass="form-control" placeholder="Correo..." TextMode="Email" MaxLength="100" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:LinkButton ID="BTN_RECUPERAR" class="btn btn-primary" Style="background: linear-gradient(60deg,#c5230c,#68120b);" OnClick="BTN_RECUPERAR_Click" runat="server">Enviar Contraseña</asp:LinkButton>
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancelar</button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>

<!--   Core JS Files   -->
<script src="../../Estilo/Private/assets/js/core/jquery.min.js"></script>
<script src="../../Estilo/Private/assets/js/core/popper.min.js"></script>
<script src="../../Estilo/Private/assets/js/bootstrap-material-design.min.js"></script>
<script src="../../Estilo/Private/assets/js/plugins/perfect-scrollbar.jquery.min.js"></script>


<!--  Plugin for Date Time Picker and Full Calendar Plugin  -->
<script src="../../Estilo/Private/assets/js/plugins/moment.min.js"></script>

<!--	Plugin for the Datepicker, full documentation here: https://github.com/Eonasdan/bootstrap-datetimepicker -->
<script src="../../Estilo/Private/assets/js/plugins/bootstrap-datetimepicker.min.js"></script>

<!--	Plugin for the Sliders, full documentation here: http://refreshless.com/nouislider/ -->
<script src="../../Estilo/Private/assets/js/plugins/nouislider.min.js"></script>



<!--	Plugin for Select, full documentation here: http://silviomoreto.github.io/bootstrap-select -->
<script src="../../Estilo/Private/assets/js/plugins/bootstrap-selectpicker.js"></script>

<!--	Plugin for Tags, full documentation here: http://xoxco.com/projects/code/tagsinput/  -->
<script src="../../Estilo/Private/assets/js/plugins/bootstrap-tagsinput.js"></script>

<!--	Plugin for Fileupload, full documentation here: http://www.jasny.net/bootstrap/javascript/#fileinput -->
<script src="../../Estilo/Private/assets/js/plugins/jasny-bootstrap.min.js"></script>

<!-- Plugins for presentation and navigation  -->
<script src="../../Estilo/Private/assets/assets-for-demo/js/modernizr.js"></script>

<!-- Material Kit Core initialisations of plugins and Bootstrap Material Design Library -->
<script src="../../Estilo/Private/assets/js/material-dashboard.js?v=2.0.1"></script>
<!-- Include a polyfill for ES6 Promises (optional) for IE11, UC Browser and Android browser support SweetAlert -->
<script src="../../Estilo/Private/assets/js/core.js"></script>
<!-- Library for adding dinamically elements -->
<script src="../../Estilo/Private/assets/js/plugins/arrive.min.js" type="text/javascript"></script>

<!-- Forms Validations Plugin -->
<script src="../../Estilo/Private/assets/js/plugins/jquery.validate.min.js"></script>

<!--  Charts Plugin, full documentation here: https://gionkunz.github.io/chartist-js/ -->
<script src="../../Estilo/Private/assets/js/plugins/chartist.min.js"></script>

<!--  Plugin for the Wizard, full documentation here: https://github.com/VinceG/twitter-bootstrap-wizard -->
<script src="../../Estilo/Private/assets/js/plugins/jquery.bootstrap-wizard.js"></script>

<!--  Notifications Plugin, full documentation here: http://bootstrap-notify.remabledesigns.com/    -->
<script src="../../Estilo/Private/assets/js/plugins/bootstrap-notify.js"></script>

<!-- Vector Map plugin, full documentation here: http://jvectormap.com/documentation/ -->
<script src="../../Estilo/Private/assets/js/plugins/jquery-jvectormap.js"></script>

<!-- Sliders Plugin, full documentation here: https://refreshless.com/nouislider/ -->
<script src="../../Estilo/Private/assets/js/plugins/nouislider.min.js"></script>

<!--  Plugin for Select, full documentation here: http://silviomoreto.github.io/bootstrap-select -->
<script src="../../Estilo/Private/assets/js/plugins/jquery.select-bootstrap.js"></script>

<!--  DataTables.net Plugin, full documentation here: https://datatables.net/    -->
<script src="../../Estilo/Private/assets/js/plugins/jquery.datatables.js"></script>

<!-- Sweet Alert 2 plugin, full documentation here: https://limonte.github.io/sweetalert2/ -->
<script src="../../Estilo/Private/assets/js/plugins/sweetalert2.js"></script>

<!-- Plugin for Fileupload, full documentation here: http://www.jasny.net/bootstrap/javascript/#fileinput -->
<script src="../../Estilo/Private/assets/js/plugins/jasny-bootstrap.min.js"></script>

<!--  Full Calendar Plugin, full documentation here: https://github.com/fullcalendar/fullcalendar    -->
<script src="../../Estilo/Private/assets/js/plugins/fullcalendar.min.js"></script>

<!-- demo init -->
<script src="../../Estilo/Private/assets/js/plugins/demo.js"></script>
<!-- Enviar parametro instantaniamente -->
<script src="https://unpkg.com/axios/dist/axios.min.js"></script>

<!-- Metodos -->
<script src="../../Scripts/Metodos.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
        //init wizard
        demo.initMaterialWizard();
        // Javascript method's body can be found in assets/js/demos.js
        demo.initDashboardPageCharts();
        demo.initCharts();
    });
</script>
<script type="text/javascript">
    $(document).ready(function () {
        demo.initVectorMap();
    });
</script>
<!-- Sharrre libray -->
<script src="../../Estilo/Private/assets/assets-for-demo/js/jquery.sharrre.js"></script>
</html>
