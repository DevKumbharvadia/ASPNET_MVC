using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models.Domain;
using WebApplication1.Models.ViewModels;

namespace WebApplication1.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly BlogDbContext _blogDbContext;

        public AdminTagsController(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }

        // GET: AdminTags/Add
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // POST: AdminTags/Add
        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest atr)
        {
            if (!ModelState.IsValid)
            {
                return View(atr); // Return the same view with the current data if the model is invalid
            }

            var tag = new Tag
            {
                Name = atr.Name,
                DisplayName = atr.DisplayName
            };

            _blogDbContext.Add(tag);
            _blogDbContext.SaveChanges();
            return RedirectToAction("List");
        }

        // GET: AdminTags/List
        [HttpGet]
        public IActionResult List()
        {
            var tags = _blogDbContext.Tags.ToList();
            return View(tags);
        }

        // GET: AdminTags/Edit/{id}
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var tag = _blogDbContext.Tags.Find(id);
            if (tag != null)
            {
                var etr = new EditTagRequest
                {
                    id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName,
                };
                return View(etr);
            }
            return NotFound(); // Return a 404 if the tag is not found
        }

        // POST: AdminTags/Edit
        [HttpPost]
        public IActionResult Edit(EditTagRequest etr)
        {
            if (!ModelState.IsValid)
            {
                return View(etr); // Return the same view with the current data if the model is invalid
            }

            var oldTag = _blogDbContext.Tags.Find(etr.id);
            if (oldTag != null)
            {
                oldTag.Name = etr.Name;
                oldTag.DisplayName = etr.DisplayName;
                _blogDbContext.SaveChanges();
                return RedirectToAction("List");
            }
            return NotFound(); // Return a 404 if the tag is not found
        }

        // POST: AdminTags/Delete/{id}
        [HttpPost]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var tag = _blogDbContext.Tags.Find(id);
            if (tag != null)
            {
                _blogDbContext.Tags.Remove(tag);
                _blogDbContext.SaveChanges();
                return RedirectToAction("List");
            }
            return NotFound(); // Return a 404 if the tag is not found
        }
    }
}
