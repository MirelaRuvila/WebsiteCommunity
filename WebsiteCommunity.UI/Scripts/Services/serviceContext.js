var ServiceContext = function () {
    var _departmentService;
    var _eventService;
    var _photoGalleryService;
    var _videoService;

    this.DepartmentsService = function () {
        if (!_departmentService) {
            _departmentService = new DepartmentsService();
        }
        return _departmentService;
    }

    this.EventsService = function () {
        if (!_eventService) {
            _eventService = new EventsService();
        }
        return _eventService;
    }

    this.PhotoGalleryService = function () {
        if (!_photoGalleryService) {
            _photoGalleryService = new PhotoGalleryService();
        }
        return _photoGalleryService;
    }

    this.VideoService = function () {
        if (!_videoService) {
            _videoService = new VideoService();
        }
        return _videoService;
    }
}