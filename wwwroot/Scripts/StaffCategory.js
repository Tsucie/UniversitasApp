var actionTitle; // Title for Modals

$(document).ready(function () {
    StaffCategoryDataTable();
    $("#btn-add-category").click(function() {
        addStfCategory(this);
    });
    $("#btn-edit-category").click(function() {
        UpdateCategory();
    });
    $("#Add-btn").click(function() {
        ShowAddModals(this);
    });
});
// JQuery Validate
function validasi() {
    var isValid = true;
    if($('#sc_name').val().trim() == "") {
        $('#sc_name').css('border-color', 'Red');
        isValid = false;
    } else {
        $('sc_name').css('border-color', 'lightgray');
    }
    return isValid;
}

// Staff_category datatables
function StaffCategoryDataTable() {
    var table = $("#tblStaff");

    $("#spinner-1").show();
    $.ajax({
        type: "GET",
        url: "/StaffCategory/GetCategoryList",
        contentType: "application/json",
        dataType: "json",
        data: null,
        success: function (data) {
            $(table).children('tbody').empty();
            var rowHTML = '';
                for (let i = 0; i < data[0].nomor.length; i++) {
                    let number = i+1;
                    rowHTML = '<tr>' +
                    '<td class="tb-content status-user col-md-1">' + number + '</td>' +
                    '<td class="tb-content">' + data[1].kategori[i] + '</td>' +
                    '<td class="tb-content">' + data[2].deskripsi[i] + '</td>' +
                    '<td class="tb-content"><a data-toggle="tooltip" data-html="true" title="Edit Data" id=\'btnedit' + i + '\' class="btn" data_id=\'' + data[0].nomor[i] + '\'><i class="fa fa-edit"></i></a><a data-toggle="tooltip" data-html="true" title="Delete Data" id=\'btndelete' + i + '\' class="btn" data_id=\'' + data[0].nomor[i] + '\'><i class="fa fa-remove"></i></a></td>' +
                    '</tr>';

                    $(table).append(rowHTML);

                    $('#btnedit' + i).click(function (event) {
                        clickCategoryEdit(this);
                    });

                    $('#btndelete' + i).click(function (event) {
                        clickCategoryDelete(this);
                    });
                }

            $(table).DataTable();
        },
        error: function (data) {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        },
        complete: function () {
            $("#spinner-1").hide();
        }
    });
}
// Modals for Add Data
function ShowAddModals() {
    actionTitle = 'Add Kategori Staff';
    $('#sc_name').val('');
    $('#sc_desc').val('');
    $("#AddEditModal").on('show.bs.modal', function (event) {
        var modal = $(this);
        modal.find('.modal-title').text(actionTitle);
        $("#btn-add-category").show();
        $("#btn-edit-category").hide();
    });
}
// Add Data
function addStfCategory() {
    var res = validasi();
    if(res == false) {
        return false;
    }
    var Data = {
        "sc_name": $("#sc_name").val(),
        "sc_desc": $("#sc_desc").val()
    };
    $.ajax({
        type: "POST",
        url: "/StaffCategory/AddCategory",
        // contentType: "application/json",
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
            $("#sc_name").val('');
            $("#sc_desc").val('');
        }
    });
}
// Modals for Edit Data
function ShowEditModals() {
    actionTitle = 'Edit Kategori Staff';
    $("#AddEditModal").on('show.bs.modal', function (event) {
        var modal = $(this);
        modal.find('.modal-title').text(actionTitle);
        $("#btn-edit-category").show();
        $("#btn-add-category").hide();
    });
}

var edit; // Save data_id for update data
// Get data by id for Edit Display
function clickCategoryEdit(obj) {
    ShowEditModals();
    let obj_id = {"sc_id": parseInt(obj.attributes.data_id.value)};
    edit = obj_id;
    $.ajax({
        type: "GET",
        url: "/StaffCategory/GetCategory/" + obj_id.sc_id,
        contentType: "application/json",
        dataType: "json",
        data: obj_id.sc_id,
        success: function (data) {
            if(data != null) {
                $("#sc_name").val(data.sc_name);
                $("#sc_desc").val(data.sc_desc);
                $("#AddEditModal").modal('show');
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
// Edit Data
function UpdateCategory() {
    var res = validasi();
    if(res == false) {
        return false;
    }
    var Data = {
        "sc_id": edit.sc_id,
        "sc_name": $("#sc_name").val(),
        "sc_desc": $("#sc_desc").val()
    };
    $.ajax({
        type: "PUT",
        url: "/StaffCategory/EditCategory",
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
            $('#sc_name').val('');
            $('#sc_desc').val('');
        }
    });
}
// Delete Data
function clickCategoryDelete(obj) {
    let obj_id = {"sc_id": parseInt(obj.attributes.data_id.value)};
    
    var konfirmasi = confirm("Yakin ingin delete kategori?");
    if(konfirmasi) {
        $.ajax({
            type: "DELETE",
            url: "/StaffCategory/DeleteCategory",
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