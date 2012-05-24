$(document).ready(function () {
    $("#fecini").datepicker({ dateFormat: 'dd/mm/yy' });
    $("#fecfin").datepicker({ dateFormat: 'dd/mm/yy' });

    $('#dialog').dialog({
        autoOpen: false,
        width: 350,
        modal: true,
        resizable: false,
        buttons: {
            "Ok": function () {
                var f = $("#FormularioPrestamos");
                $("#FormularioPrestamos").submit()
                $(this).dialog("close");
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    $('#Eliminar').click('click', function () {
        $('#dialog').dialog("open");
    });

});


$(function () {
    cbaAlumnosGlobal.BuscadorInstituciones('BuInstitutos');
    cbaAlumnosGlobal.BuscadorEquipo('BuEquipos');
});