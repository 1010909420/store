    

//js获取URL参数
function GetRequest() {
    var url = location.search; //获取url中"?"符后的字串
    var theRequest = new Object();
    if (url.indexOf("?") != -1) {
        var str = url.substr(1);
        strs = str.split("&");
        for (var i = 0; i < strs.length; i++) {
            theRequest[strs[i].split("=")[0]] = unescape(strs[i].split("=")[1]);
        }
    }
    return theRequest;
}

var $_Request = new Object();
$_Request = GetRequest();
// var 参数1,参数2,参数3,参数N;
// 参数1 = $_Request['参数1'];
// 参数2 = $_GET['参数2'];
// 参数3 = $_GET['参数3'];
// 参数N = $_GET['参数N'];


//js获取URL参数
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}


$(function () {
    //if (localStorage.getItem("menuState") == "0")
    //    collapseMenu();

    //根据bootstrap定义，横向小于768像素为超小屏幕
    if (document.documentElement.clientWidth < 768)
        $("#toggleLeft").attr("checked", "checked");//若设备屏幕宽度过小则收起菜单

    //function collapseMenu() {
    //    $('left-content').css('width', '0px');        
    //    $('left-bar').css('width', '0px');
    //    localStorage.setItem("menuState", "0");//菜单状态设为0
    //    //$('right-bar').css('width', '100%');
    //    //$('right-content').css('width', '100%');
    //}

    //function expandMenu() {
    //    $('left-content').css('width', '200px');
    //    $('left-bar').css('width', '200px');
    //    localStorage.setItem("menuState", "1");//菜单状态设为已展开
    //    //$('right-content').css('width', '80%');
    //    //$('right-bar').css('width', '80%');
    //}

    ////左侧菜单折叠切换按钮
    //$('#toggleLeft').on('click', function (e) {

    //    if ($('left-bar').css('width') != '0px') {
    //        collapseMenu();
    //    } else {
    //        expandMenu();
    //    }
    //});

    //构建List视图里面列头的排序超链接
    $(".table tr[class=bg-blue] a").each(function (idx, ele) {
        var i = $(ele).data("index");
        //alert(i);
        var isDe = false;//默认将要进行升序
        if ($_Request['o'] && $_Request['de'] && $_Request['o'] == i) {
            if ($_Request['de'] == 'false') {
                isDe = true;//当前升序，将要进行降序
                $(ele).append(' <i class="fa fa-caret-up"></i>');
            } else {
                isDe = false;//当前降序，将要进行升序
                $(ele).append(' <i class="fa fa-caret-down"></i>');
            }
        }
        var url = urlEdit(location.href, "o", i);
        url = urlEdit(url, "de", isDe);

        $(ele).attr("href", url);
    });

    ////处理数字域
    //$(".numeric").numericInput({ allowFloat: true, allowNegative: true });

    ////须放在加载Vue数据加载完毕后处理
    //$(".datetimepicker").flatpickr({ "locale": "zh", "dateFormat": "Y-m-d H:i:S", enableTime: true});
    //$(".datepicker").flatpickr({ "locale": "zh", "dateFormat": "Y-m-d H:i:S" });

    ////表单提交统一处理
    //$('#EditForm').validator().on('submit', function (e) {
    //    if (e.isDefaultPrevented()) {
    //        //js表单验证不通过
    //    } else {
    //        //防止提交表单数据，改用Ajax提交，地址为form里面定义的路径
    //        e.preventDefault();
    //        //e.defaultPrevented();
    //        $('#EditForm').ajaxSubmit({
    //            type: 'post',
    //            dataType: 'json',
    //            success: function (json) {
    //                //var json = eval("(" + data + ")");//转换为json对象（如果用JsonResult返回的话则不需要手动转换）
    //                msg(json.message);
    //                if (json.success) {
    //                    setTimeout('location.href = "List"', 1500);
    //                }
    //            },
    //            error: function () {
    //                alert('出错了，请检查网络');
    //            }
    //        });
    //    }
    //});

    var terms = $.trim($("#search").val()).split(' ');//获取关键字列表

    //遍历grid里面的数据列，操作列除外
    $(".panel td.td-text").each(function () {
        var temp = $(this).text();
        //构造正则表达式，忽略大小写
        var reg = "/" + terms.join("|") + "/ig";
        //利用js replace函数结合正则表达式和回调函数，把匹配到的字符串先用特殊符号分隔开
        temp = temp.replace(eval(reg), function (str) { return "<span style='color:red'>" + str + "</span>" });
        $(this).html(temp);
    });

});


toastr.options = {
    "closeButton": false,
    "debug": false,
    "newestOnTop": false,
    "progressBar": false,
    "positionClass": "toast-bottom-center",
    "preventDuplicates": true,
    "onclick": null,
    "showDuration": "3500",
    "hideDuration": "1500",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}

//toast提示
window.toast = function (text) {
    toastr.info(text);
}

