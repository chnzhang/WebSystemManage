using System.ComponentModel.DataAnnotations;

namespace Permission.Api.Model
{
    /// <summary>
    /// 用户登录
    /// </summary>
    public sealed class LoginModel
    {
        /// <summary>
        /// 帐号
        /// </summary>
        [Required(ErrorMessage = "用户名不能为空")]
        public string Account { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required(ErrorMessage = "密码不能为空")]
        [MinLength(6, ErrorMessage = "密码错误")]
        [MaxLength(15, ErrorMessage = "密码错误")]
        public string Password { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        [Required(ErrorMessage = "验证码不能为空")]
        [MinLength(2, ErrorMessage = "验证码错误")]
        public string Code { get; set; }

    }
}