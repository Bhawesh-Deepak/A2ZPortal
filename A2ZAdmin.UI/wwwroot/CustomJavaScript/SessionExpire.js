var notificationInterval,
    logoutInterval,
    logoutCounterSpan;

function startNotificationCounter() {
    var counter = 20;
    notificationInterval = setInterval(function () {
        counter--;
        if (counter === 20) {
            alertify.confirm("Your session is going to expire, You will automatically signed out, To continue your session Please select stay signed in.", function () {
                $.get("",
                    null,
                    function (data) {
                        resetCounters();
                        $("#SessionExpireNotification").data("kendoWindow").center().close();
                    }
                );
            }, function () {
                $("#logoutForm").submit();
            });
            startLogoutCounter();
        }
    },
        60000);
}

function startLogoutCounter() {
    var counter = 20 * 60;
    logoutInterval = setInterval(function () {
        counter--;
        if (counter < 0) {
            $("#logoutForm").submit();
        } else {
            var m = Math.floor(counter / 60);
            var s = Math.floor(counter % 60);
            var mDisplay = m < 10 ? "0" + m : m;
            var sDisplay = s < 10 ? "0" + s : s;
            logoutCounterSpan.text(mDisplay + ":" + sDisplay);
        }
    },
        1000);
}

function resetCounters() {
    clearInterval(notificationInterval);
    clearInterval(logoutInterval);
    logoutCounterSpan.text("20:00");
    startNotificationCounter();
}

function onSessionExpireNotificationClose() {
    resetCounters();
}

$(function () {
    startNotificationCounter();
});