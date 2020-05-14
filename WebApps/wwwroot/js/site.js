// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {

    debugger;
    $('#UseShipAddr').click(function () {
        debugger;
        $.ajax({
            url: "https://localhost:44371/administrator/ListRoles",
            type: "GET",
            cache: false,
            async: true,
            success: function (data) {
                var splitRoles = data.split(" ");
                alert(splitRoles)
                var len = data.split(",").filter((i) => i.length).length;
                debugger;
            },
            failure: function (data) {
                alert(data.responseText);
            }, //End of AJAX failure function   myrole card-title mt-3
            error: function (data) {
                alert(data.responseText);
            } //End of AJAX error function  
        });
    });
});



