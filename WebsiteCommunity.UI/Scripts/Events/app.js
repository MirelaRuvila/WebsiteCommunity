$(document).ready(function () {
    var eventsService = new EventsService();

    var eventsController = new EventsController();
    eventsController.PopulateList(eventsService.ReadAll());
});