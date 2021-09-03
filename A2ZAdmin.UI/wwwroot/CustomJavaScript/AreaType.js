$(document).ready(function () {
    GetDetail();
});

function BeginRequest() {
    $("#divContent").addClass("loading");
}

function GetDetail() {
    $("#divContent").addClass("loading");

    $.get("/AreaTypeMaster/GetDetail",
        function (data) {
            $("#divData").html(data);
            $("#divContent").removeClass("loading");
        });

}

function Create() {
    $.get("/AreaTypeMaster/Create",
        function (data) {
            debugger;
            $("#headerText").text("Area Type Master Create");
            $("#divCreate").html(data);
            $("#myModal").modal('show');
        });
}

function Success(response) {
    alertify.set('notifier', 'position', 'top-center');
    alertify.success("Created Successfully !!!");
    $("#myModal").modal('hide');

    GetDetail();
    $("#form")[0].Reset();
    $("#divContent").removeClass("loading");
}

function Delete(id) {
    $("#divContent").addClass("loading");
    alertify.confirm("Are you sure want to delete the record ?", function () {
        $.get("/AreaTypeMaster/Delete",
            { id: id },
            function (data) {
                alertify.success(data);
                GetDetail();
                $("#divContent").removeClass("loading");
            });
    });
}
function Edit(id) {
    $("#divContent").addClass("loading");
    $.get("/AreaTypeMaster/Create", { id: id },
        function (data) {
            $("#headerText").text("Area Type Master Update");
            $("#divCreate").html(data);
            $("#myModal").modal('show');
            $("#divContent").removeClass("loading");
        });
}