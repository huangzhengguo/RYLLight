$(document).ready(function () {
    // 菜单点击事件
    var currentClickMenu = ""
    $('#News').click(function (e) {
        e.preventDefault()
        setMenuTitleColor("News")
        $('html,body').animate({ scrollTop: $('#companyNews').offset().top - 75 }, 1000)
    });

    $('#Products').click(function (e) {
        e.preventDefault()
        setMenuTitleColor("Products")
        $('html,body').animate({ scrollTop: $('#productScenes').offset().top - 75 }, 1000)
    });

    $('#Company').click(function (e) {
        e.preventDefault()
        setMenuTitleColor("Company")
        $('html,body').animate({ scrollTop: $('#companyIntroduce').offset().top - 75 }, 1000)
    });

    $('#Contact_Us').click(function (e) {
        e.preventDefault()
        setMenuTitleColor("Contact_Us")
        $('html,body').animate({ scrollTop: $('#contact').offset().top - 75 }, 1000)
    });

    function setMenuTitleColor(menuId) {
        if (currentClickMenu != "") {
            $("#" + currentClickMenu).css("color", "#000000")
        }

        currentClickMenu = menuId
        $("#" + currentClickMenu).css("color", "#f37044")
    }

    // 滑动变色
    var currentEelment = ""
    $("a").mouseenter(function (e) {
        $(this).css("color", "#f37044")
    })

    $("a").mouseleave(function (e) {
        if (currentEelment == this) {
            $(this).css("color", "#f37044")
        } else {
            $(this).css("color", "#000000")
        }
    })

    $("a").click(function (e) {
        if (currentEelment != "") {
            $(currentEelment).css("color", "#000000")
        }

        $(this).css("color", "#f37044")
        currentEelment = this
    })

    // 新闻切换事件，全局变量
    var imgWidth = 0
    var imgHeight = 0
    var gIsFirstEnter = true
    for (var j = 1; j < 5; j++) {
        
        if (j == 2) {
            $("#newsImg" + j).mouseenter(function (e) {
                switchNewsImg(false)
            });
            $("#newsImg" + j).click(function (e) {
                switchNewsImg(false)
            });
        } else if (j == 3) {
            $("#newsImg" + j).mouseenter(function (e) {
                switchNewsImg(true)
            });
            $("#newsImg" + j).click(function (e) {
                switchNewsImg(true)
            });
        }

        if (j == 1 || j == 4) {
            $("#newsImg" + j).mouseenter(function (e) {
                // 第一次进来时，记录图片的大小，用作恢复图片大小
                if (gIsFirstEnter == true) {
                    //imgWidth = this.width
                    //imgHeight = this.height
                    gIsFirstEnter = false
                }

                /*
                $(this).animate({
                    width: imgWidth + 10 + "px",
                    height: imgHeight + 20 + "px"
                }, 100);*/
            });

            $("#newsImg" + j).mouseleave(function (e) {
                /*
                $(this).animate({
                    width: imgWidth + "px",
                    height: imgHeight + "px"
                }, 100);*/
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

    // Ajax刷新局部页面后，其中元素使用jquery绑定的事件失效，
    // 这里的绑定需要使用delegate来进行事件绑定
    $("#productSceneProduct").delegate('.nav.nav-tabs a', 'click', function (e) {
        e.preventDefault()
        $(this).tab('show')
    }
    )

    // 新闻背景高度调整
    /*
    var backgroundImg = new Image()
    $(window).resize(function (){
        // 获取新闻背景图片
        
        backgroundImg.src = $("#companyIntroduce").css('background-image').replace('url(', '').replace(')', '').replace("'", '').replace('"', '');
        console.log(backgroundImg.height + "px")
        console.log("哈哈")
        $("#companyIntroduce").css("height", backgroundImg.height + "px")
    } 
    )*/
})


