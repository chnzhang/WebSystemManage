using Microsoft.AspNetCore.Mvc;

namespace Permission.Api.Controllers
{

    [ApiController]
    [Route("/")]
    public class HomeController
    {
        public string Get()
        {
            return "欢迎使用WebSystemManage";
        }
    }
}