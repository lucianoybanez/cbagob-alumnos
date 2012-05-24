$(document).ready(function () {

    $('#dialog').dialog({
        autoOpen: false,
        width: 350,
        modal: true,
        resizable: false,
        buttons: {
            "Ok": function () {
                var f = $("#FormularioEquipos");
                $("#FormularioEquipos").submit()
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
        var f = $("#FormIndexEquipos");
        $('#FormIndexEquipos').attr('action', '/Equipamientos/BuscarEquipos');
        $("#FormIndexEquipos").submit()
    });

});

$(function () {
    cbaAlumnosGlobal.BuscadorDomicilios('BuSupervsores');
});