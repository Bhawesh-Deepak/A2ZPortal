$(document).ready(function () {
    GetDetail();
});

function BeginRequest() {
    $("#divContent").addClass("loading");
}

function GetDetail() {
    $("#divContent").addClass("loading");

    $.get("/AmenitiesMaster/GetDetail",
        function (data) {
            $("#divData").html(data);
            $("#divContent").removeClass("loading");
        });

}

function Create() {
    $.get("/AmenitiesMaster/Create",
        function (data) {
            debugger;
            $("#headerText").text("Amenities  Create");
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
        $.get("/AmenitiesMaster/Delete",
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
    $.get("/AmenitiesMaster/Create", { id: id },
        function (data) {
            $("#headerText").text("Amenities  Update");
            $("#divCreate").html(data);
            $("#myModal").modal('show');
            $("#divContent").removeClass("loading");
        });
}