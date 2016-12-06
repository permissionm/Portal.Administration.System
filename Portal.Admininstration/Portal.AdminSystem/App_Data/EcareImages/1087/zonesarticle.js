var avArray = new Array();
$(".claimPointsLink").live("click", function () {
    var contentID = $(this).attr("artclid");
    if (contentID != "000") {
        try {
            var returnTTHTML = $.ajax({
                url: "claimWelPoints",
                type: "POST",
                async: false,
                dataType: "json",
                data: { contentID: contentID, challengeID: 8 }
            }).responseText;

            if (returnTTHTML == '"Points claimed successfully"') {
                alert("Thank you. You have earned 1 wellness point.");
            } else {
                alert(returnTTHTML);
            }
            var ptsAvail = claimsAvail(contentID, 8);
            if (ptsAvail != "true") {
                $(this).removeClass("claimPointsLink").addClass("claimPointsLinkClaimed");
                $(this).attr("onmouseover", "tooltip.show('You have already earned the maximum number of points for this activity');");
            }

            return false;
        }
        catch (err) {
            alert("Error: " + err.Description + ", please try again!");
        }
    }
});
$("#librUL").treeview({
    animated: "slow",
    collapsed: true,
    unique: true
});
function checkRadio(rdName) {
    var rdObject = document.getElementsByName(rdName);
    var checked = "false";
    var rdObjLast = "";
    var rdObjChecked = "";

    for (var i = 0; i < rdObject.length; i++) {
        if (rdObject[i].checked) {
            checked = "true";
            rdObjChecked = rdObject[i].id;
        }
        rdObjLast = rdObject[i].id;
    }
    checked = checked + "," + rdObjLast;

    //return checked;
    return rdObjChecked;
}
function avgRatingArray(strAvArray) {
    //document.write("strAvArray: " + strAvArray);
    var aAvReturn = strAvArray.split("\",\"");

    for (var aAv in aAvReturn) {
        avArray[aAv] = aAvReturn[aAv].replace("[\"", "").replace("\"]", "");

        var bAvReturn = avArray[aAv].split(",");
        avArray[aAv] = new Array();
        for (var bAv in bAvReturn) {
            avArray[aAv][bAv] = bAvReturn[bAv];
        }
        //document.write("[" + aAv + "] [0]&[1] " + avArray[aAv][0] + " - " + avArray[aAv][1] + "<br/>");
    }
    //return aAv;
}
function avgRatingSucceeded() {
    try {
        //alert("avArray: " + avArray[0][1]);
        $('#' + avArray[0][1]).prop('checked', true);
        $("input[name='" + avArray[0][0] + "']").each(function (i) { jQuery(this).attr('disabled', 'disabled'); });
        $('#' + avArray[1][1]).prop('checked', true);
        $("input[name='" + avArray[1][0] + "']").each(function (i) { jQuery(this).attr('disabled', 'disabled'); });
        $('#' + avArray[2][1]).prop('checked', true);
        $("input[name='" + avArray[2][0] + "']").each(function (i) { jQuery(this).attr('disabled', 'disabled'); });

        $(".sliderRateHeart").removeClass("sliderRateHeart").addClass("sliderRateHeartRated");
        $(".sliderRateHeartRated").attr("onmouseover", "tooltip.show('You have already earned the maximum number of points for this activity');");
    }
    catch (err) {
        //alert("An error occured.");
        //window.location = "404.html";
    }
}
function getAverageRating(aveContentID) {
    try {
        $.ajax({
            url: "getAverageRating",
            type: "POST",
            async: false,
            dataType: "json",
            data: { contentID: aveContentID },
            success: function (result) {
                //alert("result: " + result);
                avgRatingArray(result);
                avgRatingSucceeded();
            }
        });
    }
    catch (err) {
        //alert("Error: " + err.Description + ", please try again!");
        //window.location = "error.html";
    }
}
function saveRatingValues(membrID, contentID, savelookupdata) {
    try {
        var transHTML = $.ajax({
            url: "saveContentRatingVals",
            type: "POST",
            async: false,
            dataType: "json",
            data: { memberID: membrID, contentID: contentID, savestring: savelookupdata.toString() }
        }).responseText;

        return transHTML;
    }
    catch (err) {
        //alert("Error: " + err.Description + ", please try again!");
        //window.location = "error.html";
    }
}
$(".ratingBtn").live("click", function () {
    var selRelID = checkRadio("210");
    var selRelVal = $("#" + selRelID).attr("value");
    var selMotID = checkRadio("211");
    var selMotVal = $("#" + selMotID).attr("value");
    var selHelpID = checkRadio("212");
    var selHelpVal = $("#" + selHelpID).attr("value");
    var thisID = $(".slider_content").attr("id");
    var contentID = thisID.replace("slider_", "");

    //alert("selRelID: " + selRelID + ", selMotID: " + selMotID + ", selHelpID: " + selHelpID);

    var savelookupdata = new Array();
    var toSave = false;
    var strIsEmpty = "empty";

    if (selRelID != "") {
        savelookupdata.push("210:" + selRelID + ":" + selRelVal);
        toSave = true;

        if (strIsEmpty != "") {
            strIsEmpty = "";
        }
    }
    if (selMotID != "") {
        savelookupdata.push("211: " + selMotID + ":" + selMotVal);
        toSave = true;

        if (strIsEmpty != "") {
            strIsEmpty = "";
        }
    }
    if (selHelpID != "") {
        savelookupdata.push("212: " + selHelpID + ":" + selHelpVal);
        toSave = true;

        if (strIsEmpty != "") {
            strIsEmpty = "";
        }
    }
    if (strIsEmpty != "empty") {
        if (toSave != false) {
            var sucLookup = saveRatingValues(membrID, contentID, savelookupdata);

            if (sucLookup.toLowerCase().indexOf("successfully")) {
                //var strMsgPopup = '<div id="msgPopup">';
                //strMsgPopup = '<div id="msgPopup-body">';
                //strMsgPopup = '<div id="msgPopup-head"><h4>Thank you for rating this article</h4></div>';
                //strMsgPopup = '<div id="msgPopup-message"><p>You have earned 1 wellness point.</p></div>';
                //strMsgPopup = '<div id="msgPopup-button"><a id="msgPopup-close" class="msgPopupClose">Close</a></div>';
                //strMsgPopup = '<div class="clrBoth">&nbsp;</div>';
                //strMsgPopup = '</div>';
                //strMsgPopup = '<div class="clrBoth">&nbsp;</div>';
                //strMsgPopup = '</div>';

                //document.write(strMsgPopup);
                getAverageRating(contentID);

                alert("Thank you for rating this article. You have earned 1 wellness point.");
            } else {
                alert("There was a problem rating this article. Please try again.");
            }

            var rtsAvail = rateAvail(contentID);
            if (rtsAvail != "true") {
                $(this).removeClass("ratingBtn").addClass("ratingAveText").html("Rating averages");
                //"<a class=\"ratingBtn\"></a>"
                //"<a class=\"ratingAveText\">Rating averages</a>"
                //$(this).attr("onmouseover", "tooltip.show('You have already earned the maximum number of points for this activity');");
            }
        }
    } else {
        alert("None of the ratings was selected.");
    }
    //var strMsgPopup = '<div id="msgPopup">';
    //strMsgPopup = '<div id="msgPopup-body">';
    //strMsgPopup = '<div id="msgPopup-head"><h4>Thank you for rating this article</h4></div>';
    //strMsgPopup = '<div id="msgPopup-message"><p>You have earned 1 wellness point.</p></div>';
    //strMsgPopup = '<div id="msgPopup-button"><a id="msgPopup-close" class="msgPopupClose">Close</a></div>';
    //strMsgPopup = '<div class="clrBoth">&nbsp;</div>';
    //strMsgPopup = '</div>';
    //strMsgPopup = '<div class="clrBoth">&nbsp;</div>';
    //strMsgPopup = '</div>';

    //document.write(strMsgPopup);

    return false;
});
buildSldrKit(ContEntID, tabHead, clientID, ssPath, contID, useThisURL);
