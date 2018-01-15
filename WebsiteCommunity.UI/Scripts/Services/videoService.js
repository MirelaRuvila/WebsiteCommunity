var VideoService = function () {
    var _video = [{
        "id": 1,
        "name": "Archive",
        "description": " "
    },
    {
        "id": 2,
        "name": "Live",
        "description": "50 kids"
    }
    ];

    this.ReadAll = function () {
        return _video;
    }

    this.Insert = function (video) {
        _video.Add(video);
    }
    this.ReadById = function (id) {
        for (var index = 0; index < _video.length; index++) {
            if (id == _video[index].id) {
                return _video[index];
            }
        }
        return null;
    }
}