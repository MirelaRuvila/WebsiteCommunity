////var jqPathDB = $('<p> src = "C:\Users\Ligia\source\repos\WebsiteCommunity\WebsiteCommunity.Repository\Core\BaseRepository.cs"');
////var xhttp = new XMLHttpRequest();
////xhttp.open('GET', 'api/departments', true);
////xhttp.onload = function () {
////    var myData = JSON.parse(xhttp.responseText);
////    console.log(myData);
////}

////xhttp.send();

//$(document).ready(function () {
//    $.ajax({
//        type: 'GET',
//        url: 'http://localhost:60364/api/departments',
//        contentType: 'application/json; charset=utf-8',
//        dataType: 'json',
//        success: function (data) {
//            $.each(data, function (i, item) {
//                var rows = "<tr>" +
//                    "<td id='departmentId'>" + item.DepartmentId + "</td>" +
//                    "<td id='Name'>" + item.DepartmentName + "</td>" +
//                    "<td id='Address'>" + item.Description + "</td>" +
//                    "</tr>";
//                $('#Table').append(rows);
//            }); //End of foreach Loop   
//            console.log(data);
//        }, //End of AJAX Success function  

//        failure: function (data) {
//            alert(data.responseText);
//        }, //End of AJAX failure function  
//        error: function (data) {
//            alert(data.responseText);
//        } //End of AJAX error function  

//    })
//});