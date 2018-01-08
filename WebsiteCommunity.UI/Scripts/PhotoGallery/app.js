$(document).ready(function () {
    var photoGalleryService = new PhotoGalleryService();

    var photoGalleryController = new PhotoGalleryController();
    photoGalleryController.PopulateList(photoGalleryService.ReadAll());
});