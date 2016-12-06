$(".photosgallery-captions").sliderkit({
    circular: true,
    mousewheel: false,
    panelbtnshover: true,
    shownavitems: 1,
    autospeed: 5000,
    auto: true,
    panelfxspeed: 500
});

/*---------------------------------
*	Extending
*---------------------------------*/

// Get the sliderkit object data
var myGallery = $(".photosgallery-captions").data("sliderkit");

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
$('.showHomeLink').click(function () {
    window.location.href = '../HomeNew/Home?curPage=Home';
    return false;
});
