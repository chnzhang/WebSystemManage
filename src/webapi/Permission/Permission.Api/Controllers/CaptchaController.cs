using Microsoft.AspNetCore.Mvc;
using Hei.Captcha;

namespace Permission.Api.Controllers
{

    [Route("/api/Captcha/")]
    public class CaptchaController : ControllerBase
    {
        private readonly SecurityCodeHelper _securityCode;
        public CaptchaController(SecurityCodeHelper securityCode)
        {
            _securityCode = securityCode;
        }


        /// <summary>
        /// 泡泡中文验证码 
        /// </summary>
        /// <returns></returns>
        [HttpGet("BubbleCode")]
        public IActionResult BubbleCode()
        {
            var code = _securityCode.GetRandomCnText(2);
            var imgbyte = _securityCode.GetBubbleCodeByte(code);
            this.HttpContext.Session.Set("captcha", System.Text.Encoding.Default.GetBytes(code));
            return File(imgbyte, "image/png");
        }

        /// <summary>
        /// 数字字母组合验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet("HybridCode")]
        public IActionResult HybridCode()
        {
            var code = _securityCode.GetRandomEnDigitalText(4);
            var imgbyte = _securityCode.GetEnDigitalCodeByte(code);          
            this.HttpContext.Session.Set("captcha", System.Text.Encoding.Default.GetBytes(code));
            return File(imgbyte, "image/png");
        }

        /// <summary>
        /// gif泡泡中文验证码 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GifBubbleCode")]
        public IActionResult GifBubbleCode()
        {
            var code = _securityCode.GetRandomCnText(2);
            var imgbyte = _securityCode.GetGifBubbleCodeByte(code);          
            this.HttpContext.Session.Set("captcha", System.Text.Encoding.Default.GetBytes(code));
            return File(imgbyte, "image/gif");
        }

        /// <summary>
        /// gif数字字母组合验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet("GifHybridCode")]
        public IActionResult GifHybridCode()
        {
            var code = _securityCode.GetRandomEnDigitalText(4);
            var imgbyte = _securityCode.GetGifEnDigitalCodeByte(code);           
            this.HttpContext.Session.Set("captcha", System.Text.Encoding.Default.GetBytes(code));
            return File(imgbyte, "image/gif");
        }
    }
}