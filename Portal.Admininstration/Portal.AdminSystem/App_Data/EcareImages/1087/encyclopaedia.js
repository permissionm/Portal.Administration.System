function getEncycResults(keywords) {
    try {
        var returnHTML = $.ajax({
            url: "EncyclopaediaList",
            type: "POST",
            async: false,
            dataType: "json",
            data: { keywords: keywords },
            success: function (result) {
                //alert("result = " + result);
                $("#encycloResultBody").empty();
                $("#encycloResultBody").html(result);
            }
        }).responseText;
        return returnHTML;
    }
    catch (err) {
        alert("Error: " + err.Description + ", please try again!");
    }
}
$(".alfabetical").click(function () {
    var strKeyword = $(this).attr("keyword");

    var trackTips = getEncycResults(strKeyword);
    //alert("strKeyword = " + strKeyword);

    $("footer").css("clear", "both");
});
$("#btnKeywords").click(function () {
    var strKeyword = $("#inpKeywords").val();

    var trackTips = getEncycResults(strKeyword);
    //alert("strKeyword = " + strKeyword);

    $("footer").css("clear", "both");
});
