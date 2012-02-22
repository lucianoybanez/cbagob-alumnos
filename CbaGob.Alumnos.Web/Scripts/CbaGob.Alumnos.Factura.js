/// <reference path="jquery-1.5.1-vsdoc.js" />
$(function () {
    $('#Institucion_Selected').bind('change', function (e) {
        var newUrl = $("#CambioUrl").val();
        $('#FormFactura').attr('action', newUrl);
        $("#FormFactura").submit();
    });
});