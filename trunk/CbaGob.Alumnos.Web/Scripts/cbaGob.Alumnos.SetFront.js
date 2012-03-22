/// <reference path="jquery-1.5.1-vsdoc.js" />
/// <reference path="jquery-ui-1.8.11.js" />

$(document).ready(function () {
    cbaAlumnosSetFront.init();
});

cbaAlumnosSetFront = function () {

    function init() {
        setJqueyUi();
        quitLastRowZebra();
    }

    function setJqueyUi() {

        // tabs
        $("#tabs").tabs();

        // AutoComplete
        $(":input[data-autocomplete]").each(function () {
            $(this).autocomplete({ source: $(this).attr("data-autocomplete") });
        });

        // Color Readonly
        $(":input[readonly]").attr('style', 'background-color:#C0C0C0');
        $(":input[set-readonly]").attr('style', 'background-color:#C0C0C0');

        // datepicker

        var allDatepicker = $(":input[data-datepicker]");
        allDatepicker.each(function () {
            if ($(this).val() == '01/01/0001 12:00:00 a.m.') {
                $(this).val($("#CurrentDate").val());
            }
        });

        $(":input[data-datepicker]").datepicker({ dateFormat: 'dd/mm/yy' });
        $(":input[data-datepicker]").mask("99/99/9999");
    }

    function quitLastRowZebra() {
        $('table[id="grilla"] tr:last').each(function () {
            var quit = false;
            $(this).find("td").each(function () {
                var result = $(this).attr('colspan');
                if (result != "undefined ") {
                    quit = true;
                    return;
                }

            });

            //border-bottom:#ccc 1px solid;
            if (quit) {
                $(this).find("td").each(function () {
                    $(this).attr('style', 'border-bottom:#ccc 0px solid;');
//                    $(this).hover(function () {
//                        $(this).css({ 'background': '#fff' });
//                    });
                });
                
//                $(this)

//                $(this).hover(function() {
//                    $(this).css({ 'background': '#fff' });
//                });


            }

        });
    }

    return {
        init: init
    };
} ();

