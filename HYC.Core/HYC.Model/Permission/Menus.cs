using System;
using System.Collections.Generic;
using System.Text;

namespace HYC.Model.Permission
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class Menus
    {
        /// <summary>
        /// 菜单Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 菜单父级ID
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int SortNum { get; set; }

        /// <summary>
        /// 层级深度
        /// </summary>
        public int DepthNum { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 菜单编码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 菜单地址
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 0:功能菜单;1:操作按钮
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string Icon { get; set; }

        /// <summary>
        /// 菜单说明描述
        /// </summary>
        public string Description { get; set; }
    }
}
