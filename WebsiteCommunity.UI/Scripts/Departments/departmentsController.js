var DepartmentsController = function () {
    this.PopulateList = function (departments) {
        var jqDepartmentsUL = $("#departmentsList"); //jquery
        for (var i = 0; i < departments.length; i++) {
            jqDepartmentsUL.append("<li class='myILClass' id='" + departments[i].id + "'>" + departments[i].name + "'>" + departments[i].description + "</li>");
        }
        $("#divDepartmentsContainer").append(jqDepartmentsUL);
        lowLetter();
    }

    function lowLetter() {

    }
}