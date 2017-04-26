using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebAppDri.Models;
using System.Data.Entity;
namespace WebAppDri.Controllers
{
    public class PesquisaController : Controller
    {
        private readonly Models.Database db;

        public PesquisaController()
        {
            db = new Models.Database();
        }

        protected override void Dispose(bool disposing)
        {
            if (db != null) db.Dispose();
            base.Dispose(disposing);
        }

        [AcceptVerbs("POST","GET")]
        public ActionResult Index(int? Kinds)
        {
            IList<Kind> kinds = db.Kind.AsNoTracking().ToList();
            ViewBag.Kinds = new SelectList(kinds, "Id", "Title", Kinds);

            if (Request.HttpMethod.ToUpper() == "POST")
            {
                return View(db.Product.AsNoTracking().Include(i => i.Kind).Where(c => c.KindId == Kinds).ToList());
            }            
            return View();
        }

        [AcceptVerbs("POST")]
        public ActionResult Excluir(IEnumerable<int> Ids)
        {            
            if (Ids != null && Ids.Count() > 0)
            {
                List<Product> products =
                    db.Product.Where(c => Ids.Contains(c.Id)).ToList();
                products.ForEach(c =>
                {
                    db.Entry(c).State = EntityState.Deleted;
                });
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}