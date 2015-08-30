
var tags = null;

$("#tags").keyup(function () {
    

    clearTimeout(tags);
    tags = setTimeout(function () {
        if ($("#tags").val().length < 3) {
            return false;
        }

        var URL = window.location + "Home/GetImages?tags=" + $("#tags").val();        

        $.getJSON(URL, function (data) {
            var container = $("#main");
            container.html("");

            if (data != null) {
                for (var i = document.images.length; i-- > 0;)
                    document.images[i].parentNode.removeChild(document.images[i]);
            };

            var index = 0;

            $.each(data, function () {
                
                index++;

                var thumb = $(".imgResult");
                
                var image = document.createElement("img");
                image.alt = "Flickr Search";
                image.id = 'Image' +index
                image.setAttribute('class', 'images');
                image.src= this.ImageUrl;
                image.title = this.Title;                
                thumb.prepend(image);
                
                container.html(thumb);                

                jQuery('#Image' +index).imageMagnify({ //apply effect to image with ID="myimage"
                    magnifyby: 5
                })
            });
        });
    }, 250);
})