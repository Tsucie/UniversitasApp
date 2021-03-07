$(document).ready(function () {
    RoleDataTable();
    $("#btn-simpan-role").click(function () {
        UpdateRolePreviledge(this);
    });
});

function RoleDataTable() {
    var table = $("#tblRole");
    $("#tbl-loading").show();
    $.ajax({
        type: "GET",
        url: "/Role/GetAll",
        contentType: "application/json",
        dataType: "json",
        data: null,
        success: function (data) {
            $(table).children('tbody').empty();
            var rowHTML = '';
                for (let i = 0; i < data[1].roleUsername.length; i++) {
                    let number = i+1;
                    rowHTML = '<tr>' +
                    '<td class="tb-content status-user col-md-1">' + number + '</td>' +
                    '<td class="tb-content">' + data[1].roleUsername[i] + '</td>'+
                    '<td class="tb-content">' + data[2].roleTypeName[i] + '</td>'+
                    '<td class="tb-content">' + data[3].roleName[i] + '</td>'+
                    '<td class="tb-content"><a data-toggle="tooltip" data-html="true" title="Role Previledge" id=\'btndetail' + i + '\' class="btn" data_id=\'' + data[0].roleId[i] + '\'><i class="glyphicon glyphicon-wrench" style="color: rgba(0, 0, 0, 0.6); font-size: 150%;"></i></a></td>'+
                    '</tr>';

                    $(table).append(rowHTML);

                    $('#btndetail' + i).click(function () {
                        clickPreviledge(this);
                    });
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

function iconStatus(id, element_id) {
    let icon = '';
    switch (id) {
        case 1:
            // icon = '<i class="glyphicon glyphicon-ok-circle" style="color: green; font-size: 150%;"></i>';
            icon = '<label class="switch">'+
                        '<input id="'+element_id+'" type="checkbox" checked>'+
                        '<span class="slider round" title="Enable"></span>'+
                    '</label>';
            break;
        case 0:
            // icon = '<i class="glyphicon glyphicon-remove-circle" style="color: red; font-size: 150%;"></i>';
            icon = '<label class="switch">'+
                        '<input id="'+element_id+'" type="checkbox">'+
                        '<span class="slider round" title="Disable"></span>'+
                    '</label>';
            break;
        case -1:
            icon = '<i class="glyphicon glyphicon-ban-circle" style="color: lightgray; font-size: 150%;"></i>';
            break;
        default:
            break;
    }
    return icon;
}

function statusCheck(obj) {
    let dataId = 0;
    if($(obj).is(":checked")) dataId = 1;

    return dataId;
}

var edit = {};

function clickPreviledge(obj) {
    let DataId = {"r_id": parseInt(obj.attributes.data_id.value)};
    var table = $("#tblRP");
    $("#tbl-loading").show();
    $("#mod-footer").hide();
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
                '<td class="tb-content status-user col-md-1">' + iconStatus(result.rp_view, 'view') + '</td>'+
                '<td class="tb-content status-user col-md-1">' + iconStatus(result.rp_add, 'add') + '</td>'+
                '<td class="tb-content status-user col-md-1">' + iconStatus(result.rp_edit, 'edit') + '</td>'+
                '<td class="tb-content status-user col-md-1">' + iconStatus(result.rp_delete, 'delete') + '</td>'+
                '<td class="tb-content status-user col-md-1"><a data-toggle="tooltip" data-html="true" title=" Edit Role Previledge " id=\'btneditRP\' class="btn"><i class="glyphicon glyphicon-edit" style="color: blue; font-size: 150%;"></i></a></td>'+
                '</tr>';

                $(table).append(row);
                edit = {"rp_id": result.rp_id};
                $('#btneditRP').click(function () {
                    $("#mod-footer").show();
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

function UpdateRolePreviledge() {
    var Data = {
        "rp_id": edit.rp_id,
        "rp_view": statusCheck("#view"),
        "rp_add": statusCheck("#add"),
        "rp_edit": statusCheck("#edit"),
        "rp_delete": statusCheck("#delete")
    };
    $.ajax({
        type: "PUT",
        url: "/Role/UpdatePreviledge",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(Data),
        success: function (data) {
            if(data.code === 1) {
                pesanAlert(data);
                setTimeout(() => { window.location.reload() }, 3000);
            }
            else {
                pesanAlert(data);
            }
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        },
        complete: function () {
            $("#PreviledgeModal").modal('hide');
        }
    });
}