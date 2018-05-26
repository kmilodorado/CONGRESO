<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkshopView.aspx.cs" Inherits="Eventos.Vistas.Publico.WorkshopView" %>

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
    <!-- Select2 -->
    <link rel="stylesheet" href="../../Estilo/select2/select2.css" />
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
                    <li class="nav-item  active ">
                        <a id="inscribir" href="#" class="nav-link" runat="server">
                            <i class="material-icons">person_add</i>
                            Registrarse
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
                        <div class="col-md-12 ml-auto mr-auto">
                            <div class="wizard-container">
                                <div class="card card-signup card-wizard" data-color="green" id="wizardProfile">
                                    <form id="form1" runat="server">
                                        <div class="card-header text-center">
                                            <h3 class="card-title" id="titulo_registro" runat="server"></h3>
                                            <div class="col-md-12 text-center">
                                                <asp:Image ID="Image2" ImageUrl="~/Imagen/Evento/logoworkshop.jpg" Width="200" Height="150" runat="server" />
                                            </div>
                                            <br />
                                            <div class="col-md-11 text-left">
                                                <asp:Panel ID="Alerta" CssClass="alert alert-success text-left" Visible="false" runat="server">
                                                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                                        <i class="material-icons">close</i>
                                                    </button>
                                                    <span><b id="Afirm" runat="server"></b>
                                                        <asp:Label ID="Alert" runat="server"></asp:Label></span>
                                                </asp:Panel>
                                            </div>
                                        </div>
                                        <div class="wizard-navigation">
                                            <ul class="nav nav-pills">
                                                <li class="nav-item">
                                                    <a class="nav-link active" href="#about" data-toggle="tab" role="tab">Datos Personales</a>
                                                </li>
                                                <li class="nav-item"><a class="nav-link" href="#account" data-toggle="tab" role="tab">Datos de interés</a>
                                                </li>
                                            </ul>
                                        </div>
                                        <div class="card-body">
                                            <div class="tab-content">
                                                <div class="tab-pane active" id="about">
                                                    <div class="row">
                                                        <div class="col-md-6 ml-auto">
                                                            <!-- Identificación -->
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <div class="form-group">
                                                                        <div class="input-group">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text">
                                                                                    <i class="material-icons">perm_identity</i>
                                                                                </span>
                                                                            </div>
                                                                            <asp:TextBox ID="TXT_IDENTIFICACION" required="required" CssClass="form-control" placeholder="N° Identificación..." pattern="^[0-9]+" MaxLength="10" MinLength="7" onblur="ValidarPersona()" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- tipo Identificación -->
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <div class="form-group has-default">
                                                                        <div class="input-group">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text">
                                                                                    <i class="material-icons">contact_mail</i>
                                                                                </span>
                                                                            </div>
                                                                            <asp:DropDownList ID="DDL_TIPO_DOC" CssClass="form-control  select2" data-style="btn select-with-transition" title=" Seleccionar Tipo Documento" runat="server"></asp:DropDownList>
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                            <!-- Nombre -->
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <div class="form-group has-default">
                                                                        <div class="input-group">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text">
                                                                                    <i class="material-icons">face</i>
                                                                                </span>
                                                                            </div>
                                                                            <asp:TextBox ID="TXT_NOMBRE" required="required" CssClass="form-control" MinLength="3" placeholder="Nombre..." MaxLength="50" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- Apellido -->
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <div class="form-group has-default">
                                                                        <div class="input-group">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text">
                                                                                    <i class="material-icons">face</i>
                                                                                </span>
                                                                            </div>
                                                                            <asp:TextBox ID="TXT_APELLIDO" required="required" CssClass="form-control" MinLength="3" placeholder="Apellido..." MaxLength="50" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- Genero -->
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <div class="form-group has-default">
                                                                        <div class="input-group">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text">
                                                                                    <i class="material-icons">brightness_1</i>
                                                                                </span>
                                                                            </div>
                                                                            <asp:DropDownList ID="DDL_GENERO" CssClass="form-control  select2" data-style="btn select-with-transition" title=" Seleccionar Genero" runat="server"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- Fecha Nacimiento -->
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <div class="form-group has-default">
                                                                        <div class="input-group">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text">
                                                                                    <i class="material-icons">calendar_today</i>
                                                                                </span>
                                                                            </div>
                                                                            <asp:TextBox ID="TXT_FECHA_NAC" required="required" CssClass="form-control" placeholder="Fecha Nacimiento..." title="Fecha Nacimiento" TextMode="Date" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- Pais Nacimiento -->
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <div class="form-group has-default">
                                                                        <div class="input-group">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text">
                                                                                    <i class="material-icons">flag</i>
                                                                                </span>
                                                                            </div>
                                                                            <asp:DropDownList ID="DDL_PAIS_NAC" CssClass="form-control  select2" data-style="btn select-with-transition" title=" Seleccionar Pais Nacimiento" runat="server"></asp:DropDownList>
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6 ml-auto">
                                                            <!-- Correo -->
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <div class="form-group has-default">
                                                                        <div class="input-group">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text">
                                                                                    <i class="material-icons">email</i>
                                                                                </span>
                                                                            </div>
                                                                            <asp:TextBox ID="TXT_CORREO" required="required" CssClass="form-control" placeholder="Correo..." TextMode="Email" MaxLength="100" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- Celular -->
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <div class="form-group has-default">
                                                                        <div class="input-group">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text">
                                                                                    <i class="material-icons">phone</i>
                                                                                </span>
                                                                            </div>
                                                                            <asp:TextBox ID="TXT_CELULAR" required="required" CssClass="form-control" MinLength="7" placeholder="Telefono o Celular..." pattern="^[0-9]+" MaxLength="10" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- Pais-->
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <div class="form-group has-default">
                                                                        <div class="input-group">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text">
                                                                                    <i class="material-icons">flag</i>
                                                                                </span>
                                                                            </div>
                                                                            <asp:DropDownList ID="DDL_PAIS" OnSelectedIndexChanged="DDL_PAIS_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control  select2" data-style="btn select-with-transition" title=" Seleccionar Pais de Residencia" runat="server"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- Departamento -->
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <div class="form-group has-default">
                                                                        <div class="input-group">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text">
                                                                                    <i class="material-icons">flag</i>
                                                                                </span>
                                                                            </div>
                                                                            <asp:DropDownList ID="DDL_DEPARTAMENTO" OnSelectedIndexChanged="DDL_DEPARTAMENTO_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control  select2" data-style="btn select-with-transition" title=" Seleccionar Departamento de Residencia" runat="server">
                                                                                <asp:ListItem Text="Seleccionar Departamento"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>

                                                                </div>
                                                            </div>
                                                            <!-- Municipio -->
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <div class="form-group has-default">
                                                                        <div class="input-group">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text">
                                                                                    <i class="material-icons">flag</i>
                                                                                </span>
                                                                            </div>
                                                                            <asp:DropDownList ID="DDL_MUNICIPIO" CssClass="form-control  select2" data-style="btn select-with-transition" title=" Seleccionar Municipio de Residencia" runat="server">
                                                                                <asp:ListItem Text="Seleccionar Municipio"></asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- Dirección -->
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <div class="form-group has-default">
                                                                        <div class="input-group">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text">
                                                                                    <i class="material-icons">place</i>
                                                                                </span>
                                                                            </div>
                                                                            <asp:TextBox ID="TXT_DIRECCION" CssClass="form-control" required="required" placeholder="Dirección..." MaxLength="100" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- Institución -->
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <div class="form-group has-default">
                                                                        <div class="input-group">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text">
                                                                                    <i class="material-icons">account_balance</i>
                                                                                </span>
                                                                            </div>
                                                                            <asp:TextBox ID="TXT_INSTITUCION" required="required" CssClass="form-control valid" placeholder="Institución..." MaxLength="50" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="tab-pane" id="account">
                                                    <div class="row">
                                                        <div class="col-md-12 ml-auto">
                                                            <!-- Condición -->
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <div class="form-group has-default">
                                                                        <div class="input-group">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text">
                                                                                    <i class="material-icons">supervised_user_circle</i>
                                                                                </span>
                                                                            </div>
                                                                            <asp:DropDownList ID="DDL_CONDICION" CssClass="form-control select2" Width="90%"  title="Cuenta con alguna condición especial" runat="server"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- Nivel de formación -->
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <div class="form-group has-default">
                                                                        <div class="input-group">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text">
                                                                                    <i class="material-icons">supervised_user_circle</i>
                                                                                </span>
                                                                            </div>
                                                                            <asp:DropDownList ID="DDL_CIRCUNS" CssClass="form-control select2" Width="90%" data-style="btn select-with-transition" title=" Seleccionar Circunscripción" runat="server"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- Nivel de formación -->
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <div class="form-group has-default">
                                                                        <div class="input-group">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text">
                                                                                    <i class="material-icons">supervised_user_circle</i>
                                                                                </span>
                                                                            </div>
                                                                            <asp:DropDownList ID="DDL_FORMACION" CssClass="form-control  select2" Width="90%" data-style="btn select-with-transition" title=" Seleccionar Nivel de Formación" runat="server"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- Ocupación -->
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <div class="form-group has-default">
                                                                        <div class="input-group">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text">
                                                                                    <i class="material-icons">supervised_user_circle</i>
                                                                                </span>
                                                                            </div>
                                                                            <asp:DropDownList ID="DDL_OCUPACION" CssClass="form-control  select2" Width="90%" data-style="btn select-with-transition" title=" Seleccionar Ocupación" runat="server"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <!-- Participante -->
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <div class="form-group has-default">
                                                                        <div class="input-group">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text">
                                                                                    <i class="material-icons">supervised_user_circle</i>
                                                                                </span>
                                                                            </div>
                                                                            <asp:DropDownList ID="DDL_PARTICIPACION" CssClass="form-control  select2" Width="90%" data-style="btn select-with-transition" title=" Seleccionar Tipo de Participación" runat="server"></asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="card-footer">
                                            <div class="mr-auto">
                                                <input type="button" class="btn btn-previous btn-fill btn-default btn-wd disabled" name="previous" value="Anterior">
                                            </div>
                                            <div class="ml-auto">
                                                <input type="button" class="btn btn-next btn-fill btn-success btn-wd" name="next" value="Siguiente">
                                                <asp:Button ID="Registrar" OnClick="Registrar_Click" CssClass="btn btn-finish btn-fill btn-success btn-wd" name="finish" Text="Registrar" Style="display: none;" runat="server" />
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
<!-- Select2 -->
<script src="../../Estilo/select2/select2.full.min.js"></script>

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
    $(function () {
        //Initialize Select2 Elements
        $('.select2').select2();
    });
</script>

<!-- Sharrre libray -->
<script src="../../Estilo/Private/assets/assets-for-demo/js/jquery.sharrre.js"></script>
</html>
