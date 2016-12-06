var currBtn = "none";
function getAskTheProInfo(asktheproID, sMGuid, sUseThisURL) {
    try {
        var returnHTML = $.ajax({
            url: "getAskThePro",
            type: "POST",
            async: false,
            dataType: "json",
            data: { asktheproID: asktheproID, sMGuid: sMGuid, sUseThisURL: sUseThisURL }
        }).responseText;
        return returnHTML;
    }
    catch (err) {
        alert("Error: " + err.Description + ", please try again!");
    }
}
$('.lnkAskThePros').click(function () {
    var asktheproID = $(this).attr('id');
    var currImg = "noimage";
    var returnHTML = "";
    if (currBtn !== "none") {
        currImg = $("#" + currBtn).css("background-image");
    }
    if (currBtn !== asktheproID) {
        $("#" + currBtn).css("background-image", "url(" + clientCSS + "/Images/" + currBtn + ".jpg)");
        currBtn = asktheproID;
        $("#" + currBtn).css("background-image", "url(" + clientCSS + "/Images/" + currBtn + "_Selected.jpg)");
        returnHTML = getAskTheProInfo(asktheproID, sMGuid, sUseThisURL);
        $("#asktheproForms").empty();
        $("#asktheproForms").html(returnHTML);
        $("#asktheproForms").show();
    } else {
        if (currImg.indexOf("/" + currBtn + ".jpg") > -1) {
            $("#" + currBtn).css("background-image", "url(" + clientCSS + "/Images/" + currBtn + "_Selected.jpg)");
            returnHTML = getAskTheProInfo(asktheproID, sMGuid, sUseThisURL);
            $("#asktheproForms").empty();
            $("#asktheproForms").html(returnHTML);
            $("#asktheproForms").show();
        } else {
            $("#" + currBtn).css("background-image", "url(" + clientCSS + "/Images/" + currBtn + ".jpg)");
            returnHTML = "";
            $("#asktheproForms").empty();
        }
        currBtn = asktheproID;
    }
});
$('.intArticlePrint').click(function (event) {
    var printID = $(this).attr('id');
    //alert("printID = " + printID);

    return false;
});
$('.intArticleExpand').click(function (event) {
    var expandID = $(this).attr('id');
    //alert("expandID = " + expandID);

    return false;
});
