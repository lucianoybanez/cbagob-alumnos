$(function () {
    cbaAlumnosBuscadorAlumno.Init();
});


cbaAlumnosBuscadorAlumno = function () {
    var nombreAlumno = null;
    var idAlumno = null;

    function Init() {
        SetDialog();
        SetBehaivour();
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

    function SetBehaivour() {

        $('#dni').val("");
        $('#dni').attr('disabled', true);

        $('#radioNombre').click(function () {
            $('#dni').val("");
            $('#dni').attr('disabled', true);
            $('#apellido').attr('disabled', false);
            $('#nombre').attr('disabled', false);
          
        });

        $('#radioDni').click(function () {
            $('#nombre').val("");
            $('#nombre').attr('disabled', true);
            $('#apellido').val("");
            $('#apellido').attr('disabled', true);
            $('#dni').attr('disabled', false);
            
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
