$(document).ready(function () {
    /*GetDetail();*/
    Create();
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
    $("#divContent").addClass('loading');
    $.get("/PropertyDetail/RentResidential",
        function (data) {
            $("#divData").html(data);
            AddActiveClass('#btnRentResidential');
            $("#lblRentSellProperty").html("Rent Residential Property")
            $("#divContent").removeClass('loading');
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

function RentResidential(eval) {
    $("#divContent").addClass('loading');
    $.get("/PropertyDetail/RentResidential",
        function (data) {
            $("#divData").html(data);
            ClearElementClass();
            AddActiveClass(eval)
            $("#lblRentSellProperty").html("Rent Residential Property");           
            $("#divContent").removeClass('loading');
        });
}
function SellResidential(eval) {
    $("#divContent").addClass('loading');
    $.get("/PropertyDetail/SellResidential",
        function (data) {
            $("#divData").html(data);
            ClearElementClass();
            AddActiveClass(eval)
            $("#lblRentSellProperty").html("Sell Residential Property")
            $("#divContent").removeClass('loading');
        });
}
function RentCommercial(eval) {
    $("#divContent").addClass('loading');
    $.get("/PropertyDetail/RentCommercial",
        function (data) {
            $("#divData").html(data);
            ClearElementClass();
            AddActiveClass(eval)
            $("#lblRentSellProperty").html("Rent Commercial Property")
            $("#divContent").removeClass('loading');
        });
  
}
function SellCommercial(eval) {
    $("#divContent").addClass('loading');
    $.get("/PropertyDetail/SellCommercial",
        function (data) {
            $("#divData").html(data);
            ClearElementClass();
            AddActiveClass(eval)
            $("#lblRentSellProperty").html("Sell Commercial Property")
            $("#divContent").removeClass('loading');
        });
}
function ClearElementClass() {
    $("#btnRentResidential").removeClass().addClass('btn btn-primary');
    $("#btnSellResidential").removeClass().addClass('btn btn-primary');
    $("#btnRentCommercial").removeClass().addClass('btn btn-primary');
    $("#btnSellCommercial").removeClass().addClass('btn btn-primary');
}
function AddActiveClass(btn) {
    debugger;
    $(btn).addClass("btn btn-success");
}