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
    debugger;
    alertify.set('notifier', 'position', 'top-center');
    alertify.success(response);
    $("#myModal").modal('hide');

    // GetDetail();
    //$("#form")[0].Reset();
    $("#divContent").removeClass("loading");
}

function Delete(id) {
    $("#divContent").addClass("loading");
    alertify.confirm("Are you sure want to delete the record ?", function () {
        $.get("/PropertyDetail/Delete",
            { id: id },
            function (data) {
                alertify.success(data);
                GetDetails();
                $("#divContent").removeClass("loading");
            });
    });
}

function Edit(id, category, propertyType) {
    debugger;
    $("#divContent").addClass("loading");
    if (category === "Residential" && propertyType === "Rent") {
        BindEditData('#btnRentResidential', 'Rent Residential Property', id, "/PropertyDetail/RentResidential");
    }

    if (category === "Residential" && propertyType === "Sell") {
        BindEditData('#btnSellResidential', 'Sell Residential Property', id, "/PropertyDetail/SellResidential");
    }
    if (category === "Commercial" && propertyType === "Rent") {
        BindEditData('#btnRentCommercial', 'Rent Commercial Property', id, "/PropertyDetail/RentCommercial");
    }
    if (category === "Commercial" && propertyType === "Sell") {
        BindEditData('#btnSellCommercial', 'Sell Commercial Property', id, "/PropertyDetail/SellCommercial");
    }
}

function BindEditData(btn,textData,id,url) {
    $.get(url, { id: id },
        function (data) {
            AddActiveClass(btn);
            $("#divData").html(data);
            $("#lblRentSellProperty").html(textData)
            $("#divContent").removeClass('loading');
            $("#myModal").modal('hide');
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
    ClearElementClass();
    $(btn).addClass("btn btn-success");
}

function CommonAlertModal() {
    alertify.confirm("Are you sure want to  leave this page, Unsaved data from the page will be lost.", function () {
        return true;
    }, function () {
        return false;
    })
}

function SuccessProperty(response) {
    if (response > 0) {
        alertify.success("Created successfully !!!");
        $.get("/PropertyDetail/GetPropertyImageDetails", { propertyId: response }, function (data) {
            $("#headerText").text("Property Image Allocation");
            $("#divCreate").html(data);
            $('#myModal').modal({ backdrop: 'static' });
        })
    }
}
function SuccessImage(response) {
    alertify.success(response);
    location.reload();
}

function GetDetails() {
    $.get("/PropertyDetail/GetPropertyList", function (data) {
        $("#headerText").text("Property Details");
        $("#divCreate").html(data);
        $(".modal-dialog").removeClass().addClass("modal-dialog modal-lg")
        $('#myModal').modal();
    })
}

function GetPropInfor(id) {
    $.get("/PropertyDetail/GetPropertyCompleteDetails", {id:id}, function (data) {
        $("#divData").html(data);
        $("#myModal").modal('hide');
    })
}