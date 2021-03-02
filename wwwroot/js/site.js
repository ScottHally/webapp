// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const hiddenNavWidth = 40;
const expandedNavWidth = 160;
function hideNav(nav) {
    var navStr = '#' + nav;
    //$('#' + nav).hide();
    var navBar = $('#' + nav);

    var closeBtn = $(navStr + ' .closebtn');
    var expandBtn = $(navStr + ' .expandbtn');
    var links = $(navStr + ' a')
    console.log(closeBtn);
    if (navBar.width() == expandedNavWidth) {
        navBar.width(hiddenNavWidth);
        navBar.height(57);
        closeBtn.hide();
        links.hide();
        expandBtn.show();
    }
    else {
        navBar.width(expandedNavWidth);
        navBar.height('100%');
        closeBtn.show();
        links.show();
        links.css('display', 'block')
        // expandBtn.hide()
    }
    expandBtn.toggleClass("change")

}

// ajax helper function!!! why didn't i ever think of this?!
function ajaxHelper(uri, method, data) {
   console.log('ENTERING AJAX HELPER METHOD')
    return $.ajax({
        type: method,
        url: uri,
        data: data // you NEVER need to stringify nor use JSON
    }).fail(function (jqXHR, textStatus, errorThrown) {
        self.error(errorThrown);
    });
}

//$(window).scroll(function () {
//    var navBar = $('#left_sidenav');
//    console.log(navBar.);

//});