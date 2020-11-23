using Acupunctuur.data;
using Acupunctuur.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Acupunctuur.Business {
    public class BuPage {
        public AcupunctuurContext Context { get; set; }

        public BuPage(AcupunctuurContext context) {
            Context = context;
        }

        public IList<Page> GetMenu() {
            return Context.Pages.Where(p => !p.IsEmail).ToList();
        }

        public IList<Page> GetMenuInclContent() {
            return Context.Pages.Include(p => p.Content).ToList();
        }

        public Page GetDynamicPage(int id) {
            return Context.Pages.Where(p => p.Id == id).Include(p => p.Content).FirstOrDefault();
        }

        public Content GetContent(int id) {
            return Context.Contents.Where(c => c.Id == id).FirstOrDefault();
        }

        public Page GetPageByInternalName(string internalName) {
            return Context.Pages.Where(p => p.InternalName == internalName).Include(p => p.Content).FirstOrDefault();
        }

        public void UpdateContent(Content content) {
            Context.Update(content);
            Context.SaveChanges();
        }
    }
}
