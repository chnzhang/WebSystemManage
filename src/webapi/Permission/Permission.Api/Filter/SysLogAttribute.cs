using System;

namespace  Permission.Api.Filter
{
    /// <summary>
    /// 系统日志注解
    /// </summary>
    public class SysLogAttribute : Attribute
    {
        public string Content { get; set; } = "操作日志";

        /// <summary>
        /// 系统操作日志
        /// </summary>
        /// <param name="content">内容</param>
        public SysLogAttribute(string content)
        {
            Content = content;
        }
    }
}