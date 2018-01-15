var PhotoGalleryService = function () {
    var _photoGallery = [{
        "id": 1,
        "name": ""
    },
    {
        "id": 2,
        "name": ""
    }
    ];

    this.ReadAll = function () {
        return _photoGallery;
    }

    this.Insert = function (photoGallery) {
        _photoGallery.Add(photoGallery);
    }

    this.ReadById = function (id) {
        for (var index = 0; index < _photoGallery.length; index++) {
            if (id == _photoGallery[index].id) {
                return _photoGallery[index];
            }
        }
        return null;
    }
}