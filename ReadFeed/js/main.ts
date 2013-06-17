function loadPage(elementID, url) {
    jQuery.support.cors = true;
    jQuery.ajax({
url: "/api/Feed",
data: {'url': url},
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            jQuery('#'+elementID).html(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });
}