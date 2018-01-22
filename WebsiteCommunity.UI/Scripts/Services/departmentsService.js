var DepartmentsService = function () {
    var _departments = $.ajax({
        type: 'GET',
        url: 'http://localhost:60364/api/departments',
        //contentType: 'application/xml ; charset=utf-8',
        dataType: 'xml',
        success: function (data) {
            $.each(data, function (i, item) {
                var rows = "<tr>" +
                    "<td id='departmentId'>" + item.DepartmentId + "</td>" +
                    "<td id='departmentName'>" + item.DepartmentName + "</td>" +
                    "<td id='description'>" + item.Description + "</td>" +
                    "</tr>";
                $('#Table').append(rows);
            }); //End of foreach Loop   
            console.log(data);
        }, //End of AJAX Success function  

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function  
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function  

    });

    //var promise = $.ajax({
    //    url: '/api/departments'
    //});
    //promise.done(successFunction);
    //promise.error(errorFunction);
    //promise.always(alwaysFunction);

    this.ReadAll = function () {
        return _departments;
    }

    this.ReadById = function (id) {
        for (var index = 0; index < _departments.length; index++) {
            if (id == _departments[index].id){
                return _departments[index];
            }
        }
        return null;
    }

    // = [{
    //    "id": 1,
    //    "name": "Leadership",
    //    "description": "HTML este o formă de marcare orientată către prezentarea documentelor text pe o singura pagină, utilizând un software de redare specializat, numit agent utilizator HTML, cel mai bun exemplu de astfel de software fiind browserul web.",
    //    "picture": "https://mdbootstrap.com/img/Photos/Horizontal/Nature/4-col/img%20%282%29.jpg"
    //},
    //{
    //    "id": 2,
    //    "name": "Kids",
    //    "description": "50 kids",
    //    "picture": "Assets/kids.jpg"
    //}
    //    ,
    //{
    //    "id": 3,
    //    "name": "Social",
    //    "description": "help people",
    //    "picture": "Assets/social.jpg"
    //}
    //    ,
    //{
    //    "id": 4,
    //    "name": "Choir",
    //    "description": "sing sing sing",
    //    "picture": "Assets/choir.jpg"
    //}
    //    ,
    //{
    //    "id": 5,
    //    "name": "Media",
    //    "descriprion": "music and sounds",
    //    "picture": "Assets/media.jpg"
    //}
    //];

}