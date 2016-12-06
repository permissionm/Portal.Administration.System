////var thisBrowser = $.browser;
//var browser = jQuery.uaMatch(navigator.userAgent).browser;
//alert("browser = " + browser);
////alert("thisBrowser = " + thisBrowser.val + ", thisBrowserVer = " + thisBrowser.version);
////if (thisBrowser.mozilla && thisBrowser.version.slice(0, 3) == "1.9") {
////    alert("Do stuff for firefox 3");
////}
//alert("sCurrentPage: " + sCurrentPage + ", sCurrentTitle: " + sCurrentTitle + ", sCurrentTab: " + sCurrentTab);
$(".ulTabs").find(".tabSelected").removeClass("tabSelected");
var thisCurrentTab = "#tab" + sCurrentTab;
//alert("thisCurrentTab = " + thisCurrentTab);
$(thisCurrentTab).parent().addClass("tabSelected");
$("a.fancyPOP").fancybox({
    'prevEffect': 'none',
    'nextEffect': 'none',
    'autoScale': false,
    'transitionIn': 'none',
    'transitionOut': 'none',
    'width': 765,
    'height': 550,
    'type': 'iframe'
    //'afterClose': function () {
    //    alert('test');
    //}
});
$(".avatarWrap").fancybox({
    'prevEffect': 'none',
    'nextEffect': 'none',
    'autoScale': false,
    'transitionIn': 'none',
    'transitionOut': 'none',
    'width': 350,
    'height': 400,
    'type': 'iframe',
    'afterClose': function () {
        self.parent.location.reload(true);
    }
});
//var d = new Date();
//var n = d.getFullYear();
//alert(n);
////$(document).ready(function () {
////});
var thisCrntBtn = "tbbtn_" + sCurrentPage.toLowerCase();
var thisCrntBtnClass = ".tbbtn_" + sCurrentPage.toLowerCase();
var thisSelectBtnClass = "tbbtn_" + sCurrentPage.toLowerCase() + "_selected";
$(window).load(function () {
    //alert( "sCurrentPage = " + sCurrentPage );
    //alert( "ContEntID = " + ContEntID );
    switch (sCurrentPage.toLowerCase()) {
        case "4me":
            $(".tbbtn_wellnesssummary").removeClass("tbbtn_wellnesssummary").addClass("tbbtn_wellnesssummary_selected");
            break;
        case "wellnesssummary":
            $(thisCrntBtnClass).removeClass(thisCrntBtn).addClass(thisSelectBtnClass);
            break;
        case "wellnessassessment":
            $(thisCrntBtnClass).removeClass(thisCrntBtn).addClass(thisSelectBtnClass);
            break;
        case "asktheprofessional":
            $(thisCrntBtnClass).removeClass(thisCrntBtn).addClass(thisSelectBtnClass);
            break;
        case "wellnesstracker":
            $(thisCrntBtnClass).removeClass(thisCrntBtn).addClass(thisSelectBtnClass);
            break;
        case "optinseries":
            $(thisCrntBtnClass).removeClass(thisCrntBtn).addClass(thisSelectBtnClass);
            break;
        case "wellnesspoints":
            $(thisCrntBtnClass).removeClass(thisCrntBtn).addClass(thisSelectBtnClass);
            break;
        case "healthbytehistory":
            $(thisCrntBtnClass).removeClass(thisCrntBtn).addClass(thisSelectBtnClass);
            break;
        //case "Case1":
        //    break;
            //default:
        //    break;
    }
});
//$(".librTab").click(function () {
//    var thisGroupID = $(this).attr("groupid");
//    var theULName = "#librSubUL" + thisGroupID;
//    //alert("theULName: " + theULName);

//    if ($(theULName).is(":hidden")) {
//        $(theULName).slideDown();
//    } else {
//        $(theULName).slideUp();
//    }

