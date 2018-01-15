var DepartmentsService = function () {
    var _departments = [{
        "id": 1,
        "name": "Leadership",
        "description": "HTML este o formă de marcare orientată către prezentarea documentelor text pe o singura pagină, utilizând un software de redare specializat, numit agent utilizator HTML, cel mai bun exemplu de astfel de software fiind browserul web.",
        "picture": "https://mdbootstrap.com/img/Photos/Horizontal/Nature/4-col/img%20%282%29.jpg"
    },
    {
        "id": 2,
        "name": "Kids",
        "description": "50 kids",
        "picture": "Assets/kids.jpg"
    }
        ,
    {
        "id": 3,
        "name": "Social",
        "description": "help people",
        "picture": "Assets/social.jpg"
    }
        ,
    {
        "id": 4,
        "name": "Choir",
        "description": "sing sing sing",
        "picture": "Assets/choir.jpg"
    }
        ,
    {
        "id": 5,
        "name": "Media",
        "descriprion": "music and sounds",
        "picture": "Assets/media.jpg"
    }
    ];

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
}