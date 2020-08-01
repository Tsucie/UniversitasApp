$(document).ready(function () {
    $("#btn-login").click(function () {
        Validate(this);
    });
});

function Validate() {
    if($('#username').val().trim() == "" || $('#password').val().trim() == "") {
      notif({msg: "<b>" + "Username & Password is required!" + "</b>", type: "warning", position: "right"});
      return false;
    }
    var Data = {
        "username": $('#username').val(),
        "password": $('#password').val()
    }
    $.ajax({
        type: "POST",
        url: '/Account/Validate',
        data: Data,
        success: function (result) {
            if((result.code === -1) || (result.code === 0)) {
            notif({msg: "<b>" + "Gagal Login! Username atau Password salah!" + "</b>", type: "warning", position: "right"});
            }
            else
            {
            if (result.status === true) {
                setTimeout(() => window.location.href = '/Home/Index', 3000);
                notif({msg: "<b>" + result.message + "</b>", type: "success", position: "right"});
            }
            else {
                notif({msg: "<b>" + result.message + "</b>", type: "warning", position: "right"});
            }
            }
        },
        error: function () {
            notif({msg: "<b>" + "Connection Error!" + "</b>", type: "error", position: "right"});
        }
    });
}