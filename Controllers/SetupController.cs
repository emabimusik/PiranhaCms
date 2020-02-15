using PiranhaBasic.Models;
using PiranhaBasic.Models.Regions;
using Microsoft.AspNetCore.Mvc;
using Piranha;
using Piranha.Extend.Blocks;
using System;
using System.Threading.Tasks;

namespace PiranhaBasic.Controllers
{
    /// <summary>
    /// This controller is only used when the project is first started
    /// and no pages has been added to the database. Feel free to remove it.
    /// </summary>
    public class SetupController : Controller
    {
        private readonly IApi _api;

        public SetupController(IApi api)
        {
            _api = api;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/seed")]
        public async Task<IActionResult> Seed()
        {
            // Get the default site
            var site = await _api.Sites.GetDefaultAsync();

            // Add media assets
            var bannerId = Guid.NewGuid();

            using (var stream = System.IO.File.OpenRead("seed/pexels-photo-355423.jpeg"))
            {
                await _api.Media.SaveAsync(new Piranha.Models.StreamMediaContent()
                {
                    Id = bannerId,
                    Filename = "pexels-photo-355423.jpeg",
                    Data = stream
                });
            }

            // Add the blog archived
            var blogId = Guid.NewGuid();
            var blogPage = BlogArchive.Create(_api);
            blogPage.Id = blogId;
            blogPage.SiteId = site.Id;
            blogPage.Title = "Blog Archive";
            blogPage.MetaKeywords = " software, website ,appdev,appbuider,backend";
            blogPage.MetaDescription = "software through to the finalt includes all that is involved between.";
            blogPage.NavigationTitle = "Blog";
            blogPage.Hero.PrimaryImage = bannerId;
            blogPage.Hero.Ingress = "software through to the finalt includes all that is involved between.";
            blogPage.Published = DateTime.Now;

            await _api.Pages.SaveAsync(blogPage);

            // Add a blog post
            var postId = Guid.NewGuid();
            var post = BlogPost.Create(_api);
            post.Id = postId;
            post.BlogId = blogPage.Id;
            post.Category = "Software";
            post.Tags.Add("Software develepement", "Machine Learning", "Technologies");
            post.Title = "Software developement";
            post.MetaKeywords = " software, website ,appdev,appbuider,backend";
            post.MetaDescription = "software through to the finalt includes all that is involved between.";
            post.Hero.PrimaryImage = bannerId;
            post.Hero.Ingress = " Software through to the final manifestation of the software it includes all that is involved between.";
            post.Blocks.Add(new HtmlBlock
            {
                Body = "<p>it includes all that is involved between the conception of the desired software through to the final manifestation of the software it includes all that is involved between the conception of the desired software through to the final manifestation of the software.</p>"
            });
            post.Published = DateTime.Now;

            await _api.Posts.SaveAsync(post);

            // Add the startpage
            var startPage = StartPage.Create(_api);
            startPage.SiteId = site.Id;
            startPage.Title = "Machine Learning";
            startPage.MetaKeywords = "Software,webdev,machine learning, technologies, web";
            startPage.MetaDescription = "software through to the finalt includes all that is involved between.";
            startPage.NavigationTitle = "Home";
            startPage.Hero.PrimaryImage = bannerId;
            startPage.Hero.Ingress = "software through to the finalt includes all that is involved between.";
            startPage.Blocks.Add(new HtmlBlock
            {
                Body = "<p>Software development is the process of conceiving, specifying, designing, programming, documenting, testing, and bug fixing involved in creating and maintaining applications, frameworks, or other software components..</p>"
            });
            startPage.Published = DateTime.Now;

            // Add teasers
            startPage.Teasers.Add(new Teaser()
            {
                Title = "Software Prod",
                SubTitle = "Software staging",
                Body = "Software development is a process of writing and maintaining the source code, but in a broader sense,.",
                PageLink = blogPage
            });
            startPage.Teasers.Add(new Teaser()
            {
                Title = "Sftware in Practice",
                SubTitle = "Software Dev",
                Body = "Tt includes all that is involved between the conception of the desired software through to the final manifestation of the software.",
                PostLink = post
            });

            await _api.Pages.SaveAsync(startPage);

            return Redirect("~/");
        }
    }
}
