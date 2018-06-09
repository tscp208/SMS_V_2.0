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

function DeleteUser(UserID) {
    if (confirm('Are you sure you want to delete user?')) {
        $.ajax({
            type: "GET",
            url: "/Users/DeleteUser?UserID=" + UserID,
            success: function (response) {

            },
            error: function () {
                debugger;
            }
        })
    }
}

function EditUser(UserID) {
    debugger;
    $.ajax({
        type: "GET",
        url: "/Users/InsertUser?UserID=" + UserID
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
}