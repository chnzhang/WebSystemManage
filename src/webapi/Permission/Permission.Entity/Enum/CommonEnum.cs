using System.ComponentModel;

namespace Permission.Entity.Enum
{

    /// <summary>
    /// 公共枚举类
    /// </summary>
    public static class CommonEnum
    {
        /// <summary>
        /// 状态
        /// </summary>
        public enum STATUS
        {

            ///<summary>
            /// 启用
            ///</summary>
            [Description("启用")]
            ENABLE = 1,

            ///<summary>
            /// 禁用
            ///</summary>
            [Description("禁用")]
            DISABLE = 2
        }
    }
}