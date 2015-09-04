Tasks:
•	Fix so the design of the images is like the attached picture in the root folder (preview.jpg)
•	Implement so you can click on the Share link and retrieve a full page that is SEO friendly
•	Style the share link so that it looks like the button in the preview
•	Add some kind of status when the AJAX is running, something like "Requesting, Retrieving"
•	Display whatever the pictures are retrieved from the cache or not, like "Loaded from cache / Loaded from flickr"
•	Implement so the cache helper (CacheHelper.cs) has support for both reference types and value types
•	In HomeController, add a feature so you can select between FlickrCacheableRepository or FlickrRepository by some configuration flag, create a solution that are easy to extend so you can have N numbers of repositories
•	Change HomeController's GetImage method only to allow POST request, update the JavaScript so the functionality still work
•	New images should fade in when they are added to the DOM, focus only on the image so each of the images loads smoothly and are display ready.
•	Style the application to look like the attached preview (background image found in the root of the Demo folder)
•	Create a responsive layout so that the application looks good in all resolutions (1 image per row in mobile, 5 on tablet and 10 on high resolution computers)


Completed Tasks:

1. Styling: 

   - Styling of the Page as per the attached preview. Used bootstrap and custom styling to give it the look and feel as required.
   - Responsive layout handled and that the application looks good.
   - Click on images, enlarge them and also navigate without going back to the application.
   - Added a loader when the search is being triggered until the images gets listed.
   - Dynamic HTML and stylesheet when images are received from Flickr API.
   - Using jQuery Fancy box library for enlarging the image on click of it.
   - Share Button can be nade SEO friendly, bot implemented as part of this.
   - Spinner loads whenever the images are being retrieved.
   - Image fading as part of Fancy Box used.
   

2. Repository Selection:
   
   - Implemented the feature of selecting the repository using the design pattern - Dependency Injection.
   - Used Unity.Mvc4 for injecting and resolving the dependencies.
   - The dependencies are configured in the web.config, which makes the change of repository when required easier.
	 eg:
	 <register type="FlickrApp.Repository.IRepository, FlickrApp" mapTo="FlickrApp.Repository.FlickrCacheableRepository, FlickrApp" /> 
   - Modified the controller so that repository dependencies can be injected and can be used.
   - The same dependecies can be injected from the bootstrapper code. 
     Eg below:
	 container.RegisterType<IRepository, FlickrCacheableRepository>();
   - This feature is extendable and any repositories can be injected and used on run time. No / Minimal code change is required.
   - This pattern can also be implemented with different Libraries that are available for dependency injection like AutoFacade.
	 
3. Controller Changes:

   - Decorated the Home Controller with HttpPost attribute, so that it only allows POST request.
   - Modified the Ajax call to do a POST request instead of GET.   
   - Bundled all the css and JavaScripts required as part of BundleConfig.
   
4. CacheHelper:
   
   - CacheHelper can be modified from using HttpCache to memory cache, not implemented as part of this assignment.
   
5. Miscellaneous:
   - Tested the application in IISExpress that comes part of Visual Studio.
   - Hosted the application in localhost and verified that minification of JavaScript and CSS happens.
   - Created a repository on GitHub so that the code can be easily shared and maintained. 
   
   
   
   