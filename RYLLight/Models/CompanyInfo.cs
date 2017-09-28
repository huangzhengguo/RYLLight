using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RYLLight.Models
{
    public class CompanyInfo
    {
        public int Id { get; set; }

        // 公司名称
        [Required]
        [MaxLength(200)]
        [Display(Name = "公司名称")]
        public string CompanyName { get; set; }

        // 公司地址
        [Required]
        [Display(Name = "公司地址")]
        public string CompanyAddress { get; set; }

        // 公司电话
        [Required]
        [Display(Name = "公司电话")]
        public string PhoneNumber { get; set; }

        // 公司邮箱
        [Required]
        [Display(Name = "公司邮箱")]
        public string MailBox { get; set; }

        // 公司简介
        [Required]
        [Display(Name = "公司简介")]
        public string CompanyDescription { get; set; }

        // 备用字段
        [Display(Name = "公司历史")]
        public string FreeOne { get; set; }
        [Display(Name = "公司业务")]
        public string FreeTwo { get; set; }
        [Display(Name = "公司简介")]
        public string FreeThree { get; set; }

        // 背景图片
        [Display(Name = "背景图片")]
        public string CompanyBackgroundImg { get; set; }

        // 分类
        [Display(Name = "分类")]
        public TypeOfProduct TypeProduct { get; set; }
    }
}