$(document).ready(function () {
    $("#iconobuscar").click(function (event) {
        $("#buscar").slideToggle(1000);
    });

    $('#pagecursos').smartpaginator({ totalrecords: $('#CountRows').val(), recordsperpage: 5, datacontainer: 'tablacursos', dataelement: 'tr', initval: 0, next: 'Next', prev: 'Prev', first: 'First', last: 'Last', theme: 'green' });
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

    $('#Buscar').click('click', function () {
        var f = $("#FormIndexInstituciones");
        $('#FormIndexInstituciones').attr('action', '/Instituciones/BuscarInstitucion');
        $("#FormIndexInstituciones").submit()
    });

    $("#selectedaño").bind("change", function () { $("#añobuscqueda").val($("#selectedaño").val()); });


});

$(function () {
    cbaAlumnosGlobal.BuscadorDomicilios('BuDomicilio');
});