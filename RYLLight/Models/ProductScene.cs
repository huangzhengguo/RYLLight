using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RYLLight.Models
{
    /// <summary>
    /// 应用场景实体类
    /// </summary>
    public class ProductScene
    {
        public int Id { get; set; }

        // 场景名称
        public string SceneName { get; set; }
        // 场景描述
        public string SceneDescription { get; set; }
        // 两种尺寸的应用场景的图片
        // 场景大图：Application页面的展示
        public string ApplicationScenePicturePath { get; set; }
        // 场景图片路径:此处的是照明和产品切换部分使用：场景小图
        public string ScenePicturePath { get; set; }
        // 关联产品列表:一个场景中有多个图片
        public virtual List<Product> Produts { get; set; }
        // 备用字段
        [Display(Name = "场景分类")]
        public string FreeOne { get; set; }
        public string FreeTwo { get; set; }
        public string FreeThree { get; set; }
    }
}