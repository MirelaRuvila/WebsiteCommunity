var DepartmentDetailsController = function (department) {

    this.RenderDetailsCard = function () {
        var jqDetails = $("<div id='divDetailsCard'>")
            .append("<h4 > " + department.name + "</h4 >")
            .append("<p>" + department.description + "</p>");

        $("#divDepartmentContainer").append(jqDetails);
    }
}
