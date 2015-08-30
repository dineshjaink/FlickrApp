using System.Collections.Generic;
using System.Xml;
using FlickrApp.Models;
using FlickrNet;

namespace FlickrApp.Repository
{
    /// <summary>
    /// Acting as a repository for Flickr
    /// </summary>
    public class FlickrRepository : IRepository
    {

        // To see the raw data, have a look at
        // http://api.flickr.com/services/feeds/photos_public.gne?tags=cats
        // https://api.flickr.com/services/rest/?format=json&nojsoncallback=1&method=flickr.photos.search&api_key=bb8dce2d4a46031d12ee2e208ef3963b&per_page=25&tags=cat


        /// <summary>
        /// Returns the image
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public List<FlickrImage> GetImagesByTags(string tags)
        {
            return GetPhotos(tags);
            /*var nodes = LoadData(tags);
            var images = new List<FlickrImage>();


            foreach (XmlNode item in nodes)
            {
                var image = new FlickrImage {Title = item.FirstChild.InnerText};
                var xmlAttributeCollection = item.ChildNodes[9].Attributes;
                if (xmlAttributeCollection != null){ 
                    image.ImageUrl = xmlAttributeCollection["href"].Value;
                }
                if (!image.ImageUrl.Contains("creativecommons"))
                {
                    images.Add(image);
                }
            }*/

            //return images;
        }

        private List<FlickrImage> GetPhotos(string tag)
        {
            string flickrKey = "bb8dce2d4a46031d12ee2e208ef3963b";

            string sharedSecret = "821338c9f437a6ee";

            var flickrImages = new List<FlickrImage>();

            PhotoSearchOptions options = new PhotoSearchOptions();
            options.PerPage = 12;
            options.Page = 1;
            options.SortOrder = PhotoSearchSortOrder.DatePostedDescending;
            options.MediaType = MediaType.Photos;
            options.Extras = PhotoSearchExtras.All;
            options.Tags = tag;

            Flickr flickr = new Flickr(flickrKey, sharedSecret);
            PhotoCollection photos = flickr.PhotosSearch(options);

            foreach(var images in photos)
            {
                if (images.IsPublic)
                {
                    var image = new FlickrImage { Title = images.Title };
                    image.ImageUrl = images.MediumUrl;
                    flickrImages.Add(image);
                }
            }

            return flickrImages;
        }
        /// <summary>
        /// Load data from flickr
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        private XmlNodeList LoadData(string tags){
            var xdoc = new XmlDocument();//xml doc used for xml parsing
            xdoc.Load(string.Format("https://api.flickr.com/services/rest/?format=json&nojsoncallback=1&method=flickr.photos.search&api_key=bb8dce2d4a46031d12ee2e208ef3963b&per_page=25&tags={0}", tags));
            var xNodelst = xdoc.GetElementsByTagName("entry");
            return xNodelst;
        }
    }

}
