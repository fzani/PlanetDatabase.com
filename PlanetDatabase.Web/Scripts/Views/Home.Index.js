$(document).ready(PageLoad);


function PageLoad() {
    getPlanets();
    //alert(123);
};

var getPlanets = function() {
    $.ajax({
        url: '/api/Planets',
        type: "get",
        dataType: "json",
        success: function (data, textStatus, jqXHR) {
            // since we are using jQuery, you don't need to parse response
            drawTable(data);
        }
    });
};

var drawTable = function(data) {
    $("#planetsDataTable").append("<div id='load'>loading...</div>");

    for (var i = 0; i < data.length; i++) {
        drawRow(data[i]);
    }
    $("#planetsDataTable").show();
    $("#load").html("");
};

var drawRow = function(rowData) {
    var row = $("<tr />");
    //this will append tr element to table...
    $("#planetsDataTable").append(row);
    //row.append($("<td>" + rowData.Id + "</td>"));
    row.append($("<td>" + rowData.Name + "</td>"));
    row.append($("<td>" + rowData.AwayOfStar + "</td>"));
};
