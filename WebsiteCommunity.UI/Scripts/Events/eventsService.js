var EventsService = function () {
    var _events = [{
        "eventId": 1,
        "eventName": "Christmas Carol",
        "description": " "
    },
    {
        "eventId": 2,
        "eventName": "Celebration",
        "description": ""
    }
    ];

    this.ReadAll = function () {
        return _events;
    }

    this.Insert = function (event1) {
        _events.Add(event1);
    }
}