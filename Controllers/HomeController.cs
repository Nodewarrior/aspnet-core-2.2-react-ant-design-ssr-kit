using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Prerendering;
using Newtonsoft.Json;

namespace React_Redux_Ssr_Ant.Controllers
{
	[Route("api/[controller]")]
	public class HomeController : Controller
	{
		[Route("/")]
		public async Task<IActionResult> Index([FromServices] ISpaPrerenderer prerenderer)
		{
			var initialState = JsonConvert.SerializeObject(new { metadata = new { isviewable = true } });
			var prerenderResult = await prerenderer.RenderToString("./ClientApp/server/bootstrap", customDataParameter: initialState);

			return Content(prerenderResult.Html, "text/html");
		}
	}
}
