
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

                // Clear everything when searched again
                jQuery(".imgResult").html("");                

                var index = 0;
                var thumb = jQuery(".imgResult");
                jQuery.each(data, function() {

                    index++;

                    var imageDiv = document.createElement("div");

                    imageDiv.id = "divImg" + index;
                    imageDiv.setAttribute('class', 'imgContent');
                    var image = document.createElement("img");
                    image.alt = "Flickr Search";
                    image.id = 'Image' + index;
                    image.setAttribute('class', 'images');
                    image.src = this.ImageUrl;
                    image.title = this.Title;

                    imageDiv.appendChild(image);

                    thumb.append(imageDiv);
                   
                    jQuery(".images").fadeIn(20000, function() {
                        // Animation complete.
                    });

                    var titlePosition = '';

                    var jQuerythis = jQuery(image);
                    var title = jQuerythis.attr('title');
                    var src = jQuerythis.attr('data-big') || jQuerythis.attr('src');
                    var a = jQuery('<a href="#" class="fancybox"></a>').attr('href', src).attr('title', title);
                    jQuerythis.wrap(a);

                    jQuery('a.fancybox').attr('rel', 'fancyboxgallery');

                    jQuery('a.fancybox').fancybox({
                        titlePosition: titlePosition
                    });

                    jQuery.noConflict();
                    
                });
                container.html(thumb);
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


