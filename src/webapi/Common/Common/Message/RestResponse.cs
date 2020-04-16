using System;
using System.Collections.Generic;

namespace Common.Message
{
    /// <summary>
    /// 状态码
    /// </summary>
    public enum HttpStatus
    {
        /// <summary>
        /// 成功
        /// </summary>
        OK = 200,

        /// <summary>
        /// 错误请求
        /// </summary>
        BAD_REQUEST = 400,

        /// <summary>
        /// 未授权
        /// </summary>
        UNAUTHORIZED = 401,

        /// <summary>
        /// 无权限
        /// </summary>
        FORBIDDEN = 403,

        /// <summary>
        /// 未找到
        /// </summary>
        NOT_FOUND = 404,

        /// <summary>
        /// 程序错误异常
        /// </summary>
        INTERNAL_SERVER_ERROR = 500,

        /// <summary>
        /// 注册错误
        /// </summary>
        REGISTER_ERROR_CODE = 601,
        ACTIVE_ERROR_CODE = 665

    }

    /// <summary>
    /// 返回数据
    /// </summary>
    public class RestResponse : Dictionary<string, object>
    {

        public RestResponse()
        {

        }
        public RestResponse(HttpStatus code, string msg)
        {

            this.Add("code", code);
            this.Add("msg", msg);
        }

        /// <summary>
        /// 增加参数
        /// </summary>
        /// <param name="code">key</param>
        /// <param name="value">值</param>
        /// <returns></returns>
        public RestResponse put(string code, object value)
        {
            this[code] = value;
            return this;
        }


        /// <summary>
        /// 参数校验
        /// </summary>
        /// <returns></returns>
        public static RestResponse validate(string msg)
        {
            return new RestResponse(HttpStatus.BAD_REQUEST,msg);
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <returns></returns>
        public static RestResponse error()
        {
            return new RestResponse(HttpStatus.INTERNAL_SERVER_ERROR, "未知异常，请联系管理员或重试");
        }

        /// <summary>
        /// 错误-内容
        /// </summary>
        /// <param name="msg">内容</param>
        /// <returns></returns>
        public static RestResponse error(string msg)
        {
            return new RestResponse(HttpStatus.INTERNAL_SERVER_ERROR, msg);
        }

        /// <summary>
        /// 错误-状态码-内容
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="msg">内容</param>
        /// <returns></returns>
        public static RestResponse error(HttpStatus code, string msg)
        {
            return new RestResponse(code, msg);
        }






        /// <summary>
        /// 错误-状态码
        /// </summary>
        /// <param name="code">状态码</param>
        /// <returns></returns>
        public static RestResponse error(HttpStatus code)
        {
            return new RestResponse(code, code.ToString());
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static RestResponse success(string msg)
        {
            return new RestResponse(HttpStatus.OK, msg);
        }

        /// <summary>
        /// 成功 内容
        /// </summary>
        /// <param name="key">数据key</param>
        /// <param name="data">数据value</param>
        /// <returns></returns>
        public static RestResponse success(string key, object data)
        {
            return new RestResponse(HttpStatus.OK, "success").put(key, data);
        }

        /// <summary>
        /// 成功
        /// </summary>
        /// <returns></returns>
        public static RestResponse success()
        {
            return new RestResponse(HttpStatus.OK, "success");
        }


    }

}
