$(document).ready(function () {
    FakultasDataTable();
    $("#Add-Fks-btn").click(function () {
        ShowModal(this, "Add Fakultas", "#btn-add-fks");
    });
    $("#Add-Prodi-btn").click(function () {
        ShowModal(this, "Add Program Studi", "#btn-add-prodi");
    });
    $("#btn-add-fks").click(function () {
        AddFakultas(this);
    });
    $("#btn-edit-fks").click(function() {
        UpdateFakultas(this);
    });
    $("#btn-add-prodi").click(function () {
        AddProdi(this);
    });
    $("#btn-edit-prodi").click(function () {
        UpdateProdi(this);
    });
});

function ModalInit() {
    $('#name').val('');
    $('#desc').val('');
    $('#btn-add-fks').hide();
    $('#btn-edit-fks').hide();
    $('#btn-add-prodi').hide();
    $('#btn-edit-prodi').hide();
}

function ShowModal(type, title, button) {
    let item_type = type.attributes.data_item.value;
    if(item_type == "Program Studi") {
        let comboBox = $('#select-fks');
        $('#fks-combo').show();
        if(comboBox.val() == null) {
            FakultasComboBox(comboBox);
        }
    } else{
        $('#fks-combo').hide();
    }
    ModalInit();
    $(button).show();
    $('#AddEditModal').on('show.bs.modal', function () {
        var modal = $(this); //this (event) merujuk pada $('#AddEditModal') html element beserta childnya
        modal.find('.modal-title').text(title);
        modal.find('#name-lbl').text(item_type);
        modal.find('#desc-lbl').text("Deskripsi " + item_type);
    });
}

function FakultasComboBox(comboBox) {
    $.ajax({
        type: "GET",
        url: "/Fakultas/GetList",
        contentType: "application/json",
        dataType: "json",
        data: null,
        success: function (data) {
            if(data.code === 0 || data.code === -1) {
                pesanAlert(data);
                $('#AddEditModal').modal('hide');
            }
            else {
                $(comboBox)
                var opsi = '';
                for (let i = 0; i < data[0].nomor.length; i++) {
                    opsi = '<option value="'+data[0].nomor[i]+'" title="'+data[2].deskripsi[i]+'">'+data[1].fakultas[i]+'</option>';
                    $(comboBox).append(opsi);
                }
            }
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        }
    });
}

