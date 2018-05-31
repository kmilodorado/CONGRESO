<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EventosView.aspx.cs" Inherits="Eventos.Vistas.Publico.EventosView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Eventos</title>
    <!---------------------------------------- Estilos ----------------------------------------->
    <!--     Fonts and icons     -->
    <link rel="stylesheet" type="text/css" href="../../Estilo/Private/assets/css/material.css" />
    <link rel="stylesheet" href="../../Estilo/Private/assets/css/font-awesome.min.css" />
    <link rel="stylesheet" href="../../Estilo/Private/assets/css/material-dashboard.min.css?v=2.0.1" />
    <link href="../../Estilo/Public/assets/css/font-awesome.min.css" rel="stylesheet" />
    <!-- Documentation extras -->
    <!-- CSS Just for demo purpose, don't include it in your project -->
    <link href="../../Estilo/Private/assets/assets-for-demo/demo.css" rel="stylesheet" />
</head>
<body class="off-canvas-sidebar register-page">
    <div class="wrapper wrapper-full-page">
        <div class="page-header register-page header-filter" filter-color="black" style="background-image: url('../../Estilo/Public/assets/img/bg14.jpg'); background-size: cover; background-position: top center;">
            <div class="container">
                <form id="form1" runat="server">
                    <div class="row">
                        <div class="col-md-12 ml-auto mr-auto">
                            <div class="card card-signup">
                                <div class="card-header card-header-danger card-header-icon">
                                    <div class="card-icon">
                                        <i class="material-icons">event</i>
                                    </div>
                                    <h2 class="card-title text-center">Eventos</h2>
                                </div>
                                <div class="card-body">
                                    <div class="row">
                                        <div class="col-md-12 ml-auto">
                                            <!-- Identificación -->
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <div class="toolbar">
                                                        <!--        Here you can write extra buttons/actions for the toolbar              -->
                                                    </div>
                                                    <div class="material-datatables">

                                                        <table id="datatables" class="table table-striped table-no-bordered table-hover" cellspacing="0" width="100%" style="width: 100%">
                                                            <thead>
                                                                <tr>
                                                                    <th>Nombre del evento</th>
                                                                    <th>Logo</th>
                                                                    <th>Fecha inicio</th>
                                                                    <th>Fecha final</th>
                                                                    <th>Url</th>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <asp:Repeater ID="Repeater1" runat="server">
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td><%# Eval("NOMBRE") %></td>
                                                                            <td>
                                                                                <img src="../../Imagen/Evento/<%# Eval("LOGO") %>" width="100" height="50" /></td>
                                                                            <td><%# DateTime.Parse(Eval("F_INI").ToString()).ToString("dd/MM/yyyy") %></td>
                                                                            <td><%# DateTime.Parse(Eval("F_FIN").ToString()).ToString("dd/MM/yyyy") %></td>
                                                                            <td><a href="LoginView.aspx?Evento=<%# Eval("SIGLAS") %>" class="btn btn-warning"><i class="material-icons"></i>ir</a></td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
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
                </form>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
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

<!--  DataTables.net Plugin, full documentation here: https://datatables.net/    -->
<script src="../../Estilo/Private/assets/js/plugins/jquery.datatables.js"></script>

<!-- demo init -->
<script src="../../Estilo/Private/assets/js/plugins/demo.js"></script>
<script type="text/javascript">

    $(document).ready(function () {
        $('#datatables').DataTable({
            "pagingType": "full_numbers",
            "lengthMenu": [
                [10, 25, 50, -1],
                [10, 25, 50, "All"]
            ],
            responsive: true,
            language: {
                search: "_INPUT_",
                searchPlaceholder: "Buscar",
            }

        });

        var table = $('#datatables').DataTable();
        $('.card .material-datatables label').addClass('form-group');
    });

</script>
</html>
