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
function BackgroundJobListController($scope, $http, $window) {
    var gridId = 'data_grid';
    $scope.LoadBackgroundJobList = function () {
        oUtils.jqGrid({
            gridId: gridId,
            url: '/BackgroundJob/List?r=' + Math.random(),
            dataIdKey: 'BackgroundJobId',
            isPager: true,
            colNames: [
                        "操作",
                        "记录ID",
                        "名称",
                        "状态",
                        "类型",
                        "程序集名称",
                        "类名",
                        "最后运行时间",
                        "下次运行时间",
                        "总运行次数",
                          "描述",
                        "Cron表达式",
                        "Cron表达式描述",
                        "创建人姓名",
                        "创建日期时间",
                        "最后更新人姓名",
                        "最后更新时间"
            ],
            colModel: [
                        { name: 'BackgroundJobId', index: 'BackgroundJobId', width: 120, formatter: $scope.formatModel, edittype: 'custom', hidden: false },
                        { name: "BackgroundJobId", width: 60, index: "BackgroundJobId", sortable: false, hidden: true },
                        { name: "Name", width: 150, index: "Name", sortable: false },
                        { name: "State", width: 105, index: "State", sortable: false, formatter: $scope.formatState },
                        { name: "JobType", width: 80, index: "JobType", sortable: false },
                        { name: "AssemblyName", width: 140, index: "AssemblyName", sortable: false },
                        { name: "ClassName", width: 130, index: "ClassName", sortable: false },
                        { name: "LastRunTime", width: 135, index: "LastRunTime", sortable: false },
                        { name: "NextRunTime", width: 135, index: "NextRunTime", sortable: false },
                        { name: "RunCount", width: 80, index: "RunCount", sortable: false },
                         { name: "Description", width: 140, index: "Description", sortable: false },
                        { name: "CronExpression", width: 100, index: "CronExpression", sortable: false },
                        { name: "CronExpressionDescription", width: 110, index: "CronExpressionDescription", sortable: false },
                        { name: "CreatedByUserName", width: GridCreatedByUserNameWidth, index: "CreatedByUserName", sortable: false },
                        { name: "CreatedDateTime", width: GridCreatedDateTimeWidth, index: "CreatedDateTime", sortable: false },
                        { name: "LastUpdatedByUserName", width: GridLastUpdatedByUserNameWidth, index: "LastUpdatedByUserName", sortable: false },
                        { name: "LastUpdatedDateTime", width: GridLastUpdatedDateTimeWidth, index: "LastUpdatedDateTime", sortable: false },
            ]
        });
    };

    $scope.formatModel = function (cellValue, options, rowObject) {
        var btns = [];
        btns.push('<a href="javascript:void(0);" onclick="ShowEditFrame(\'' + cellValue + '\')" class="btn btn-info  btn-xs" >编辑</a>');

        //状态 0-停止  1-运行   3-正在启动中...   5-停止中...
        var State = rowObject.State;
        if (State == 0) {
            btns.push('<a href="javascript:void(0);" onclick="SetState(\'' + cellValue + '\',3)" class="btn btn-success  btn-xs" >启用</a>');
        } else if (State == 1) {
            btns.push('<a href="javascript:void(0);" onclick="SetState(\'' + cellValue + '\',5)" class="btn btn-warning  btn-xs" >停止</a>');
        }
        return btns.join('&nbsp;&nbsp;&nbsp;&nbsp;');
    };

    $scope.formatState = function (cellValue, options, rowObject) {
        //状态 0-停止  1-运行   3-正在启动中...   5-停止中...
        var state = rowObject.State;
        if (state == 0) {
            return '<span class="label label-warning">停止</span>';
        } else if (state == 1) {
            return '<span class="label label-primary">运行</span>';
        } else if (state == 3) {
            return '<span class="label label-info">启动中...</span>';
        } else if (state == 5) {
            return '<span class="label label-info">停止中...</span>';
        } else {
            return '<span class="label label-danger">未知</span>';
        }
    };


    $scope.model = {
        Name: ''
    };

    $(function () {
        $scope.LoadBackgroundJobList();

        $(".query-container .btn-search").click(function () {
            var parameter = "";
            parameter += 'Name:' + "'" + escape($scope.model.Name) + "'";
            oUtils.jqGrid.search(gridId, parameter);
        });
    });
};

/**
*后台任务新增视图控制器
**/
function BackgroundJobAddController($scope, $http, $window) {
    $scope.model = {
        BackgroundJobId: EmptyGUID,
        JobType: '',
        Name: '',
        AssemblyName: '',
        ClassName: '',
        Description: '',
        JobArgs: '',
        CronExpression: '',
        CronExpressionDescription: '',
        NextRunTime: '',
        LastRunTime: '',
        RunCount: '',
        State: '0',
        DisplayOrder: '0',
    };
    $scope.SubmitAdd = function () {
        if (!$('#form').validationEngine('validate')) {
            return;
        }
        $http({
            method: 'POST',
            url: '/BackgroundJob/AddPost?r=' + Math.random(),
            data: $scope.model
        })
       .success(function (result, status, headers, config) {

           if (result.success) {
               oUtils.alertSuccess('保存成功', function () {
                   $("#opt_is_success").val('true');
                   parent.layer.close(parent.layer.getFrameIndex(window.name));
               });
           } else {
               oUtils.alertError('保存失败');
           }
       })
       .error(function (result, status, headers, config) {
           alert(result.message || '操作过程中发生异常');
       });
    };
};

/**
*后台任务修改视图控制器
**/
function BackgroundJobUpdateController($scope, $http, $window) {

    var request = oUtils.urlParameter();
    var BackgroundJobId = request["BackgroundJobId"];

    $scope.model = {
        BackgroundJobId: BackgroundJobId,
        JobType: '',
        Name: '',
        AssemblyName: '',
        ClassName: '',
        Description: '',
        JobArgs: '',
        CronExpression: '',
        CronExpressionDescription: '',
        NextRunTime: '',
        LastRunTime: '',
        RunCount: '',
        State: '',
        DisplayOrder: '',
    };

    $scope.LoadBackgroundJobInfo = function () {
        $scope.model.BackgroundJobId = BackgroundJobId;
        $http({
            method: 'GET',
            url: '/BackgroundJob/InfoData?r=' + Math.random(),
            cache: false,
            params: { BackgroundJobId: BackgroundJobId }
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

    $scope.SubmitUpdate = function () {
        if (!$('#form').validationEngine('validate')) {
            return;
        }
        $http({
            method: 'POST',
            url: '/BackgroundJob/UpdatePost?r=' + Math.random(),
            data: $scope.model
        })
        .success(function (result, status, headers, config) {
            if (result.success) {
                oUtils.alertSuccess('保存成功', function () {
                    $("#opt_is_success").val('true');
                    parent.layer.close(parent.layer.getFrameIndex(window.name));
                });
            } else {
                oUtils.alertError('保存失败');
            }
        })
        .error(function (result, status, headers, config) {
            alert(result.message || '请求过程中发生异常');
        });
    };

    $(function () {
        $scope.LoadBackgroundJobInfo();
    });
};
