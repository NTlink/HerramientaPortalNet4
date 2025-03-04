using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace TimbraNtlink4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Timbrar( string archivo)
        {
            archivo = archivo.Replace("data:text/xml;base64,", "");
            byte[] binaryData = Convert.FromBase64String(archivo);
            string cfdi = System.Text.Encoding.UTF8.GetString(binaryData);

            ServiceReference1.ServicioTimbradoClient cliente = new ServiceReference1.ServicioTimbradoClient();
             var result= await cliente.TimbraCfdiSinSelloAsync("URE180429TM6@ntlink.com.mx", "NTPruebas.2021*?", cfdi);
            if (result != null)
            {
                //return Content(result);
                return Json(new { codigo = "OK", data = result }, JsonRequestBehavior.AllowGet);

            }
            else
                return Json(new { codigo = "Error", data = result }, JsonRequestBehavior.AllowGet);



        }
    }
}