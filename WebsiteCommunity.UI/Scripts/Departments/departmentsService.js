var DepartmentsService = function () {
    var _departments = [{
        "id": 1,
        "name": "Leadership",
        "description": " "
    },
    {
        "id": 2,
        "name": "Kids",
        "description": "50 kids"
    }
        ,
    {
        "id": 3,
        "name": "Social",
        "description": "help people"
    }
    ];

    this.ReadAll = function () {
        return _departments;
    }

    this.Insert = function (department) {
        _department.Add(department);
    }
}