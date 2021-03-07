$(document).ready(function () {
    $("#btn-login").click(function () {
        Validate(this);
    });
    $(".validate-form").on('keypress', function (e) {
        if (e.which === 13) {
            Validate(this);
        }
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
    // $('#btn-login').hide();
    // $('#loading-animated').show();
    $.ajax({
        type: "POST",
        url: '/Account/Validate',
        data: Data,
        success: function (result) {
            switch (result.code) {
                case 1:
                    setTimeout(() => window.location.href = '/Home/Index', 2000);
                    notif({msg: "<b>" + result.message + "</b>", type: "success", position: "right"});
                    break;
                case 0:
                    notif({msg: "<b>" + result.message + "</b>", type: "warning", position: "right"});
                    break;
                case -1:
                    notif({msg: "<b>" + result.message + "</b>", type: "warning", position: "right"});
                    break;
            
                default:
                    break;
            }
        },
        error: function () {
            notif({msg: "<b>" + "Connection Error!" + "</b>", type: "error", position: "right"});
        }
        // complete: function () {
        //     $('#btn-login').show();
        //     $('#loading-animated').hide();
        // }
    });
}