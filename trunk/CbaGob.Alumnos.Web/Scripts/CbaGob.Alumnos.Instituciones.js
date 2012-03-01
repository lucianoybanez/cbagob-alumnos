$(document).ready(function () {
    $("#iconobuscar").click(function (event) {
        $("#buscar").slideToggle(1000);
    });
});

$(document).ready(function () {

    $('#dialog').dialog({
        autoOpen: false,
        width: 350,
        modal: true,
        resizable: false,
        buttons: {
            "Ok": function () {
                var f = $("#FormularioInstituciones");
                $("#FormularioInstituciones").submit()
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
    cbaAlumnosGlobal.BuscadorDomicilios('BuSupervsores');
});