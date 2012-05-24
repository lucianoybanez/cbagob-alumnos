/// <reference path="jquery-1.5.1-vsdoc.js" />
/// <reference path="CbaGob.Alumnos.Global.js" />

$(function () {
    cbaAlumnosGlobal.changeCombo('Institucion_Selected', 'FormFactura', $("#CambioUrl").val());
});

$(document).ready(function () {

    $('#dialog').dialog({
        autoOpen: false,
        width: 350,
        modal: true,
        resizable: false,
        buttons: {
            "Ok": function () {
                var f = $("#FormFactura");
                $("#FormFactura").submit();
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


    $('#Buscar').click(function () {
        var url = $("#UrlBuscar").val();
        $('#FormIndexFacturas').attr('action', url);
        $('#FormIndexFacturas').submit();
    });

});