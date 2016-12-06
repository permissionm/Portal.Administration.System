function getCurrTrack(LangId, MembrId) {
    //alert("getCurrTrack");
    try {
        var returnCTHTML = $.ajax({
            url: "getCurrentTrack",
            type: "POST",
            async: false,
            dataType: "json",
            data: { LangId: LangId, MembrId: MembrId }//, //int LangId, int MembrId
        }).responseText;

        $("#ulCurrTrack").empty();
        $("#ulCurrTrack").html(returnCTHTML);

        return "Done";
        //return returnHTML;
    }
    catch (err) {
        alert("Error: " + err.Description + ", please try again!");
    }
}
function getAvailTrack(LangId, MembrId) {
    //alert("getAvailTrack");
    try {
        var returnATHTML = $.ajax({
            url: "getAvailableTrack",
            type: "POST",
            async: false,
            dataType: "json",
            data: { LangId: LangId, MembrId: MembrId }
        }).responseText;

        $("#ulAvailTrack").empty();
        $("#ulAvailTrack").html(returnATHTML);

        return "Done";
    }
    catch (err) {
        alert("Error: " + err.Description + ", please try again!");
    }
}
function getCurTrackInfo(OptionId, checkDate) {
    //alert("getCurTrackInfo");
    try {
        var returnTIHTML = $.ajax({
            url: "getTrackInfo",
            type: "POST",
            async: false,
            dataType: "json",
            data: { OptionId: OptionId, checkDate: checkDate }
        }).responseText;

        $("#trackBody").empty();
        $("#trackBody").html(returnTIHTML);

        return "Done";
    }
    catch (err) {
        alert("Error: " + err.Description + ", please try again!");
    }
}
function getCurTrackTips(OptionId) {
    //alert("getCurTrackTips");
    try {
        var returnTTHTML = $.ajax({
            url: "getTrackTips",
            type: "POST",
            async: false,
            dataType: "json",
            data: { OptionId: OptionId }
        }).responseText;

        $("#ulTips").empty();
        $("#ulTips").html(returnTTHTML);

        return "Done";
    }
    catch (err) {
        alert("Error: " + err.Description + ", please try again!");
    }
}
function drawGraph(optID, period, grphHead) {
    $.ajax({
        url: "getChartData",
        type: "POST",
        data: { optionID: optID, period: period, graphHeader: grphHead },
        dataType: "text json",
        success: function (result) {
            buildGraph(result);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("XMLHttpRequest=" + XMLHttpRequest.responseText + "\ntextStatus=" + textStatus + "\nerrorThrown=" + errorThrown);
        }
    });

    function buildGraph(grphData) {
        //alert("buildGraph");
        if (FusionCharts("welltrackGraph")) FusionCharts("welltrackGraph").dispose();
        $("#welltrackGraphWrap").empty();
        $("#welltrackGraphWrap").insertFusionCharts({
            swfUrl: "../Scripts/Charts/MSLine.swf",
            width: "615",
            height: "350",
            id: "welltrackGraph",
            dataFormat: "json",
            dataSource: grphData
        });
    }

    var mDesc = "";
    var buildSelBox = "<div id=\"graphPeriodText\">Choose tracking period</div>";
    buildSelBox += "<select id=\"selGraphPeriod\">";
    for (var mCount = 1; mCount <= 6; mCount++) {
        if (mCount == 1 || mCount == 3 || mCount == 6) {
            if (mCount < 2) {
                mDesc = mCount + " Month";
            } else {
                mDesc = mCount + " Months";
            }
            if (mCount != period) {
                buildSelBox += "<option value=\"" + mCount + "\" onclick=\"javascript:selectedPeriod(this.value);\">" + mDesc + "</option>";
            } else {
                buildSelBox += "<option value=\"" + mCount + "\" onclick=\"javascript:selectedPeriod(this.value);\" selected>" + mDesc + "</option>";
            }
        }
    }
    buildSelBox += "</select>";

    $("#graphPeriodWrap").empty();
    $("#graphPeriodWrap").append(buildSelBox);
}
function selectedPeriod(selVal) {
    //alert(selVal);

    var retDrawGraph = drawGraph(oid, selVal, strGraphHead);
}
var oid, checkDate;
var curTrack = getCurrTrack(langID, membrID);
var availTrack = getAvailTrack(langID, membrID);
var strGraphHead = "";
//$(".ctRadio").click(function () {
$(".ctRadio").live("click", function () {
    oid = this.id;
    checkDate = $(this).attr("chkDate");
    var gHead = $(this).parent().find("label").text();
    strGraphHead = "View your " + gHead.replace(" (kg)", "") + " behaviours or indicate over time";

    var trackInf = getCurTrackInfo(oid, checkDate);

    var retDrawGraph = drawGraph(oid, 1, strGraphHead);

    var trackTips = getCurTrackTips(oid);

    //alert("membrID = " + membrID);
});
function saveTrackValues(iOptVal, iOptTargetVal) {
    //alert("membrID = " + membrID + ", langID = " + langID + ", oid = " + oid + ", iOptVal = " + iOptVal + ", iOptTargetVal = " + iOptTargetVal);
    try {
        var returnSTVHTML = $.ajax({
            url: "saveTrackInfo",
            type: "POST",
            async: false,
            dataType: "json",
            data: { MemberId: membrID, OptionId: oid, OptionValue: iOptVal, OptionTargetValue: iOptTargetVal }
            //success: function (result) {
            //    //alert("result = " + result);

            //    var curTrack = getCurrTrack(langID, membrID);
            //    var availTrack = getAvailTrack(langID, membrID);

            //    getCurTrackInfo(oid, 99);

            //    $('#' + oid).prop('checked', true);

            //    return (result);
            //}
        }).responseText;

        var curTrack = getCurrTrack(langID, membrID);
        var availTrack = getAvailTrack(langID, membrID);

        //getCurTrackInfo(oid, 99);

        var trackInf = getCurTrackInfo(oid, 99);

        var retDrawGraph = drawGraph(oid, 1, strGraphHead);

        var trackTips = getCurTrackTips(oid);

        $('#' + oid).prop('checked', true);

        return returnSTVHTML;
    }
    catch (err) {
        alert("Error: " + err.Description + ", please try again!");
    }
}
function checkTrackValues() {
    var iOptVal = parseInt($("#inptOptValue").val());
    var iOptTargetVal = parseInt($("#inptOptTargetValue").val());
    var saveNow = true;
    var minCtrlValNum = parseInt("30");
    var maxCtrlValNum = parseInt("200");
    //alert("membrID = " + membrID + ", langID = " + langID + ", oid = " + oid + ", iOptVal = " + iOptVal + ", iOptTargetVal = " + iOptTargetVal);

    if (isNaN(iOptVal)) {
        //alert("Do not save valOptVal");
        $("#errOptValue").removeClass("hideErrMsg").addClass("showErrMsg");
        saveNow = false;
    } else {
        $("#errOptValue").removeClass("showErrMsg").addClass("hideErrMsg");
    }
    if (isNaN(iOptTargetVal)) {
        //alert("Do not save valOptTargetVal");
        $("#errOptTargetValue").removeClass("hideErrMsg").addClass("showErrMsg");
        saveNow = false;
    } else {
        $("#errOptTargetValue").removeClass("showErrMsg").addClass("hideErrMsg");
    }
    if (saveNow == true) {
        //alert("Save now");
        var savedTVals = saveTrackValues(iOptVal, iOptTargetVal);
    }
}
$("a.fancyPOPCalc").fancybox({
    'prevEffect': 'none',
    'nextEffect': 'none',
    'autoScale': false,
    'transitionIn': 'none',
    'transitionOut': 'none',
    'width': 440,
    'height': 460,
    'type': 'iframe'
});
