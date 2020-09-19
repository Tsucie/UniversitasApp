$(document).ready(function () {
    $("#active-link").text('Mahasiswa');
    MhsDataTable();
    FksComboBox();
    $("#btn-addmhspage").click(function () {
        $("#active-link").text('Add Mahasiswa');
        $("#active-title").text('Add Mahasiswa');
        $("#password-field").show();
        $("#btn-edit-mhs").hide();
        $("#btn-create-mhs").show();
        ShowForm();
    });
    $("#btn-cancel-mhs").click(function () {
        ShowTable();
    });
    $("#select-fakultas").change(function () {
        ProdiComboBox(this);
    });
    $("#btn-create-mhs").click(function() {
        addMhs(this);
    });
    $("#btn-edit-mhs").click(function () {
        UpdateMhs(this);
    });
});

function ShowTable() {
    $("#active-link").text('Mahasiswa');
    $("#mhs-table-content").show();
    $("#mhs-form-content").hide();
}

function ShowForm() {
    $("#mhs-table-content").hide();
    $("#mhs-form-content").show();
}

function MhsDataTable() {
    var table = $("#tblMahasiswa");
    $('#spinner').show();
    $.ajax({
        type: "GET",
        url: "/Mahasiswa/GetMhsList",
        contentType: "application/json",
        dataType: "json",
        data: null,
        success: function (data) {
            $(table).children('tbody').empty();
            var rowHTML = '';
            let status = '';
                for(let i = 0; i < data[0].nama.length; i++) {
                    status = (data[5].stat[i] == 1) ? '<td class="tb-content status-user"><a class="btn btn-sm btn-success" title="User '+data[0].nama[i]+' berstatus Aktif"><b>Aktif</b></a></td>' : '<td class="tb-content status-user"><a class="btn btn-sm btn-danger" title="User '+data[0].nama[i]+' berstatus Tidak Aktif"><b>Tidak Aktif</b></a></td>';
                    rowHTML = '<tr>' +
                    '<td class="tb-content">' + data[0].nama[i] + '</td>' +
                    '<td class="tb-content">' + data[1].fakultas[i] + '</td>' +
                    '<td class="tb-content">' + data[2].nim[i] + '</td>' +
                    '<td class="tb-content">' + data[3].kelas[i] + '</td>' +
                    '<td class="tb-content">' + data[4].email[i] + '</td>' +
                    status +
                    '<td class="tb-content"><a data-toggle="tooltip" data-html="true" title="Edit Data" id=\'btnmhsedit' + i + '\' class="btn" data_id=\'' + data[6].number[i] + '\'><i class="fa fa-edit" style="color: blue;"></i></a><a data-toggle="tooltip" data-html="true" title="Delete Data" id=\'btnmhsdelete' + i + '\' class="btn" data_id=\'' + data[6].number[i] + '\'><i class="fa fa-remove" style="color: red;"></i></a></td>' +
                    '</tr>';

                    $(table).append(rowHTML);

                    $('#btnmhsedit' + i).click(function () {
                        clickMhsEdit(this);
                    });

                    $('#btnmhsdelete' + i).click(function () {
                        clickMhsDelete(this);
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

function FksComboBox() {
    var comboBox = $('#select-fakultas');
    $.ajax({
        type: "GET",
        url: "/Fakultas/GetList",
        contentType: "application/json",
        dataType: "json",
        data: null,
        success: function (data) {
            var opsi = '';
            for (let i = 0; i < data[0].nomor.length; i++) {
                opsi = '<option value="'+data[0].nomor[i]+'" title="'+data[2].deskripsi[i]+'">'+data[1].fakultas[i]+'</option>';
                $(comboBox).append(opsi);
            }
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        }
    });
}

function ProdiComboBox() {
    var comboBox = $("#select-prodi");
    let obj_id = { "ps_fks_id": parseInt($("#select-fakultas").val()) };
    $.ajax({
        type: "GET",
        url: "/Fakultas/GetListById/" + obj_id.ps_fks_id,
        contentType: "application/json",
        dataType: "json",
        data: obj_id.ps_fks_id,
        success: function (data) {
            if(data.code === 0 || data.code === -1) {
                pesanAlert(data);
            }
            else {
                $(comboBox).empty(); // Set to empty every Fakultas ComboBox Change event
                var opsi = '';
                for (let i = 0; i < data[0].nomor.length; i++) {
                    opsi = '<option value="'+data[0].nomor[i]+'" title="'+data[3].deskripsi[i]+'">'+data[2].prodi[i]+'</option>';
                    $(comboBox).append(opsi);
                }
            }
        },
        error: function () {
            notif({msg: "<b>Pilih Fakultas!</b>", type: "error", position: "center"});
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
    // if($("#select-fakultas").val() == "") {
    //     $("fakultas-alrt").show();
    //     isValid = false;
    // }
    // if($("#select-prodi").val() == "") {
    //     $("#prodi-alrt").show();
    //     isValid = false;
    // }
    return isValid;
}

function addMhs() {
    var res = validasiAddStaff();
    if(res == false) {
        return false;
    }
    var Data = {
        //users
        "u_username": $("#u_username").val(),
        "u_password": $("#u_password").val(),
        //mhs_detail
        "mhs_fks_id": parseInt($("#select-fakultas").val()),
        "mhs_ps_id": parseInt($("#select-prodi").val()),
        "mhs_fullname": $("#mhs_fullname").val(),
        "mhs_nim": $("#mhs_nim").val(),
        "mhs_kelas": $("#mhs_kelas").val(),
        "mhs_address": $("#mhs_address").val(),
        "mhs_province": $("#mhs_province").val(),
        "mhs_city": $("#mhs_city").val(),
        "mhs_birthplace": $("#mhs_birthplace").val(),
        "mhs_birthdate": $("#mhs_birthdate").val(),
        "mhs_gender": $("#select-gender").val(),
        "mhs_religion": $("#mhs_religion").val(),
        "mhs_state": $("#mhs_state").val(),
        "mhs_email": $("#mhs_email").val(),
        "mhs_stat": parseInt($("#select-status").val()),
        "mhs_contact": $("#mhs_contact").val()
    };
    $.ajax({
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        type: "POST",
        url: "/Mahasiswa/AddMhs/Create",
        data: JSON.stringify(Data),
        success: function (data) {
            if(data.code === 1) {
                pesanAlert(data);
                MhsDataTable()
                setTimeout(() => {
                    ShowTable();
                }, 1000);
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

var edit = {};

function clickMhsEdit(obj) {
    $("#active-link").text('Edit Mahasiswa');
    $("#active-title").text('Edit Mahasiswa');
    $("#password-field").hide();
    $("#btn-create-mhs").hide();
    $("#btn-edit-mhs").show();
    let obj_id = {
        "mhs_id": 0,
        "mhs_u_id": parseInt(obj.attributes.data_id.value)
    };
    $.ajax({
        type: "GET",
        url: "/Mahasiswa/GetMhsById/" + obj_id.mhs_u_id,
        contentType: "application/json",
        dataType: "json",
        data: obj_id.mhs_u_id,
        success: function (data) {
            if(data.code === 0 || data.code === -1) {
                pesanAlert(data);
            }
            else {
                obj_id.mhs_id = data.mhs_id;
                $("#u_username").val(data.u_username);
                $("#select-fakultas").val(''+data.mhs_fks_id);
                ProdiComboBox();
                $("#select-prodi").val(''+data.mhs_ps_id);
                $("#mhs_fullname").val(data.mhs_fullname);
                $("#mhs_nim").val(data.mhs_nim);
                $("#mhs_kelas").val(data.mhs_kelas);
                $("#mhs_address").val(data.mhs_address);
                $("#mhs_province").val(data.mhs_province);
                $("#mhs_city").val(data.mhs_city);
                $("#mhs_birthplace").val(data.mhs_birthplace);
                $("#mhs_birthdate").val(data.mhs_birthdate);
                $("#mhs_gender").val(data.mhs_gender);
                $("#mhs_religion").val(data.mhs_religion);
                $("#mhs_state").val(data.mhs_state);
                $("#mhs_email").val(data.mhs_email);
                $("#mhs_stat").val(''+data.mhs_stat);
                $("#mhs_contact").val(data.mhs_contact);
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

function UpdateMhs() {
    if($("#u_username").val().trim() == "") {
        $("#username-alrt").show();
        return false;
    }
    var Data = {
        "mhs_id": edit.mhs_id,
        "mhs_u_id": edit.mhs_u_id,
        "u_username": $("#u_username").val(),
        "mhs_fks_id": parseInt($("#select-fakultas").val()),
        "mhs_ps_id": parseInt($("#select-prodi").val()),
        "mhs_fullname": $("#mhs_fullname").val(),
        "mhs_nim": $("#mhs_nim").val(),
        "mhs_kelas": $("#mhs_kelas").val(),
        "mhs_address": $("#mhs_address").val(),
        "mhs_province": $("#mhs_province").val(),
        "mhs_city": $("#mhs_city").val(),
        "mhs_birthplace": $("#mhs_birthplace").val(),
        "mhs_birthdate": $("#mhs_birthdate").val(),
        "mhs_gender": $("#select-gender").val(),
        "mhs_religion": $("#mhs_religion").val(),
        "mhs_state": $("#mhs_state").val(),
        "mhs_email": $("#mhs_email").val(),
        "mhs_stat": parseInt($("#select-status").val()),
        "mhs_contact": $("#mhs_contact").val()
    };
    $.ajax({
        type: "PUT",
        url: "/Mahasiswa/UpdateMhs/Edit",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(Data),
        success: function (data) {
            if(data.code === 1) {
                pesanAlert(data);
                MhsDataTable();
                setTimeout(() => { ShowTable(); }, 1000);
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

function clickMhsDelete(obj) {
    let obj_id = {"mhs_u_id": parseInt(obj.attributes.data_id.value)};
    var konfirmasi = confirm("Yakin ingin Delete Mahasiswa?");
    if(konfirmasi) {
        $.ajax({
            type: "DELETE",
            url: "/Mahasiswa/DeleteMhs",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(obj_id),
            success: function (data) {
                if(data.code === 1) {
                    pesanAlert(data);
                    setTimeout(() => { MhsDataTable(); }, 2000);
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