
function Pesonas(idpersona, nom, apell, dni, cuil) {
    window.document.getElementById('Nov_Nombre').value = nom + "," + apell;
    window.document.getElementById('Id_Persona').value = idpersona;
}

$(document).ready(function () {

    $('#dialog').dialog({
        autoOpen: false,
        width: 350,
        modal: true,
        resizable: false,
        buttons: {
            "Ok": function () {
                var f = $("#FormularioAlumnos");
                $("#FormularioAlumnos").submit()
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
        var f = $("#FormIndexAlumnos");
        $('#FormIndexAlumnos').attr('action', '/Alumnos/BuscarAlumnos');
        $("#FormIndexAlumnos").submit()
    });
});
