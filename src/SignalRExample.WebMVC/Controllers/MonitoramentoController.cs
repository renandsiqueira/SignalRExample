using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRExample.WebMVC.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignalRExample.WebMVC.Controllers
{
    public class MonitoramentoController : Controller
    {
        // GET: Monitoramento
        public ActionResult Index(string mensagem)
        {
            var hub = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            hub.Clients.All.broadcastMessage("Servidor", "Mensagem");

            return Json(new { result = "true" }, JsonRequestBehavior.AllowGet);
        }
    }
}