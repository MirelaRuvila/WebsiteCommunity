var DepartmentsController = function (serviceContext) {

    this.RenderPage = function () {
        var allDepartments = serviceContext.DepartmentsService().ReadAll();
        for (var i = 0; i < allDepartments.length; i++) {
            var departmentCardController = new DepartmentCardController("divDepartmentsCards", allDepartments[i]);
            departmentCardController.RenderCard();
            var selectedDepartment = serviceContext.DepartmentsService().ReadById(allDepartments[i]);
        }
    }
}