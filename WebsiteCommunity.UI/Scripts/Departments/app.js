$(document).ready(function () {
    var departmentsService = new DepartmentsService();

    var departmentsController = new DepartmentsController();
    departmentsController.PopulateList(departmentsService.ReadAll());
});