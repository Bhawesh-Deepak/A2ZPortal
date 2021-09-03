$(document).ready(function () {
    GetDetail();
});

function BeginRequest() {
    $("#divContent").addClass("loading");
}

function GetDetail() {
    $("#divContent").addClass("loading");

    $.get("/FurnishedStatusMaster/GetDetail",
        function (data) {
            $("#divData").html(data);
            $("#divContent").removeClass("loading");
        });

}

function Create() {
    $.get("/FurnishedStatusMaster/Create",
        function (data) {
            debugger;
            $("#headerText").text("Furnished Status Create");
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
        $.get("/FurnishedStatusMaster/Delete",
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
    $.get("/FurnishedStatusMaster/Create", { id: id },
        function (data) {
            $("#headerText").text("Furnished Status   Update");
            $("#divCreate").html(data);
            $("#myModal").modal('show');
            $("#divContent").removeClass("loading");
        });
}