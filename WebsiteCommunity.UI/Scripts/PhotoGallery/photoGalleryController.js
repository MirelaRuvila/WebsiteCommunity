var PhotoGalleryController = function () {
    this.PopulateList = function (photoGallery) {
        var jqPhotoGalleryUL = $("#photoGalleryList"); //jquery
        for (var i = 0; i < photoGallery.length; i++) {
            jqPhotoGalleryUL.append("<li class='myILClass' id='" + photoGallery[i].id + "'>" + photoGallery[i].name + "</li>");
        }
        $("#divPhotoGalleryContainer").append(jqPhotoGalleryUL);
        lowLetter();
    }

    function lowLetter() {

    }
}