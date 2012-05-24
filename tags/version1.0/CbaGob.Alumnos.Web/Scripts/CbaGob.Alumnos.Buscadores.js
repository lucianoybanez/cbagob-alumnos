$(document).ready(function () {

    $('#buscadorpopup').dialog({
        autoOpen: false,
        width: 350,
        modal: true,
        resizable: false,
        buttons: {
            "Ok": function () {
                alert( @ViewContext.Controller.ValueProvider.GetValue('controller').RawValue);
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    $('#buscaralumnobtn').click('click', function () {

//        $.ajax({
//            type: "POST",
//            url: "Default.aspx/GetFacturas",
//            data: "{}",
//            contentType: "application/json; charset=utf-8",
//            dataType: "json",
//            success: function (response) {
//                var alumnos = (typeof response.d) == 'string' ?
//                               eval('(' + response.d + ')') :
//                               response.d;
//               
//            },
//            error: function (msg) {
//                location.href = "PantallaError.aspx";
//            }
//        });




        $('#buscadorpopup').dialog("open");
    });


});