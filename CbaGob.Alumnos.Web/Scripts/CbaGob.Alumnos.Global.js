/// <reference path="jquery-1.5.1-vsdoc.js" />
/// <reference path="jquery-ui-1.8.11.js" />

$(document).ready(function () {
    cbaAlumnosGlobal.init();
});

cbaAlumnosGlobal = function () {

    function init() {

        setPager();
        loadPlaceHolder();

    }

    function loadPlaceHolder() {
        $('input[placeholder],textarea[placeholder]').placeholder();
    }

    function setPager() {

        var PageNumber = parseInt($("#PageNumber").val());
        var PageCount = parseInt($("#TotalPages").val());

        PageClick = function (pageclickednumber) {
            $("#PageNumber").val(pageclickednumber);
            $("#pager").pager({ pagenumber: pageclickednumber, pagecount: PageCount, buttonClickCallback: PageClick });
            var formName = $('#FormName').val();

            $('#' + formName).attr('action', $("#ActionName").val());
            $('#' + formName).submit();
        };

        if (parseInt($("#TotalPages").val()) > 1) {
            $("#pager").pager({ pagenumber: PageNumber, pagecount: PageCount, buttonClickCallback: PageClick });
            $("#pager").show();
        }
        else {
            $("#pager").hide();
        }
    }

    function changeCombo(idCombo, idForm, urlToChange) {
        $('.input-validation-error').removeClass("input-validation-error");
        $('.field-validation-error').addClass("field-validation-valid");

        $('#' + idCombo).bind('change', function (e) {
            $('#' + idForm).validate().cancelSubmit = true;
            $('#' + idForm).attr('action', urlToChange);
            $('#' + idForm).submit();
        });
    }

    function ChangeMultipleCombo(idCombo, idForm, urlToChange, hiddenComboName) {
        $('.input-validation-error').removeClass("input-validation-error");
        $('.field-validation-error').addClass("field-validation-valid");

        $('#' + idCombo).bind('change', function (e) {
            $("#" + hiddenComboName).val(idCombo);
            $('#' + idForm).validate().cancelSubmit = true;
            $('#' + idForm).attr('action', urlToChange);
            $('#' + idForm).submit();
        });
    }


    function BuscadorPersonas(id) {
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

    function BuscadorEquipo(id) {
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

    function BuscadorSupervisores(id) {
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

    function BuscadorPersonasJuridica(id) {
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
            case "Estableciminetos":
                $('#Id_Establecimiento').val(codigo);
                break;
            case "PersonasJuridica":
                $('#Id_PersonaJuridica').val(codigo);
                break;
            case "Supervisores":
                $('#Id_Supervisor').val(codigo);
                break;
            case "Equipos":
                $('#Id_Equipo').val(codigo);
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
                var trHeader = "<thead><tr><th>Nombre</th><th>Apellido</th><th>Dni</th><th>Cuil</th><th>Fecha Nacimiento</th><th></th></tr></thead>"
                var table = '#' + id + 'table';
                $(table).empty();
                $(table).append(trHeader);
                for (var i = 0; i < data.length; i++) {
                    var myDate = new Date(parseInt(data[i].Fecha_Nacimiento.replace(/\/+Date\(([\d+-]+)\)\/+/, '$1')));
                    var mMonth = myDate.getMonth() + 1;
                    var ViewDate = myDate.getDate() + '/' + mMonth + '/' + myDate.getFullYear();
                    var trFileds = "<tr><td>" + data[i].Nov_Nombre + "</td><td>" + data[i].Nov_Apellido + "</td><td>" + data[i].Nro_Documento + "</td><td>" + data[i].Cuil + "</td><td>" + ViewDate + '</td><td><img style="cursor: pointer" onclick="cbaAlumnosGlobal.Seleccion(' + "'" + id + "'" + ',' + "'" + Tipo + "'" + ',' + "'" + data[i].Nov_Nombre + "," + data[i].Nov_Apellido + "-" + data[i].Nro_Documento + "'" + ');"  src="../../../Content/images/seleccionar.jpg"  width="25" height="25"  /></td></tr>';
                    $(table).append(trFileds);
                }
                break;
            case "Domicilios":
                var trHeader = "<thead><tr><th>Provincia</th><th>Localidad</th><th>Barrio</th><th>Calle</th><th>Nro</th><th></th></tr></thead>"
                var table = '#' + id + 'table';
                $(table).empty();
                $(table).append(trHeader);
                for (var i = 0; i < data.length; i++) {
                    var trFileds = "<tr><td>" + data[i].Provincia + "</td><td>" + data[i].Localidad + "</td><td>" + data[i].Barrio + "</td><td>" + data[i].Calle + "</td><td>" + data[i].Nro + '</td><td><img style="cursor: pointer" onclick="cbaAlumnosGlobal.Seleccion(' + "'" + id + "'" + ',' + "'" + Tipo + "'" + ',' + "'" + data[i].Provincia + "," + data[i].Localidad + "," + data[i].Barrio + "," + data[i].Calle + "," + data[i].Nro + "'," + data[i].Id_Domicilio + ');"  src="../../../Content/images/seleccionar.jpg"  width="25" height="25"  /></td></tr>';
                    $(table).append(trFileds);
                }
                break;
            case "Instituciones":
                var trHeader = "<thead><tr><th>Nombre Institucion</th><th>Direccion</th><th></th></tr></thead>"
                var table = '#' + id + 'table';
                $(table).empty();
                $(table).append(trHeader);
                for (var i = 0; i < data.length; i++) {
                    var trFileds = "<tr><td>" + data[i].Nombre_Institucion + "</td><td>" + data[i].DireccionCompleta + '</td><td><img style="cursor: pointer" onclick="cbaAlumnosGlobal.Seleccion(' + "'" + id + "'" + ',' + "'" + Tipo + "'" + ',' + "'" + data[i].Nombre_Institucion + "'," + data[i].Id_Institucion + ');"  src="../../../Content/images/seleccionar.jpg"  width="25" height="25"  /></td></tr>';
                    $(table).append(trFileds);
                }
                break;
            case "PersonasJuridica":
                var trHeader = "<thead><tr><th>Cuit</th><th>Razon_Social</th><th></th></tr></thead>"
                var table = '#' + id + 'table';
                $(table).empty();
                $(table).append(trHeader);
                for (var i = 0; i < data.length; i++) {
                    var trFileds = "<tr><td>" + data[i].Cuit + "</td><td>" + data[i].Razon_Social + '</td><td><img style="cursor: pointer" onclick="cbaAlumnosGlobal.Seleccion(' + "'" + id + "'" + ',' + "'" + Tipo + "'" + ',' + "'" + data[i].Cuit + "-" + data[i].Razon_Social + "'," + data[i].Id_PersonaJur + ');"  src="../../../Content/images/seleccionar.jpg"  width="25" height="25"  /></td></tr>';
                    $(table).append(trFileds);
                }
                break;
            case "Supervisores":
                var trHeader = "<thead><tr><th>Cuit</th><th>Razon_Social</th><th></th></tr></thead>"
                var table = '#' + id + 'table';
                $(table).empty();
                $(table).append(trHeader);
                for (var i = 0; i < data.length; i++) {
                    var trFileds = "<tr><td>" + data[i].Cuil_Cuit + "</td><td>" + data[i].Razon_Social + '</td><td><img style="cursor: pointer" onclick="cbaAlumnosGlobal.Seleccion(' + "'" + id + "'" + ',' + "'" + Tipo + "'" + ',' + "'" + data[i].Cuil_Cuit + "-" + data[i].Razon_Social + "'," + data[i].Id_Supervisor + ');"  src="../../../Content/images/seleccionar.jpg"  width="25" height="25"  /></td></tr>';
                    $(table).append(trFileds);
                }
                break;
            case "Equipos":
                var trHeader = "<thead><tr><th>Nombre del Equipo</th><th></th></tr></thead>"
                var table = '#' + id + 'table';
                $(table).empty();
                $(table).append(trHeader);
                for (var i = 0; i < data.length; i++) {
                    var trFileds = "<tr><td>" + data[i].N_Equipos + '</td><td><img style="cursor: pointer" onclick="cbaAlumnosGlobal.Seleccion(' + "'" + id + "'" + ',' + "'" + Tipo + "'" + ',' + "'" + data[i].N_Equipos + "'," + data[i].Id_Equipo + ');"  src="../../../Content/images/seleccionar.jpg"  width="25" height="25"  /></td></tr>';
                    $(table).append(trFileds);
                }
                break;
            case "Estableciminetos":
                var trHeader = "<thead><tr><th>Nombre del Establecimiento</th><th></th></tr></thead><tbody>"
                var table = '#' + id + 'table';
                $(table).empty();
                $(table).append(trHeader);
                for (var i = 0; i < data.length; i++) {
                    var trFileds = "<tr><td>" + data[i].NombreEstablecimiento + '</td><td><img style="cursor: pointer" onclick="cbaAlumnosGlobal.Seleccion(' + "'" + id + "'" + ',' + "'" + Tipo + "'" + ',' + "'" + data[i].NombreEstablecimiento + "'," + data[i].Id_Establecimiento + ');"  src="../../../Content/images/seleccionar.jpg"  width="25" height="25"  /></td></tr>';
                    $(table).append(trFileds);
                }
                $(table).append("<tbody>");
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
        BuscadorPersonasJuridica: BuscadorPersonasJuridica,
        BuscadorSupervisores: BuscadorSupervisores,
        BuscadorEquipo: BuscadorEquipo,
        ChangeMultipleCombo: ChangeMultipleCombo,
        BuscadorEstablecimientos: BuscadorEstablecimientos
    };
} ();

