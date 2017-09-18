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
    for (var j = 0; j < 4; j++) {
        if (j % 2 == 0) {
            $("#newsImg" + j).mousemove(function (e) {
                switchNewsImg(false)
            });
            $("#newsImg" + j).click(function (e) {
                switchNewsImg(false)
            });
        } else {
            $("#newsImg" + j).mousemove(function (e) {
                switchNewsImg(true)
            });
            $("#newsImg" + j).click(function (e) {
                switchNewsImg(true)
            });
        }

    }

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

    // 点击场景显示对应场景下的产品
})


