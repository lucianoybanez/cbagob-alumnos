$(document).ready(function () {
    $("#login").bind("keypress", function (e) {
        if (e.keyCode == 13) {
            $("#login").submit();
        }
    });

    $("#UserName").focus();
});