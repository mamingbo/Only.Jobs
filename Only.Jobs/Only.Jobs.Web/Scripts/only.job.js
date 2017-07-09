var EmptyGUID = '00000000-0000-0000-0000-000000000000';

var GridUserNameWidth = 85;
var GridDateTimeWidth = 135;
var GridDisplayOrderWidth = 45;
var GridCreatedByUserNameWidth = 100;
var GridCreatedDateTimeWidth = 140;
var GridLastUpdatedByUserNameWidth = 100;
var GridLastUpdatedDateTimeWidth = 140;

; !function (a, undefined) {
    var b = function () { };

    b.jqGrid = function (options) {
        var settings = {
            gridId: 'data_grid',
            isPager: false,
            dataIdKey: "",
            mtype: 'GET',
            rownumbers: true,
            autowidth: true,
            shrinkToFit: false,
            autoScroll: true,
            height: 330,
            rowNum: 20,
            rowList: [20, 30, 50, 200],
            datatype: 'json',
            sortable: true,
            sortorder: 'asc',
            sortname: 'ID',
            viewrecords: true,
            multiselect: true,
            sortable: true,
            pager: '#grid_pager_bar',
            gridComplete: function () {
                $('#' + settings.gridId).closest(".ui-jqgrid-bdiv").css({ 'overflow-x': 'scroll' });
                $('#' + settings.gridId).closest(".ui-jqgrid-bdiv").css({ 'overflow-y': 'scroll' });
            },
        };
        jQuery.extend(settings, options);
        var jsonReader = {};
        if (settings.isPager == true) {
            jsonReader = {
                root: "data.dataList",
                page: "data.CurrentPage",
                total: "data.TotalPage",
                records: "data.TotalRecord",
                id: settings.dataIdKey
            };
        } else {
            jsonReader = {
                root: "data",
                id: settings.dataIdKey
            };
        }
        settings.jsonReader = jsonReader;
        $('#' + settings.gridId).jqGrid(settings).navGrid(settings.pager, {
            add: false,
            edit: false,
            del: false,
            search: false
        });

    },

    b.jqGrid.search = function (gridId, postData) {
        var ParamJson = '{' + postData + '}';
        var postData = $('#' + gridId).jqGrid("getGridParam", "postData");
        $.extend(postData, { Param: ParamJson });
        $('#' + gridId).jqGrid("setGridParam", { search: true, datatype: 'json' }).trigger("reloadGrid", [{ page: 1 }]);  //重载JQGrid
    },

    b.urlParameter = function () {
        var url = location.search; //获取url中"?"符后的字串
        var theRequest = new Object();
        if (url.indexOf("?") != -1) {
            var str = url.substr(1);
            if (str.indexOf("&") != -1) {
                var strs = str.split("&");
                for (var i = 0; i < strs.length; i++) {
                    theRequest[strs[i].split("=")[0]] = unescape(decodeURI(strs[i].split("=")[1]));
                }
            } else {
                var key = str.substring(0, str.indexOf("="));
                var value = str.substr(str.indexOf("=") + 1);
                theRequest[key] = decodeURI(value);
            }
        }
        return theRequest;
    }

    b.showIframe = function (options) {
        var settings = {
            areaWidth: options.areaWidth ? options.areaWidth : '700px',
            areaHeight: options.areaHeight ? options.areaHeight : '530px',
            Url: options.Url ? options.Url : "",
            title: options.title ? options.title : false,
            beforeClose: options.beforeClose ? options.beforeClose : {},
            end: options.end ? options.end : {}
        };
        jQuery.extend(settings, options);

        window.parent.layer.open({
            type: 2,
            area: [options.areaWidth, options.areaHeight],
            fix: false,
            scrollbar: true,
            title: options.title,
            maxmin: false,
            content: options.Url,
            beforeClose: function (index) {
                "function" == typeof options.beforeClose && options.beforeClose(index);
            },
            end: function () {
            },
            success: function (layero, index) {

            }
        });

    },

    b.alertSuccess = function (msg, callback) {
        if (msg == null) {
            msg = 'There is no content';
        }
        layer.alert(msg, { icon: 1 }, function (index) {
            if (callback)
                callback();
        });
    }

    b.alertError = function (msg) {
        if (msg == null) {
            msg = 'There is no content';
        }
        layer.alert(msg, { icon: 7 });
    }

    window.alert = function (msg) {
        if (msg == null) {
            msg = 'There is no content';
        }
        layer.alert(msg, { icon: 7 });
    }

    b.Init = function () {
        var self = this;
    }
    ;

    a.oUtils = a.oUtils || b;

}(window);


/** angular app initialize **/
var app = angular.module('app', []);
app.config(['$httpProvider', function ($httpProvider) {
    $httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';
    //$httpProvider.defaults.headers.common["RequestVerificationToken"] = requestVerificationToken;
}]);


$(function () {

    //jgrid default ui setting
    if (typeof ($.jgrid) != 'undefined') {
        $.jgrid.defaults.styleUI = "Bootstrap";
    }

    //面板机能初始化
    oUtils.Init();

});