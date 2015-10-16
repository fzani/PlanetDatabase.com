/// <reference path="../_references.js" />

//After pages load is completed... Call function PageLoad
$(document).ready(PageLoad);


function PageLoad() {
    /// <summary>Load Function. This strat after the page load is completed</summary>
    getPlanets();
};

var getPlanets = function () {
    /// <summary>Api call, this load data from planets to page</summary>
    $.ajax({
        url: '/api/Planets',
        type: "get",
        dataType: "json",
        success: function (data, textStatus, jqXHR) {
            // since we are using jQuery, you don't need to parse response
            drawTable(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.dir(jqXHR);
                console.dir(textStatus);
                console.dir(errorThrown);
            alert("Error in API request. Please verify ConnectionStrings paths in Web.Config");
        }
    });
};

var drawTable = function(data) {
    /// <summary>Write the html with planets</summary>
    var _message = data.length > 0 ? "loading..." : "Error...";
    $("#planetsDataTable").append("<div id='load'>"+ _message +"</div>");

    for (var i = 0; i < data.length; i++) {
        drawRow(data[i]);
    }
    if (data.length > 0) {
        $("#planetsDataTable").show();
        $("#load").html("");
    }
    
};

var drawRow = function(rowData) {
    /// <summary>Description</summary>
    var row = $("<tr />");

    //this will append tr element to table...
    $("#planetsDataTable").append(row);

    //draw rows
    row.append($("<td>" + rowData.Name + "</td>"));
    row.append($("<td>" + rowData.AwayOfStar + "</td>"));
};
