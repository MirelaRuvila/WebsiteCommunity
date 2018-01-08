$(document).ready(function () {
    var videoService = new VideoService();

    var videoController = new VideoController();
    videoController.PopulateList(videoService.ReadAll());
});