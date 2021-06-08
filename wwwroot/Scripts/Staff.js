$(document).ready(function () {
    $("#active-link").text('Kategori Staff & Staff');
    StaffDetailDataTable();
    GetFakultas();
    $("#add-staff-btn").click(function () {
        addStaffPage();
        $("#active-link").text('Add Staff');
        $("#form-title").text('Add Staff');
        $("#password-field").show();
        $("#btn-edit-stf").hide();
        $("#btn-create-stf").show();
        ShowForm();
    });
    $("#btn-cancel-stf").click(function () {
        ShowTables();
    });
    $("#btn-edit-stf").click(function () {
        updateStaff(this);
    });
    $("#btn-create-stf").click(function() {
        addStaff(this);
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

// Responsive Select Box
$('#select-stfcategory').on('change', function () {
    if (this.value === '1' || this.value === '2' || this.value === '3') {
        $('#fakultas-input').show();
        if (this.value === '2' || this.value === '3') {
            $('#prodi-input').show();
            if (this.value === '3') {
                $('#matkul-input').show();
            }
            else {
                $('#matkul-input').hide();
            }
        }
        else {
            $('#prodi-input').hide();
            $('#matkul-input').hide();
        }
    }
    else {
        $('#fakultas-input').hide();
        $('#prodi-input').hide();
        $('#matkul-input').hide();
    }
});
$("#select-fakultas").on('change', function () {
    if ($('#select-stfcategory').val() === '2' || $('#select-stfcategory').val() === '3') {
        GetProdi(parseInt(this.value));
    }
});
$("#select-prodi").on('change', function () {
    if ($('#select-stfcategory').val() === '3') {
        GetMatkul(parseInt(this.value));
    }
});

function ShowForm() {
    $("#category-table").hide();
    $("#staff-table").hide();
    $("#form-content").show();
}

function ShowTables() {
    $("#active-link").text('Kategori Staff & Staff');
    $("#form-content").hide();
    $("#category-table").show();
    $("#staff-table").show();
    $('#select-fakultas').empty();
    $('#fakultas-input').hide();
    $('#prodi-input').hide();
    $('#matkul-input').hide();
    ClearInputs();
}

function ClearInputs() {
    $('#profile-img').attr('src','images/DefaultPPimg.jpg');
    $('#u_file').val(null);
    $('#u_username').val('');
    $('#u_password').val('');
    $('#stf_fullname').val('');
    $('#stf_email').val('');
    $('#stf_contact').val('');
    $('#stf_nik').val('');
    $('#stf_address').val('');
    $('#stf_city').val('');
    $('#stf_province').val('');
    $('#stf_birthplace').val('');
    $('#stf_birthdate').val('');
    $('#stf_religion').val('');
    $('#stf_state').val('');
}

function StaffDetailDataTable() {
    var table = $("#tblStaff-detail");
    $("#tbl-loading-2").show();
    $.ajax({
        type: "GET",
        url: "/StaffCategory/GetStaffList",
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
                    if (data[5].dataStat[i] == 1) {
                        status = '<td class="tb-content status-user"><a class="btn btn-sm btn-success" title="User '+data[2].dataNama[i]+' berstatus Aktif"><b>Aktif</b></a></td>';
                    } else {
                        status = '<td class="tb-content status-user"><a class="btn btn-sm btn-danger" title="User '+data[2].dataNama[i]+' berstatus Tidak Aktif"><b>Tidak Aktif</b></a></td>';
                    }
                    rowHTML = '<tr>' +
                    '<td class="tb-content" style="text-align: center; padding: 10px 0 10px 0px !important;">' + stringImg + '</td>' +
                    '<td class="tb-content">' + data[1].username[i] + '</td>' +
                    '<td class="tb-content">' + data[2].dataNama[i] + '</td>' +
                    '<td class="tb-content">' + data[3].dataKategori[i] + '</td>' +
                    '<td class="tb-content">' + data[4].dataNIK[i] + '</td>' +
                    status +
                    '<td class="tb-content"><a data-toggle="tooltip" data-html="true" title="Edit Data" id=\'btnstfedit' + i + '\' class="btn" data_id=\'' + data[0].nomor[i] + '\'><i class="fa fa-edit" style="color: blue;"></i></a><a data-toggle="tooltip" data-html="true" title="Delete Data" id=\'btnstfdelete' + i + '\' class="btn" data_id=\'' + data[0].nomor[i] + '\'><i class="fa fa-remove" style="color: red;"></i></a></td>' +
                    '</tr>';

                    $(table).append(rowHTML);

                    $('#btnstfedit' + i).click(function () {
                        clickStaffEdit(this);
                    });

                    $('#btnstfdelete' + i).click(function () {
                        clickStaffDelete(this);
                    });
                }

            $(table).DataTable();
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        },
        complete: function () {
            $("#tbl-loading-2").hide();
        }
    });
}

function addStaffPage() {
    var comboBox = $("#select-stfcategory");

    $.ajax({
        type: "GET",
        url: "/StaffCategory/GetCategoryList",
        contentType: "application/json",
        dataType: "json",
        data: null,
        success: function (data) {
            $(comboBox).empty();
            $(comboBox).append('<option selected>Pilih</option>'); // default option
            var opsi = '';
            for (let i = 0; i < data[0].nomor.length; i++) {
                opsi = '<option value="'+data[0].nomor[i]+'" title="'+data[2].deskripsi[i]+'">'+data[1].kategori[i]+'</option>';
                $(comboBox).append(opsi);
            }
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        }
    });
}

function validasiAddStaff() {
    var isValid = true;
    if($("#u_username").val().trim() == "") {
        $("#username-alrt").show();
        isValid = false;
    }
    if($("#u_password").val().trim() == "") {
        $("#password-alrt").show();
        isValid = false;
    }
    return isValid;
}

function addStaff() {
    var res = validasiAddStaff();
    if(res == false) {
        return false;
    }
    var formData = new FormData();
    let imgFile = $('#u_file');
    if (imgFile[0].files[0] != null)
        formData.append("u_file", imgFile[0].files[0], imgFile.val());
    
    let sc_id = parseInt($('#select-stfcategory').val());
    formData.append("u_username", $('#u_username').val());
    formData.append("u_password", $('#u_password').val());
    formData.append("stf_sc_id", sc_id);
    if (sc_id === 1 || sc_id === 2 || sc_id === 3) {
        formData.append("stf_fks_id", parseInt($('#select-fakultas').val()));
        if (sc_id === 2 || sc_id === 3)
        {
            formData.append("stf_ps_id", parseInt($('#select-prodi').val()));
            if (sc_id === 3)
                if ($('#select-matkul').val() != "Pilih") formData.append("stf_mk_id", parseInt($('#select-matkul').val()));
        }
    }
    formData.append("stf_fullname", $('#stf_fullname').val());
    formData.append("stf_email", $('#stf_email').val());
    formData.append("stf_contact", $('#stf_contact').val());
    formData.append("stf_nik", $('#stf_nik').val());
    formData.append("stf_address", $('#stf_address').val());
    formData.append("stf_city", $('#stf_city').val());
    formData.append("stf_province", $('#stf_province').val());
    formData.append("stf_birthdate", $('#stf_birthdate').val());
    formData.append("stf_birthplace", $('#stf_birthplace').val());
    formData.append("stf_gender", $('#select-gender').val());
    formData.append("stf_religion", $('#stf_religion').val());
    formData.append("stf_state", $('#stf_state').val());
    formData.append("stf_stat", parseInt($('#select-status').val()));

    $.ajax({
        // headers: {
        //     'Accept': 'application/json',
        //     'Content-Type': 'application/json'
        // },
        type: "POST",
        url: "/StaffCategory/AddStaff/Create",
        // data: JSON.stringify(Data),
        data: formData,
        processData: false,
        contentType: false,
        success: function (data) {
            if(data.code === 1) {
                pesanAlert(data);
                StaffDetailDataTable();
                setTimeout(() => { ShowTables(); }, 1000);
            }
            else {
                pesanAlert(data);
            }
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        },
        complete: function () {
            $("#username-alrt").hide();
            $("#password-alrt").hide();
        }
    });
}

var edit;

function clickStaffEdit(obj) {
    addStaffPage();
    $("#active-link").text('Edit Staff');
    $("#form-title").text('Edit Staff');
    $("#password-field").hide();
    $("#btn-create-stf").hide();
    $("#btn-edit-stf").show();
    let obj_id = {
        "stf_id": 0,
        "stf_u_id": parseInt(obj.attributes.data_id.value)
    };
    $.ajax({
        type: "GET",
        url: "/StaffCategory/UpdateStaff/GetById/" + obj_id.stf_u_id,
        contentType: "application/json",
        dataType: "json",
        data: obj_id.stf_u_id,
        success: function (data) {
            if(data.code === 0 || data.code === -1) {
                pesanAlert(data);
            }
            else {
                obj_id.stf_id = data.stf_id;
                if (data.up_photo !== null) {
                    let fileExt = data.up_filename.split('.').pop();
                    $('#profile-img').attr('src', 'data:image/'+fileExt+';base64,'+data.up_photo+'');
                }
                $("#u_username").val(data.u_username);
                $("#select-stfcategory").val(''+data.stf_sc_id);
                $("#stf_fullname").val(data.stf_fullname);
                $("#stf_nik").val(data.stf_nik);
                $("#stf_address").val(data.stf_address);
                $("#stf_province").val(data.stf_province);
                $("#stf_city").val(data.stf_city);
                $("#stf_birthplace").val(data.stf_birthplace);
                $("#stf_birthdate").val(data.stf_birthdate);
                $("#select-gender").val(data.stf_gender);
                $("#stf_religion").val(data.stf_religion);
                $("#stf_state").val(data.stf_state);
                $("#stf_email").val(data.stf_email);
                $("#select-status").val(''+data.stf_stat);
                $("#stf_contact").val(data.stf_contact);
                ShowForm();
            }
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        },
        complete: function () {
            edit = obj_id;
        }
    });
}

function updateStaff() {
    if($("#u_username").val().trim() == "") {
        $("#username-alrt").show();
        return false;
    }
    var formData = new FormData();
    let imgFile = $('#u_file');
    if (imgFile[0].files[0] != null)
        formData.append("u_file", imgFile[0].files[0], imgFile.val());
    
    formData.append("stf_id", edit.stf_id);
    formData.append("stf_u_id", edit.stf_u_id);
    formData.append("u_username", $('#u_username').val());
    formData.append("u_password", $('#u_password').val());
    formData.append("stf_sc_id", parseInt($("#select-stfcategory").val()));
    formData.append("stf_fullname", $('#stf_fullname').val());
    formData.append("stf_email", $('#stf_email').val());
    formData.append("stf_contact", $('#stf_contact').val());
    formData.append("stf_nik", $('#stf_nik').val());
    formData.append("stf_address", $('#stf_address').val());
    formData.append("stf_city", $('#stf_city').val());
    formData.append("stf_province", $('#stf_province').val());
    formData.append("stf_birthdate", $('#stf_birthdate').val());
    formData.append("stf_birthplace", $('#stf_birthplace').val());
    formData.append("stf_gender", $('#select-gender').val());
    formData.append("stf_religion", $('#stf_religion').val());
    formData.append("stf_state", $('#stf_state').val());
    formData.append("stf_stat", parseInt($('#select-status').val()));

    $.ajax({
        type: "PUT",
        url: "/StaffCategory/UpdateStaff/Update",
        // contentType: "application/json",
        // dataType: "json",
        // data: JSON.stringify(Data),
        processData: false,
        contentType: false,
        data: formData,
        success: function (data) {
            if(data.code === 1) {
                pesanAlert(data);
                StaffDetailDataTable();
                setTimeout(() => { ShowTables(); }, 1000);
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

function clickStaffDelete(obj) {
    let obj_id = {"stf_u_id": parseInt(obj.attributes.data_id.value)};

    var konfirmasi = confirm("Yakin ingin Delete Staff?");
    if(konfirmasi) {
        $.ajax({
            type: "DELETE",
            url: "/StaffCategory/DeleteUserStaff",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(obj_id),
            success: function (data) {
                if(data.code === 1) {
                    pesanAlert(data);
                    StaffDetailDataTable();
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

function GetFakultas() {
    let comboBox = $('#select-fakultas');
    $.ajax({
        type: "GET",
        url: "/Fakultas/GetList",
        contentType: "application/json",
        dataType: "json",
        data: null,
        success: function (data) {
            comboBox.empty();
            comboBox.append('<option value="null" selected>Pilih</option>');
            let opsi = '';
            for (let i = 0; i < data[0].nomor.length; i++) {
                opsi = '<option value="'+data[0].nomor[i]+'" title="'+data[2].deskripsi[i]+'">'+data[1].fakultas[i]+'</option>';
                comboBox.append(opsi);
            }
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        }
    });
}

function GetProdi(fks_id = 0) {
    let comboBox = $('#select-prodi');
    $.ajax({
        type: "GET",
        url: "/Fakultas/GetListById/" + fks_id,
        contentType: "application/json",
        dataType: "json",
        data: fks_id,
        success: function (data) {
            if(data.code === 0 || data.code === -1) {
                pesanAlert(data);
            }
            else {
                comboBox.empty();
                comboBox.append('<option value="null" selected>Pilih</option>');
                let opsi = '';
                for (let i = 0; i < data[0].nomor.length; i++) {
                    opsi = '<option value="'+data[0].nomor[i]+'" title="'+data[3].deskripsi[i]+'">'+data[2].prodi[i]+'</option>';
                    comboBox.append(opsi);
                }
            }
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        }
    });
}

function GetMatkul(ps_id = 0) {
    let comboBox = $('#select-matkul');
    $.ajax({
        type: "GET",
        url: "/MataKuliah/GetListById/" + ps_id,
        contentType: "application/json",
        dataType: "json",
        data: ps_id,
        success: function (data) {
            if(data.code === 0 || data.code === -1) {
                pesanAlert(data);
            }
            else {
                comboBox.empty();
                comboBox.append('<option selected>Pilih</option>');
                let opsi = '';
                for (let i = 0; i < data[0].nomor.length; i++) {
                    opsi = '<option value="'+data[0].nomor[i]+'" title="'+data[7].desc[i]+'">('+data[8].smcode[i]+') ('+data[5].mkcode[i]+') '+data[6].name[i]+'</option>';
                    comboBox.append(opsi);
                }
            }
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        }
    });
}