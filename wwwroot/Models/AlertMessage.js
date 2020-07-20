AlertMessage = (function () {
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

    return AlertMessage;
})();