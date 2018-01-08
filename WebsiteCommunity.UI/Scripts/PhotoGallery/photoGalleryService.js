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
}