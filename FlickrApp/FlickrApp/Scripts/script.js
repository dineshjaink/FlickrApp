
var tags = null;

jQuery("#tags").keyup(function(e) {
    if (e.which == 13) {

        clearTimeout(tags);
        tags = setTimeout(function() {
            if (jQuery("#tags").val().length < 3) {
                return false;
            }

            var url = window.location + "Home/GetImages?tags=" + jQuery("#tags").val();


            jQuery.post(url, function(data) {
                var container = jQuery("#main");
                container.html("");

                if (data != null) {
                    for (var i = document.images.length; i-- > 0;)
                        document.images[i].parentNode.removeChild(document.images[i]);
                };

                var index = 0;

                jQuery.each(data, function() {

                    index++;
                    
                    var thumb = jQuery(".imgResult").fadeIn(5000);

                    var imageDiv = document.createElement("div");

                    imageDiv.id = "divImg" + index;
                    imageDiv.setAttribute('class', 'imgContent');
                    var image = document.createElement("img");
                    image.alt = "Flickr Search";
                    image.id = 'Image' + index;
                    image.setAttribute('class', 'images');
                    image.src = this.ImageUrl;
                    image.title = this.Title;
                    //image.fadeOut(5000);

                    imageDiv.appendChild(image);

                    thumb.append(imageDiv);

                    container.html(thumb);

                    jQuery('#Image' + index).imageMagnify({
                        magnifyby: 1.5
                    });
                    jQuery(".images").fadeIn(20000, function() {
                        // Animation complete.
                    });
                });
            });
        }, 250);
    }
});

jQuery(document).ajaxStart(function () {
    jQuery("#content").show();
});

jQuery(document).ajaxStop(function () {
    jQuery("#content").hide();
});


