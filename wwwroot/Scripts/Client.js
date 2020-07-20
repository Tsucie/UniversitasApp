var actionTitle; // Title for Modals

$(document).ready(function () {
    ClientDataTable();
    $("#btn-add-client").click(function() {
        addStfClient(this);
    });
    $("#btn-edit-client").click(function() {
        UpdateClient();
    });
    $("#Add-btn").click(function() {
        ShowAddModals(this);
    });
});