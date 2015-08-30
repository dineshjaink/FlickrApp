using System.Collections.Generic;
using FlickrApp.Models;

namespace FlickrApp.Repository
{
    /// <summary>
    /// The Repository interface
    /// </summary>
    interface IRepository
    {
        List<FlickrImage> GetImagesByTags(string tags);
    }
}
