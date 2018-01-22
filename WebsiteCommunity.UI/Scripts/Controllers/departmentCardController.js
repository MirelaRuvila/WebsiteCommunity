var DepartmentCardController = function (containerId, department) {

    this.RenderCard = function () {

        var departmentDetailsController = new DepartmentDetailsController(department);
        //var dep = depDetailsController.RenderDetailsCard();
        var jqCard = $("<div class='col-sm-6 col-md-4 col-lg-3 mt-4'>")
            .append("<div id='" + department.DepartmentId + "'class='card'>")
            //.append("<img class='img-fluid' src='" + department.picture + "' alt='Card image cap'>")
            .append("<img class='img-fluid' src='https://mdbootstrap.com/img/Photos/Horizontal/Nature/4-col/img%20%282%29.jpg' alt='Card image cap'>")
            .append("<div class='card-block'  style='background-color:lightgrey'>")
            .append("<a href ='#' onclick='" + departmentDetailsController.RenderDetailsCard() + "' '<h4 class='card-title'>" + department.DepartmentName + "</h4>");

        $("#" + containerId).append(jqCard);
    }
    //this.RenderCard = function () {
    //    var jqCard = $("<div class='col-sm-6 col-md-4 col-lg-3 mt-4'>")
    //        .append("<div id='" + department.id + "'class='card'>")
    //        .append("<img class='img-fluid' src='https://mdbootstrap.com/img/Photos/Horizontal/Nature/4-col/img%20%282%29.jpg' alt='Card image cap'>")
    //        .append("<div class='card-block'  style='background-color:lightgrey'>")
    //        .append("<h4 class='card-title'>" + department.name + "</h4>")
    //        .append("<p class='card-text'>" + department.description + "</p>")
    //        .append("<a href='#' class='btn btn-primary'>View Details</a>");

    //    $("#" + containerId).append(jqCard);
    //}
}