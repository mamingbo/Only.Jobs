//======================================================================
// Copyright (c) Only.Jobs  development team. All rights reserved.
// 所属项目：Only.Jobs js.controller
// 创 建 人：Only.Jobs development team
// 创建日期：2017-07-06 16:21:57
// 用    途：后台任务 (BackgroundJob)js控制器
//======================================================================

/**
*加载后台任务列表
**/
function BackgroundJobLogListController($scope, $http, $window) {
    var gridId = 'data_grid';
    $scope.LoadBackgroundJobLogList = function () {
        oUtils.jqGrid({
            gridId: gridId,
            url: '/BackgroundJobLog/List?r=' + Math.random(),
            dataIdKey: 'BackgroundJobLogId',
            isPager: true,
            colNames: [
                         "操作",
                        "记录ID",
                        "JobId",
                        "名称",
                        "执行时间",
                        "执行持续时长",
                        "创建日期时间",
                        "日志内容",
            ],
            colModel: [
                        { name: 'BackgroundJobLogId', index: 'BackgroundJobLogId', width: 75, formatter: $scope.formatModel, edittype: 'custom' },
                        { name: "BackgroundJobLogId", width: 60, index: "BackgroundJobLogId", sortable: false, hidden: true },
                        { name: "BackgroundJobId", width: 60, index: "BackgroundJobId", sortable: false, hidden: true },
                        { name: "JobName", width: 150, index: "JobName", sortable: false },
                        { name: "ExecutionTime", width: 145, index: "ExecutionTime", sortable: false },
                        { name: "ExecutionDuration", width: 80, index: "ExecutionDuration", sortable: false },
                        { name: "CreatedDateTime", width: GridCreatedDateTimeWidth, index: "CreatedDateTime", sortable: false },
                        { name: "RunLog", width: 250, index: "RunLog", sortable: false },
            ]
        });
    };

    $scope.formatModel = function (cellValue, options, rowObject) {
        var btns = [];
        btns.push('<a href="javascript:void(0);" onclick="ShowEditFrame(\'' + cellValue + '\')" class="btn btn-info btn-xs" >详情</a>');
        return btns.join('&nbsp;&nbsp;&nbsp;&nbsp;');
    };

    $scope.model = {
        JobName: '',
    };

    $(function () {
        $scope.LoadBackgroundJobLogList();

        $(".query-container .btn-search").click(function () {
            var parameter = "";
            parameter += 'JobName:' + "'" + escape($scope.model.JobName) + "'";
            oUtils.jqGrid.search(gridId, parameter);
        });
    });
};


/**
*后台任务修改视图控制器
**/
function BackgroundJobLogInfoController($scope, $http, $window) {

    var request = oUtils.urlParameter();
    var BackgroundJobLogId = request["BackgroundJobLogId"];

    $scope.model = {
        BackgroundJobLogId: BackgroundJobLogId,
        BackgroundJobId: '',
        Name: '',
        ExecutionTime: '',
        ExecutionDuration: '',
        RunLog: '',
    };

    $scope.LoadBackgroundJobLogInfo = function () {
        $scope.model.BackgroundJobLogId = BackgroundJobLogId;
        $http({
            method: 'GET',
            url: '/BackgroundJobLog/InfoData?r=' + Math.random(),
            cache: false,
            params: { BackgroundJobLogId: BackgroundJobLogId }
        })
       .success(function (result, status, headers, config) {
           if (result.success) {
               $scope.model = result.data;
           } else {
               oUtils.alertError(result.message);
           }
       })
       .error(function (result, status, headers, config) {
           alert(result.message || '请求过程中发生异常');
       });
    };


    $(function () {
        $scope.LoadBackgroundJobLogInfo();
    });
};