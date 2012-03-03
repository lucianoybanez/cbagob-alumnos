
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

    function Init() {
        SetDialog();
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

    function AbrirBuscador(pIdCondicionCurso, pNombeInstitucion, pNombreCurso, pNombreEstadoCurso, pNombreNivel, pNombreModalidad, pNombrePrograma) {
        idCondicionCurso = pIdCondicionCurso;
        nombeInstitucion = pNombeInstitucion;
        nombreCurso = pNombreCurso;
        nombreEstadoCurso = pNombreEstadoCurso;
        nombreNivel = pNombreNivel;
        nombreModalidad = pNombreModalidad;
        nombrePrograma = pNombrePrograma;
        $("#" + dialogName).dialog('open');
    }

    function Seleccionar(pIdCondicionCurso, pNombeInstitucion, pNombreCurso, pNombreEstadoCurso, pNombreNivel, pNombreModalidad, pNombrePrograma) {
        $("#" + idCondicionCurso).val(pIdCondicionCurso);
        $("#" + nombeInstitucion).val(pNombeInstitucion);
        $("#" + nombreCurso).val(pNombreCurso);
        $("#" + nombreEstadoCurso).val(pNombreEstadoCurso);
        $("#" + nombreNivel).val(pNombreNivel);
        $("#" + nombreModalidad).val(pNombreModalidad);
        $("#" + nombrePrograma).val(pNombrePrograma);
        $("#" + dialogName).dialog('close');
    }

    return {
        Init: Init,
        AbrirBuscador: AbrirBuscador,
        Seleccionar: Seleccionar
    };
} ();
