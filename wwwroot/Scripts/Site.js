var actionTitle; // Title for Modals

$(document).ready(function () {
    SiteDataTable();
    $('#btn-edit-site').click(function () {
        UpdateSite();
    });
    $('#btn-add-site').click(function () {
        AddSite(this);
    });
    $("#Add-btn").click(function() {
        ShowAddModals(this);
    });
});

$('#u_file').on('change', function () {
    readUrl(this, '#profile-img');
});

function readUrl(input, selector) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(selector).attr('src',e.target.result);
        }
        reader.readAsDataURL(input.files[0]);
    }
}

function SiteDataTable() {
    var table = $('#tblSite');
    $('#spinner').show();
    $.ajax({
        type: "GET",
        url: "/Site/GetAll",
        contentType: "application/json",
        dataType: "json",
        data: null,
        success: function (data) {
            $(table).children('tbody').empty();
            var rowHTML = '';
            let status = '';
            for (let i = 0; i < data[0].nomor.length; i++) {
                // Photo Render
                let stringImg = '<img src="../images/DefaultPPimg.jpg" width="60" height="60" alt="Photo Profile">';
                if (data[7].photoData[i] !== null)
                {
                    let fileExt = data[6].photoFilename[i].split('.').pop();
                    stringImg = '<img src="data:image/'+fileExt+';base64,'+data[7].photoData[i]+'" width="60" height="60" alt="'+data[6].photoFilename[i]+'">';
                }
                // Status
                if (data[5].status[i] == 1) {
                    status = '<td class="tb-content status-user"><a class="btn btn-sm btn-success" title="User '+data[2].fullname[i]+' berstatus Aktif"><b>Aktif</b></a></td>';
                } else {
                    status = '<td class="tb-content status-user"><a class="btn btn-sm btn-danger" title="User '+data[2].fullname[i]+' berstatus Tidak Aktif"><b>Tidak Aktif</b></a></td>';
                }
                rowHTML = '<tr>' +
                '<td class="tb-content" style="text-align: center; padding: 10px 0 10px 0px !important;">' + stringImg + '</td>' +
                '<td class="tb-content">' + data[1].username[i] + '</td>' +
                '<td class="tb-content">' + data[2].fullname[i] + '</td>' +
                '<td class="tb-content">' + data[3].nik[i] + '</td>' +
                '<td class="tb-content">' + data[4].role[i] + '</td>' +
                status +
                '<td class="tb-content"><a data-toggle="tooltip" data-html="true" title="Edit Data" id=\'btnedit' + i + '\' class="btn" data_id=\'' + data[0].nomor[i] + '\'><i class="fa fa-edit" style="color: blue;"></i></a><a data-toggle="tooltip" data-html="true" title="Delete Data" id=\'btndelete' + i + '\' class="btn" data_id=\'' + data[0].nomor[i] + '\'><i class="fa fa-remove" style="color: red;"></i></a></td>' +
                '</tr>';

                $(table).append(rowHTML);

                $('#btnedit' + i).click(function (event) {
                    GetEditData(this);
                });

                $('#btndelete' + i).click(function (event) {
                    SiteDelete(this);
                });
            }
            $(table).DataTable();
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        },
        complete: function () {
            $('#spinner').hide();
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

// Clearing Modal Inputs
function ClearModalInput() {
    $('#u_username').val('');
    $('#u_password').val('');
    $('#s_fullname').val('');
    $('#s_email').val('');
    $('#s_contact').val('');
    $('#s_nik').val('');
    $('#s_address').val('');
    $('#s_city').val('');
    $('#s_province').val('');
    $('#s_birthplace').val('');
    $('#s_birthdate').val('');
    $('#s_religion').val('');
    $('#s_state').val('');
}

// Modal for add data
function ShowAddModals() {
    actionTitle = 'Add Site';
    $('#profile-img').attr('src','images/DefaultPPimg.jpg');
    ClearModalInput();
    $('#AddEditModal').on('show.bs.modal', function (event) {
        var modal = $(this);
        modal.find('.modal-title').text(actionTitle);
        $('#pass-txtbox').show();
        $('#btn-add-site').show();
        $('#btn-edit-site').hide();
    });
}

function AddSite() {
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

    var formData = new FormData();
    let imgFile = $('#u_file');
    if (imgFile[0].files[0] != null)
        formData.append("u_file", imgFile[0].files[0], imgFile.val());
    
    formData.append("u_username", $('#u_username').val());
    formData.append("u_password", $('#u_password').val());
    formData.append("s_fullname", $('#s_fullname').val());
    formData.append("s_email", $('#s_email').val());
    formData.append("s_contact", $('#s_contact').val());
    formData.append("r_desc", $('#r_desc').val());
    formData.append("s_nik", $('#s_nik').val());
    formData.append("s_address", $('#s_address').val());
    formData.append("s_city", $('#s_city').val());
    formData.append("s_province", $('#s_province').val());
    formData.append("s_birthdate", $('#s_birthdate').val());
    formData.append("s_birthplace", $('#s_birthplace').val());
    formData.append("s_gender", $('#s_gender').val());
    formData.append("s_religion", $('#s_religion').val());
    formData.append("s_state", $('#s_state').val());
    formData.append("s_stat", parseInt($('#s_stat').val()));
    console.log(formData.get("u_file"));

    $.ajax({
        type: "POST",
        url: "/Site/Create",
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            if (data.code === 1) {
                pesanAlert(data);
                // setTimeout(function () { window.location.reload() }, 2000);
                SiteDataTable();
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
            ClearModalInput();
            $('#pass-txtbox').hide();
        }
    });
}

// Modals for Edit Data
function ShowEditModals() {
    actionTitle = 'Edit Site';
    $('#AddEditModal').on('show.bs.modal', function (event) {
        var modal = $(this);
        modal.find('.modal-title').text(actionTitle);
        $('#pass-txtbox').hide();
        $('#btn-edit-site').show();
        $('#btn-add-site').hide();
    });
}
// Save data_id for update data
var edit;

function GetEditData(obj) {
    ShowEditModals();
    let obj_id = {
        "s_id": 0,
        "s_u_id": parseInt(obj.attributes.data_id.value)
    };
    $.ajax({
        type: "GET",
        url: "/Site/GetById/" + obj_id.s_u_id,
        contentType: "application/json",
        dataType: "json",
        data: obj_id.s_u_id,
        success: function (data) {
            console.log(data);
            if(data != null) {
                obj_id.s_id = data.s_id;
                edit = obj_id;
                if (data.up_photo !== null) {
                    let fileExt = data.up_filename.split('.').pop();
                    $('#profile-img').attr('src', 'data:image/'+fileExt+';base64,'+data.up_photo+'');
                }
                $('#u_username').val(data.u_username);
                $('#r_desc').val(data.r_desc);
                $('#s_fullname').val(data.s_fullname);
                $('#s_email').val(data.s_email);
                $('#s_contact').val(data.s_contact);
                $('#s_nik').val(data.s_nik);
                $('#s_address').val(data.s_address);
                $('#s_city').val(data.s_city);
                $('#s_province').val(data.s_province);
                $('#s_birthplace').val(data.s_birthplace);
                $('#s_birthdate').val(data.s_birthdate);
                $('#s_religion').val(data.s_religion);
                $('#s_state').val(data.s_state);
                $('#s_gender').val(data.s_gender);
                $('#s_stat').val(''+data.s_stat);
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
function UpdateSite() {
    var res = validasi();
    if(res == false) return false;

    var formData = new FormData();
    let imgFile = $('#u_file');
    if (imgFile[0].files[0] != null)
        formData.append("u_file", imgFile[0].files[0], imgFile.val());
    
    formData.append("s_id", edit.s_id);
    formData.append("s_u_id", edit.s_u_id);
    formData.append("u_username", $('#u_username').val());
    formData.append("s_fullname", $('#s_fullname').val());
    formData.append("s_email", $('#s_email').val());
    formData.append("s_contact", $('#s_contact').val());
    formData.append("r_desc", $('#r_desc').val());
    formData.append("s_nik", $('#s_nik').val());
    formData.append("s_address", $('#s_address').val());
    formData.append("s_city", $('#s_city').val());
    formData.append("s_province", $('#s_province').val());
    formData.append("s_birthdate", $('#s_birthdate').val());
    formData.append("s_birthplace", $('#s_birthplace').val());
    formData.append("s_gender", $('#s_gender').val());
    formData.append("s_religion", $('#s_religion').val());
    formData.append("s_state", $('#s_state').val());
    formData.append("s_stat", parseInt($('#s_stat').val()));
    console.log(formData.get("u_file"));

    $.ajax({
        type: "PUT",
        url: "/Site/Update",
        processData: false,
        contentType: false,
        data: formData,
        success: function (data) {
            if (data.code === 1) {
                pesanAlert(data);
                // setTimeout(function () { window.location.reload() }, 2000);
                SiteDataTable();
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
            ClearModalInput();
        }
    });
}

//Delete Data
function SiteDelete(obj) {
    let obj_id = { "s_u_id": parseInt(obj.attributes.data_id.value) };
    var konfirmasi = confirm("Yakin ingin Hapus data Site?");
    if (konfirmasi) {
        $.ajax({
            type: "DELETE",
            url: "/Site/Delete",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(obj_id),
            success: function (data) {
                if (data.code === 1) {
                    pesanAlert(data);
                    // setTimeout(function () { window.location.reload() }, 2000);
                    SiteDataTable();
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