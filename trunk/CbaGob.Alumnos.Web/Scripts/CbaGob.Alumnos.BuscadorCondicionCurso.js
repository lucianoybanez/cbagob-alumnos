
$(function () {
    cbaAlumnosBuscadorCondicionCurso.Init();
});


cbaAlumnosBuscadorCondicionCurso = function () {

    var dialogName = 'CondicionCursoDialog';

    var idCondicionCurso = null;
    var nombeInstitucion = null;
    var nombreCurso = null;
    var nombreEstadoCurso = null;
    var nombreNivel = null;
    var nombreModalidad = null;
    var nombrePrograma = null;
    var fechaInicio = null;
    var fechaFin = null;
    var nroResolucion = null;

    function Init() {
        SetDialog();
        SetBehaivour();
    }

    function SetBehaivour() {

        $('#curso').attr('disabled', true);
        $('#programa').attr('disabled', true);

        $('#radioInstitucion').click(function () {
            clearCurso();
            clearPrograma();
            $('#institucion').attr('disabled', false);
        });

        $('#radioCurso').click(function () {
            clearInstitucion();
            clearPrograma();
            $('#curso').attr('disabled', false);
        });

        $('#radioPrograma').click(function () {
            clearInstitucion();
            clearCurso();
            $('#programa').attr('disabled', false);
        });


        function clearInstitucion() {
            $('#institucion').val("");
            $('#institucion').attr('disabled', true);
        }

        function clearPrograma() {
            $('#programa').val("");
            $('#programa').attr('disabled', true);
        }

        function clearCurso() {
            $('#curso').val("");
            $('#curso').attr('disabled', true);
        }

    }



    function SetDialog() {
        $("#" + dialogName).dialog({
            autoOpen: false,
            width: 700,
            height: 600,
            modal: true,
            resizable: false,
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });
    }

    function AbrirBuscador(pIdCondicionCurso, pNombeInstitucion, pNombreCurso, pNombreEstadoCurso, pNombreNivel, pNombreModalidad, pNombrePrograma, pFechaInicio, pFechaFin, pNroResolucion) {
        idCondicionCurso = pIdCondicionCurso;
        nombeInstitucion = pNombeInstitucion;
        nombreCurso = pNombreCurso;
        nombreEstadoCurso = pNombreEstadoCurso;
        nombreNivel = pNombreNivel;
        nombreModalidad = pNombreModalidad;
        nombrePrograma = pNombrePrograma;
        fechaInicio = pFechaInicio;
        fechaFin = pFechaFin;
        nroResolucion = pNroResolucion;
        $("#" + dialogName).dialog('open');
    }

    function Seleccionar(pIdCondicionCurso, pNombeInstitucion, pNombreCurso, pNombreEstadoCurso, pNombreNivel, pNombreModalidad, pNombrePrograma, pFechaInicio, pFechaFin, pNroResolucion) {
        $("#" + idCondicionCurso).val(pIdCondicionCurso);
        $("#" + nombeInstitucion).val(pNombeInstitucion);
        $("#" + nombreCurso).val(pNombreCurso);
        $("#" + nombreEstadoCurso).val(pNombreEstadoCurso);
        $("#" + nombreNivel).val(pNombreNivel);
        $("#" + nombreModalidad).val(pNombreModalidad);
        $("#" + nombrePrograma).val(pNombrePrograma);
        $("#" + fechaInicio).val(pFechaInicio);
        $("#" + fechaFin).val(pFechaFin);
        $("#" + nroResolucion).val(pNroResolucion);
        $("#" + dialogName).dialog('close');
    }

    return {
        Init: Init,
        AbrirBuscador: AbrirBuscador,
        Seleccionar: Seleccionar
    };
} ();
