$(document).ready(function () {
    SiteDataTable();
});

function SiteDataTable() {
    var table = $('#tblSite');
    $('#spinner').show();
    $.ajax({
        type: "GET",
        url: "/Site/GetSiteList",
        contentType: "application/json",
        dataType: "json",
        data: null,
        success: function (obj) {
            var rowHTML = '';
            let status = '';
            for (let i = 0; i < obj[0].nomor.length; i++) {
                if (obj[4].status[i] == 1) {
                    status = '<td class="tb-content status-user"><a class="btn btn-sm btn-success" title="User '+obj[2].fullname[i]+' berstatus Aktif"><b>Aktif</b></a></td>';
                } else {
                    status = '<td class="tb-content status-user"><a class="btn btn-sm btn-danger" title="User '+obj[2].fullname[i]+' berstatus Tidak Aktif"><b>Tidak Aktif</b></a></td>';
                }
                rowHTML = '<tr>' +
                '<td class="tb-content">' + obj[1].username[i] + '</td>' +
                '<td class="tb-content">' + obj[2].fullname[i] + '</td>' +
                '<td class="tb-content">' + obj[3].nik[i] + '</td>' +
                status +
                '<td class="tb-content"><a data-toggle="tooltip" data-html="true" title="Edit Data" id=\'btnedit' + i + '\' class="btn" data_id=\'' + obj[0].nomor[i] + '\'><i class="fa fa-edit" style="color: blue;"></i></a><a data-toggle="tooltip" data-html="true" title="Delete Data" id=\'btndelete' + i + '\' class="btn" data_id=\'' + obj[0].nomor[i] + '\'><i class="fa fa-remove" style="color: red;"></i></a></td>' +
                '</tr>';

                $(table).append(rowHTML);

                $('#btnedit' + i).click(function (event) {
                    clickStaffEdit(this);
                });

                $('#btndelete' + i).click(function (event) {
                    clickStaffDelete(this);
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