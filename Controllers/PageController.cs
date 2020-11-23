using Acupunctuur.Business;
using Acupunctuur.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Acupunctuur.Controllers {
    public class PageController : Controller {
        private readonly BuPage PModel;
        private readonly SessionManager sessMan;

        public PageController(BuPage buPage, SessionManager sessMan) {
            PModel = buPage;
            this.sessMan = sessMan;
        }

        /**
         * GET /Page/Main/{id=X}
         */
        public IActionResult Main(int id = 1) {
            PageViewModel pageVM = new PageViewModel {
                Pages = PModel.GetMenu(),
                CurrentPage = PModel.GetDynamicPage(id),
                Dynamic = true
            };
            return View(pageVM);
        }

        /**
         * GET /Page/EditIndex
         */
        public IActionResult EditIndex() {
            if (!sessMan.IsLoggedIn()) {
                return RedirectToAction("Main", "Page");
            }
            EditIndexViewModel pageVM = new EditIndexViewModel {
                Pages = PModel.GetMenu(),
                CurrentPage = new Page {
                    InternalName = "Edit",
                    DisplayName = "Pagina bewerken - Index"
                },
                Dynamic = false,
                EditPages = PModel.GetMenuInclContent()
            };
            return View(pageVM);
        }

        /**
         * GET /Page/Edit/id=X
         */
        public IActionResult Edit(int id) {
            if (!sessMan.IsAdmin()) {
                return RedirectToAction("Main", "Page");
            }
            PageViewModel pageVM = new PageViewModel {
                Pages = PModel.GetMenu(),
                CurrentPage = new Page {
                    InternalName = "Edit",
                    DisplayName = "Pagina bewerken",
                    Content = PModel.GetDynamicPage(id).Content
                },
                Dynamic = false
            };
            return View(pageVM);
        }

        /**
         * POST /Page/Edit?id=X&rawHtml=X
         */
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(int id, string rawHtml) {
            if (!sessMan.IsAdmin()) {
                return RedirectToAction("Main", "Page");
            }

            var oldContent = PModel.GetContent(id);
            // The old content obj MUST be changed due to entity tracking messing up if we create a new obj and store it.
            oldContent.RawHtml = rawHtml;
            PModel.UpdateContent(oldContent);

            PageViewModel pageVM = new PageViewModel {
                Pages = PModel.GetMenu(),
                CurrentPage = new Page {
                    InternalName = "Edit",
                    DisplayName = "Bewerken",
                    Content = oldContent
                },
                Dynamic = false
            };
            return View(pageVM);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
