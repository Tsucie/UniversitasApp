$(document).ready(function () {
    StaffDetailDataTable();
    addStaffPage();
    $("#btn-edit-stf").click(function () {
        updateStaff();
    });
    $("#btn-create-stf").click(function() {
        addStaff(this);
    });
});

function pesanAlert(obj) {
    let color = "";
    let msg = "";
    let position = "";
    switch (parseInt(obj.code)) {
        case 1:
            color = "success";
            msg = obj.pesan;
            position = "center";
            break;
        case 0:
            color = "warning";
            msg = obj.pesan;
            position = "center";
            break;
        case -1:
            color = "danger";
            msg = obj.pesan;
            position = "center";
            break;
        default:
            break;
    }
    notif({
        msg: "<b>" + msg + "</b>",
        type: color,
        position: "center"
    });
}

function StaffDetailDataTable() {
    var table = $("#tblStaff-detail");

    $("#spinner-2").show();
    $.ajax({
        type: "GET",
        url: "/StaffCategory/GetStaffList",
        contentType: "application/json",
        dataType: "json",
        data: null,
        success: function (obj) {
            $(table).children('tbody').empty();
            var rowHTML = '';
            let status = '';
                for (let i = 0; i < obj[0].dataNama.length; i++) {
                    if (obj[5].dataStat[i] == 1) {
                        status = '<td class="tb-content status-user"><a class="btn btn-sm btn-success" title="User '+obj[0].dataNama[i]+' berstatus Aktif"><b>Aktif</b></a></td>';
                    } else {
                        status = '<td class="tb-content status-user"><a class="btn btn-sm btn-danger" title="User '+obj[0].dataNama[i]+' berstatus Tidak Aktif"><b>Tidak Aktif</b></a></td>';
                    }
                    rowHTML = '<tr>' +
                    '<td class="tb-content">' + obj[0].dataNama[i] + '</td>' +
                    '<td class="tb-content">' + obj[1].dataKategori[i] + '</td>' +
                    '<td class="tb-content">' + obj[2].dataNIK[i] + '</td>' +
                    '<td class="tb-content">' + obj[3].dataEmail[i] + '</td>' +
                    '<td class="tb-content">' + obj[4].dataTelp[i] + '</td>' +
                    status +
                    '<td class="tb-content"><a data-toggle="tooltip" data-html="true" title="Edit Data" id=\'btnstfedit' + i + '\' class="btn" data_id=\'' + obj[6].dataU_id[i] + '\'><i class="fa fa-edit"></i></a><a data-toggle="tooltip" data-html="true" title="Delete Data" id=\'btnstfdelete' + i + '\' class="btn" data_id=\'' + obj[6].dataU_id[i] + '\'><i class="fa fa-remove"></i></a></td>' +
                    '</tr>';

                    $(table).append(rowHTML);

                    $('#btnstfedit' + i).click(function (event) {
                        clickStaffEdit(this);
                    });

                    $('#btnstfdelete' + i).click(function (event) {
                        clickStaffDelete(this);
                    });
                }

            $(table).DataTable();
        },
        error: function (data) {
            pesanAlert(data);
        },
        complete: function () {
            $("#spinner-2").hide();
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
            $(comboBox).children('select').empty();
            var opsi = '';
            for (let i = 0; i < data[0].nomor.length; i++) {
                opsi = '<option value="'+data[0].nomor[i]+'" title="'+data[2].deskripsi[i]+'">'+data[1].kategori[i]+'</option>';
                $(comboBox).append(opsi);
            }
        },
        error: function (data) {
            pesanAlert(data);
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
    var Data = {
        //users
        "u_username": $("#u_username").val(),
        "u_password": $("#u_password").val(),
        "u_ut_id": 3,
        //stf_detail
        "stf_sc_id": parseInt($("#select-stfcategory").val()),
        // "stf_fks_id": parseInt($("#select-fakultas").val()),
        "stf_fullname": $("#stf_fullname").val(),
        "stf_nik": $("#stf_nik").val(),
        "stf_address": $("#stf_address").val(),
        "stf_province": $("#stf_province").val(),
        "stf_city": $("#stf_city").val(),
        "stf_birthplace": $("#stf_birthplace").val(),
        "stf_birthdate": $("#stf_birthdate").val(),
        "stf_gender": $("#select-gender").val(),
        "stf_religion": $("#stf_religion").val(),
        "stf_state": $("#stf_state").val(),
        "stf_email": $("#stf_email").val(),
        "stf_stat": parseInt($("#select-status").val()),
        "stf_contact": $("#stf_contact").val()
    };
    $.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        type: "POST",
        url: "/StaffCategory/AddStaff/Create",
        data: JSON.stringify(Data),
        success: function (data) {
            if(data.code === 1) {
                pesanAlert(data);
                setTimeout(function () { window.location.href = "../StaffCategory"; }, 1000);
            }
            else {
                pesanAlert(data);
            }
        },
        error: function () {
            alert("Error Connection!");
        }
    });
}

var edit;

function clickStaffEdit(obj) {
    let obj_id = {
        "stf_id": 0,
        "stf_u_id": parseInt(obj.attributes.data_id.value)
    };
    $.ajax({
        type: "GET",
        url: "/StaffCategory/UpdateStaff/" + obj_id.stf_u_id,
        contentType: "application/json",
        dataType: "json",
        data: obj_id.stf_u_id,
        success: function (data) {
            if(data != null) {
                window.location.href = '../StaffCategory/UpdateStaff/';
                obj_id.stf_id = data.stf_id;
                console.log(data);
                console.log(obj_id);
                $("#u_username").val(data.u_username);
                $("#select-stfcategory").val(data.stf_sc_id);
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
                $("#select-status").val(data.stf_stat);
                $("#stf_contact").val(data.stf_contact);
            }
            else {
                pesanAlert(data);
            }
        },
        error: function (data) {
            alert("Error Connection!");
        }
    });
    edit = obj_id;
}

function updateStaff() {
    if($("#u_username").val().trim() == "") {
        $("#username-alrt").show();
        return false;
    }
    var Data = {
        "stf_id": edit.stf_id,
        "stf_u_id": edit.stf_u_id,
        "u_username": $("#u_username").val(),
        "stf_sc_id": $("#select-stfcategory").val(),
        "stf_fullname": $("#stf_fullname").val(),
        "stf_nik": $("#stf_nik").val(),
        "stf_address": $("#stf_address").val(),
        "stf_province": $("#stf_province").val(),
        "stf_city": $("#stf_city").val(),
        "stf_birthplace": $("#stf_birthplace").val(),
        "stf_birthdate": $("#stf_birthdate").val(),
        "stf_gender": $("#select-gender").val(),
        "stf_religion": $("#stf_religion").val(),
        "stf_state": $("#stf_state").val(),
        "stf_email": $("#stf_email").val(),
        "stf_stat": $("#select-status").val(),
        "stf_contact": $("#stf_contact").val()
    };
    $.ajax({
        type: "PUT",
        url: "/StaffCategory/UpdateStaff/Update",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(Data),
        success: function (data) {
            if(data.code === 1) {
                pesanAlert(data);
                setTimeout(function () { window.location.href = "../StaffCategory"; }, 1000);
            }
            else {
                pesanAlert(data);
            }
        },
        error: function () {
            alert("Error Connection!");
        }
    });
}

function clickStaffDelete(obj) {
    let obj_id = {"stf_u_id": parseInt(obj.attributes.data_id.value)};

    var konfirmasi = confirm("Yakin inigin Delete Staff?");
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
                    setTimeout(function () { window.location.reload() }, 2000);
                }
                else {
                    pesanAlert(data);
                }
            },
            error: function () {
                alert("Error Connection!");
            }
        });
    }
}