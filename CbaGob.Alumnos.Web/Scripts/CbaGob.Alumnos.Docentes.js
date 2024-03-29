﻿$(document).ready(function () {
    $("#tabs").tabs();

    $('#dialog').dialog({
        autoOpen: false,
        width: 350,
        modal: true,
        resizable: false,
        buttons: {
            "Ok": function () {
                var f = $("#FormularioDocentes");
                $("#FormularioDocentes").submit()
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

    $('#Buscar').click('click', function () {
        var f = $("#FormIndexDocentes");
        $('#FormIndexDocentes').attr('action', '/Docentes/BuscarDocente');
        $("#FormIndexDocentes").submit()
    });
});

$(function () {
    cbaAlumnosGlobal.BuscadorDomicilios('BuDomicilio');
    cbaAlumnosGlobal.BuscadorPersonasJuridica('BuPersonasJur');
});