/// <reference path="jquery-1.5.1-vsdoc.js" />
/// <reference path="CbaGob.Alumnos.Global.js" />

$(function () {

    // Set Mask

    $("#Nota").mask("9?9");

    var accion = $("#Accion").val();
    if (accion == "Eliminar") {

        
        var urleliminar = $("#urlEliminar").val();
        $("#FormExamenes").attr('action', urleliminar);
        $("#BTGuardar").val("Eliminar");

    }
})