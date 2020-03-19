//*******************************
// Create By cnzhang
// Date 2020-03-19 18:53
// Code Generate By SmartCode
// Code Generate Github : https://github.com/Ahoo-Wang/SmartCode
//*******************************

using System;
namespace Permission.Entity
{

    ///<summary>
    /// Table, sys_menu
    ///</summary>
    public class SysMenu
    {
        ///<summary>
        /// id
        ///</summary>
        public virtual string MenuId { get; set; }
        ///<summary>
        /// 名称
        ///</summary>
        public virtual string Name { get; set; }
        ///<summary>
        /// 跳转路径
        ///</summary>
        public virtual string Path { get; set; }
        ///<summary>
        /// 父菜单id
        ///</summary>
        public virtual string ParentId { get; set; }
        ///<summary>
        /// 类型 1目录 2菜单 3按钮
        ///</summary>
        public virtual int? Type { get; set; }
        ///<summary>
        /// 图标
        ///</summary>
        public virtual string Icon { get; set; }
        ///<summary>
        /// 排序
        ///</summary>
        public virtual int? Sort { get; set; }
        ///<summary>
        /// COMPONENT, varchar
        ///</summary>
        public virtual string Component { get; set; }
    }
}

