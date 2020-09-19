// const obj = {
//     code: 1,
//     pesan: "Welcome!"
// };

function pesanAlert(obj) {
    let color = "";
    let msg = "";
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
            color = "error";
            msg = "Internal Server Error!";
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

// pesanAlert(obj);