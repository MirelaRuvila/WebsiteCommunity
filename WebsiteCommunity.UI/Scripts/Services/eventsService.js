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

    this.ReadById = function (id) {
        for (var index = 0; index < _events.length; index++) {
            if (id == _events[index].eventId) {
                return _events[index];
            }
        }
        return null;
    }
}