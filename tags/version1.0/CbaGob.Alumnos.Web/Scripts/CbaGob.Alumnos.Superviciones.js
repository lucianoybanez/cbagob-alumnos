$(document).ready(function () {
    $("#fecSup").datepicker({ dateFormat: 'dd/mm/yy' });

    $('#dialog').dialog({
        autoOpen: false,
        width: 350,
        modal: true,
        resizable: false,
        buttons: {
            "Ok": function () {
                var f = $("#FormularioSuperviciones");
                $("#FormularioSuperviciones").submit()
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

    $("#selectedhora").bind("change", function () { $("#hora").val($("#selectedhora").val()); });
    $("#selectedminuto").bind("change", function () { $("#minuto").val($("#selectedminuto").val()) });


});


$(function () {
    cbaAlumnosGlobal.BuscadorSupervisores('BuSupervsores');
});