/// <reference path="jquery-1.5.1-vsdoc.js" />
/// <reference path="jquery-ui-1.8.11.js" />

$(document).ready(function () {
    cbaAlumnosGlobal.init();
});

cbaAlumnosGlobal = function () {
 
    function init() {
        setJqueyUi();
    }
    
    function changeCombo(idCombo,urlToChange) {
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
    return {
        init: init,
        changeCombo: changeCombo
    };
} ();

