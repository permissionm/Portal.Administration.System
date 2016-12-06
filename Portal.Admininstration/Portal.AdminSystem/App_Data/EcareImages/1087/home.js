$(".photoslider-bullets").sliderkit({
    circular: true,
    mousewheel: false,
    shownavitems: 3,
    autospeed: 8000,
    auto: true
});
$(".photoslider-adverts").sliderkit({
    autospeed: 8000,
    circular: true
});
$(".slideshow-ltstArticle").sliderkit({
    autospeed: 8000,
    circular: true,
    shownavitems: 10
});
$(".askProf").fancybox({
    'prevEffect': 'none',
    'nextEffect': 'none',
    'autoScale': false,
    'transitionIn': 'none',
    'transitionOut': 'none',
    'width': 400,
    'height': 430,
    'type': 'iframe'
});
if (showWelcome != 'no') {
    $.fancybox(
    '<div id="pupdivwelcome" class="popup_block"><div id="welcomeintro"><p>' + welcomeMsg + '</p><div class="clrBoth">&nbsp;</div></div></div>',
    {
        'prevEffect': 'none',
        'nextEffect': 'none',
        'autoSize': false,
        'transitionIn': 'none',
        'transitionOut': 'none',
        'width': 460,
        'height': 350
    });
}

// Get the sliderkit object data
var myGallery = $(".photoslider-bullets").data("sliderkit");

// Reset previous animations (internal method)
var clearAnimation = function () {
    myGallery._clearCallBacks(myGallery.panelAnteFns);
    myGallery._clearCallBacks(myGallery.panelPostFns);
};

//	External pagination
//	----------------------
var myPaginTag = $("#myPagination1");

// Selecting first item
var myPaginItems = $('li', myPaginTag);
myPaginItems.eq(myGallery.options.start).addClass('selected');

// Pagination items click event
$('a', myPaginTag).click(function () {
    var $a = $(this);
    if (!$a.parent().hasClass('selected')) {
        myGallery.changeWithId($a.attr('rel'));
    }
    return false;
});

// Selecting current pagination item
myGallery.options.panelfxbefore = function () {
    myPaginItems.removeClass('selected');
    myPaginItems.eq(myGallery.currId).addClass('selected');
};

var liWidth = 0;

$('#myPagination1 ul li').each(function () {
    liWidth += $(this).outerWidth();
});
//alert("liWidth = " + liWidth);
var totLiWidth = (liWidth + 3);
$('#myPagination1 ul').width(totLiWidth + "px");

