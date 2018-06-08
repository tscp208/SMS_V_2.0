$(document).ready(function () {
    $('#dtUserTypes').dataTable({
        "processing": true, // for show progress bar  
        "serverSide": true, // for process server side
        "lengthMenu": [[5, 10, 20, 50, 100], [5, 10, 20, 50, 100]],
        //"info": true,
        "ajax": {
            "url": "/UserType/GetUserTypeData",
            "type": "POST",
            "datatype": "json",
            "dataSrc": function (result) {
                return result.data;
            }
        },
        "columnDefs":
        [{
            "targets": [0],
            "visible": false,
            "searchable": false
        },
        {
            "targets": [1],
            "searchable": false,
            "orderable": false
        },
        {
            "targets": [2],
            "searchable": false
        },
        {
            "targets": [3],
            "searchable": false
        },
        {
            "targets": [4],
            "orderable": false
        }],
        "columns": [
            { "data": "UserTypeID", "name": "UserTypeID", "autoWidth": true },
            { "data": "SrNo", "name": "SrNo", "title": "Sr No.", "autoWidth": true },
            { "data": "UserTypeName", "title": "User Type", "name": "UserTypeName", "autoWidth": true },
            { "data": "UserTypeDesc", "name": "UserTypeDesc", "title": "Description", "autoWidth": true },
            {
                "render": function (data, type, full, meta)
                { return "<a href='#' class='glyphicon glyphicon-edit' style='font-size:17px;text-decoration:none;' onclick = EditUserType('" + full.UserTypeID + "'); ></a> <a href='#' class='glyphicon glyphicon-remove' style='font-size:17px;color: #ff000094;text-decoration:none;' onclick=DeleteUserType('" + full.UserTypeID + "'); ></a>"; }
            }
        ],
        aaSorting: [[0, 'asc']]
    });

    $('#dtUserTypes_filter input').unbind();
    $('#dtUserTypes_filter input').bind('keyup', function (e) {
        if (e.keyCode == 13) {
            $('#dtUserTypes').DataTable().search(this.value).draw();
        }
    });
});

$("#btnAddUserType").click(function () {
    $.ajax({
        type: "GET",
        url: "/UserType/AddUserType"
    }).done(function (response) {
        $("#modalBody").html('');
        $("#modalBody").html(response);
        $("#modalTitle").html('');
        $("#modalTitle").html('Add User Type');
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
    $.ajax({
        type: "GET",
        url: "/UserType/AddUserType?userTypeID=" + userTypeID
    }).done(function (response) {
        $("#modalBody").html('');
        $("#modalBody").html(response);
        $("#modalTitle").html('');
        $("#modalTitle").html('Update User Type');
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

        $('#dtUserTypes').DataTable().ajax.reload(null, false);
        //$('#dtUserTypes').ajax.reload();

        //$.ajax({
        //    type: "GET",
        //    url: "/UserType/UserTypeGrid"
        //}).done(function (response) {
        //    $("#UserTypeGridBlock").html('');
        //    $("#UserTypeGridBlock").html(response);
        //});
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