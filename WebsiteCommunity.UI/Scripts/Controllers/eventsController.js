var EventsController = function () {
    this.PopulateList = function (events) {
        var jqEventsUL = $("#eventsList"); //jquery
        for (var i = 0; i < events.length; i++) {
            jqEventsUL.append("<li class='myILClass' id='" + events[i].eventId + "'>" + events[i].eventName + "'>" + events[i].description + "</li>");
        }
        $("#divEventsContainer").append(jqDepartmentsUL);
        lowLetter();
    }

    function lowLetter() {

    }
}