$(document).ready(function () {
    UserdataTable();
    $('#Details-btn').click(function () {
        ShowDetails(this);
    });
    $('#ChangePassword-btn').click(function () {
        ShowPassForm(this);
    });
});

function UserdataTable() {
    var table = $("#tblUser");
    $("#tbl-loading").show();
    $.ajax({
        type: "GET",
        url: "/User/GetList",
        contentType: "application/json",
        dataType: "json",
        data: null, 
        success: function (data) {
            $(table).children('tbody').empty();
            var rowHTML = '';
            let status = '';
                for (let i = 0; i < data[0].dataName.length; i++) {
                    if (data[4].dataStatus[i] == 1) {
                        status = '<td class="tb-content status-user"><a class="btn btn-sm btn-success" title="User '+data[0].dataName[i]+' is Online"><b>Online</b></a></td>';
                    } else {
                        status = '<td class="tb-content status-user"><a class="btn btn-sm btn-danger" title="User '+data[0].dataName[i]+' is Offline"><b>Offline</b></a></td>';
                    }
                    rowHTML = '<tr>' +
                        '<td class="tb-content" id="name_table">' + data[0].dataName[i] + '</td>' +
                        '<td class="tb-content">' + data[1].dataKategori[i] + '</td>' +
                        '<td class="tb-content">' + data[2].dataLogin[i] + '</td>' +
                        '<td class="tb-content">' + data[3].dataLogout[i] + '</td>' +status;

                    $(table).append(rowHTML);
                }

            $(table).DataTable();
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        },
        complete: function () {
            $("#tbl-loading").hide();
        }
    });
}

function ShowDetails() {
    $('#ChangePassword-Form').hide();
    $('#Details-Form').show();
}

function ShowPassForm() {
    $('#Details-Form').hide();
    $('#ChangePassword-Form').show();
}