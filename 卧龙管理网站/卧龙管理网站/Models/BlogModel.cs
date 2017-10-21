using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WollonMe.Models
{
    public class Blog
    {
        public int BlogId { set; get; }
        /// <summary>
        /// 作者
        /// </summary>
        public string AuthorID { set; get; }
        /// <summary>
        /// 标题 
        /// </summary>
        public string BlogTitle { set; get; }
        /// <summary>
        /// 摘要
        /// </summary>
        public string BlogAbst { set; get; }
        /// <summary>
        /// 内容
        /// </summary>
        public string BlogCont { set; get; }
        /// <summary>
        /// 来源
        /// </summary>
        public string BlogSource { set; get; }
        /// <summary>
        /// 发表时间
        /// </summary>
        public DateTime UpTime { set; get; }
        /// <summary>
        /// 标签
        /// </summary>
        public string Tags { set; get; }
        /// <summary>
        /// 个人分类
        /// </summary>
        public string PerKinds { set; get; }
        /// <summary>
        /// 是否可见
        /// </summary>
        public Boolean isView { set; get; }
        /// <summary>
        /// 点击量
        /// </summary>
        public int ClickNum { set; get; }
        /// <summary>
        /// 评论量
        /// </summary>
        public int RemarkNum { set; get; }
        /// <summary>
        /// 主分类
        /// </summary>
        [ForeignKey("MainKind")]
        public int MainKindID { set; get; }
        public virtual MainKindModel MainKind { set; get; }
        /// <summary>
        /// 图片
        /// </summary>
        [ForeignKey("BlogImg")]
        public int FileID { set; get; }
        public virtual FileModel BlogImg { set; get; }
        /// <summary>
        /// 博文级别
        /// </summary>
        [ForeignKey("Level")]
        public int LevelID { set; get; }
        public virtual LevelModel Level { set; get; }

    }
}