//Bloquear el direccionamiento a la pagina inicial
function nobackbutton() {
    window.location.hash = "no-back-button";
    window.location.hash = "Again-No-back-button" //chrome
    window.onhashchange = function () { window.location.hash = "no-back-button"; }
}

function ValidarPersona() {
    var id = document.getElementById("Contenido_TXT_IDENTIFICACION").value;
    axios.get("../Complemento/ValidarPersona.aspx?id=" + id).then((resul) => {
        var mensaje = resul.data.split(',');
        var condicion = false;
        if (mensaje[0] == "true") {
            document.getElementById("Contenido_TXT_NOMBRE").value = mensaje[2];
            document.getElementById("Contenido_TXT_APELLIDO").value = mensaje[3];
            document.getElementById("Contenido_TXT_CORREO").value = mensaje[4];
            document.getElementById("Contenido_TXT_CELULAR").value = mensaje[5];
            document.getElementById("Contenido_TXT_DIRECCION").value = mensaje[6];
            document.getElementById("Contenido_TXT_INSTITUCION").value = mensaje[7];
            document.getElementById("Contenido_TXT_USER").value = mensaje[8];
            document.getElementById("Contenido_Registrar").value = "Inscribir";
            condicion = true;
        } else {
            document.getElementById("Contenido_Registrar").value = "Registrar";
        }

        document.getElementById("Contenido_DDL_TIPO_DOC").disabled = condicion;
        document.getElementById("Contenido_TXT_NOMBRE").disabled = condicion;
        document.getElementById("Contenido_TXT_APELLIDO").disabled = condicion;
        document.getElementById("Contenido_TXT_CORREO").disabled = condicion;
        document.getElementById("Contenido_TXT_CELULAR").disabled = condicion;
        document.getElementById("Contenido_DDL_DEPARTAMENTO").disabled = condicion;
        document.getElementById("Contenido_DDL_MUNICIPIO").disabled = condicion;
        document.getElementById("Contenido_TXT_DIRECCION").disabled = condicion;
        document.getElementById("Contenido_TXT_INSTITUCION").disabled = condicion;
        document.getElementById("Contenido_DDL_FORMACION").disabled = condicion;
        document.getElementById("Contenido_DDL_OCUPACION").disabled = condicion;
        document.getElementById("Contenido_TXT_USER").disabled = condicion;
        document.getElementById("Contenido_TXT_PASS").disabled = condicion;
        document.getElementById("Contenido_DDL_PARTICIPACION").disabled = condicion;
       
    }).catch(error=> {
    });
}