<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="Eventos.Vistas.Reporte.Reporte" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Reporte</title>
    <!-- weather icons -->
    <link rel="stylesheet" href="../../Scripts/bower_components/weather-icons/css/weather-icons.min.css" media="all">
    <!-- uikit -->
    <link rel="stylesheet" href="../../Scripts/bower_components/uikit/css/uikit.almost-flat.min.css" media="all">

    <!-- flag icons -->
    <link rel="stylesheet" href="../../Scripts/assets/icons/flags/flags.min.css" media="all">
    <!-- style switcher -->
    <link rel="stylesheet" href="../../Scripts/assets/css/style_switcher.min.css" media="all">
    <!-- altair admin -->
    <link rel="stylesheet" href="../../Scripts/assets/css/main.min.css" media="all">
    <!-- themes -->
    <link rel="stylesheet" href="../../Scripts/assets/css/themes/themes_combined.min.css" media="all">
</head>
<body>
    <form id="form1" runat="server">
        <div class="md-card uk-margin-medium-bottom">
            <div class="md-card-content">
                <div class="dt_colVis_buttons"></div>
                <table id="dt_tableExport" class="uk-table" width="100%">
                    <thead>
                        <tr>
                            <% if (consulta.Columns.Count != 0)
                                {
                                    for (int i = 0; i < consulta.Columns.Count; i++)
                                    {
                                        Response.Write("<th>" + consulta.Columns[i].ToString() + "</th>");
                                    }
                                }
                                else
                                {
                                    Response.Write("<th>No hay valores</th>");
                                }
                            %>
                        </tr>
                    </thead>
                    <tbody>
                        <% 
                            Response.Write("<tr>");
                            for (int i = 0; i < consulta.Rows.Count; i++)
                            {
                                for (int j = 0; j < consulta.Columns.Count; j++)
                                {
                                    Response.Write("<td>" + consulta.Rows[i][j] + "</td>");
                                }
                                Response.Write("</tr>");
                            }

                        %>
                    </tbody>
                </table>
            </div>
        </div>
    </form>
    <!-- common functions -->
    <script src="../../Scripts/assets/js/common.min.js"></script>
    <!-- uikit functions -->
    <script src="../../Scripts/assets/js/uikit_custom.min.js"></script>
    <!-- altair common functions/helpers -->
    <script src="../../Scripts/assets/js/altair_admin_common.min.js"></script>
    <!-- page specific plugins -->
    <!-- datatables -->
    <script src="../../Scripts/bower_components/datatables/media/js/jquery.dataTables.min.js"></script>
    <!-- datatables buttons-->
    <script src="../../Scripts/bower_components/datatables-buttons/js/dataTables.buttons.js"></script>
    <script src="../../Scripts/assets/js/custom/datatables/buttons.uikit.js"></script>
    <script src="../../Scripts/bower_components/jszip/dist/jszip.min.js"></script>
    <script src="../../Scripts/bower_components/pdfmake/build/pdfmake.min.js"></script>
    <script src="../../Scripts/bower_components/pdfmake/build/vfs_fonts.js"></script>
    <script src="../../Scripts/bower_components/datatables-buttons/js/buttons.colVis.js"></script>
    <script src="../../Scripts/bower_components/datatables-buttons/js/buttons.html5.js"></script>
    <script src="../../Scripts/bower_components/datatables-buttons/js/buttons.print.js"></script>
    <!-- datatables custom integration -->
    <script src="../../Scripts/assets/js/custom/datatables/datatables.uikit.min.js"></script>
    <!--  datatables functions -->
    <script src="../../Scripts/assets/js/pages/plugins_datatables.min.js"></script>

    <!-- d3 -->
    <script src="../../Scripts/bower_components/d3/d3.min.js"></script>
    <!-- metrics graphics (charts) -->
    <script src="../../Scripts/bower_components/metrics-graphics/dist/metricsgraphics.min.js"></script>
    <!-- c3.js (charts) -->
    <script src="../../Scripts/bower_components/c3js-chart/c3.min.js"></script>
    <!-- chartist -->
    <script src="../../Scripts/bower_components/chartist/dist/chartist.min.js"></script>
    <!--  charts functions -->
    <script src="../../Scripts/assets/js/pages/plugins_charts.min.js"></script>
</body>
</html>
