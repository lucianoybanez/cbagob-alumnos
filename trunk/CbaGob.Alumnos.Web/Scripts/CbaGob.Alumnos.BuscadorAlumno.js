


$(function () {
    cbaAlumnosBuscadorAlumno.Init();
});


cbaAlumnosBuscadorAlumno = function () {
    var nombreAlumno = null;
    var idAlumno = null;

    function Init() {
        SetDialog();
    }

    function SetDialog() {
        $("#AlumnosDialog").dialog({
            autoOpen: false,
            width: 500,
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

    function AbrirBuscadorAlumno(varNombreAlumno, varIdAlumno) {
        nombreAlumno = varNombreAlumno;
        idAlumno = varIdAlumno;
        $("#AlumnosDialog").dialog('open');
    }

    function SeleccionarAlumno(nombreAlumnoSelected, idAlumnoSelected) {
        $("#" + nombreAlumno).val(nombreAlumnoSelected);
        $("#" + idAlumno).val(idAlumnoSelected);
        $("#AlumnosDialog").dialog('close');
    }

    return {
        Init: Init,
        AbrirBuscadorAlumno: AbrirBuscadorAlumno,
        SeleccionarAlumno: SeleccionarAlumno
    };
} ();
