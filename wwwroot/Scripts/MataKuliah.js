var actionTitle; // Title for Modals

$(document).ready(function () {
    $("#active-link").text('Mata Kuliah');
    MatkulDataTable();
    $("#btn-add-matkul").click(function() {
        AddMatkul(this);
    });
    $("#btn-edit-matkul").click(function() {
        UpdateMatkul();
    });
    $("#Add-btn").click(function() {
        ShowAddModals(this);
    });
});

function MatkulDataTable() {
    
}

// Modals for Add Data
function ShowAddModals() {
    actionTitle = 'Add Mata Kuliah';
    ClearInputs();
    $("#AddEditModal").on('show.bs.modal', function (event) {
        var modal = $(this);
        modal.find('.modal-title').text(actionTitle);
        $("#btn-add-matkul").show();
        $("#btn-edit-matkul").hide();
    });
}

// Modals for Edit Data
function ShowEditModals() {
    actionTitle = 'Edit Mata Kuliah';
    $("#AddEditModal").on('show.bs.modal', function (event) {
        var modal = $(this);
        modal.find('.modal-title').text(actionTitle);
        $("#btn-edit-matkul").show();
        $("#btn-add-matkul").hide();
    });
}

function ClearInputs() {
    $('#mk_code').val('');
    $('#mk_name').val('');
    $('#mk_desc').val('');
    $('#mk_sks').val('');
    $('#mk_mutu').val('');
}