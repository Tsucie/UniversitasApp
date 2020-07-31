var actionTitle; // Title for Modals

$(document).ready(function () {
    ClientDataTable();
    $("#btn-add-client").click(function() {
        addClient(this);
    });
    $("#btn-edit-client").click(function() {
        UpdateClient();
    });
    $("#Add-btn").click(function() {
        ShowAddModals(this);
    });
});

// Clients datatables.net
function ClientDataTable() {
    var table = $("#tblClient");

    $("#spinner").show();
    $.ajax({
        type: "GET",
        url: "/Client/GetAll",
        contentType: "application/json",
        dataType: "json",
        data: null,
        success: function (data) {
            $(table).children('tbody').empty();
            var rowHTML = '';
                for (let i = 0; i < data[1].dataCode.length; i++) {
                    rowHTML = '<tr>' +
                    '<td class="tb-content">' + data[1].dataCode[i] + '</td>' +
                    '<td class="tb-content">' + data[2].dataUsername[i] + '</td>'+
                    '<td class="tb-content">' + data[3].dataName[i] + '</td>'+
                    '<td class="tb-content">' + data[4].dataRemark[i] + '</td>' +
                    '<td class="tb-content"><a data-toggle="tooltip" data-html="true" title="Edit Data" id=\'btnedit' + i + '\' class="btn" data_id=\'' + data[0].dataId[i] + '\'><i class="fa fa-edit"></i></a><a data-toggle="tooltip" data-html="true" title="Delete Data" id=\'btndelete' + i + '\' class="btn" data_id=\'' + data[0].dataId[i] + '\'><i class="fa fa-remove"></i></a></td>' +
                    '</tr>';

                    $(table).append(rowHTML);

                    $('#btnedit' + i).click(function (event) {
                        ClientGetDataById(this);
                    });

                    $('#btndelete' + i).click(function (event) {
                        ClientDelete(this);
                    });
                }

            $(table).DataTable();
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        },
        complete: function () {
            $("#spinner").hide();
        }
    });
}

// JQuery Validate
function validasi() {
    var isValid = true;
    if($('#u_username').val().trim() == "") {
        $('#u_username').css('border-color', 'Red');
        $('#username-alrt').show();
        isValid = false;
    } else {
        $('#u_username').css('border-color', 'lightgray');
        $('#username-alrt').hide();
    }
    return isValid;
}

// Modals for Add Data
function ShowAddModals() {
    actionTitle = 'Add Client';
    $('#u_username').val('');
    $('#u_password').val('');
    $('#c_name').val('');
    $('#c_remark').val('');
    $("#AddEditModal").on('show.bs.modal', function (event) {
        var modal = $(this);
        modal.find('.modal-title').text(actionTitle);
        $('#pass-txtbox').show();
        $("#btn-add-client").show();
        $("#btn-edit-client").hide();
    });
}

// Add Data
function addClient() {
    var res = validasi();
    if($('#u_password').val().trim() == "") {
        $('#u_password').css('border-color', 'Red');
        $('#password-alrt').show();
        res = false;
    } else {
        $('#u_password').css('border-color', 'lightgray');
        $('#password-alrt').hide();
    }
    if(res == false) return false;

    var Data = {
        "u_username": $('#u_username').val(),
        "u_password": $('#u_password').val(),
        "c_name": $('#c_name').val(),
        "c_remark": $('#c_remark').val()
    };
    console.log(Data);
    $.ajax({
        type: "POST",
        url: "/Client/Create",
        dataType: "json",
        data: Data,
        success: function (data) {
            if(data.code === 1) {
                pesanAlert(data);
                setTimeout(function () { window.location.reload() }, 2000);
            }
            else {
                pesanAlert(data);
            }
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        },
        complete: function () {
            $("#AddEditModal").modal('hide');
            $('#u_username').val('');
            $('#u_password').val('');
            $('#c_name').val('');
            $('#c_remark').val('');
            $('#pass-txtbox').hide();
        }
    });
}

// Modals for Edit Data
function ShowEditModals() {
    actionTitle = 'Edit Client';
    $("#AddEditModal").on('show.bs.modal', function (event) {
        var modal = $(this);
        modal.find('.modal-title').text(actionTitle);
        $("#btn-edit-client").show();
        $("#btn-add-client").hide();
    });
}
// Save data_id for update data
var edit;
// Get data by id for Edit Display
function ClientGetDataById(obj) {
    ShowEditModals();
    let obj_id = {
        "c_id": 0,
        "c_u_id": parseInt(obj.attributes.data_id.value)
    };
    $.ajax({
        type: "GET",
        url: "/Client/GetById/" + obj_id.c_u_id,
        contentType: "application/json",
        dataType: "json",
        data: obj_id.c_u_id,
        success: function (data) {
            if(data != null) {
                obj_id.c_id = data.c_id;
                edit = obj_id;
                $('#u_username').val(data.u_username);
                $('#c_name').val(data.c_name);
                $('#c_remark').val(data.c_remark);
                $("#AddEditModal").modal('show');
            } else {
                pesanAlert(data);
            }
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        }
    });
}
// Edit Data
function UpdateClient() {
    var res = validasi();
    if(res == false) return false;

    var Data = {
        "c_id": edit.c_id,
        "c_u_id": edit.c_u_id,
        "u_username": $('#u_username').val(),
        "c_name": $('#c_name').val(),
        "c_remark": $('#c_remark').val()
    };
    $.ajax({
        type: "PUT",
        url: "/Client/Update",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(Data),
        success: function (data) {
            if(data.code === 1) {
                pesanAlert(data);
                setTimeout(function () { window.location.reload() }, 2000);
            }
            else {
                pesanAlert(data);
            }
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        },
        complete: function () {
            $('#AddEditModal').modal('hide');
            $('#u_username').val('');
            $('#c_name').val('');
            $('#c_remark').val('');
        }
    });
}
// Delete Data
function ClientDelete(obj) {
    let obj_id = { "c_u_id": parseInt(obj.attributes.data_id.value) };
    var konfirmasi = confirm("Yakin ingin Hapus data Client?");
    if(konfirmasi) {
        $.ajax({
            type: "DELETE",
            url: "/Client/Delete",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(obj_id),
            success: function (data) {
                if(data.code === 1) {
                    pesanAlert(data);
                    setTimeout(function () { window.location.reload() }, 2000);
                }
                else {
                    pesanAlert(data);
                }
            },
            error: function () {
                notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
            }
        });
    }
}