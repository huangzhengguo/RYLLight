using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RYLLight.Models
{
    public class News
    {
        public int Id { get; set; }

        // 新闻标题
        [Display(Name = "新闻标题")]
        [Required(ErrorMessage = "请输入新闻标题!")]
        [MaxLength(64)]
        public string Title { get; set; }

        // 新闻副标题
        [Display(Name = "新闻副标题")]
        [Required(ErrorMessage = "请输入新闻副标题!")]
        [MaxLength(64)]
        public string SubTitle { get; set; }

        // 缩略图
        [Display(Name = "缩略图")]
        [Required(ErrorMessage = "请输入缩略图!")]
        public string Thumbnail { get; set; }

        // 大图
        [Required(ErrorMessage = "请输入手机版新闻!")]
        [Display(Name = "手机版新闻")]
        public string Picture { get; set; }

        // 文章内容
        [Display(Name = "文章内容")]
        [Required(ErrorMessage = "请输入文章内容!")]
        public string Content { get; set; }

        // 作者
        [Display(Name = "文章作者")]
        [Required(ErrorMessage = "请输入文章作者!")]
        [MaxLength(32)]
        public string Author { get; set; }

        // 发布时间
        [Display(Name = "发布时间")]
        [Required(ErrorMessage = "请输入发布时间!")]
        public DateTime? PublishDateTime { get; set; }

        // 编辑时间
        [Display(Name = "编辑时间")]
        public DateTime? EditDateTime { get; set; }

        // 是否发布
        [Display(Name = "是否发布")]
        [Required(ErrorMessage = "请选择是否发布新闻!")]
        public bool PublishOrNot { get; set; }

        // 排序编号
        [Display(Name = "排序编号")]
        [Required(ErrorMessage = "请输入排序标号!")]
        public int SortNumber { get; set; }

        // 新闻背景图片
        [Display(Name = "新闻背景图片")]
        [Required(ErrorMessage = "请输入背景图片！")]
        public string NewsBackgroundImg { get; set; }

        // 分类
        [Display(Name = "分类")]
        public TypeOfProduct TypeProduct { get; set; }
    }
}