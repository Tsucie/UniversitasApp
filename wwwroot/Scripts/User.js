$(document).ready(function () {
    UserdataTable();
    // addPage();
    // addFksPage();
    // addStaffPage();
    // $("#btn-create-mhs").click(function() {
    //     addMhs(this);
    // });
});

function UserdataTable() {
    var table = $("#tblUser");

    $("#spinner").show();
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
        error: function (data) {
            alert("ErrorConnection!");
        },
        complete: function () {
            $("#spinner").hide();
        }
    });
};

// function addPage() {
//     var comboBox = $("#select-category");

//     $.ajax({
//         type: "GET",
//         url: "/User/GetCategoryList",
//         contentType: "application/json",
//         dataType: "json",
//         data: null,
//         success: function (data) {
//             $(comboBox).children('select').empty();
//             var opsi = '';
//             for (let i = 0; i < data[0].nilai.length; i++) {
//                 opsi = '<option value="'+data[0].nilai[i]+'" title="'+data[2].judul[i]+'">'+data[1].tampil[i]+'</option>';
//                 $(comboBox).append(opsi);
//             }
//         },
//         error: function (data) {
//             pesanAlert(data);
//         }
//     });
// }

// function addFksPage() {
//     var comboBox = $("#select-fakultas");

//     $.ajax({
//         type: "GET",
//         url: "/User/GetFakultasList",
//         contentType: "application/json",
//         dataType: "json",
//         data: null,
//         success: function (data) {
//             $(comboBox).children('select').empty();
//             var opsi = '';
//             for (let i = 0; i < data[0].nilai.length; i++) {
//                 opsi = '<option value="'+data[0].nilai[i]+'" title="'+data[2].judul[i]+'">'+data[1].tampil[i]+'</option>';
//                 $(comboBox).append(opsi);
//             }
//         },
//         error: function (data) {
//             pesanAlert(data);
//         }
//     });
// }

// function addMhs() {
//     var Data = {
//         //users
//         "u_username": $("#u_username").val(),
//         "u_password": $("#u_password").val(),
//         "u_ut_id": parseInt($("#select-category").val()),
//         //mhs_detail
//         "mhs_fks_id": parseInt($("#select-fakultas").val()),
//         "mhs_fullname": $("#mhs_fullname").val(),
//         "mhs_nim": $("#mhs_nim").val(),
//         "mhs_kelas": $("#mhs_kelas").val(),
//         "mhs_address": $("#mhs_address").val(),
//         "mhs_province": $("#mhs_province").val(),
//         "mhs_city": $("#mhs_city").val(),
//         "mhs_birthplace": $("#mhs_birthplace").val(),
//         "mhs_birthdate": $("#mhs_birthdate").val(),
//         "mhs_gender": $("#select-gender").val(),
//         "mhs_religion": $("#mhs_religion").val(),
//         "mhs_state": $("#mhs_state").val(),
//         "mhs_email": $("#mhs_email").val(),
//         "mhs_stat": parseInt($("#select-status").val()),
//         "mhs_contact": $("#mhs_contact").val()
//     };
//     $.ajax({
//         headers: {
//             'Accept': 'application/json',
//             'Content-Type': 'application/json'
//         },
//         type: "POST",
//         url: "/User/AddMhs/Create",
//         data: JSON.stringify(Data),
//         success: function (data) {
//             window.location.href = "../User";
//             setTimeout(pesanAlert(data), 5000);
//         },
//         error: function (data) {
//             pesanAlert(data);
//         }
//     });
// }