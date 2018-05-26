<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgramaView.aspx.cs" Inherits="Eventos.Vistas.Publico.ProgramaView" %>

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
<body class="off-canvas-sidebar register-page">
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


    <div class="wrapper wrapper-full-page">
        <div class="page-header register-page header-filter" filter-color="black" style="background-image: url('../../Estilo/Public/assets/img/bg14.jpg'); background-size: cover; background-position: top center;">
            <div class="container">
                <div class="container-fluid">
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-md-10 ml-auto mr-auto">
                            <div class="wizard-container">
                                <div class="card card-signup card-wizard" data-color="red" id="wizardProfile">
                                    <form id="form1" runat="server">
                                        <div class="card-header text-center">
                                            <h3 class="card-title" id="titulo_registro" runat="server"></h3>
                                            <br />
                                            <div class="col-md-12 text-center">
                                                <asp:Image ID="Image2"  Width="250" Height="100" runat="server" />
                                            </div>
                                        </div>
                                        <div class="wizard-navigation">
                                            <ul class="nav nav-pills">
                                                <li class="nav-item">
                                                    <a class="nav-link active" href="#about" data-toggle="tab" role="tab">Jueves 21 junio 2018</a>
                                                </li>
                                                <li class="nav-item"><a class="nav-link" href="#account" data-toggle="tab" role="tab">Viernes 22 junio 2018 </a>
                                                </li>
                                            </ul>
                                        </div>
                                        <div class="card-body">
                                            <div class="tab-content">
                                                <div class="tab-pane active" id="about">
                                                    <div class="toolbar">
                                                        <!--        Here you can write extra buttons/actions for the toolbar              -->
                                                    </div>
                                                    <div class="material-datatables">
                                                        <table id="datatables" class="table table-striped table-no-bordered table-hover" style="width: 100%">
                                                            <thead>
                                                                <tr>
                                                                    <th style="width: 20%">Hora</th>
                                                                    <th style="width: 40%">Actividad</th>
                                                                    <th style="width: 40%">Responsable</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr>
                                                                    <td>7:30 – 8:00 </td>
                                                                    <td>Inscripciones </td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>8:00 - 8:15 </td>
                                                                    <td>Himnos </td>
                                                                    <td>GRUPO LLANERO EJERCITO NACIONAL </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>8:15 – 9:00 </td>
                                                                    <td>Actos protocolarios -Presentación institucional </td>
                                                                    <td>MEN,Uniamazonia Mg. Gerardo Antonio Castrillón Artunduaga,CCV, CACAOMET y UNILLANOS </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>9:00 -9:25 </td>
                                                                    <td>Presentación CACAO TIC’s </td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>9:25 – 10:10 </td>
                                                                    <td>Graduación de productores </td>
                                                                    <td>EQUIPO CACAOTIC’s </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>10:10 - 10:40 </td>
                                                                    <td>Refrigerio </td>
                                                                    <td>EQUIPO LOGÍSTICA </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>10:40 – 11:05 </td>
                                                                    <td>PONENCIA CACAOMET </td>
                                                                    <td>Edgar Daniel Pacheco Ramírez </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>11:05 – 11:40 </td>
                                                                    <td>PONENCIA CIRAD FRANCIA </td>
                                                                    <td>XAVIER ARGOUT </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>11:40 – 12:05 </td>
                                                                    <td>PONENCIA FEDECACAO </td>
                                                                    <td>Eduard Baquero. Presidente Federación Nacional de Cacaoteros </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>12:05 – 12:30 </td>
                                                                    <td>Acidez del suelo y su relación con la producción de grano de Cacao </td>
                                                                    <td>PhD. Gelber Rosas Patiño – Universidad de la Amazonia </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>2:00 – 2:40 </td>
                                                                    <td>Ronda 1 concurso catación </td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>2:40 – 3:20 </td>
                                                                    <td>Las Universidades, clave en el cambio y la innovación del emprendimiento en el sector cacaotero y chocolatero venezolano </td>
                                                                    <td>ROSA SPINOSA – UNIVERSIDAD SIMÓN BOLIVAR-VENEZUELA </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>3:20 – 4:00 </td>
                                                                    <td>Ronda 2 concurso catación </td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>4:00– 4:30 </td>
                                                                    <td>Refrigerio </td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>4:30– 6:30 </td>
                                                                    <td>Foro: Cacao con esencia de Mujer </td>
                                                                    <td>1. Rosa Spinosa/ USB </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                                <div class="tab-pane" id="account">
                                                    <div class="toolbar">
                                                        <!--        Here you can write extra buttons/actions for the toolbar              -->
                                                    </div>
                                                    <div class="material-datatables">
                                                        <table id="datatables" class="table table-striped table-no-bordered table-hover" style="width: 100%">
                                                            <thead>
                                                                <tr>
                                                                    <th style="width: 20%">Hora</th>
                                                                    <th style="width: 40%">Actividad</th>
                                                                    <th style="width: 40%">Responsable</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr>
                                                                    <td>8:00 – 8:20 </td>
                                                                    <td>Documental “Un Nuevo Comienzo”. Orígenes. Mujer rural </td>
                                                                    <td>EQUIPO AUDIOVISUALES </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>8:20 - 9:00 </td>
                                                                    <td>PONENCIA CIRAD FRANCIA </td>
                                                                    <td>STEPHANE DUPAS </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>9:00 – 9:15 </td>
                                                                    <td>CHOCOLATE TIBITÓ  </td>
                                                                    <td>GUSTAVO ERNESTO PRADILLA </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>9:15 – 10:00 </td>
                                                                    <td>Nuestras experiencias de acceso al mercado / calidad del producto </td>
                                                                    <td>JUAN PABLO BUCHERT – CHOCOLATES NAHUA - COSTA RICA </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>10:00 – 10:30 </td>
                                                                    <td>Refrigerio </td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>10:30 – 12:30 </td>
                                                                    <td>Foro: Perspectivas de la industria cacaotera colombiana </td>
                                                                    <td>Juan Fernando Valenzuela: Nacional Chocolates, Juan Pablo Buchert/ NAHUA, Luis Fernando Muñoz Caviedes SANTA MARÍA, Ángel Antonio Cachaya SENA, Ángel Leonel Torres Ortiz HEIFER GUATEMALA</td>
                                                                </tr>
                                                                <tr>
                                                                    <td>2:00 - 2:30 </td>
                                                                    <td>PONENCIA CIRAD FRANCIA </td>
                                                                    <td>OLIVIER SOUINIGO </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>2:30 - 2:50 </td>
                                                                    <td>Luis Fernando Muñoz Caviedes </td>
                                                                    <td>Chocolates Santa María, Municipio de Hobo, Huila, UDLA </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>3:20 – 3:45 </td>
                                                                    <td>PONENCIA PAZ  </td>
                                                                    <td>Myriam Oviedo, Carolina Cuellar/ USCO-UDLA </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>3:45 - 4:00 </td>
                                                                    <td>INVITADO ESPECIAL </td>
                                                                    <td>POR CONFIRMAR </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>4:00 – 4:30 </td>
                                                                    <td>Refrigerio </td>
                                                                    <td>EQUIPO LOGÍSTICA </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>4:30 - 5:00 </td>
                                                                    <td>Final Concurso Catación </td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>5:00 – 5:30 </td>
                                                                    <td>Premiación Catadores y Grano </td>
                                                                    <td>EQUIPO LOGÍSTICA </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>5:30 – 6:00 </td>
                                                                    <td>Cierre evento y nueva sede </td>
                                                                    <td></td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="card-footer">
                                            <div class="mr-auto">
                                                <input type="button" class="btn btn-previous btn-fill btn-default btn-wd disabled" name="previous" value="Anterior">
                                            </div>
                                            <div class="ml-auto">
                                                <input type="button" class="btn btn-next btn-fill btn-default btn-wd" name="next" value="Siguiente">
                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <footer class="footer ">
                <div class="container">
                    <div class="copyright pull-right">
                        &copy;
                        <script>document.write(new Date().getFullYear())</script>
                        , Desarrollado por el grupos Investigació <a href="http://giecom.co/" target="_blank">Giecom</a>.
                    </div>
                </div>
            </footer>
        </div>
    </div>
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
