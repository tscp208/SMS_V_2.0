$(document).ready(function () {
    $('#btnAddUser').click(function () {
        $.ajax({
            type: "GET",
            url: "/Users/InsertUser"
        }).done(function (response) {
            $("#UsermodalBody").html('');
            $("#UsermodalBody").html(response);
            $("#userModal").modal({
                backdrop: 'static',
                keyboard: false
            });
            $("#userModal").modal('show');
            //$("form").each(function () { $.data($(this)[0], 'validator', false); });
            //$.validator.unobtrusive.parse("form");
        });
        //$('#userModal').modal('show');
    });
});