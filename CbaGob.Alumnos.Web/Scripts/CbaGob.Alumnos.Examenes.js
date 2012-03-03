/// <reference path="jquery-1.5.1-vsdoc.js" />
/// <reference path="CbaGob.Alumnos.Global.js" />

$(function () {

    var accion = $("#Accion").val();
    if (accion == "Eliminar") {

        $("fieldset input").attr('readonly', 'readonly');
        var urleliminar = $("#urlEliminar").val();
        $("#FormExamenes").attr('action', urleliminar);
        $("#BTGuardar").val("Eliminar");

    }
})