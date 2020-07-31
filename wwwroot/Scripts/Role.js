$(document).ready(function () {
    RoleDataTable();
    $("#btn-simpan-role").click(function () {
        UpdateRolePreviledge(this);
    });
});

function RoleDataTable() {
    var table = $("#tblRole");
    $("#spinner").show();
    $.ajax({
        type: "GET",
        url: "/Role/GetAll",
        contentType: "application/json",
        dataType: "json",
        data: null,
        success: function (data) {
            $(table).children('tbody').empty();
            var rowHTML = '';
                for (let i = 0; i < data[1].roleTypeName.length; i++) {
                    let number = i+1;
                    rowHTML = '<tr>' +
                    '<td class="tb-content status-user col-md-1">' + number + '</td>' +
                    '<td class="tb-content">' + data[1].roleTypeName[i] + '</td>'+
                    '<td class="tb-content">' + data[2].roleName[i] + '</td>'+
                    '<td class="tb-content"><a data-toggle="tooltip" data-html="true" title="Role Previledge" id=\'btndetail' + i + '\' class="btn" data_id=\'' + data[0].roleId[i] + '\'><i class="glyphicon glyphicon-wrench" style="color: rgba(0, 0, 0, 0.6); font-size: 150%;"></i></a></td>'+
                    '</tr>';

                    $(table).append(rowHTML);

                    $('#btndetail' + i).click(function (event) {
                        clickPreviledge(this);
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

function statusCheck(id) {
    let icon = '';
    switch (id) {
        case 1:
            icon = '<a data-toggle="tooltip" data-html="true" title="Enable" id=\'btnenable\' class="btn btn-success" data_id=\'' + id + '\'><i class="glyphicon glyphicon-ok-circle" style="color: green; font-size: 150%;"></i></a>';
            break;

        case 0:
            icon = '<a data-toggle="tooltip" data-html="true" title="Disable" id=\'btndisable\' class="btn btn-danger" data_id=\'' + id + '\'><i class="glyphicon glyphicon-remove-circle" style="color: red; font-size: 150%;"></i></a>';
            break;

        case -1:
            icon = '<a data-toggle="tooltip" data-html="true" title="Unavailable" id=\'btnunavailable\' class="btn btn-default" data_id=\'' + id + '\'><i class="glyphicon glyphicon-ban-circle" style="color: lightgray; font-size: 150%;"></i></a>';
            break;

        default:
            break;
    }
    return icon;
}

function clickPreviledge(obj) {
    let DataId = {"r_id": parseInt(obj.attributes.data_id.value)};
    var table = $("#tblRP");
    $("#spinner").show();
    $.ajax({
        type: "GET",
        url: "/Role/GetPreviledge/" + DataId.r_id,
        contentType: "application/json",
        dataType: "json",
        data: DataId.r_id,
        success: function (result) {
            $(table).children('tbody').empty();
            if(result != null) {
                var row = '';
                row = '<tr>' +
                '<td class="tb-content status-user col-sm-1"><i class="glyphicon glyphicon-option-horizontal"></i></td>' +
                '<td class="tb-content">'+ result.r_name + '</td>'+
                '<td class="tb-content status-user col-md-1>' + statusCheck(result.rp_view) + '</td>'+
                '<td class="tb-content status-user col-md-1>' + statusCheck(result.rp_add) + '</td>'+
                '<td class="tb-content status-user col-md-1>' + statusCheck(result.rp_edit) + '</td>'+
                '<td class="tb-content status-user col-md-1>' + statusCheck(result.rp_delete) + '</td>'+
                '<td class="tb-content col-md-1"><a data-toggle="tooltip" data-html="true" title="Role PreviledgeEdit" id=\'btneditRP\' class="btn" data_id=\'' + result.rp_id + '\'><i class="glyphicon glyphicon-edit" style="color: blue; font-size: 150%;"></i></a></td>'+
                '</tr>';

                $(table).append(row);

                $('#btneditRP').click(function (event) {
                    // clickPreviledge(this);
                    clickPreviledgeEdit(this);
                });
                $("#PreviledgeModal").modal('show');
            } else {
                pesanAlert(result);
            }
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        },
        complete: function () {
            $("#spinner").hide();
        }
    });
}

var edit;
function clickPreviledgeEdit(obj) {
    notif({msg: "<b>"+ obj.attributes.data_id.value +"</b>", type: "success", position: "center"});
}

function UpdateRolePreviledge(obj) {
    
}