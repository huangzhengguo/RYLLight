$(document).ready(function () {
    // 菜单点击事件
    $('#News').click(function (e) {
        e.preventDefault()
        $('html,body').animate({ scrollTop: $('#companyNews').offset().top - 75 }, 1000)
    });
    $('#Products').click(function (e) {
        e.preventDefault()
        $('html,body').animate({ scrollTop: $('#productScenes').offset().top - 75 }, 1000)
    });
    $('#Company').click(function (e) {
        e.preventDefault()
        $('html,body').animate({ scrollTop: $('#companyIntroduce').offset().top - 75 }, 1000)
    });
    $('#Contact_Us').click(function (e) {
        e.preventDefault()
        $('html,body').animate({ scrollTop: $('#contact').offset().top - 75 }, 1000)
    });

    // 新闻切换事件
    for (var j = 1; j < 5; j++) {
        
        if (j % 2 == 0) {
            $("#newsImg" + j).mouseenter(function (e) {
                switchNewsImg(false)
            });
            $("#newsImg" + j).click(function (e) {
                switchNewsImg(false)
            });
        } else {
            $("#newsImg" + j).mouseenter(function (e) {
                switchNewsImg(true)
            });
            $("#newsImg" + j).click(function (e) {
                switchNewsImg(true)
            });
        }

        if (j == 1 || j == 4) {
            $("#newsImg" + j).mouseenter(function (e) {
                $(this).animate({
                    width: this.width + 10 + "px",
                    height: this.height + 20 + "px"
                }, 100);
            });

            $("#newsImg" + j).mouseout(function (e) {
                $(this).animate({
                    width: this.width - 10 + "px",
                    height: this.height - 20 + "px"
                }, 100);
            });
        } else {
            var k = 0
            if (j == 2) {
                k = 4
            } else {
                k = 1
            }

            $("#newsImg" + j).mouseenter(function (e) {
                $("newsImg" + k).animate({
                    width: $("newsImg" + k).width + 10 + "px",
                    height: $("newsImg" + k).height + 20 + "px"
                }, 100);
            });
        }

    }

    // 切换新闻背景及文字描述
    function switchNewsImg(isFirst) {
        if (isFirst == true) {
            // 切换到第二个
            $("#companyNews").css("display","block")
            $("#companyNews1").css("display","none")
        } else {
            $("#companyNews").css("display","none")
            $("#companyNews1").css("display","block")
        }
    }

    // 产品数据标签页切换事件
    $('.nav.nav-tabs a').click(function (e) {
        e.preventDefault()
        $(this).tab('show')
    });

    // 新闻图片动画
})


