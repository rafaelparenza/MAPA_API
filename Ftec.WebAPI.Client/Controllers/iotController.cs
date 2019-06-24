namespace Ftec.WebAPI.Client.Controllers
{
    public class iotController
    {
        public ActionResult Index()
        {
            var iot = clienteHttp.Get<List<Cliente>>(@"cliente");

            return View(clientes);
        }
    }
}