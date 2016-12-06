$('.searchList').click(function () {
    $(this).parent().parent().find(".lnkSelected").removeClass("lnkSelected");
    //var thisImg = $(this).attr('id');
    var thisImg = $(this).attr('imgToUse');
    var imgName = sCSS + "/MedCond/" + thisImg;
    $(this).addClass("lnkSelected");
    $("#bodyImg").attr('src', imgName);
    $("#medCondBtm").empty();

    return false;
});
function pageScroll() {
    window.scrollBy(0, 300); // horizontal and vertical scroll increments
    //scrolldelay = setTimeout( 'pageScroll()', 100 ); // scrolls every 100 milliseconds
}
$('.searchList').click(function () {
    var thisContEntID = $(this).attr("entToUse");

    var bodyContentList = $.ajax({
        url: "BodyIndexContent",
        type: "POST",
        async: false,
        dataType: "json",
        data: { ContentEntID: thisContEntID }
    }).responseText;

    $("#medCondBtm").html(bodyContentList);
    //pageScroll();
});
$(window).load(function () {
    $(".btnplus").live("click", function () {
        var thisPName = $(this).attr("name");
        var divPName = "#medCondDiv" + thisPName;
        if ($(divPName).is(":hidden")) {
            $(this).parent().parent().find(".btnplus").removeClass("btnplus_select").addClass("btnplus_notselect");
            $(this).parent().parent().find(".btnminus").removeClass("btnminus_select").addClass("btnminus_notselect");

            $(this).parent().find(".btnplus").removeClass("btnplus_notselect").addClass("btnplus_select");
            $(this).parent().find(".btnminus").removeClass("btnminus_notselect").addClass("btnminus_select");

            $(this).parent().parent().find(".medCondDiv").slideUp("slow");
            $(divPName).slideDown("slow");
        } else {
            ////Do nothing
        }
        return false;
    });
    $(".btnminus").live("click", function () {
        var thisMName = $(this).attr("name");
        var divMName = "#medCondDiv" + thisMName;
        if ($(divMName).is(":hidden")) {
            ////Do nothing
            //$(this).parent().parent().find(".medCondDiv").slideUp("slow");
        } else {
            $(this).parent().find(".btnplus").removeClass("btnplus_select").addClass("btnplus_notselect");
            $(this).parent().find(".btnminus").removeClass("btnminus_select").addClass("btnminus_notselect");

            $(divMName).slideUp("slow");
        }
        return false;
    });
});