//    return false;
//});
function shareSucceeded() {
    try {
        $(".sliderShareHeart").removeClass("sliderShareHeart").addClass("sliderShareHeartShared");
        $(".sliderShareHeartShared").attr("onmouseover", "tooltip.show('You have already earned the maximum number of points for this activity');");
    }
    catch (err) {
        //alert("An error occured.");
        //window.location = "404.html";
    }
}
function shareAvail(contentid, challengeid) {
    try {
        var transHTML = $.ajax({
            url: "ClaimAvailable",
            type: "POST",
            async: false,
            dataType: "json",
            data: { contentid: contentid, challengeid: challengeid }
        }).responseText;
        return transHTML;
    }
    catch (err) {
        //alert("Error: " + err.Description + ", please try again!");
    }
}
function claimWelnessPoints(cntntID, chlngID) {
    try {
        var clmWellHTML = $.ajax({
            url: "claimWelPoints",
            type: "POST",
            async: false,
            dataType: "json",
            data: { contentID: cntntID, challengeID: chlngID }
        }).responseText;
        //alert("clmWellHTML=" + clmWellHTML);
        return clmWellHTML;
    }
    catch (err) {
        //alert("Error: " + err.Description + ", please try again!");
        //window.location = "error.html";
    }
}
$("#scLinkFacebook").live("click", function () {
    var contDiv = $(".slider_content");
    var contDivID = contDiv.attr("id");
    var vContID = contDivID.replace("slider_", "");
    //alert("vContID = " + vContID);
    var vContHead = $("#" + contDivID).find("h1");
    var vContHeadText = $(vContHead).text();
    //alert("vContHeadText = " + vContHeadText);

    var width = 575,
        height = 400,
        left = ($(window).width() - width) / 2,
        top = ($(window).height() - height) / 2,
        url = 'http://www.facebook.com/share.php?u=https://www.ecare4me.com/twitterviewer/twitterview.aspx?id=' + vContID + '%26region=1&t=' + vContHeadText + '',
        opts = 'status=1,width=' + width + ',height=' + height + ',top=' + top + ',left=' + left;

    window.open(url, 'Facebook', opts);

    var cwPoints = claimWelnessPoints(vContID, 11);
    var ptsShareAvail = shareAvail(vContID, 11);

    if (ptsShareAvail != "false") {
        //shareSucceeded();
    } else {
        shareSucceeded();
    }

    return false;
});
$("#scLinkTwitter").live("click", function () {
    var contDiv = $(".slider_content");
    var contDivID = contDiv.attr("id");
    var vContID = contDivID.replace("slider_", "");
    //alert("vContID = " + vContID);
    var vContHead = $("#" + contDivID).find("h1");
    var vContHeadText = $(vContHead).text();
    //alert("vContHeadText = " + vContHeadText);

    var width = 575,
        height = 400,
        left = ($(window).width() - width) / 2,
        top = ($(window).height() - height) / 2,
    //url = this.href,
        url = 'http://twitter.com/home?status=' + vContHeadText + ' – https://www.ecare4me.com/twitterviewer/twitterview.aspx?id=' + vContID + '%26region=1 (Via  @eCare4me)',
        opts = 'status=1,width=' + width + ',height=' + height + ',top=' + top + ',left=' + left;

    window.open(url, 'Twitter', opts);

    var cwPoints = claimWelnessPoints(vContID, 11);
    var ptsShareAvail = shareAvail(vContID, 11);

    if (ptsShareAvail != "false") {
        //shareSucceeded();
    } else {
        shareSucceeded();
    }

    return false;
});
$("#scLinkEmail").live("click", function () {
    var contDiv = $(".slider_content");
    var contDivID = contDiv.attr("id");
    var vContID = contDivID.replace("slider_", "");
    var useHeading = $(this).attr("useHeading");

    var formattedBody = "https://www.ecare4me.com/TwitterViewer/TwitterView.aspx?id=" + vContID;
    var mailToLink = "mailto:?subject=" + useHeading + "&body=" + encodeURIComponent(formattedBody);
    window.location.href = mailToLink;

    var cwPoints = autoWelnessPoints(vContID, 11);
    var ptsShareAvail = shareAvail(vContID, 11);

    if (ptsShareAvail != "false") {
        //shareSucceeded();
    } else {
        shareSucceeded();
    }

    return false;
});
$("#scLinkPinterest").live("click", function () {
    var contDiv = $(".slider_content");
    var contDivID = contDiv.attr("id");
    var vContID = contDivID.replace("slider_", "");
    //alert("vContID = " + vContID);
    var vContHead = $("#" + contDivID).find("h1");
    var vContHeadText = $(vContHead).text();
    //alert("vContHeadText = " + vContHeadText);

    var width = 575,
        height = 400,
        left = ($(window).width() - width) / 2,
        top = ($(window).height() - height) / 2,
        url = 'http://pinterest.com/pin/create/button/?url=https%3A%2F%2Fwww.ecare4me.com%2FArticleViewer%2F%3Fid%3D' + vContID + '%26region=1',
        opts = 'status=1,width=' + width + ',height=' + height + ',top=' + top + ',left=' + left;

    window.open(url, 'Pinterest', opts);

    var cwPoints = claimWelnessPoints(vContID, 11);
    var ptsShareAvail = shareAvail(vContID, 11);

    if (ptsShareAvail != "false") {
        //shareSucceeded();
    } else {
        shareSucceeded();
    }

    return false;
});
$("#scLinkPrint").live("click", function () {
    var win = null;
    var areaToPrint = $(this).attr("printArea");
    var printThis = $("#" + areaToPrint).html();
    //var printThis = $("#contentToPrint").html();
    win = window.open();
    self.focus();
    win.document.open();
    win.document.write("<" + "html" + "><" + "head" + ">");
    win.document.write("<" + "link href='" + clientCSS + "/zonesprint.css' rel='stylesheet' type='text/css' " + "/>");
    win.document.write("<" + "/" + "head" + "><" + "body" + ">");
    win.document.write("<" + "div" + " id=\"contentToPrint\"" + ">");
    win.document.write(printThis);
    win.document.write('<' + '/' + 'div' + '>');
    win.document.write('<' + '/' + 'body' + '><' + '/' + 'html' + '>');
    win.document.close();
    win.print();
    win.close();

    return false;
});
$(".intArticleExpand").click(function () {
    var thisIntArtID = $(this).attr("id");
    var thisArtID = thisIntArtID.replace("expand", "");
    var isMinExp = $(this).html();

    if (isMinExp != "expand +") {
        $(this).html("expand +");

        $("#minexp" + thisArtID).addClass("minHeight");
    } else {
        $(this).html("minimize -");

        $("#minexp" + thisArtID).removeClass("minHeight");
    }

    return false;
});
var tooltip = function () {
    var id = 'tt';
    var top = 3;
    var left = 3;
    var maxw = 300;
    var speed = 10;
    var timer = 20;
    var endalpha = 95;
    var alpha = 0;
    var tt, t, c, b, h;
    var ie = document.all ? true : false;
    return {
        show: function ( v, w ) {
            if ( tt == null ) {
                tt = document.createElement( 'div' );
                tt.setAttribute( 'id', id );
                t = document.createElement( 'div' );
                t.setAttribute( 'id', id + 'top' );
                c = document.createElement( 'div' );
                c.setAttribute( 'id', id + 'cont' );
                b = document.createElement( 'div' );
                b.setAttribute( 'id', id + 'bot' );
                tt.appendChild( t );
                tt.appendChild( c );
                tt.appendChild( b );
                document.body.appendChild( tt );
                tt.style.opacity = 0;
                tt.style.filter = 'alpha(opacity=0)';
                document.onmousemove = this.pos;
            }
            tt.style.display = 'block';
            c.innerHTML = v;
            tt.style.width = w ? w + 'px' : 'auto';
            if ( !w && ie ) {
                t.style.display = 'none';
                b.style.display = 'none';
                tt.style.width = tt.offsetWidth;
                t.style.display = 'block';
                b.style.display = 'block';
            }
            if ( tt.offsetWidth > maxw ) { tt.style.width = maxw + 'px'; }
            h = parseInt( tt.offsetHeight ) + top;
            clearInterval( tt.timer );
            tt.timer = setInterval( function () { tooltip.fade( 1 ); }, timer );
        },
        pos: function ( e ) {
            var u = ie ? event.clientY + document.documentElement.scrollTop : e.pageY;
            var l = ie ? event.clientX + document.documentElement.scrollLeft : e.pageX;
            tt.style.top = ( u - h ) + 'px';
            tt.style.left = ( l + left ) + 'px';
        },
        fade: function ( d ) {
            var a = alpha;
            if ( ( a != endalpha && d == 1 ) || ( a != 0 && d == -1 ) ) {
                var i = speed;
                if ( endalpha - a < speed && d == 1 ) {
                    i = endalpha - a;
                } else if ( alpha < speed && d == -1 ) {
                    i = a;
                }
                alpha = a + ( i * d );
                tt.style.opacity = alpha * .01;
                tt.style.filter = 'alpha(opacity=' + alpha + ')';
            } else {
                clearInterval( tt.timer );
                if ( d == -1 ) { tt.style.display = 'none'; }
            }
        },
        hide: function () {
            clearInterval( tt.timer );
            tt.timer = setInterval( function () { tooltip.fade( -1 ); }, timer );
        }
    };
}();
//var tooltip = function () {
//    var id = 'tt';
//    var top = 3;
//    var left = 3;
//    var maxw = 300;
//    var speed = 10;
//    var timer = 20;
//    var endalpha = 95;
//    var alpha = 0;
//    var tt, t, c, b, h;
//    var ie = document.all ? true : false;
//    return {
//        show: function (v, w) {
//            if (tt == null) {
//                tt = document.createElement('div');
//                tt.setAttribute('id', id);
//                t = document.createElement('div');
//                t.setAttribute('id', id + 'top');
//                c = document.createElement('div');
//                c.setAttribute('id', id + 'cont');
//                b = document.createElement('div');
//                b.setAttribute('id', id + 'bot');
//                tt.appendChild(t);
//                tt.appendChild(c);
//                tt.appendChild(b);
//                document.body.appendChild(tt);
//                tt.style.opacity = 0;
//                tt.style.filter = 'alpha(opacity=0)';
//                document.onmousemove = this.pos;
//            }
//            tt.style.display = 'block';
//            c.innerHTML = v;
//            tt.style.width = w ? w + 'px' : 'auto';
//            if (!w && ie) {
//                t.style.display = 'none';
//                b.style.display = 'none';
//                tt.style.width = tt.offsetWidth;
//                t.style.display = 'block';
//                b.style.display = 'block';
//            }
//            if (tt.offsetWidth > maxw) { tt.style.width = maxw + 'px' }
//            h = parseInt(tt.offsetHeight) + top;
//            clearInterval(tt.timer);
//            tt.timer = setInterval(function () { tooltip.fade(1) }, timer);
//        },
//        pos: function (e) {
//            var u = ie ? event.clientY + document.documentElement.scrollTop : e.pageY;
//            var l = ie ? event.clientX + document.documentElement.scrollLeft : e.pageX;
//            tt.style.top = (u - h) + 'px';
//            tt.style.left = (l + left) + 'px';
//        },
//        fade: function (d) {
//            var a = alpha;
//            if ((a != endalpha && d == 1) || (a != 0 && d == -1)) {
//                var i = speed;
//                if (endalpha - a < speed && d == 1) {
//                    i = endalpha - a;
//                } else if (alpha < speed && d == -1) {
//                    i = a;
//                }
//                alpha = a + (i * d);
//                tt.style.opacity = alpha * .01;
//                tt.style.filter = 'alpha(opacity=' + alpha + ')';
//            } else {
//                clearInterval(tt.timer);
//                if (d == -1) { tt.style.display = 'none' }
//            }
//        },
//        hide: function () {
//            clearInterval(tt.timer);
//            tt.timer = setInterval(function () { tooltip.fade(-1) }, timer);
//        }
//    };
//}();
//function adjustIFrameSize(iframeWindow) {
//    var iframeElement = document.getElementById(iframeWindow.name);
//    iframeElement.style.height = iframeWindow.document.body.scrollHeight + 5 + 'px';

//    if (iframeWindow.document.height) {
//        var iframeElement = document.getElementById(iframeWindow.name);
//        iframeElement.style.height = iframeWindow.document.height + 'px';
//    }
//    else if (document.all) {
//        var iframeElement = document.all[iframeWindow.name];
//        if (iframeWindow.document.compatMode && iframeWindow.document.compatMode != 'BackCompat') {
//            iframeElement.style.height = iframeWindow.document.documentElement.scrollHeight + 5 + 'px';
//        }
//        else {
//            iframeElement.style.height = iframeWindow.document.body.scrollHeight + 5 + 'px';
//        }
//    }
//}
$(window).load(function () {
    $("#divLoading").hide();
});
