var VideoController = function () {
    this.PopulateList = function (video) {
        var jqVideoUL = $("#videoList"); //jquery
        for (var i = 0; i < video.length; i++) {
            jqVideoUL.append("<li class='myILClass' id='" + video[i].id + "'>" + video[i].name + "'>" + video[i].description + "</li>");
        }
        $("#divVideoContainer").append(jqVideoUL);
        lowLetter();
    }

    function lowLetter() {

    }
}