
var xhttp = new XMLHttpRequest();
xhttp.open('GET', 'WebsiteCommunity.Repository\Core\BaseRepository.cs\GetConnectionString', true);
xhttp.onload = function () {
    var myData = JSON.parse(xhttp.responseText);
    console.log(myData);
}

xhttp.send();