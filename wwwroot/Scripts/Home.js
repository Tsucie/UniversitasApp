$(document).ready(function () {
    getUsers();
});

function getUsers() {
    let users = $('#total-user');
    let rektor = $('#rektor');
    let staff = $('#staff');
    let mhs = $('#mahasiswa');

    $.ajax({
        type: "GET",
        url: "/User/GetUser",
        contentType: "application/json",
        dataType: "json",
        data: null,
        success: function (data) {
            if (data.code !== 1) {
                pesanAlert(data);
            }
            else {
                users.text(data.pesan.total_users);
                rektor.text(data.pesan.total_rektor);
                staff.text(data.pesan.total_staff);
                mhs.text(data.pesan.total_mhs);
            }
        },
        error: function () {
            notif({msg: "<b>Connection Error!</b>", type: "error", position: "center"});
        }
    });
}