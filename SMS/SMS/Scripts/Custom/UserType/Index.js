
$("#btnAddUserType").click(function () {
    debugger;
    $.ajax({
        type: "GET",
        url: "/UserType/AddUserType"
    }).done(function (response) {
        $("#modalBody").html('');
        $("#modalBody").html(response);
        $("#userTypeModal").modal({
            backdrop: 'static',
            keyboard: false
        });
        $("#userTypeModal").modal('show');
        $("form").each(function () { $.data($(this)[0], 'validator', false); });
        $.validator.unobtrusive.parse("form");
    });
});

function EditUserType(userTypeID) {
    debugger;
    $.ajax({
        type: "GET",
        url: "/UserType/AddUserType?userTypeID=" + userTypeID
    }).done(function (response) {
        $("#modalBody").html('');
        $("#modalBody").html(response);
        $("#userTypeModal").modal({
            backdrop: 'static',
            keyboard: false
        });
        $("#userTypeModal").modal('show');
        $("form").each(function () { $.data($(this)[0], 'validator', false); });
        $.validator.unobtrusive.parse("form");
    });
}

function SuccessMethod(result) {
    if (result.Status) {
        $("#userTypeModal").modal('hide');
        $("#msgBlocks").html("<div id='divMessages' class='fade-in' role='alert'><span id='spnMsgs'></span><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button></div>");
        $("#spnMsgs").html(result.Message);
        $("#divMessages").addClass("alert alert-success alert-dismissible");

        $("#divMessages").fadeTo(2000, 500).slideUp(500, function () {
            $("#divMessages").slideUp(1000);
        });

        $.ajax({
            type: "GET",
            url: "/UserType/UserTypeGrid"
        }).done(function (response) {
            $("#UserTypeGridBlock").html('');
            $("#UserTypeGridBlock").html(response);
        });
    }
    else {
        $("#msgBlock").html("<div id='divMessage' class='fade-in' role='alert'><span id='spnMsg'></span><button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button></div>");
        $("#spnMsg").html(result.Message);
        $("#divMessage").addClass("alert alert-danger alert-dismissible");
    }
    $("#divMessage").fadeTo(2000, 500).slideUp(500, function () {
        $("#divMessage").slideUp(1000);
    });
}

function DeleteUserType(userType) {
    if (confirm("Are you sure you want to Delete this User Type?")) {
        $.ajax({
            type: "GET",
            url: "/UserType/DeleteUserType?userTypeID=" + userType,
            success: function (response) {
                SuccessMethod(response);
            },
            error: function () {
                debugger;
            }
        });
    }
    else {
        return false;
    }
}