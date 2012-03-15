$(document).ready(function () {

    $('#dialog').dialog({
        autoOpen: false,
        width: 350,
        modal: true,
        resizable: false,
        buttons: {
            "Ok": function () {
                var f = $("#FormularioCargos");
                $("#FormularioCargos").submit()
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