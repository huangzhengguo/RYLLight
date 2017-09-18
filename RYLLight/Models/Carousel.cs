using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RYLLight.Models
{
    public class Carousel
    {
        public int Id { get; set; }

        [Display(Name = "电脑版轮播图")]
        [Required(ErrorMessage = "请输入电脑版轮播图!")]
        // 图片路径
        public string PicturePath { get; set; }

        // 手机图片路径
        [Display(Name = "手机版轮播图")]
        [Required(ErrorMessage = "请输入手机版轮播图!")]
        public string MobilePicturePath { get; set; }

        // 关联产品id
        [Required(ErrorMessage = "请输入排序编号!")]
        [Display(Name = "轮播图排序编号")]
        public int SortNumber { get; set; }

        // 图片名称
        [Required(ErrorMessage = "请输入关联产品Id!")]
        [Display(Name = "轮播图关联产品id")]
        public string PictureName { get; set; }

        // 图片描述
        [Required(ErrorMessage = "请输入描述!")]
        [Display(Name = "轮播图描述")]
        public string PictureDes { get; set; }

        // 图片标题
        [Required(ErrorMessage = "请输入标题!")]
        [Display(Name = "轮播图标题")]
        public string PictureTitle { get; set; }
    }
}