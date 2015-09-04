using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Microsoft.Practices.Unity;
using Unity.Mvc4;
using FlickrApp.Models;

namespace FlickrApp.Repository
{
    /// <summary>
    /// Acting as a repository for Flickr
    /// </summary>
    public class FlickrRepository : IRepository
    {
        private const string FLICKR_API = "http://api.flickr.com/services/feeds/photos_public.gne?tags={0}";
       
        /// <summary>
        /// Returns the images based on Search Tags
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        public List<FlickrImage> GetImagesByTags(string tags)
        {
            var images = new List<FlickrImage>();

            //Testing code Starts
            //var im = new FlickrImage
            //{
            //    Title = "test",
            //    ImageUrl = "http://www.dailydesigninspiration.com/diverse/3d/rodriguepralier/A-dude.jpg"
            //};

            //images.Add(im);

            ////Testing code Starts
            //var im1 = new FlickrImage
            //{
            //    Title = "test",
            //    ImageUrl = "http://www.bloomfield.k12.nj.us/Portals/Bloomfield/District/new.png"
            //};

            //images.Add(im1);

            //return images;
            //Testind Code Ends

            var nodes = LoadData(tags);
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
            }
            return images;
        }
        
        /// <summary>
        /// Load data from Flickr
        /// </summary>
        /// <param name="tags"></param>
        /// <returns></returns>
        private XmlNodeList LoadData(string tags){
            var xdoc = new XmlDocument();//xml doc used for xml parsing
            xdoc.Load(string.Format(FLICKR_API, tags));
            var xNodelst = xdoc.GetElementsByTagName("entry");
            return xNodelst;
        }
    }

}
