$(document).ready(function () {
    GetDetail();
});

function BeginRequest() {
    $("#divContent").addClass("loading");
}

function GetDetail() {
    $("#divContent").addClass("loading");
    debugger;
    $.get("/PropertyDetail/GetPropertyDetail",
        function (data) {
            $("#divData").html(data);
            $("#divContent").removeClass("loading");
        });

}

function Create() {
    $.get("/PropertyDetail/Create",
        function (data) {
            $("#headerText").text("Property Detail Create");
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
        $.get("/PropertyDetail/Delete",
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
    $.get("/PropertyDetail/Create", { id: id },
        function (data) {
            $("#headerText").text("Property Detail Update");
            $("#divCreate").html(data);
            $("#myModal").modal('show');
            $("#divContent").removeClass("loading");
        });
}