function popup2(consMsg1, thisWidth, status) {
    $("#dialog-box2").width(thisWidth);

    // get the screen height and width  
    var maskHeight = $(document).height();
    var maskWidth = $(window).width();

    // calculate the values for center alignment
    var dialogTop = (maskHeight / 4) - ($("#dialog-box2").height());
    var dialogLeft = (maskWidth / 2) - ($("#dialog-box2").width() / 2);

    // assign values to the overlay and dialog box
    $("#dialog-overlay2").css({ height: maskHeight, width: maskWidth }).show();
    $("#dialog-box2").css({ top: dialogTop, left: dialogLeft }).show();

    // display the message
    $("#dialog-message2").html(consMsg1);
    if (status != "donothing") {
        $("#dialog-error2").html(status);
    }
}
function buildPasswordDialog(status) {
    var consMsg2 = '<h2>TO PROCEED PLEASE CHANGE YOUR PASSWORD</h2>';
    consMsg2 += "<p>As part of the log in process, please change your password to one you’re likely to remember.</p>";

    consMsg2 += "<div class=\"dialog-input3\">";
    consMsg2 += "<input id=\"cngPassword\" class=\"inpEmail\" type=\"text\" />";
    consMsg2 += "<div class=\"inpLabel\">New password</div>";
    consMsg2 += "</div>";

    consMsg2 += "<div class=\"dialog-input3\">";
    consMsg2 += "<input id=\"cngConfPassword\" class=\"inpEmail\" type=\"text\" />";
    consMsg2 += "<div class=\"inpLabel\">Confirm new password</div>";
    consMsg2 += "</div>";

    consMsg2 += "<p>Please note that we take your privacy seriously. All personal information (including health information) collected as part of the Wellness Assessment";
    consMsg2 += ", will be handled in accordance with the HealthInSite Privacy Policy. Please also read the Site Disclaimer.</p>";

    var consBtn = "";

    popup2(consMsg2, 760, status);
    //return false;
}
if (showNewPassword.toLowerCase() == "true") {
    buildPasswordDialog("donothing")
}
function saveNewPassword(sResult, confPassword) {
    var saveHTML = $.ajax({
        url: "saveUpdatedPassword",
        type: "POST",
        async: false,
        dataType: "json",
        data: { password: confPassword }
    }).responseText;

    $("#dialog-overlay, #dialog-box1").hide();
    $("#dialog-box1").css({ top: 0, left: 0 });

    return saveHTML;
}
$("#btnContinue2").live("click", function () {
    var thisPassword = $("#cngPassword").val();
    var thisConfPassword = $("#cngConfPassword").val();
    var thisErrMsg = "donothing";
    //alert("thisPassword: " + thisPassword + ", thisConfPassword: " + thisConfPassword);

    if (thisPassword != "" && thisConfPassword != "") {
        if (thisPassword != thisConfPassword) {
            thisErrMsg = "Password and confirmation password do not match";
        } else {
            thisErrMsg = "donothing";
        }
    } else {
        thisErrMsg = "Password/Confirmation password can not be empty";
    }

    if (thisErrMsg != "donothing") {
        $("#dialog-overlay2, #dialog-box2").hide();
        $("#dialog-box2").css({ top: 0, left: 0 });

        buildPasswordDialog(thisErrMsg);
    } else {
        if (thisConfPassword.length < 6) {
            $("#dialog-overlay2, #dialog-box2").hide();
            $("#dialog-box2").css({ top: 0, left: 0 });

            buildPasswordDialog("Password/Confirmation password length must be 6 characters or more");
        } else {
            //var thisDone = "true";
            var thisDone = saveNewPassword("true", thisConfPassword);

            if (thisDone.toLowerCase() != "true") {
                $("#dialog-overlay2, #dialog-box2").hide();
                $("#dialog-box2").css({ top: 0, left: 0 });

                buildPasswordDialog("An error occured please try again");
            } else {
                $("#dialog-overlay2, #dialog-box2").hide();

                alert("Password updated successfully");
            }
        }
    }
    return false;
});
function BuildTwittertemplate(data) {
    var strHTML = "<table>";
    for (var i = 0; i < data.length; i++) {
        strHTML += "<tr>";
        strHTML += "<td>";
        strHTML += "<img src=\"Assets/Images/Twitter-Blue_small.png\" />";
        strHTML += "</td>";
        strHTML += "<td class=\"tweettd\">";
        strHTML += data[i].text;
        strHTML += "</td>";
        strHTML += "</tr>"
    }
    strHTML += "</tr>"
    strHTML += "</table>";
    //console.log("TEMPLATE = " + strHTML);

    return strHTML;
}
function RetrieveTwitterFeed() {
    var twitURL = "https://api.twitter.com/1/statuses/user_timeline.json?screen_name=ecare4me&count=2&trim_user=1";
    //console.log(strurl);

    var twitterInfo = $.ajax(
    {
        url: 'getTwitterInfo',
        type: 'POST',
        async: false,
        dataType: 'json',
        data: { strTwitterURL: twitURL },
        //headers: { Accept: "application/json", "Access-Control-Allow-Origin": "*" },
        //success: function (data) {
        //    console.log("twitter success");
        //    console.log(data[0].text);
        //    var templateinfo = BuildTwittertemplate(data);
        //    var template = kendo.template($("#twittertemplate").html());
        //    $("#tweetcontent").html(template({
        //        twitterfeed: templateinfo
        //    })
        //    );
        //},
        error: function (data) {
            alert("error");
        }
    }).responseText;

    alert(twitterInfo);
    var templateinfo = BuildTwittertemplate(twitterInfo);
    $("#twittertemplate").html(templateinfo);
}
//RetrieveTwitterFeed();
