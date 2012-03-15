/// <reference path="CbaGob.Alumnos.Global.js" />
/// <reference path="jquery-1.5.1-vsdoc.js" />
/// <reference path="jquery-ui-1.8.11.js" />
/// <reference path="CbaGob.Alumnos.BuscadorAlumno.js" />
/// <reference path="CbaGob.Alumnos.BuscadorCondicionCurso.js" />


$(function () {

    cbaAlumnosInscripciones.initInscripciones();
    cbaAlumnosInscripciones.initCertificado();
    cbaAlumnosInscripciones.initReportes();


});

cbaAlumnosInscripciones = function () {
    var current = null;
    function initInscripciones() {

        var accion = $("#Accion").val();
        if (accion == "Eliminar") {
            $("fieldset input").attr('set-readonly', 'true');
            $("fieldset input").attr('readonly', 'readonly');
            var urleliminar = $("#urlEliminar").val();
            $("#FormularioInscripciones").attr('action', urleliminar);
            $("#BuscarInstitucion").hide();
            $("#BuscarAlumno").hide();
        }

        if (accion == "Ver") {
            $("fieldset input").attr("set-readonly", "true");
            $("fieldset input").attr('readonly', 'readonly');
            $("#BuscarInstitucion").hide();
            $("#BuscarAlumno").hide();
            hideEliminarButton();
        }

        $("#AbrirPresentismo").click(function () {
            $("#PresentismoDialog").dialog('open');
        });

        $("#PresentismoDialog").dialog({
            autoOpen: false,
            width: 400,
            height: 200,
            modal: true,
            resizable: false,
            buttons: { "Cancelar": function () { $(this).dialog("close"); }, "Guardar": function () {
                $("#FormularioPresentismo").submit();
            }
            }
        });

    }
    function initCertificado() {
        $("#BuscarAlumno").click(function () {
            cbaAlumnosBuscadorAlumno.AbrirBuscadorAlumno('NombreAlumno', 'IdAlumno');
        });

        $("#BuscarInstitucion").click(function () {
            cbaAlumnosBuscadorCondicionCurso.AbrirBuscador('IdCondicionCurso', 'NombreInstitucion', 'NombreCurso', 'NombreEstadoCurso', 'NombreNivel', 'NombreModalidad', 'NombrePrograma', 'FechaInicio', 'FechaFin');
        });

        $("#Emitir").click(function () {
            $("#FormCertificado").submit();
        });

    }

    function initReportes() {
        $('.reporteTipo').click(function() {
            $("#Reporte").val($(this).val());
        });
    }

    function hideEliminarButton() {
        $(".toHide").hide();
    }

    return {
        initInscripciones: initInscripciones,
        initCertificado: initCertificado,
        hideEliminarButton: hideEliminarButton,
        initReportes: initReportes

    };
} ();

