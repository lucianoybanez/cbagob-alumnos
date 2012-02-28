/// <reference path="jquery-1.5.1-vsdoc.js" />
/// <reference path="jquery-ui-1.8.11.js" />

$(document).ready(function () {
    cbaAlumnosGlobal.init();
});

cbaAlumnosGlobal = function () {

    function init() {
        setJqueyUi();
    }

    function changeCombo(idCombo, urlToChange) {
        $('.input-validation-error').removeClass("input-validation-error");
        $('.field-validation-error').addClass("field-validation-valid");

        $('#' + idCombo).bind('change', function (e) {
            $("form").validate().cancelSubmit = true;
            $('#FormFactura').attr('action', urlToChange);
            $("#FormFactura").submit();
        });
    }

    function setJqueyUi() {
        $("#tabs").tabs();
        $(":input[data-autocomplete]").each(function () {
            $(this).autocomplete({ source: $(this).attr("data-autocomplete") });
        });
    }


    function BuscadorPersonas(id) {
        $("#" + id).dialog({
            autoOpen: false,
            width: 500,
            modal: true,
            resizable: false,
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });
    }

    function BuscadorPersonasJuridica(id) {
        $("#" + id).dialog({
            autoOpen: false,
            width: 500,
            modal: true,
            resizable: false,
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });
    }

    function BuscadorDomicilios(id) {
        $("#" + id + "Div").dialog({
            autoOpen: false,
            width: 500,
            modal: true,
            resizable: false,
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });
    }


    function BuscadorInstituciones(id) {
        $("#" + id + "Div").dialog({
            autoOpen: false,
            width: 500,
            modal: true,
            resizable: false,
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });
    }

    function BuscadorEstablecimientos(id) {
        $("#" + id + "Div").dialog({
            autoOpen: false,
            width: 500,
            modal: true,
            resizable: false,
            buttons: {
                "Cancel": function () {
                    $(this).dialog("close");
                }
            }
        });
    }


    function Seleccion(id, Tipo, texto, codigo) {
        $('#' + id + "txt").val(texto);
        switch (Tipo) {
            case "Personas":
                break;
            case "Domicilios":
                $('#Id_Domicilio').val(codigo);
                break;
            case "Instituciones":
                $('#Id_Institucion').val(codigo);
                break;
            case "Establecimientos":
                $('#Id_Establecimiento').val(codigo);
                break;
            case "PersonasJuridica":
                $('#Id_PersonaJur').val(codigo);
                break;
        }
        $('#' + id + "Div").dialog("close");
    }

    function Buscar(id, Tipo, texto, IdRelacionado) {
        $.ajax({
            type: "POST",
            url: "/Buscador/" + Tipo,
            data: "{busqueda:'" + texto + "', IdRelacionado:'" + IdRelacionado + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                Cargar(id, Tipo, data);
                $('#' + id + "Div").dialog("open");
            },
            error: function (msg) {
                alert(msg);
            }
        });
    }


    function Cargar(id, Tipo, data) {

        switch (Tipo) {
            case "Personas":
                var trHeader = "<tr><td>Nombre</td><td>Apellido</td><td>Dni</td><td>Cuil</td><td>Fecha Nacimiento</td><td></td></tr>"
                var table = '#' + id + 'table';
                $(table).empty();
                $(table).append(trHeader);
                for (var i = 0; i < data.length; i++) {
                    var myDate = new Date(parseInt(data[i].Fecha_Nacimiento.replace(/\/+Date\(([\d+-]+)\)\/+/, '$1')));
                    var mMonth = myDate.getMonth() + 1;
                    var ViewDate = myDate.getDate() + '/' + mMonth + '/' + myDate.getFullYear();
                    var trFileds = "<tr><td>" + data[i].Nov_Nombre + "</td><td>" + data[i].Nov_Apellido + "</td><td>" + data[i].Nro_Documento + "</td><td>" + data[i].Cuil + "</td><td>" + ViewDate + '</td><td><img onclick="cbaAlumnosGlobal.Seleccion(' + "'" + id + "'" + ',' + "'" + Tipo + "'" + ',' + "'" + data[i].Nov_Nombre + "," + data[i].Nov_Apellido + "-" + data[i].Nro_Documento + "'" + ');"  src="../../../Content/images/seleccionar.jpg"  width="25" height="25"  /></td></tr>';
                    $(table).append(trFileds);
                }
                break;
            case "Domicilios":
                var trHeader = "<tr><td>Provincia</td><td>Localidad</td><td>Barrio</td><td>Calle</td><td>Nro</td><td></td></tr>"
                var table = '#' + id + 'table';
                $(table).empty();
                $(table).append(trHeader);
                for (var i = 0; i < data.length; i++) {
                    var trFileds = "<tr><td>" + data[i].Provincia + "</td><td>" + data[i].Localidad + "</td><td>" + data[i].Barrio + "</td><td>" + data[i].Calle + "</td><td>" + data[i].Nro + '</td><td><img onclick="cbaAlumnosGlobal.Seleccion(' + "'" + id + "'" + ',' + "'" + Tipo + "'" + ',' + "'" + data[i].Provincia + "," + data[i].Localidad + "," + data[i].Barrio + "," + data[i].Calle + "," + data[i].Nro + "'," + data[i].Id_Domicilio + ');"  src="../../../Content/images/seleccionar.jpg"  width="25" height="25"  /></td></tr>';
                    $(table).append(trFileds);
                }
                break;
            case "Instituciones":
                var trHeader = "<tr><td>Nombre Institucion</td><td>Direccion</td><td></td></tr>"
                var table = '#' + id + 'table';
                $(table).empty();
                $(table).append(trHeader);
                for (var i = 0; i < data.length; i++) {
                    var trFileds = "<tr><td>" + data[i].Nombre_Institucion + "</td><td>" + data[i].DireccionCompleta + '</td><td><img onclick="cbaAlumnosGlobal.Seleccion(' + "'" + id + "'" + ',' + "'" + Tipo + "'" + ',' + "'" + data[i].Nombre_Institucion + "'," + data[i].Id_Institucion + ');"  src="../../../Content/images/seleccionar.jpg"  width="25" height="25"  /></td></tr>';
                    $(table).append(trFileds);
                }
                break;
            case "PersonasJuridica":
                var trHeader = "<tr><td>Cuit</td><td>Razon_Social</td><td></td></tr>"
                var table = '#' + id + 'table';
                $(table).empty();
                $(table).append(trHeader);
                for (var i = 0; i < data.length; i++) {
                    var trFileds = "<tr><td>" + data[i].Cuit + "</td><td>" + data[i].Razon_Social + '</td><td><img onclick="cbaAlumnosGlobal.Seleccion(' + "'" + id + "'" + ',' + "'" + Tipo + "'" + ',' + "'" + data[i].Cuit + "-" + data[i].Razon_Social + "'," + data[i].Id_PersonaJur + ');"  src="../../../Content/images/seleccionar.jpg"  width="25" height="25"  /></td></tr>';
                    $(table).append(trFileds);
                }
                break;
        }
    }


    return {
        init: init,
        changeCombo: changeCombo,
        BuscadorPersonas: BuscadorPersonas,
        Buscar: Buscar,
        Seleccion: Seleccion,
        BuscadorDomicilios: BuscadorDomicilios,
        BuscadorInstituciones: BuscadorInstituciones,
        BuscadorPersonasJuridica: BuscadorPersonasJuridica
    };
} ();