//简易的弹窗
function msg(content) {
    //BootstrapDialog.alert({
    //    title: '系统提示',
    //    draggable: true,
    //    message: content,
    //    buttons: [{
    //        label: '确认',
    //        action: function (dialog) {
    //            dialog.close();
    //        }
    //    }]
    //});
    toastr.info(content);
}

//搜索
function doSearch() {
    var criteria = $("#search").val();
    toast(criteria);
    location.href = "?s=" + criteria;
}

//放弃修改并刷新的确认
function abandon() {
    BootstrapDialog.show({
        title: '系统提示',
        message: '您确定要放弃修改么？',
        buttons: [{
            label: '确认',
            action: function (dialog) {
                $('#EditForm').resetForm();
                dialog.close();
            }
        }, {
            label: '取消',
            action: function (dialog) {
                dialog.close();
            }
        }]
    });
}

//ajax统一的错误处理方法
function errorHandler(data, errMsg, ex) {
    var err = eval("(" + data.responseText + ")");
    if (err != null) {
        alert(ex + ": " + err.Message);
    } else {
        alert(ex + ": " + errMsg);
    }
}

//删除确认
function delConfirm(id, callback) {
    var HTML = "<div class='box no-border' style='width:100%;height:100%;'>";
    HTML += '您确定要删除ID为<span style="color:red"> ' + id + ' </span>的记录吗?<br/>请注意，记录一经删除则不可恢复！';
    HTML += '<div id="loading" class="overlay hidden"> <i class="fa fa-refresh fa-spin"></i></div>';
    HTML += "</div>";

    BootstrapDialog.show({
        title: '系统提示',
        message: $(HTML),
        buttons: [{
            label: '确认',
            action: function (dialog) {
                //提交到本页面删除数据
                $.ajax({
                    async: false,//异步
                    type: "get",
                    url: "Del",
                    data: { 'id': id },
                    success: function (json) {
                        $("#loading").addClass("hidden");
                        //var json = eval("(" + data + ")");//转换为json对象
                        toast(json.message);

                        if (json.success) {
                            if (callback)
                                callback();
                            else
                                setTimeout("window.location.href = document.referrer;", 2500);
                        }
                    },
                    error: function () {
                        $("#loading").addClass("hidden");
                        alert('出错了，请检查网络');
                    }
                });
            }
        }, {
            label: '取消',
            action: function (dialog) {
                dialog.close();
            }
        }]
    });
}

 

// 对Date的扩展，将 Date 转化为指定格式的String   
// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符，   
// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字)   
// 例子：   
// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423   
// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18   
Date.prototype.Format = function (fmt) { //author: meizz   
    var o = {
        "M+": this.getMonth() + 1,                 //月份   
        "d+": this.getDate(),                    //日   
        "h+": this.getHours(),                   //小时   
        "m+": this.getMinutes(),                 //分   
        "s+": this.getSeconds(),                 //秒   
        "q+": Math.floor((this.getMonth() + 3) / 3), //季度   
        "S": this.getMilliseconds()             //毫秒   
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var k in o)
        if (new RegExp("(" + k + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    return fmt;
};



function urlEdit(url, key, value) {
    var strs = new Array();

    if (url.indexOf("?") != -1) {
        var found = false;
        var i = 0;
        var str = url.split("?")[1];
        strs = str.split("&");

        for (; i < strs.length; i++) {
            if (strs[i].split("=")[0] == key) {
                strs[i] = key + "=" + value;
                found = true;
                break;
            }
        }
        //strs.splice(i, 1);
        if (found)
            return url.split('?')[0] + "?" + strs.join("&");
        else
            return url + "&" + key + "=" + value;
    } else {
        return url + "?" + key + "=" + value;
    }
}


//搜索
function doSearch() {
    //toast(location.href.split("/")[location.href.split("/").length-1]);
    var action = location.href.split("/")[location.href.split("/").length - 1];
    location.href = urlEdit(urlEdit(location.href.replace(action, "list"), "s", $("#search").val()), "p", 1);
}

function enterSumbit() {
    var event = arguments.callee.caller.arguments[0] || window.event;//消除浏览器差异    
    if (event.keyCode == 13) {//回车键
        doSearch();
    }
}

function RenderComboBox(app, eleId) {
    //等待Vue数据填充及渲染完毕事件
    //app.$nextTick(function () {
        $('#' + eleId).combobox({
            fitToElement: true,
            items: 50,
            afterSelect: function (v, l) {
                app.entity[eleId] = v;
            }
        });
    //});
}

//加载外键选项
function LoadFKOptions(app, FKName, isComboBox = false) {
    $.ajax({
        url: 'Get' + FKName + 's',
        success: function (json) {
            if (json.success) {
                app[FKName + 's'] = json.data;
                //如果需要做成自定义combobox
                if (isComboBox == true) {
                    setTimeout(function () {
                        $('#' + FKName).combobox({
                            fitToElement: true,
                            items: 50,
                            afterSelect: function (v, l) {
                                app.entity[FKName] = v;
                            }
                        });
                    }, 10);
                    
                }
            }
        }
    });
}