function FakultasDataTable() {
    var table = $("#tblFks");
    $("#tbl-loading").show();
    $.ajax({
        type: "GET",
        url: "/Fakultas/GetList",
        contentType: "application/json",
        dataType: "json",
        data: null,
        success: function (data) {
            $(table).children('tbody').empty();
            var rowHTML = '';
                for (let i = 0; i < data[0].nomor.length; i++) {
                    let number = i+1;
                    rowHTML ='<tr>' +
                      '<td class="tb-content status-user col-md-1">' + number + '</td>' +
                      '<td class="tb-content">' + data[1].fakultas[i] + '</td>' +
                      '<td class="tb-content">' + data[2].deskripsi[i] + '</td>' +
                      '<td class="tb-content">'+
                        '<a data-toggle="tooltip" data-html="true" title="Lihat Program Studi" id=\'btnget' + i + '\' class="btn" data_id=\'' + data[0].nomor[i] + '\'><i class="fa fa-book" style="color: green;"></i></a>'+
                        '<a data-toggle="tooltip" data-html="true" title="Edit Data" id=\'btnedit' + i + '\' class="btn" data_id=\'' + data[0].nomor[i] + '\' data_item="Fakultas"><i class="fa fa-edit" style="color: blue;"></i></a>'+
                        '<a data-toggle="tooltip" data-html="true" title="Delete Data" id=\'btndelete' + i + '\' class="btn" data_id=\'' + data[0].nomor[i] + '\'><i class="fa fa-remove" style="color: red;"></i></a>'+
                      '</td>' +
                    '</tr>';

                    $(table).append(rowHTML);

                    $('#btnget' + i).click(function () {
                        clickActionGet(this);
                    });

                    $('#btnedit' + i).click(function () {
                        clickActionEdit(this);
                    });

                    $('#btndelete' + i).click(function () {
                        clickActionDelete(this);
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

function AddFakultas() {
    var Data = {
        "fks_name": $('#name').val(),
        "fks_desc": $('#desc').val()
    };
    $.ajax({
        type: "POST",
        url: "/Fakultas/Create",
        headers: {
            accept: "application/json",
            'Content-Type': "application/json"
        },
        dataType: "json",
        data: JSON.stringify(Data),
        success: function (data) {
            if(data.code === 1) {
                pesanAlert(data);
                FakultasDataTable();
            }
            else {
                pesanAlert(data);
            }
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        },
        complete: function () {
            $('#btn-add-fks').hide();
            $('#AddEditModal').modal('hide');
        }
    });
}

var edit = {"id": 0};

function clickActionEdit(obj) {
    var obj_id = {"fks_id": parseInt(obj.attributes.data_id.value)};
    ShowModal(obj, "Edit Fakultas", "#btn-edit-fks");
    $.ajax({
        type: "GET",
        url: "/Fakultas/GetFksById/" + obj_id.fks_id,
        contentType: "application/json",
        dataType: "json",
        data: obj_id.fks_id,
        success: function (data) {
            if(data.code === 0 || data.code === -1) {
                pesanAlert(data);
            }
            else {
                edit.id = data.fks_id;
                $('#name').val(data.fks_name);
                $('#desc').val(data.fks_desc);
                $('#AddEditModal').modal('show');
            }
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        }
    });
}

function UpdateFakultas() {
    var Data = {
        "fks_id": edit.id,
        "fks_name": $('#name').val(),
        "fks_desc": $('#desc').val()
    };
    console.log(Data);
    $.ajax({
        type: "PUT",
        url: "/Fakultas/Update",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(Data),
        success: function (data) {
            if(data.code === 1) {
                pesanAlert(data);
                FakultasDataTable();
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
            $('#name').val('');
            $('#desc').val('');
            $('#btn-edit-fks').hide();
        }
    });
}

function clickActionDelete(obj) {
    let obj_id = {"fks_id": parseInt(obj.attributes.data_id.value)};
    let konfirmasi = confirm("Yakin ingin delete Fakultas?");
    if(konfirmasi) {
        $.ajax({
            type: "DELETE",
            url: "/Fakultas/Delete",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(obj_id),
            success: function (data) {
                if(data.code === 1 || data.code === -1) {
                    pesanAlert(data);
                    FakultasDataTable();
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

function clickActionGet(obj) {
    let obj_id = {
        "ps_fks_id": parseInt(obj.attributes.data_id.value)
    };
    ProdiDataTable(obj_id);
}

function ProdiDataTable(obj_id) {
    var table = $("#tblProdi");
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
                $(table).children('tbody').empty();
                var rowData = '';
                for(let i = 0; i < data[0].nomor.length; i++) {
                    let number = i+1;
                    rowData = '<tr>'+
                      '<td class="tb-content status-user col-md-1">' + number + '</td>' +
                      '<td class="tb-content">' + data[2].prodi[i] + '</td>' +
                      '<td class="tb-content">' + data[3].deskripsi[i] + '</td>' +
                      '<td class="tb-content">'+
                        '<a data-toggle="tooltip" data-html="true" title="Edit Data" id=\'btnEditProdi' + i + '\' class="btn" dataId=\'' + data[0].nomor[i] + '\' dataParentId=\'' + data[1].fksnomor[i] + '\' data_item="Program Studi"><i class="fa fa-edit" style="color: blue;"></i></a>'+
                        '<a data-toggle="tooltip" data-html="true" title="Delete Data" id=\'btnDeleteProdi' + i + '\' class="btn" dataId=\'' + data[0].nomor[i] + '\' dataParentId=\'' + data[1].fksnomor[i] + '\'><i class="fa fa-remove" style="color: red;"></i></a>'+
                      '</td>' +
                    '</tr>';

                    $(table).append(rowData);

                    $('#btnEditProdi' + i).click(function () {
                        prodiEdit(this);
                    });

                    $('#btnDeleteProdi' + i).click(function () {
                        prodiDelete(this);
                    });
                }
            }
            $(table).DataTable();
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        }
    });
}

function AddProdi() {
    var Data = {
        "ps_fks_id": parseInt($('#select-fks').val()),
        "ps_name": $('#name').val(),
        "ps_desc": $('#desc').val()
    };
    $.ajax({
        type: "POST",
        url: "/Fakultas/Prodi/Create",
        headers: {
            accept: "application/json",
            'Content-Type': "application/json"
        },
        dataType: "json",
        data: JSON.stringify(Data),
        success: function (data) {
            pesanAlert(data);
            ProdiDataTable(Data);
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        },
        complete: function () {
            $('#btn-add-prodi').hide();
            $('#AddEditModal').modal('hide');
        }
    });
}

function prodiEdit(obj) {
    let obj_id = {
        "ps_id": parseInt(obj.attributes.dataId.value),
        "ps_fks_id": parseInt(obj.attributes.dataParentId.value)
    };
    ShowModal(obj, "Edit Program Studi", "#btn-edit-prodi");
    $.ajax({
        type: "GET",
        url: "/Fakultas/GetProdiById/" + obj_id.ps_id,
        contentType: "application/json",
        dataType: "json",
        data: obj_id.ps_id,
        success: function (data) {
            if(data.code === 0 || data.code === -1) {
                pesanAlert(data);
            }
            else {
                edit.id = data.ps_id;
                $('#select-fks').val(data.ps_fks_id);
                $('#name').val(data.ps_name);
                $('#desc').val(data.ps_desc);
                $('#AddEditModal').modal('show');
            }
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        }
    });
}

function UpdateProdi() {
    var Data = {
        "ps_id": edit.id,
        "ps_fks_id": parseInt($('#select-fks').val()),
        "ps_name": $('#name').val(),
        "ps_desc": $('#desc').val()
    };
    console.log(Data);
    $.ajax({
        type: "PUT",
        url: "/Fakultas/Prodi/Update",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(Data),
        success: function (data) {
            pesanAlert(data);
            ProdiDataTable(Data);
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        },
        complete: function () {
            $('#AddEditModal').modal('hide');
            $('#name').val('');
            $('#desc').val('');
            $('#btn-edit-prodi').hide();
        }
    });
}

function prodiDelete(obj) {
    let obj_id = {
        "ps_id": parseInt(obj.attributes.dataId.value),
        "ps_fks_id": parseInt(obj.attributes.dataParentId.value)
    };
    var konfirmasi = confirm("Yakin ingin delete Program Studi?");
    if(konfirmasi) {
        $.ajax({
            type: "DELETE",
            url: "/Fakultas/Prodi/Delete",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify(obj_id),
            success: function (data) {
                pesanAlert(data);
                ProdiDataTable(obj_id);
            },
            error: function () {
                notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
            }
        });
    }
}