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

        /// <summary>
        /// 公司名称
        /// </summary>
        [Required]
        [MaxLength(200)]
        [Display(Name = "公司名称")]
        public string CompanyName { get; set; }

        /// <summary>
        /// 公司地址
        /// </summary>
        [Required]
        [Display(Name = "公司地址")]
        public string CompanyAddress { get; set; }

        /// <summary>
        /// 公司电话
        /// </summary>
        [Required]
        [Display(Name = "公司电话")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 公司邮箱
        /// </summary>
        [Required]
        [Display(Name = "公司邮箱")]
        public string MailBox { get; set; }

        /// <summary>
        /// 公司简介
        /// </summary>
        [Required]
        [Display(Name = "公司简介")]
        public string CompanyDescription { get; set; }

        /// <summary>
        /// 备用字段
        /// </summary>
        [Display(Name = "公司历史")]
        public string FreeOne { get; set; }
        [Display(Name = "公司业务")]
        public string FreeTwo { get; set; }
        [Display(Name = "手机版背景图片")]
        public string FreeThree { get; set; }

        /// <summary>
        /// 背景图片
        /// </summary>
        [Display(Name = "背景图片")]
        public string CompanyBackgroundImg { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        [Display(Name = "分类")]
        public TypeOfProduct TypeProduct { get; set; }
    }
}