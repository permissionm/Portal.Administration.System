//function shareAvail(contentid, challengeid) {
//    try {
//        var transHTML = $.ajax({
//            url: "ClaimAvailable",
//            type: "POST",
//            async: false,
//            dataType: "json",
//            data: { contentid: contentid, challengeid: challengeid }
//        }).responseText;
//        return transHTML;
//    }
//    catch (err) {
//        //alert("Error: " + err.Description + ", please try again!");
//    }
//}
//function autoWelnessPoints(cntntID, chlngID) {
//    try {
//        var clmWellHTML = $.ajax({
//            url: "claimWelPoints",
//            type: "POST",
//            async: false,
//            dataType: "json",
//            data: { contentID: cntntID, challengeID: chlngID }
//        }).responseText;
//        //alert("clmWellHTML=" + clmWellHTML);
//        return clmWellHTML;
//    }
//    catch (err) {
//        //alert("Error: " + err.Description + ", please try again!");
//        //window.location = "error.html";
//    }
//}
$('.compLinks').click(function (event) {
    var showID = "#" + $(this).attr("id") + "Wrap";
    var detailDiv = "#" + $(this).attr("id") + "DatailWrap";
    var thisCompid = $(this).attr("compid");

    if ($(showID).is(":visible")) {
        $(showID).hide("slow");

        if (thisCompid != "0") {
            //$("div.slider_content").remove();
            $(detailDiv).children().remove();
        }
    } else {
        $(".compCategoryWrap").hide("slow");

        if (thisCompid != "0") {
            $(detailDiv).children().remove();

            //alert("detailDiv: " + detailDiv);
            buildContent(thisCompid, detailDiv);
        }

        $(showID).show("slow");
    }

    return false;
});
