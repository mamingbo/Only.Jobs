/*
Navicat MySQL Data Transfer

Source Server         : 127.0.0.1
Source Server Version : 50523
Source Host           : 127.0.0.1:3306
Source Database       : only.jobs

Target Server Type    : MYSQL
Target Server Version : 50523
File Encoding         : 65001

Date: 2017-08-01 11:51:43
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for `backgroundjob`
-- ----------------------------
DROP TABLE IF EXISTS `backgroundjob`;
CREATE TABLE `backgroundjob` (
  `BackgroundJobId` char(36) NOT NULL COMMENT 'JobID',
  `JobType` varchar(50) DEFAULT NULL COMMENT 'Job类型',
  `Name` varchar(255) DEFAULT NULL COMMENT 'Job名称',
  `Description` varchar(255) DEFAULT NULL COMMENT '描述',
  `AssemblyName` varchar(255) DEFAULT NULL COMMENT '程序集名称',
  `ClassName` varchar(255) DEFAULT NULL COMMENT '类名',
  `JobArgs` varchar(255) DEFAULT NULL COMMENT '参数',
  `CronExpression` varchar(255) DEFAULT NULL COMMENT 'Cron表达式',
  `CronExpressionDescription` varchar(255) DEFAULT NULL COMMENT 'Cron表达式描述',
  `LastRunTime` datetime DEFAULT NULL COMMENT '最后运行时间',
  `NextRunTime` datetime DEFAULT NULL COMMENT '下次运行时间',
  `RunCount` int(11) NOT NULL DEFAULT '0' COMMENT '运行次数',
  `State` int(11) NOT NULL DEFAULT '0' COMMENT '0-运行   2-停止',
  `DisplayOrder` int(11) NOT NULL DEFAULT '0' COMMENT '排序',
  `CreatedByUserId` varchar(40) DEFAULT NULL COMMENT '创建人ID',
  `CreatedByUserName` varchar(80) DEFAULT NULL COMMENT '创建人姓名',
  `CreatedDateTime` datetime NOT NULL COMMENT '创建日期时间',
  `LastUpdatedByUserId` varchar(40) DEFAULT NULL COMMENT '最后更新人ID',
  `LastUpdatedByUserName` varchar(80) DEFAULT NULL COMMENT '最后更新人姓名',
  `LastUpdatedDateTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '最后更新时间',
  `IsDelete` int(11) NOT NULL DEFAULT '0' COMMENT '是否删除',
  PRIMARY KEY (`BackgroundJobId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='后台任务';

-- ----------------------------
-- Records of backgroundjob
-- ----------------------------
INSERT INTO `backgroundjob` VALUES ('1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'Test', 'TestC', 'TestC', 'Only.Jobs.Items.TestC.dll', 'Only.Jobs.Items.TestC.JobTestC', null, '0/6 * * * * ?', '每隔6秒执行一次', '2017-07-26 09:35:42', '2017-07-26 09:35:48', '110', '1', '0', null, null, '2017-07-26 09:19:24', null, null, '2017-07-26 09:19:24', '0');
INSERT INTO `backgroundjob` VALUES ('6542715c-4378-4c19-92cb-c1a4ecb552c1', 'Test', 'TestB', 'TestB', 'Only.Jobs.Items.TestB.dll', 'Only.Jobs.Items.TestB.JobTestB', null, '0/5 * * * * ?', '每隔5秒执行一次', null, null, '0', '0', '0', null, null, '2017-07-26 09:18:58', null, null, '2017-07-26 09:18:58', '0');
INSERT INTO `backgroundjob` VALUES ('9438ca5a-320d-4784-b353-5bba2ea45b4c', 'Test', 'TestA', 'TestA', 'Only.Jobs.Items.TestA.dll', 'Only.Jobs.Items.TestA.JobTestA', null, '0/4 * * * * ?', '每隔4秒执行一次', '2017-07-26 09:35:44', '2017-07-26 09:35:48', '166', '1', '0', null, null, '2017-07-25 17:33:48', null, null, '2017-07-26 09:18:27', '0');
INSERT INTO `backgroundjob` VALUES ('da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理', 'Job管理器', '负责Job的动态调度', 'Only.Jobs.exe', 'Only.Jobs.JobItems.ManagerJob', null, '0/3 * * * * ?', '每隔3秒执行一次', '2017-07-26 09:35:45', '2017-07-26 09:35:48', '221', '1', '0', null, null, '2017-07-25 14:01:57', null, null, '2017-07-25 14:01:57', '0');

-- ----------------------------
-- Table structure for `backgroundjoblog`
-- ----------------------------
DROP TABLE IF EXISTS `backgroundjoblog`;
CREATE TABLE `backgroundjoblog` (
  `BackgroundJobLogId` char(36) NOT NULL COMMENT '日志ID',
  `BackgroundJobId` char(36) DEFAULT NULL COMMENT 'JobID',
  `JobName` varchar(255) DEFAULT NULL COMMENT 'Job名称',
  `ExecutionTime` datetime DEFAULT NULL COMMENT '执行时间',
  `ExecutionDuration` decimal(18,2) DEFAULT NULL COMMENT '执行持续时间',
  `CreatedDateTime` datetime NOT NULL COMMENT '创建日期时间',
  `RunLog` text COMMENT '日志内容',
  PRIMARY KEY (`BackgroundJobLogId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='后台任务运行日志';

-- ----------------------------
-- Records of backgroundjoblog
-- ----------------------------
INSERT INTO `backgroundjoblog` VALUES ('009a8a24-dc6f-4cff-acca-50afeb548ebe', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:28:06', '0.00', '2017-07-26 09:28:06', '');
INSERT INTO `backgroundjoblog` VALUES ('00defef6-1158-4d99-8705-e186a77c9490', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:30:36', '0.02', '2017-07-26 09:30:36', '');
INSERT INTO `backgroundjoblog` VALUES ('012f2d57-af64-4863-82b9-79a2519c63e9', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:29:32', '0.00', '2017-07-26 09:29:32', '[extend_logA:JobTestA Executing2017/7/26 9:29:32,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('01619dcd-01bf-4208-8895-1582f22802d6', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:32:00', '0.01', '2017-07-26 09:32:00', '[extend_logA:JobTestA Executing2017/7/26 9:32:00,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('019ca3dd-9adb-412c-8ff2-a371ab2a64c0', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:30:54', '0.01', '2017-07-26 09:30:54', '');
INSERT INTO `backgroundjoblog` VALUES ('01ac2260-693c-4bb6-b9b0-ab70f16773d9', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:30:04', '0.00', '2017-07-26 09:30:04', '[extend_logA:JobTestA Executing2017/7/26 9:30:04,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('03c274b1-d12e-438b-8188-4a7cd1641c96', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:34:36', '0.00', '2017-07-26 09:34:36', '[extend_logA:JobTestA Executing2017/7/26 9:34:36,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('04375c51-0814-4ce4-9012-dd04d85a9982', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:28:48', '0.01', '2017-07-26 09:28:48', '');
INSERT INTO `backgroundjoblog` VALUES ('043f1fde-197c-4fd6-8f85-34b19f4d5577', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:29:40', '0.00', '2017-07-26 09:29:40', '[extend_logA:JobTestA Executing2017/7/26 9:29:40,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('04495a04-8ea0-4e7d-b2c4-192da3585cab', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:29:10', '0.01', '2017-07-26 09:29:10', '');
INSERT INTO `backgroundjoblog` VALUES ('059186e1-ad40-4653-9fcc-4645df83c32a', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:35:09', '0.01', '2017-07-26 09:35:09', '');
INSERT INTO `backgroundjoblog` VALUES ('0603c0b2-a693-4ead-982d-93f3f057e5d4', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:31:36', '0.01', '2017-07-26 09:31:36', '');
INSERT INTO `backgroundjoblog` VALUES ('06a48e15-33d4-48f7-8fba-33ed417a4c32', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:32:08', '0.00', '2017-07-26 09:32:08', '[extend_logA:JobTestA Executing2017/7/26 9:32:08,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('06ec4d5e-9469-4aa1-8a41-848779c6b846', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:27:48', '0.02', '2017-07-26 09:27:48', '');
INSERT INTO `backgroundjoblog` VALUES ('07148836-ecf1-4432-ad8b-87370865902d', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:30:33', '0.01', '2017-07-26 09:30:33', '');
INSERT INTO `backgroundjoblog` VALUES ('07993398-670e-4f1e-b875-31cac0cfbf75', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:34:51', '0.01', '2017-07-26 09:34:51', '');
INSERT INTO `backgroundjoblog` VALUES ('0828905a-7a1b-419e-a4e2-6fac5d5c9eaa', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:25:24', '0.01', '2017-07-26 09:25:24', '');
INSERT INTO `backgroundjoblog` VALUES ('087a9240-f137-49a7-8cd4-cd09a251ea39', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:26:00', '0.03', '2017-07-26 09:26:00', '[extend_logA:JobTestA Executing2017/7/26 9:26:00,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('0882248d-d769-442e-9ee8-fecb4e203b8e', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:34:32', '0.02', '2017-07-26 09:34:32', '[extend_logA:JobTestA Executing2017/7/26 9:34:32,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('08b3614a-c481-4e40-b1c9-b8ee265b51b5', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:29:56', '0.00', '2017-07-26 09:29:56', '[extend_logA:JobTestA Executing2017/7/26 9:29:56,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('0a083ee0-a701-4779-8e55-a3324c3acda2', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:28:24', '0.02', '2017-07-26 09:28:24', '');
INSERT INTO `backgroundjoblog` VALUES ('0a49c335-0978-4469-9f31-582aca46019e', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:32:54', '0.01', '2017-07-26 09:32:54', '');
INSERT INTO `backgroundjoblog` VALUES ('0ab5ac44-3a8b-4df9-b60e-b526c0808b05', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:25:09', '0.01', '2017-07-26 09:25:09', '');
INSERT INTO `backgroundjoblog` VALUES ('0ac88928-c9bf-4076-ab84-5d79866332f0', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:29:15', '0.01', '2017-07-26 09:29:15', '');
INSERT INTO `backgroundjoblog` VALUES ('0b9152c6-6a6e-47ac-b40f-2f21631bac5d', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:29:03', '0.01', '2017-07-26 09:29:03', '');
INSERT INTO `backgroundjoblog` VALUES ('0ba0655d-4705-44e0-bb0d-44ac0e643126', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:30:08', '0.00', '2017-07-26 09:30:08', '[extend_logA:JobTestA Executing2017/7/26 9:30:08,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('0bd7c819-65c2-4443-b08b-729d3b06af51', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:28:39', '0.01', '2017-07-26 09:28:39', '');
INSERT INTO `backgroundjoblog` VALUES ('0ced48b1-8668-4cb7-bbb0-871de7d1a2a2', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:28:28', '0.01', '2017-07-26 09:28:28', '[extend_logA:JobTestA Executing2017/7/26 9:28:28,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('0d59a3c6-0e57-4c51-9245-709ad3ec9f18', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:29:00', '0.01', '2017-07-26 09:29:00', '[extend_logA:JobTestA Executing2017/7/26 9:29:00,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('0e648272-3080-4148-89fb-de077a2066b1', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:25:36', '0.02', '2017-07-26 09:25:36', '');
INSERT INTO `backgroundjoblog` VALUES ('0e8b860d-8786-4c4b-9cfe-9b171aa3f78a', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:30:27', '0.01', '2017-07-26 09:30:27', '');
INSERT INTO `backgroundjoblog` VALUES ('0f1067a0-829e-4b5f-98e6-df67cb382651', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:34:40', '0.00', '2017-07-26 09:34:40', '[extend_logA:JobTestA Executing2017/7/26 9:34:40,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('0fc2ee46-b90d-4950-8a1e-ebc5aec53c1e', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:28:40', '0.00', '2017-07-26 09:28:40', '[extend_logA:JobTestA Executing2017/7/26 9:28:40,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('0fe23c57-d039-4482-aeb0-d4bf15454084', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:32:33', '0.01', '2017-07-26 09:32:33', '');
INSERT INTO `backgroundjoblog` VALUES ('103fa58b-70d0-4fb3-8854-7df0d2957e73', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:25:48', '0.03', '2017-07-26 09:25:48', '');
INSERT INTO `backgroundjoblog` VALUES ('10642f38-8216-4b06-bd50-e7afab134a0a', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:30:06', '0.00', '2017-07-26 09:30:06', '');
INSERT INTO `backgroundjoblog` VALUES ('10c58499-b221-4712-8bc4-eb8437af0619', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:25:00', '0.00', '2017-07-26 09:25:00', '');
INSERT INTO `backgroundjoblog` VALUES ('10fec3ba-add4-48d6-a120-7532e8076196', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:32:00', '0.02', '2017-07-26 09:32:00', '');
INSERT INTO `backgroundjoblog` VALUES ('111b870c-6208-47af-846c-923c530e9d59', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:29:57', '0.00', '2017-07-26 09:29:57', '');
INSERT INTO `backgroundjoblog` VALUES ('11beea2e-eb62-4191-a047-2d27d3c2cdba', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:26:39', '0.01', '2017-07-26 09:26:39', '');
INSERT INTO `backgroundjoblog` VALUES ('11e3438e-16df-4cfb-861b-58084bc045a9', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:27:33', '0.01', '2017-07-26 09:27:33', '');
INSERT INTO `backgroundjoblog` VALUES ('1238097c-1e5c-4beb-9069-0e6d024398f7', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:34:08', '0.00', '2017-07-26 09:34:08', '[extend_logA:JobTestA Executing2017/7/26 9:34:08,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('1267d7a5-1ba7-4569-9715-821a5f39a848', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:31:00', '0.01', '2017-07-26 09:31:00', '[extend_logA:JobTestA Executing2017/7/26 9:31:00,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('129f9280-b04d-48fe-b5d2-7365d944e678', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:29:45', '0.00', '2017-07-26 09:29:45', '');
INSERT INTO `backgroundjoblog` VALUES ('12d8b243-cd2a-4919-b449-cd66ab0ced7c', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:29:54', '0.01', '2017-07-26 09:29:54', '');
INSERT INTO `backgroundjoblog` VALUES ('1348d06a-a304-44ff-91bf-4c273ad2c8b2', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:35:42', '0.00', '2017-07-26 09:35:42', '');
INSERT INTO `backgroundjoblog` VALUES ('13c5cd9d-5fc0-4a69-b36e-6ee40d9b929f', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:34:44', '0.00', '2017-07-26 09:34:44', '[extend_logA:JobTestA Executing2017/7/26 9:34:44,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('142d66d9-c3c2-458c-adcb-cbe9f82e7a47', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:27:16', '0.00', '2017-07-26 09:27:16', '[extend_logA:JobTestA Executing2017/7/26 9:27:16,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('14e5af54-136a-4cf1-acbf-85ed1547eaa1', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:33:54', '0.01', '2017-07-26 09:33:54', '');
INSERT INTO `backgroundjoblog` VALUES ('150b1a9e-0d05-445e-9c25-928c88399e21', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:27:00', '0.01', '2017-07-26 09:27:00', '');
INSERT INTO `backgroundjoblog` VALUES ('15210189-661c-4625-99a8-b57d56473f27', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:26:30', '0.01', '2017-07-26 09:26:30', '');
INSERT INTO `backgroundjoblog` VALUES ('155cd97d-1d76-4a36-a628-8e5d2baaaea5', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:31:36', '0.17', '2017-07-26 09:31:36', '');
INSERT INTO `backgroundjoblog` VALUES ('1571b1af-5e70-485e-8d5c-03d2893ec83b', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:25:44', '0.01', '2017-07-26 09:25:44', '[extend_logA:JobTestA Executing2017/7/26 9:25:44,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('16e258bc-a7cd-4fb3-9b31-74bf7e87f0ac', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:31:45', '0.01', '2017-07-26 09:31:45', '');
INSERT INTO `backgroundjoblog` VALUES ('1701b4e9-9fbc-482d-a157-a276c01590da', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:25:12', '0.01', '2017-07-26 09:25:12', '');
INSERT INTO `backgroundjoblog` VALUES ('17984abe-4b38-47e2-942b-90d3ccbdaac8', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:27:00', '0.01', '2017-07-26 09:27:00', '[extend_logA:JobTestA Executing2017/7/26 9:27:00,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('184aac2f-5d6f-4fa4-bc39-13584d3f2ae8', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:33:39', '0.01', '2017-07-26 09:33:39', '');
INSERT INTO `backgroundjoblog` VALUES ('185ec5fa-b7f3-4c2b-8d8c-1740b171885f', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:25:30', '0.02', '2017-07-26 09:25:30', '');
INSERT INTO `backgroundjoblog` VALUES ('19576ba5-12be-420e-b243-eff7034566db', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:30:18', '0.01', '2017-07-26 09:30:18', '');
INSERT INTO `backgroundjoblog` VALUES ('1960b763-16d3-4d0b-841d-faf92758510e', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:33:24', '0.02', '2017-07-26 09:33:24', '');
INSERT INTO `backgroundjoblog` VALUES ('19891ed1-5c4b-4b12-b3f2-314421dcb893', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:30:48', '0.02', '2017-07-26 09:30:48', '');
INSERT INTO `backgroundjoblog` VALUES ('1abcbc32-c61f-4cd7-b15c-5195d2e4ed3f', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:31:42', '0.00', '2017-07-26 09:31:42', '');
INSERT INTO `backgroundjoblog` VALUES ('1afba894-30e2-40e8-9037-8263f99568a1', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:30:24', '0.02', '2017-07-26 09:30:24', '');
INSERT INTO `backgroundjoblog` VALUES ('1b0fd1e7-5931-4649-8951-6d59f8201910', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:26:00', '0.03', '2017-07-26 09:26:00', '');
INSERT INTO `backgroundjoblog` VALUES ('1b1a1e79-6474-40a4-b879-1b1dcab11c6f', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:33:42', '0.01', '2017-07-26 09:33:42', '');
INSERT INTO `backgroundjoblog` VALUES ('1b35287b-5468-40a2-adef-312ad433f7a7', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:29:48', '0.01', '2017-07-26 09:29:48', '');
INSERT INTO `backgroundjoblog` VALUES ('1b55fa54-832b-446c-944f-1309674aabcd', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:32:12', '0.02', '2017-07-26 09:32:12', '[extend_logA:JobTestA Executing2017/7/26 9:32:12,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('1c653713-cdf7-4d73-bdc2-2c5579361b10', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:25:06', '0.01', '2017-07-26 09:25:06', '');
INSERT INTO `backgroundjoblog` VALUES ('1c6ae5bf-b6dd-43b6-9c66-7b2c6ba18b1f', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:33:32', '0.00', '2017-07-26 09:33:32', '[extend_logA:JobTestA Executing2017/7/26 9:33:32,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('1c96c37b-115b-49e2-a460-4b85af74efce', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:34:48', '0.03', '2017-07-26 09:34:48', '');
INSERT INTO `backgroundjoblog` VALUES ('1deb1d59-2123-4adf-a9bf-07fc44d94f01', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:28:12', '0.02', '2017-07-26 09:28:12', '');
INSERT INTO `backgroundjoblog` VALUES ('1e848c45-a179-4575-ba21-037f8472e1bd', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:33:00', '0.03', '2017-07-26 09:33:00', '');
INSERT INTO `backgroundjoblog` VALUES ('1fa563a6-27f7-43a0-bef3-8a975ea93842', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:35:30', '0.01', '2017-07-26 09:35:30', '');
INSERT INTO `backgroundjoblog` VALUES ('1ff9e1e8-bd2a-4a29-867e-849ffca6f614', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:26:51', '0.00', '2017-07-26 09:26:51', '');
INSERT INTO `backgroundjoblog` VALUES ('20b42816-5ddb-40e7-a076-3856433e2c4c', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:32:57', '0.01', '2017-07-26 09:32:57', '');
INSERT INTO `backgroundjoblog` VALUES ('212049b0-581b-4ffb-a127-778b1136ff62', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:33:45', '0.01', '2017-07-26 09:33:45', '');
INSERT INTO `backgroundjoblog` VALUES ('21f8d4f9-6221-4609-be64-7fbb246ac5e9', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:32:30', '0.02', '2017-07-26 09:32:30', '');
INSERT INTO `backgroundjoblog` VALUES ('2202452d-e2c4-443f-8ce2-7021e56b5b1d', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:29:06', '0.01', '2017-07-26 09:29:07', '');
INSERT INTO `backgroundjoblog` VALUES ('228c7cb7-dd2a-4478-8cee-9383797df1a3', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:26:54', '0.00', '2017-07-26 09:26:54', '');
INSERT INTO `backgroundjoblog` VALUES ('22946ac3-89e2-4bfb-bac7-34236d98f7fe', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:33:21', '0.01', '2017-07-26 09:33:21', '');
INSERT INTO `backgroundjoblog` VALUES ('23073af4-bb20-4d4d-8751-11b71ffa6dbd', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:32:12', '0.01', '2017-07-26 09:32:12', '');
INSERT INTO `backgroundjoblog` VALUES ('23165be7-7f3e-4490-aefd-fd42d1d009b3', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:34:12', '0.00', '2017-07-26 09:34:12', '[extend_logA:JobTestA Executing2017/7/26 9:34:12,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('23b00548-0b24-4bb8-9407-3c776ee7aea3', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:35:12', '0.01', '2017-07-26 09:35:12', '[extend_logA:JobTestA Executing2017/7/26 9:35:12,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('23b00b5e-33c9-4cea-a158-1c52e32b4f31', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:33:24', '0.01', '2017-07-26 09:33:24', '');
INSERT INTO `backgroundjoblog` VALUES ('2544afc3-2ed1-471f-b8b4-e57735caf6f6', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:35:27', '0.01', '2017-07-26 09:35:27', '');
INSERT INTO `backgroundjoblog` VALUES ('26f63275-2f0c-4175-9ad3-c520fa98bfcb', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:28:06', '0.01', '2017-07-26 09:28:06', '');
INSERT INTO `backgroundjoblog` VALUES ('274f86aa-1007-4875-82dd-d530ed0ef74f', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:34:00', '0.01', '2017-07-26 09:34:00', '');
INSERT INTO `backgroundjoblog` VALUES ('297a0cb0-dc96-40ba-ac48-fde7eb375b28', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:34:45', '0.00', '2017-07-26 09:34:45', '');
INSERT INTO `backgroundjoblog` VALUES ('29d2b152-63eb-4c88-b820-c08c6cf88005', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:33:52', '0.00', '2017-07-26 09:33:52', '[extend_logA:JobTestA Executing2017/7/26 9:33:52,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('2a8f0f45-88c4-4b60-9328-50ec109a6005', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:31:56', '0.00', '2017-07-26 09:31:56', '[extend_logA:JobTestA Executing2017/7/26 9:31:56,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('2ad383bd-4235-4374-927a-80b471bf8fac', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:29:20', '0.00', '2017-07-26 09:29:21', '[extend_logA:JobTestA Executing2017/7/26 9:29:20,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('2cf2fde2-62d2-466e-b2e2-4e8eb6a0fa45', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:32:12', '0.02', '2017-07-26 09:32:12', '');
INSERT INTO `backgroundjoblog` VALUES ('2d1abd24-676c-4d5a-986a-7c31eb28e38b', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:28:36', '0.01', '2017-07-26 09:28:36', '');
INSERT INTO `backgroundjoblog` VALUES ('2ec1e9ed-ab86-4eca-a95d-e4dfeb0e1d51', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:25:04', '0.01', '2017-07-26 09:25:04', '[extend_logA:JobTestA Executing2017/7/26 9:25:04,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('2f784d5c-5348-42bc-85a1-897ae6ecdcdb', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:26:56', '0.00', '2017-07-26 09:26:56', '[extend_logA:JobTestA Executing2017/7/26 9:26:56,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('2ffe8055-13f4-469b-8d68-4db219a698be', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:31:12', '0.02', '2017-07-26 09:31:12', '');
INSERT INTO `backgroundjoblog` VALUES ('3026f813-e538-4bbb-a467-286e2b8c04d4', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:35:36', '0.01', '2017-07-26 09:35:36', '[extend_logA:JobTestA Executing2017/7/26 9:35:36,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('30620e5e-307e-403c-81a1-05308a734b9a', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:28:12', '0.03', '2017-07-26 09:28:12', '[extend_logA:JobTestA Executing2017/7/26 9:28:12,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('30ca78a1-d95d-4c6b-b409-65b6c1cdcdc3', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:33:20', '0.00', '2017-07-26 09:33:20', '[extend_logA:JobTestA Executing2017/7/26 9:33:20,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('33112dce-31b5-4888-aa96-f8677b22a893', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:26:27', '0.01', '2017-07-26 09:26:27', '');
INSERT INTO `backgroundjoblog` VALUES ('3320fcb7-31f8-4b01-b140-7a3dc27eb664', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:26:18', '0.03', '2017-07-26 09:26:18', '');
INSERT INTO `backgroundjoblog` VALUES ('33c12e9f-4e4b-45df-99de-76fd5388a1f4', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:30:30', '0.01', '2017-07-26 09:30:30', '');
INSERT INTO `backgroundjoblog` VALUES ('34638688-6c16-4231-87f8-88d57caee671', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:31:48', '0.02', '2017-07-26 09:31:48', '');
INSERT INTO `backgroundjoblog` VALUES ('34a56048-8fcb-441a-87d0-9b2c8a33e2f2', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:32:03', '0.01', '2017-07-26 09:32:03', '');
INSERT INTO `backgroundjoblog` VALUES ('36723e30-6c43-4e8c-93d5-900fa701b01a', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:25:00', '0.01', '2017-07-26 09:25:00', '');
INSERT INTO `backgroundjoblog` VALUES ('367453e4-f8b9-434e-b830-a35723f53ec6', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:25:18', '0.01', '2017-07-26 09:25:18', '');
INSERT INTO `backgroundjoblog` VALUES ('389d33dc-b12a-4657-a15a-51ee671877c0', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:32:24', '0.19', '2017-07-26 09:32:24', '');
INSERT INTO `backgroundjoblog` VALUES ('3a4f388d-8746-4f96-8c91-cdd004dcfd7d', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:29:42', '0.01', '2017-07-26 09:29:42', '');
INSERT INTO `backgroundjoblog` VALUES ('3ac4844d-5f31-4bee-8834-f91042c2bdf6', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:34:28', '0.00', '2017-07-26 09:34:28', '[extend_logA:JobTestA Executing2017/7/26 9:34:28,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('3bce4b9c-8087-4fb2-9c7a-4b6474e7f5fb', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:25:54', '0.02', '2017-07-26 09:25:54', '');
INSERT INTO `backgroundjoblog` VALUES ('3bdd7d8b-c796-43f1-bf61-2c5499f1d485', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:34:20', '0.00', '2017-07-26 09:34:20', '[extend_logA:JobTestA Executing2017/7/26 9:34:20,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('3c2b89b3-72f8-48c0-afc5-0caf3f51f86b', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:26:57', '0.01', '2017-07-26 09:26:57', '');
INSERT INTO `backgroundjoblog` VALUES ('3ca8e9ad-8e14-4798-b6df-9111849b8489', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:28:00', '0.02', '2017-07-26 09:28:00', '');
INSERT INTO `backgroundjoblog` VALUES ('3cbcbd59-e66a-4f12-9bf5-ac3325ddb0f5', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:27:20', '0.00', '2017-07-26 09:27:20', '[extend_logA:JobTestA Executing2017/7/26 9:27:20,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('3d2bf2f1-bccd-404d-9876-0264c0cdf3c9', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:26:03', '0.01', '2017-07-26 09:26:03', '');
INSERT INTO `backgroundjoblog` VALUES ('3d3cc538-8aab-456f-aae1-83d4d9c0f6ea', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:30:30', '0.02', '2017-07-26 09:30:30', '');
INSERT INTO `backgroundjoblog` VALUES ('3f7f7b48-1bcc-4b8d-9e82-cdb34b993687', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:27:18', '0.00', '2017-07-26 09:27:18', '');
INSERT INTO `backgroundjoblog` VALUES ('3f971af7-1729-4dd1-987d-aa4f8498f153', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:34:27', '0.01', '2017-07-26 09:34:27', '');
INSERT INTO `backgroundjoblog` VALUES ('40321417-fd1b-4cef-ab64-8e79ecbf86c7', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:28:20', '0.00', '2017-07-26 09:28:20', '[extend_logA:JobTestA Executing2017/7/26 9:28:20,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('408dd926-2dea-4662-93cb-9f3fac2100ff', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:27:12', '0.01', '2017-07-26 09:27:12', '[extend_logA:JobTestA Executing2017/7/26 9:27:12,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('40c29eec-9293-4901-9a29-59e9241de0aa', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:34:16', '0.00', '2017-07-26 09:34:16', '[extend_logA:JobTestA Executing2017/7/26 9:34:16,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('416089a8-af7f-4395-9e35-eed9a0a79d42', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:26:04', '0.02', '2017-07-26 09:26:04', '[extend_logA:JobTestA Executing2017/7/26 9:26:04,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('41659fb5-44d5-4310-8e59-86fa9b8e3117', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:27:04', '0.01', '2017-07-26 09:27:04', '[extend_logA:JobTestA Executing2017/7/26 9:27:04,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('41a2182c-3d91-4a5a-a39a-35e1eaf59feb', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:25:30', '0.01', '2017-07-26 09:25:30', '');
INSERT INTO `backgroundjoblog` VALUES ('41aced92-0713-4ae6-8d04-66293149de39', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:33:57', '0.01', '2017-07-26 09:33:57', '');
INSERT INTO `backgroundjoblog` VALUES ('41bf1d46-3761-4e1e-9c04-7233017c28da', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:25:48', '0.02', '2017-07-26 09:25:48', '');
INSERT INTO `backgroundjoblog` VALUES ('41f4b123-162d-436b-bcfd-8837de8bb48c', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:25:24', '0.01', '2017-07-26 09:25:24', '');
INSERT INTO `backgroundjoblog` VALUES ('428cb267-c5bf-4f73-b00f-48671e14a460', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:30:00', '0.02', '2017-07-26 09:30:00', '');
INSERT INTO `backgroundjoblog` VALUES ('42f0d092-b247-4e4e-a97c-fd9990ba752c', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:34:30', '0.00', '2017-07-26 09:34:30', '');
INSERT INTO `backgroundjoblog` VALUES ('434fef85-73a1-4e6b-ae94-7742753158a3', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:24:45', '0.01', '2017-07-26 09:24:45', '');
INSERT INTO `backgroundjoblog` VALUES ('439bc81d-2178-47f8-a8ed-502cc9014158', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:34:00', '0.01', '2017-07-26 09:34:00', '[extend_logA:JobTestA Executing2017/7/26 9:34:00,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('43e82ef8-33ce-471c-a2c9-f9d8a9feaa85', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:33:12', '0.02', '2017-07-26 09:33:12', '[extend_logA:JobTestA Executing2017/7/26 9:33:12,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('44b3a17a-0ec6-4589-89cc-9bd6005d7d27', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:34:00', '0.33', '2017-07-26 09:34:00', '');
INSERT INTO `backgroundjoblog` VALUES ('4530d783-3f49-4087-9aa3-f3c82a7a0499', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:32:48', '0.01', '2017-07-26 09:32:48', '');
INSERT INTO `backgroundjoblog` VALUES ('45aa3175-5af5-4365-85c6-c05b097fd7f2', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:33:18', '0.01', '2017-07-26 09:33:18', '');
INSERT INTO `backgroundjoblog` VALUES ('45baf3e5-0d1b-440c-8386-0746e6fc29eb', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:26:48', '0.01', '2017-07-26 09:26:48', '');
INSERT INTO `backgroundjoblog` VALUES ('462fabae-350b-4cc8-bca3-bec77c23b14c', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:31:57', '0.01', '2017-07-26 09:31:57', '');
INSERT INTO `backgroundjoblog` VALUES ('469cbf29-53e7-4bf6-8340-1ea5ee884144', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:25:28', '0.02', '2017-07-26 09:25:28', '[extend_logA:JobTestA Executing2017/7/26 9:25:28,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('46f5a305-e52f-4c9f-9adb-8e85542fa905', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:29:28', '0.00', '2017-07-26 09:29:28', '[extend_logA:JobTestA Executing2017/7/26 9:29:28,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('472b6c67-eac8-4459-bade-0bb2d8a3165c', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:26:15', '0.01', '2017-07-26 09:26:15', '');
INSERT INTO `backgroundjoblog` VALUES ('472f1a3f-373e-49ab-83fb-8125ad20ecfe', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:32:42', '0.00', '2017-07-26 09:32:42', '');
INSERT INTO `backgroundjoblog` VALUES ('48537f7d-8fbb-4602-96f3-92256c920ba4', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:26:54', '0.00', '2017-07-26 09:26:54', '');
INSERT INTO `backgroundjoblog` VALUES ('48b8d16d-8632-4a9b-86e2-b607df9bd882', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:25:48', '0.03', '2017-07-26 09:25:48', '[extend_logA:JobTestA Executing2017/7/26 9:25:48,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('4904fdbc-e6df-4cae-9305-bc16491232aa', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:34:56', '0.00', '2017-07-26 09:34:56', '[extend_logA:JobTestA Executing2017/7/26 9:34:56,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('49069c07-ff6e-4624-9100-fe65b5395eb9', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:31:54', '0.01', '2017-07-26 09:31:54', '');
INSERT INTO `backgroundjoblog` VALUES ('4a90f2ae-f816-4e15-a500-8de23b17c271', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:31:18', '0.01', '2017-07-26 09:31:18', '');
INSERT INTO `backgroundjoblog` VALUES ('4ab6dd10-0364-42d7-a2f5-13bee62279e6', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:32:24', '0.01', '2017-07-26 09:32:24', '');
INSERT INTO `backgroundjoblog` VALUES ('4adde163-ed03-4004-8cd0-1e22fafa94f5', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:35:28', '0.00', '2017-07-26 09:35:28', '[extend_logA:JobTestA Executing2017/7/26 9:35:28,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('4c361e67-0dc1-4e03-aa66-3818bd2aa5f4', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:34:33', '0.01', '2017-07-26 09:34:33', '');
INSERT INTO `backgroundjoblog` VALUES ('4c53666e-3e1a-4994-9196-f438bdc89c26', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:34:57', '0.01', '2017-07-26 09:34:57', '');
INSERT INTO `backgroundjoblog` VALUES ('4c5457af-7167-4af2-9861-1bfcaaf2d359', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:26:20', '0.00', '2017-07-26 09:26:20', '[extend_logA:JobTestA Executing2017/7/26 9:26:20,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('4c9be7e2-19d1-48f2-91fa-756812054df1', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:27:06', '0.00', '2017-07-26 09:27:06', '');
INSERT INTO `backgroundjoblog` VALUES ('4d5fdb7d-6d48-4729-99cc-3098394551cc', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:32:42', '0.00', '2017-07-26 09:32:42', '');
INSERT INTO `backgroundjoblog` VALUES ('4e2069de-bccb-490d-8a8c-24ec499d7ead', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:33:27', '0.01', '2017-07-26 09:33:27', '');
INSERT INTO `backgroundjoblog` VALUES ('4e47fcc6-415e-409d-805d-44297f25d674', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:32:36', '0.01', '2017-07-26 09:32:36', '');
INSERT INTO `backgroundjoblog` VALUES ('4ec43616-09cf-425a-b403-4076ca738027', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:30:21', '0.01', '2017-07-26 09:30:21', '');
INSERT INTO `backgroundjoblog` VALUES ('4f225e75-1341-4f08-9744-59716ca410aa', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:31:12', '0.01', '2017-07-26 09:31:12', '');
INSERT INTO `backgroundjoblog` VALUES ('4f3e4cb0-1fe7-4762-a0c5-af090ded62c6', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:27:36', '0.02', '2017-07-26 09:27:36', '');
INSERT INTO `backgroundjoblog` VALUES ('4f42ebb1-d8ba-48b3-b853-df09aa1e45f9', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:28:52', '0.00', '2017-07-26 09:28:52', '[extend_logA:JobTestA Executing2017/7/26 9:28:52,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('511e1158-9ab1-4dd0-93fb-61e04d249954', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:25:16', '0.01', '2017-07-26 09:25:16', '[extend_logA:JobTestA Executing2017/7/26 9:25:16,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('520096d8-9a11-4bcd-9e03-fb120db09297', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:29:04', '0.00', '2017-07-26 09:29:04', '[extend_logA:JobTestA Executing2017/7/26 9:29:04,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('528a1393-6b6a-4dd0-bd9b-3436be25058e', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:26:28', '0.00', '2017-07-26 09:26:28', '[extend_logA:JobTestA Executing2017/7/26 9:26:28,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('52990b51-cd89-481a-9851-6c2ceef599c1', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:33:12', '0.03', '2017-07-26 09:33:12', '');
INSERT INTO `backgroundjoblog` VALUES ('52d25110-2622-4b58-98d5-04766bbd80bd', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:32:15', '0.01', '2017-07-26 09:32:15', '');
INSERT INTO `backgroundjoblog` VALUES ('531cd492-3daa-4b5c-a9d6-f9259b29a430', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:25:36', '0.02', '2017-07-26 09:25:36', '[extend_logA:JobTestA Executing2017/7/26 9:25:36,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('539cb092-962a-483a-aa41-a2f02508dc62', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:27:21', '0.01', '2017-07-26 09:27:21', '');
INSERT INTO `backgroundjoblog` VALUES ('53d35355-9a29-4ca5-a837-ce75bb73b292', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:25:12', '0.01', '2017-07-26 09:25:12', '[extend_logA:JobTestA Executing2017/7/26 9:25:12,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('54914478-71b4-471c-b3c4-7b34a4d60ad0', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:30:00', '0.03', '2017-07-26 09:30:00', '[extend_logA:JobTestA Executing2017/7/26 9:30:00,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('55039539-a435-40d7-8869-b06cbabd1e53', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:24:57', '0.01', '2017-07-26 09:24:57', '');
INSERT INTO `backgroundjoblog` VALUES ('5539428e-68bb-4762-a8d5-ffcb6cbe1855', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:29:52', '0.00', '2017-07-26 09:29:52', '[extend_logA:JobTestA Executing2017/7/26 9:29:52,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('554a5cc3-8c86-4b8a-beeb-0dd0d5718809', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:34:36', '0.00', '2017-07-26 09:34:36', '');
INSERT INTO `backgroundjoblog` VALUES ('5589ce1a-ab70-4053-b7ac-28cdae0f6055', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:31:16', '0.00', '2017-07-26 09:31:16', '[extend_logA:JobTestA Executing2017/7/26 9:31:16,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('55f9289f-8e1c-46dc-94c9-2b475d908faf', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:29:24', '0.01', '2017-07-26 09:29:24', '');
INSERT INTO `backgroundjoblog` VALUES ('5641701d-49bd-4b99-ad1c-6c291da8e2a3', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:34:09', '0.01', '2017-07-26 09:34:09', '');
INSERT INTO `backgroundjoblog` VALUES ('5649c1d0-4107-43e2-b723-b8b529af1af0', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:24:48', '0.01', '2017-07-26 09:24:48', '');
INSERT INTO `backgroundjoblog` VALUES ('5663b638-5406-4b78-870f-df375b5c0287', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:35:32', '0.00', '2017-07-26 09:35:32', '[extend_logA:JobTestA Executing2017/7/26 9:35:32,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('57117738-c24d-4a7d-ba82-78ec95558a39', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:28:03', '0.01', '2017-07-26 09:28:03', '');
INSERT INTO `backgroundjoblog` VALUES ('572d89b6-ab05-4882-b418-32d828046f5c', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:35:33', '0.01', '2017-07-26 09:35:33', '');
INSERT INTO `backgroundjoblog` VALUES ('57562bcc-fadf-4357-bd95-3f1e41cf197b', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:31:24', '0.03', '2017-07-26 09:31:24', '');
INSERT INTO `backgroundjoblog` VALUES ('57c1b16c-0c82-4495-b90d-ad9583d23e56', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:30:54', '0.00', '2017-07-26 09:30:54', '');
INSERT INTO `backgroundjoblog` VALUES ('57fe52a5-9943-4c24-a12a-b07bd488413c', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:25:03', '0.00', '2017-07-26 09:25:03', '');
INSERT INTO `backgroundjoblog` VALUES ('5a48b4e6-3296-4b14-911a-f8354bbdde74', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:30:24', '0.01', '2017-07-26 09:30:24', '[extend_logA:JobTestA Executing2017/7/26 9:30:24,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('5a65ec96-5517-4b49-9211-155cfa85c3c2', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:29:24', '0.01', '2017-07-26 09:29:24', '[extend_logA:JobTestA Executing2017/7/26 9:29:24,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('5b896f89-59bb-43c5-b2b2-c9fd00b6bab5', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:26:24', '0.03', '2017-07-26 09:26:24', '');
INSERT INTO `backgroundjoblog` VALUES ('5beee963-779d-453e-a1ef-eedf16f2b82c', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:35:00', '0.03', '2017-07-26 09:35:00', '');
INSERT INTO `backgroundjoblog` VALUES ('5c427e68-0e7f-4f22-b743-39fe6391719b', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:30:45', '0.01', '2017-07-26 09:30:45', '');
INSERT INTO `backgroundjoblog` VALUES ('5ce503fd-ad03-43cb-991a-0ac87e2ee8e8', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:25:20', '0.00', '2017-07-26 09:25:20', '[extend_logA:JobTestA Executing2017/7/26 9:25:20,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('5d6ab8a6-f0a6-4610-9e2f-4707ab7fbcf1', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:32:39', '0.01', '2017-07-26 09:32:39', '');
INSERT INTO `backgroundjoblog` VALUES ('5d7c05c6-d9ee-45d8-8773-617ff5a1cce9', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:25:12', '0.01', '2017-07-26 09:25:12', '');
INSERT INTO `backgroundjoblog` VALUES ('5dad967a-ee6b-48b6-ba55-f9bfcbbde2a1', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:31:33', '0.01', '2017-07-26 09:31:33', '');
INSERT INTO `backgroundjoblog` VALUES ('5deca93b-df3d-4eb7-b9a5-d9542721d8f3', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:31:15', '0.01', '2017-07-26 09:31:15', '');
INSERT INTO `backgroundjoblog` VALUES ('5df08aae-fae4-4c4b-ad42-8f7199063cd0', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:27:56', '0.00', '2017-07-26 09:27:56', '[extend_logA:JobTestA Executing2017/7/26 9:27:56,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('5e226525-d917-48c9-849e-cc620f53f2fd', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:35:15', '0.01', '2017-07-26 09:35:15', '');
INSERT INTO `backgroundjoblog` VALUES ('5f0dc41a-9b53-4e68-8681-46169fb54a61', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:30:42', '0.01', '2017-07-26 09:30:42', '');
INSERT INTO `backgroundjoblog` VALUES ('5faaf855-2aa9-463d-bbbf-811ab34da4f0', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:27:48', '0.03', '2017-07-26 09:27:48', '[extend_logA:JobTestA Executing2017/7/26 9:27:48,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('61e6c2a3-f57a-4b3b-a530-5d300eb6d790', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:32:44', '0.00', '2017-07-26 09:32:44', '[extend_logA:JobTestA Executing2017/7/26 9:32:44,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('622ac58b-a579-438a-acf6-590e9bdd6e51', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:28:12', '0.02', '2017-07-26 09:28:12', '');
INSERT INTO `backgroundjoblog` VALUES ('628bf4a8-a71e-479a-be6e-291cb108789f', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:33:36', '0.01', '2017-07-26 09:33:36', '[extend_logA:JobTestA Executing2017/7/26 9:33:36,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('63ff6560-f25f-44da-9924-87ef6515cacd', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:24:54', '0.04', '2017-07-26 09:24:54', '');
INSERT INTO `backgroundjoblog` VALUES ('6418fa63-818d-4d07-8132-5edb908399fd', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:25:56', '0.01', '2017-07-26 09:25:56', '[extend_logA:JobTestA Executing2017/7/26 9:25:56,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('642ec0d5-d567-4e6f-afeb-ec5ba7e58ece', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:31:24', '0.02', '2017-07-26 09:31:24', '[extend_logA:JobTestA Executing2017/7/26 9:31:24,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('646ee81c-06b6-4a76-8fed-4fda5747ca41', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:31:32', '0.00', '2017-07-26 09:31:32', '[extend_logA:JobTestA Executing2017/7/26 9:31:32,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('65430c2e-1afd-4d06-80fb-8aca4186efae', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:28:56', '0.00', '2017-07-26 09:28:56', '[extend_logA:JobTestA Executing2017/7/26 9:28:56,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('65c13a08-534d-434d-a768-ec103198c8ef', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:28:24', '0.02', '2017-07-26 09:28:24', '[extend_logA:JobTestA Executing2017/7/26 9:28:24,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('65cab5cd-3b97-423d-8f49-d571e5a7183b', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:31:09', '0.01', '2017-07-26 09:31:09', '');
INSERT INTO `backgroundjoblog` VALUES ('66140d4e-5ce9-44e4-8a04-880c83b2a261', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:34:42', '0.03', '2017-07-26 09:34:42', '');
INSERT INTO `backgroundjoblog` VALUES ('668490c1-f1eb-4c32-919e-ea0161144c84', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:32:32', '0.01', '2017-07-26 09:32:32', '[extend_logA:JobTestA Executing2017/7/26 9:32:32,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('66fc07a1-620e-4adb-a384-1cd20e011ad5', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:35:20', '0.01', '2017-07-26 09:35:20', '[extend_logA:JobTestA Executing2017/7/26 9:35:20,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('66fca48b-dee8-484d-8b9f-2d3aa0198d49', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:34:21', '0.00', '2017-07-26 09:34:21', '');
INSERT INTO `backgroundjoblog` VALUES ('674a6265-8332-4b98-aaa4-5b39d0ab8e06', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:30:44', '0.00', '2017-07-26 09:30:44', '[extend_logA:JobTestA Executing2017/7/26 9:30:44,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('68148c58-68c0-4dc2-9687-b190ec6d1dec', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:27:51', '0.01', '2017-07-26 09:27:51', '');
INSERT INTO `backgroundjoblog` VALUES ('687596f8-02e5-492a-a2fc-dd681c0cdebb', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:30:52', '0.00', '2017-07-26 09:30:52', '[extend_logA:JobTestA Executing2017/7/26 9:30:52,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('689dc4c2-07ea-4600-b1b8-171f7c53d333', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:34:06', '0.04', '2017-07-26 09:34:06', '');
INSERT INTO `backgroundjoblog` VALUES ('68ffbb64-256c-4c79-8d58-06c367dbe4ae', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:34:48', '0.01', '2017-07-26 09:34:48', '[extend_logA:JobTestA Executing2017/7/26 9:34:48,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('6a1b6e2a-a345-4efc-9907-fa3d23b4c5a9', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:28:00', '0.01', '2017-07-26 09:28:00', '[extend_logA:JobTestA Executing2017/7/26 9:28:00,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('6a4a76b0-52ad-48a4-84f5-887ae124948f', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:27:03', '0.00', '2017-07-26 09:27:03', '');
INSERT INTO `backgroundjoblog` VALUES ('6aa2833b-268a-491a-8f9e-7d308412c7a3', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:29:44', '0.00', '2017-07-26 09:29:44', '[extend_logA:JobTestA Executing2017/7/26 9:29:44,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('6bac81ea-db58-4b2b-bd24-9253c707a9ec', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:25:42', '0.02', '2017-07-26 09:25:42', '');
INSERT INTO `backgroundjoblog` VALUES ('6c13bc02-4ff9-4045-bfe8-79b48a09b6d8', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:24:51', '0.00', '2017-07-26 09:24:51', '');
INSERT INTO `backgroundjoblog` VALUES ('6c557b77-acbd-4eed-b9ba-bb8d57c046dc', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:29:54', '0.01', '2017-07-26 09:29:54', '');
INSERT INTO `backgroundjoblog` VALUES ('6c8edd5d-331b-4f9f-ae80-3cc853ea759d', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:32:06', '0.02', '2017-07-26 09:32:06', '');
INSERT INTO `backgroundjoblog` VALUES ('6cd01dae-8905-473e-a80b-3a8cb2c27ca1', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:30:39', '0.01', '2017-07-26 09:30:39', '');
INSERT INTO `backgroundjoblog` VALUES ('6ddb01ef-0ff5-443f-99e4-da19d09926ec', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:24:52', '0.00', '2017-07-26 09:24:52', '[extend_logA:JobTestA Executing2017/7/26 9:24:52,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('6def4914-11d7-4435-9c60-c4252b2aa827', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:25:27', '0.01', '2017-07-26 09:25:27', '');
INSERT INTO `backgroundjoblog` VALUES ('6df3ed8c-3ec5-4f7e-8c73-7750ddabfc98', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:29:42', '0.01', '2017-07-26 09:29:42', '');
INSERT INTO `backgroundjoblog` VALUES ('6f39444c-b451-4547-a71e-bbb4d13debcf', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:31:21', '0.01', '2017-07-26 09:31:21', '');
INSERT INTO `backgroundjoblog` VALUES ('6fdf7d19-471c-4575-ac7a-b01e8434175d', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:29:48', '0.02', '2017-07-26 09:29:48', '[extend_logA:JobTestA Executing2017/7/26 9:29:48,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('70efec6d-837c-47d1-bb00-d8d0011f3d72', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:30:32', '0.00', '2017-07-26 09:30:32', '[extend_logA:JobTestA Executing2017/7/26 9:30:32,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('712c7a2e-9b43-4260-9946-35522bc7c9c6', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:33:30', '0.00', '2017-07-26 09:33:30', '');
INSERT INTO `backgroundjoblog` VALUES ('71750bf5-68a2-4b2f-ae52-c3b3c03f6ac2', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:32:27', '0.00', '2017-07-26 09:32:27', '');
INSERT INTO `backgroundjoblog` VALUES ('71e4f661-e819-4130-8491-eb1f59ecca5e', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:35:24', '0.01', '2017-07-26 09:35:24', '[extend_logA:JobTestA Executing2017/7/26 9:35:24,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('72b8b92c-5c67-4b4f-923d-9473da7c7185', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:34:52', '0.00', '2017-07-26 09:34:52', '[extend_logA:JobTestA Executing2017/7/26 9:34:52,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('72c89406-1fdf-476d-9096-c3edab2832c3', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:26:32', '0.00', '2017-07-26 09:26:32', '[extend_logA:JobTestA Executing2017/7/26 9:26:32,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('7357e41b-b7c6-433b-a6cc-d8ec4abc17ae', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:27:00', '0.02', '2017-07-26 09:27:00', '');
INSERT INTO `backgroundjoblog` VALUES ('74648f72-3305-4bb7-975b-ce5d18a151e2', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:27:09', '0.01', '2017-07-26 09:27:09', '');
INSERT INTO `backgroundjoblog` VALUES ('74fef2d4-d664-4410-bb3e-dec87ebd8e2d', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:34:18', '0.00', '2017-07-26 09:34:18', '');
INSERT INTO `backgroundjoblog` VALUES ('75793477-3219-4dff-95f6-d317fb50829b', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:29:00', '0.02', '2017-07-26 09:29:00', '');
INSERT INTO `backgroundjoblog` VALUES ('760f3052-918e-4aa0-9591-faeceaf8d491', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:28:42', '0.01', '2017-07-26 09:28:42', '');
INSERT INTO `backgroundjoblog` VALUES ('76df4fa3-675d-444d-8fd9-f8380b8fd39d', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:33:56', '0.00', '2017-07-26 09:33:56', '[extend_logA:JobTestA Executing2017/7/26 9:33:56,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('777e0de7-603f-463c-a377-2296858a88e3', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:30:06', '0.01', '2017-07-26 09:30:06', '');
INSERT INTO `backgroundjoblog` VALUES ('779aece4-bcd8-436c-a8d6-0f286e55ec8d', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:30:16', '0.00', '2017-07-26 09:30:16', '[extend_logA:JobTestA Executing2017/7/26 9:30:16,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('77d3bc6e-5331-40bb-a80c-fd2e2b829fc5', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:33:06', '0.01', '2017-07-26 09:33:06', '');
INSERT INTO `backgroundjoblog` VALUES ('7847f049-1fc1-4eac-85f4-8b00fbe2068e', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:26:36', '0.01', '2017-07-26 09:26:36', '[extend_logA:JobTestA Executing2017/7/26 9:26:36,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('79155aef-b326-461a-972c-654af3396748', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:25:15', '0.01', '2017-07-26 09:25:15', '');
INSERT INTO `backgroundjoblog` VALUES ('7a137690-0eb4-4723-807e-f3defe31c02d', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:26:16', '0.01', '2017-07-26 09:26:16', '[extend_logA:JobTestA Executing2017/7/26 9:26:16,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('7a218757-d7a4-47c7-b928-1cddb89ba5cc', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:28:15', '0.01', '2017-07-26 09:28:15', '');
INSERT INTO `backgroundjoblog` VALUES ('7ce7fcff-1d7f-437c-a586-376bd9b2e021', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:32:48', '0.02', '2017-07-26 09:32:48', '');
INSERT INTO `backgroundjoblog` VALUES ('7cf3c4cb-2315-4ae7-ae4d-df6a407eaba4', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:27:40', '0.01', '2017-07-26 09:27:40', '[extend_logA:JobTestA Executing2017/7/26 9:27:40,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('7d6a1c18-1551-4c48-a619-746026ed000d', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:29:30', '0.00', '2017-07-26 09:29:30', '');
INSERT INTO `backgroundjoblog` VALUES ('7d82772e-d330-411f-8539-ab0b7be04e80', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:34:39', '0.01', '2017-07-26 09:34:39', '');
INSERT INTO `backgroundjoblog` VALUES ('7edd2eba-67cc-4446-86af-46a7898c19a4', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:29:12', '0.01', '2017-07-26 09:29:12', '');
INSERT INTO `backgroundjoblog` VALUES ('7f359109-3b64-45f7-a419-6e05013c4703', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:35:03', '0.00', '2017-07-26 09:35:03', '');
INSERT INTO `backgroundjoblog` VALUES ('7f4ebab5-1160-40b5-8a10-4d9e125ffd39', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:31:24', '0.03', '2017-07-26 09:31:24', '');
INSERT INTO `backgroundjoblog` VALUES ('7f87868a-8ed9-4e92-9c5c-cd8ab24ea87b', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:27:45', '0.01', '2017-07-26 09:27:45', '');
INSERT INTO `backgroundjoblog` VALUES ('81045d3d-f024-495b-b4e7-32077e5436a2', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:28:42', '0.01', '2017-07-26 09:28:42', '');
INSERT INTO `backgroundjoblog` VALUES ('81da1fe9-733f-4bc6-a7b4-14e4dc524de5', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:31:48', '0.02', '2017-07-26 09:31:48', '');
INSERT INTO `backgroundjoblog` VALUES ('825ec216-2779-4c84-8368-61e7eddd26e1', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:29:12', '0.00', '2017-07-26 09:29:12', '');
INSERT INTO `backgroundjoblog` VALUES ('831e7f91-b8c9-4b3e-9976-ef7c7ed95baa', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:34:24', '0.04', '2017-07-26 09:34:24', '[extend_logA:JobTestA Executing2017/7/26 9:34:24,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('835db490-f99e-4680-badb-75cbd62e60d7', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:32:54', '0.01', '2017-07-26 09:32:54', '');
INSERT INTO `backgroundjoblog` VALUES ('838b96aa-ad0c-4878-bfe3-61bdd20b4fdf', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:30:15', '0.01', '2017-07-26 09:30:16', '');
INSERT INTO `backgroundjoblog` VALUES ('84b7b1e6-aeb9-4ee2-a080-be9891906491', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:25:39', '0.01', '2017-07-26 09:25:39', '');
INSERT INTO `backgroundjoblog` VALUES ('84cd3604-a61a-4a4f-8338-92d0c4f751c3', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:29:48', '0.01', '2017-07-26 09:29:48', '');
INSERT INTO `backgroundjoblog` VALUES ('84dbec63-850a-4c43-babf-3e520612181c', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:26:21', '0.01', '2017-07-26 09:26:21', '');
INSERT INTO `backgroundjoblog` VALUES ('8513a44d-3701-462f-8fc9-0a99e4ec6c7c', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:29:36', '0.02', '2017-07-26 09:29:36', '[extend_logA:JobTestA Executing2017/7/26 9:29:36,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('85ae8ddd-40f0-41d4-a8c3-30a0308b69b7', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:30:48', '0.02', '2017-07-26 09:30:48', '');
INSERT INTO `backgroundjoblog` VALUES ('85c9ceba-5f3a-43ad-a47d-b2b6a2488942', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:33:24', '0.01', '2017-07-26 09:33:24', '[extend_logA:JobTestA Executing2017/7/26 9:33:24,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('86119a36-8e2e-4d80-a955-6da26a92540c', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:29:16', '0.00', '2017-07-26 09:29:16', '[extend_logA:JobTestA Executing2017/7/26 9:29:16,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('8649c898-d710-4675-af36-ea6dacfad2fe', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:27:30', '0.01', '2017-07-26 09:27:30', '');
INSERT INTO `backgroundjoblog` VALUES ('86f01fdb-714a-4d46-9d3f-904f32f34ae0', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:26:42', '0.01', '2017-07-26 09:26:42', '');
INSERT INTO `backgroundjoblog` VALUES ('874e7532-d450-47d7-a1ba-38ef28cce859', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:32:45', '0.01', '2017-07-26 09:32:45', '');
INSERT INTO `backgroundjoblog` VALUES ('88964780-6393-455c-9e19-bc3889ca554c', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:35:24', '0.01', '2017-07-26 09:35:24', '');
INSERT INTO `backgroundjoblog` VALUES ('88c9f716-0005-4243-b200-d3ed46280274', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:31:36', '0.01', '2017-07-26 09:31:36', '[extend_logA:JobTestA Executing2017/7/26 9:31:36,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('892c89ef-fb06-463e-b0c6-041a0aa67cb7', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:26:09', '0.01', '2017-07-26 09:26:09', '');
INSERT INTO `backgroundjoblog` VALUES ('89a786d6-9668-4f43-8b6d-d84caadfa995', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:26:36', '0.01', '2017-07-26 09:26:36', '');
INSERT INTO `backgroundjoblog` VALUES ('89f9b397-d73b-4bd5-9f05-d2942a7f0da5', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:27:08', '0.00', '2017-07-26 09:27:08', '[extend_logA:JobTestA Executing2017/7/26 9:27:08,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('8a4ec930-7c24-4e38-948a-e14eb5c619be', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:29:21', '0.01', '2017-07-26 09:29:21', '');
INSERT INTO `backgroundjoblog` VALUES ('8acfb756-67a3-4dc6-803e-5af5dd775f4e', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:33:54', '0.00', '2017-07-26 09:33:54', '');
INSERT INTO `backgroundjoblog` VALUES ('8bbf58a5-391b-42fb-b364-a71602ae0854', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:28:32', '0.00', '2017-07-26 09:28:32', '[extend_logA:JobTestA Executing2017/7/26 9:28:32,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('8bd5254c-adf5-4118-aad2-d069b2409c04', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:35:44', '0.00', '2017-07-26 09:35:44', '[extend_logA:JobTestA Executing2017/7/26 9:35:44,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('8bee9927-a47c-4ce6-a518-8f7705540c6f', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:33:36', '0.02', '2017-07-26 09:33:36', '');
INSERT INTO `backgroundjoblog` VALUES ('8bef8ccd-4e55-45b0-88fd-3cae786c8414', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:25:00', '0.01', '2017-07-26 09:25:00', '[extend_logA:JobTestA Executing2017/7/26 9:25:00,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('8c4db6c9-9562-40ca-862e-dc58c7c40bcc', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:32:18', '0.01', '2017-07-26 09:32:18', '');
INSERT INTO `backgroundjoblog` VALUES ('8c5971e8-de1e-4088-b54e-486bfdc480b8', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:26:24', '0.03', '2017-07-26 09:26:24', '');
INSERT INTO `backgroundjoblog` VALUES ('8ca17e4e-af80-4961-830c-f306e8d70550', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:29:27', '0.01', '2017-07-26 09:29:27', '');
INSERT INTO `backgroundjoblog` VALUES ('8dccf599-4713-46ea-821d-d9552439eb09', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:35:45', '0.00', '2017-07-26 09:35:45', '');
INSERT INTO `backgroundjoblog` VALUES ('8e006b45-0396-4e68-88a9-a6b3d625d29b', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:31:18', '0.00', '2017-07-26 09:31:18', '');
INSERT INTO `backgroundjoblog` VALUES ('8e32a11c-97e3-4405-9c36-90bfd8ca4f4e', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:34:18', '0.01', '2017-07-26 09:34:18', '');
INSERT INTO `backgroundjoblog` VALUES ('8f2fa742-97ff-4e71-92c0-2189e56bb053', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:28:24', '0.03', '2017-07-26 09:28:24', '');
INSERT INTO `backgroundjoblog` VALUES ('8f6960a0-9386-45d6-8e7d-1d0a370ad649', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:28:33', '0.01', '2017-07-26 09:28:33', '');
INSERT INTO `backgroundjoblog` VALUES ('8fb258c8-8213-4826-a824-54f87fa94ae8', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:31:48', '0.01', '2017-07-26 09:31:48', '[extend_logA:JobTestA Executing2017/7/26 9:31:48,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('8fdbabb3-007c-414b-a6f4-322aafddb6f5', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:34:03', '0.01', '2017-07-26 09:34:03', '');
INSERT INTO `backgroundjoblog` VALUES ('9032cef8-8bbc-40b9-8b3b-e7452c8e1aad', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:26:12', '0.02', '2017-07-26 09:26:12', '');
INSERT INTO `backgroundjoblog` VALUES ('90eee9a6-219a-40e0-95e2-b26d64d8de8f', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:29:06', '0.00', '2017-07-26 09:29:07', '');
INSERT INTO `backgroundjoblog` VALUES ('91e160d0-48b2-4fca-b8ec-92959bce7301', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:29:51', '0.01', '2017-07-26 09:29:51', '');
INSERT INTO `backgroundjoblog` VALUES ('91f51461-ec76-4ac1-a25d-0a4b57ad4262', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:34:04', '0.00', '2017-07-26 09:34:04', '[extend_logA:JobTestA Executing2017/7/26 9:34:04,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('92193af1-0425-4832-b0aa-6be3bb13ca04', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:35:12', '0.01', '2017-07-26 09:35:12', '');
INSERT INTO `backgroundjoblog` VALUES ('925b11f6-9bd8-4bee-96cd-59c1f55e8c1a', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:33:33', '0.01', '2017-07-26 09:33:33', '');
INSERT INTO `backgroundjoblog` VALUES ('92a071ee-7f89-4346-8957-9c8705be642c', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:30:48', '0.01', '2017-07-26 09:30:48', '[extend_logA:JobTestA Executing2017/7/26 9:30:48,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('92bc9e46-8de8-43c3-8247-26c4a024004e', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:32:40', '0.00', '2017-07-26 09:32:40', '[extend_logA:JobTestA Executing2017/7/26 9:32:40,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('92fcfdc7-6a2f-4e46-9230-382451f30bf6', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:33:15', '0.01', '2017-07-26 09:33:15', '');
INSERT INTO `backgroundjoblog` VALUES ('9353e09f-19e8-475f-a884-2fad0a4c9f1f', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:28:44', '0.00', '2017-07-26 09:28:44', '[extend_logA:JobTestA Executing2017/7/26 9:28:44,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('93787db8-4229-479e-a5a7-9f42f5d5983f', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:27:52', '0.01', '2017-07-26 09:27:52', '[extend_logA:JobTestA Executing2017/7/26 9:27:52,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('93e8aadc-a9af-4d8a-8e61-30dad4093fb8', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:30:00', '0.02', '2017-07-26 09:30:00', '');
INSERT INTO `backgroundjoblog` VALUES ('95564d81-64ed-434c-8ab6-1b614d48ae82', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:31:12', '0.01', '2017-07-26 09:31:12', '[extend_logA:JobTestA Executing2017/7/26 9:31:12,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('969f1d87-3bde-43ea-9caf-9d812490e5f9', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:32:56', '0.00', '2017-07-26 09:32:56', '[extend_logA:JobTestA Executing2017/7/26 9:32:56,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('96e21b8e-7724-4fbe-b8e7-4986d0fe9a8a', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:30:12', '0.02', '2017-07-26 09:30:12', '[extend_logA:JobTestA Executing2017/7/26 9:30:12,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('9783ee03-67ee-45b3-9e3c-b810104aca01', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:28:51', '0.01', '2017-07-26 09:28:51', '');
INSERT INTO `backgroundjoblog` VALUES ('97bf7306-b31e-4d8e-9acf-ff556427304b', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:31:06', '0.00', '2017-07-26 09:31:06', '');
INSERT INTO `backgroundjoblog` VALUES ('98031de6-4135-4a6e-8ecd-0003458c8e52', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:27:27', '0.00', '2017-07-26 09:27:27', '');
INSERT INTO `backgroundjoblog` VALUES ('982b23c4-f1f4-4e5f-ac6a-3f8c5e58ec04', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:24:56', '0.00', '2017-07-26 09:24:56', '[extend_logA:JobTestA Executing2017/7/26 9:24:56,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('983bfdf7-f6ce-4f77-b8d2-581da4d28920', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:24:48', '0.01', '2017-07-26 09:24:48', '');
INSERT INTO `backgroundjoblog` VALUES ('984f2fd2-51bd-464d-bb25-511c14f951ca', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:26:00', '0.03', '2017-07-26 09:26:00', '');
INSERT INTO `backgroundjoblog` VALUES ('98a26c24-7627-4eac-ae9a-d82a56d20d63', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:27:06', '0.01', '2017-07-26 09:27:06', '');
INSERT INTO `backgroundjoblog` VALUES ('99d98cdc-f618-4c27-8200-8aa262956e35', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:35:21', '0.01', '2017-07-26 09:35:21', '');
INSERT INTO `backgroundjoblog` VALUES ('99faa245-708d-465c-b092-aa491930b34f', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:25:42', '0.01', '2017-07-26 09:25:42', '');
INSERT INTO `backgroundjoblog` VALUES ('9a700b05-600d-4f9f-94ef-b8991739d06f', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:34:54', '0.01', '2017-07-26 09:34:54', '');
INSERT INTO `backgroundjoblog` VALUES ('9bae51a9-bc97-456f-90e4-b08aaf72c6b4', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:28:18', '0.00', '2017-07-26 09:28:18', '');
INSERT INTO `backgroundjoblog` VALUES ('9cc73779-75d2-429a-a2f3-ab6c9ee7936c', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:25:52', '0.01', '2017-07-26 09:25:52', '[extend_logA:JobTestA Executing2017/7/26 9:25:52,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('9d38100c-a832-4b9f-be27-c417f5993e0f', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:27:48', '0.03', '2017-07-26 09:27:48', '');
INSERT INTO `backgroundjoblog` VALUES ('9e294067-3d12-4a3d-a235-5a52bce395f3', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:26:52', '0.00', '2017-07-26 09:26:52', '[extend_logA:JobTestA Executing2017/7/26 9:26:52,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('9e97d027-e84f-4611-82c7-24b8b25fa495', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:35:18', '0.01', '2017-07-26 09:35:18', '');
INSERT INTO `backgroundjoblog` VALUES ('9f6ea52e-3391-4788-9be7-63fae459bdcf', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:28:08', '0.00', '2017-07-26 09:28:08', '[extend_logA:JobTestA Executing2017/7/26 9:28:08,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('9fe786bc-9eef-41ee-9b1d-139e6f2e30dc', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:28:54', '0.01', '2017-07-26 09:28:54', '');
INSERT INTO `backgroundjoblog` VALUES ('a0bc658f-1b48-4ecd-b42b-52f5a588a972', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:35:16', '0.00', '2017-07-26 09:35:16', '[extend_logA:JobTestA Executing2017/7/26 9:35:16,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('a1c8116e-881c-4728-9613-8f8d2060e147', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:25:45', '0.01', '2017-07-26 09:25:45', '');
INSERT INTO `backgroundjoblog` VALUES ('a2696139-02f1-41e2-ac5a-ecc42933311e', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:30:12', '0.02', '2017-07-26 09:30:12', '');
INSERT INTO `backgroundjoblog` VALUES ('a29e948c-c593-41a4-9487-90932994ce34', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:26:08', '0.01', '2017-07-26 09:26:08', '[extend_logA:JobTestA Executing2017/7/26 9:26:08,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('a30b7c48-2bd5-46c4-a13e-c390d053d8f0', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:31:54', '0.01', '2017-07-26 09:31:54', '');
INSERT INTO `backgroundjoblog` VALUES ('a310075d-b27d-4050-b89c-dd58b6270faf', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:33:48', '0.02', '2017-07-26 09:33:48', '[extend_logA:JobTestA Executing2017/7/26 9:33:48,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('a4376372-c395-4272-8b4e-69b789d24b6a', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:26:30', '0.02', '2017-07-26 09:26:30', '');
INSERT INTO `backgroundjoblog` VALUES ('a471246d-537a-4a91-962b-7b2faa80137f', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:33:28', '0.00', '2017-07-26 09:33:28', '[extend_logA:JobTestA Executing2017/7/26 9:33:28,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('a5748667-de35-422a-b55e-2d9c839999a3', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:35:30', '0.01', '2017-07-26 09:35:30', '');
INSERT INTO `backgroundjoblog` VALUES ('a6163600-5902-4479-b86e-1c5716262a01', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:35:04', '0.00', '2017-07-26 09:35:04', '[extend_logA:JobTestA Executing2017/7/26 9:35:04,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('a626be34-2795-4eb5-8932-0b92549dd930', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:28:27', '0.00', '2017-07-26 09:28:27', '');
INSERT INTO `backgroundjoblog` VALUES ('a6850260-1e06-4355-bda5-d9f5306dc9a9', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:31:39', '0.01', '2017-07-26 09:31:39', '');
INSERT INTO `backgroundjoblog` VALUES ('a6f6bc85-a671-4597-a30d-c9a753fd9a05', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:33:48', '0.01', '2017-07-26 09:33:48', '');
INSERT INTO `backgroundjoblog` VALUES ('a7358db2-0a1d-4ec3-b8cc-23cd7cf5175b', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:25:18', '0.01', '2017-07-26 09:25:18', '');
INSERT INTO `backgroundjoblog` VALUES ('a7b10dd7-8e2f-4ea9-bec9-83195c0e8ee0', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:31:51', '0.00', '2017-07-26 09:31:51', '');
INSERT INTO `backgroundjoblog` VALUES ('a7d0fd1f-2b4f-4b93-9375-fe297fbe6fb5', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:29:36', '0.03', '2017-07-26 09:29:36', '');
INSERT INTO `backgroundjoblog` VALUES ('a7e5b435-0d01-4035-bbee-3a0edeb236aa', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:25:40', '0.00', '2017-07-26 09:25:40', '[extend_logA:JobTestA Executing2017/7/26 9:25:40,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('a89a959e-d57d-414c-a953-5876ddc8a911', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:29:39', '0.01', '2017-07-26 09:29:39', '');
INSERT INTO `backgroundjoblog` VALUES ('a9133ce3-b556-4b36-b968-375ae5dc1697', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:34:42', '0.03', '2017-07-26 09:34:42', '');
INSERT INTO `backgroundjoblog` VALUES ('a95a5687-ad34-40cc-b946-140cfa9ad313', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:34:24', '0.04', '2017-07-26 09:34:24', '');
INSERT INTO `backgroundjoblog` VALUES ('a9d8bd82-e22b-4765-a586-14816e8c3ac7', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:29:30', '0.01', '2017-07-26 09:29:30', '');
INSERT INTO `backgroundjoblog` VALUES ('a9f1ba1f-c68e-4de3-b084-bd26b8a05802', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:32:00', '0.03', '2017-07-26 09:32:00', '');
INSERT INTO `backgroundjoblog` VALUES ('aac9cf9b-6b14-48b5-b52b-ec80558bb49c', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:35:36', '0.02', '2017-07-26 09:35:36', '');
INSERT INTO `backgroundjoblog` VALUES ('ab5c3121-27aa-4b14-94bf-f60c42adcec4', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:34:48', '0.01', '2017-07-26 09:34:48', '');
INSERT INTO `backgroundjoblog` VALUES ('ab68c9f5-b2e3-4405-ad4b-0cc580d446e5', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:33:18', '0.00', '2017-07-26 09:33:18', '');
INSERT INTO `backgroundjoblog` VALUES ('aca1c66f-d28e-4666-9204-0995e14e1373', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:28:48', '0.01', '2017-07-26 09:28:48', '[extend_logA:JobTestA Executing2017/7/26 9:28:48,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('ad64976c-5a7b-4d11-ab8d-6ffb306c7291', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:32:51', '0.01', '2017-07-26 09:32:51', '');
INSERT INTO `backgroundjoblog` VALUES ('ad8af5f8-b229-4b44-962d-98095fab762e', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:28:21', '0.01', '2017-07-26 09:28:21', '');
INSERT INTO `backgroundjoblog` VALUES ('ae7e1d15-2330-4939-a77b-29f17b0c0c71', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:33:42', '0.01', '2017-07-26 09:33:42', '');
INSERT INTO `backgroundjoblog` VALUES ('b0046f7d-06b9-4151-9109-367c06fed809', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:31:06', '0.01', '2017-07-26 09:31:06', '');
INSERT INTO `backgroundjoblog` VALUES ('b06d0f69-d50d-4faf-87d1-abb0922b6378', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:27:18', '0.01', '2017-07-26 09:27:18', '');
INSERT INTO `backgroundjoblog` VALUES ('b0cd9e38-306c-4be1-b753-7771e0c6343e', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:28:00', '0.01', '2017-07-26 09:28:00', '');
INSERT INTO `backgroundjoblog` VALUES ('b15ae821-8082-446c-8c58-8bc93b91bbe9', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:31:08', '0.00', '2017-07-26 09:31:08', '[extend_logA:JobTestA Executing2017/7/26 9:31:08,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('b1e129f5-2482-48a6-b1bb-d6bf74ab7c25', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:34:36', '0.01', '2017-07-26 09:34:36', '');
INSERT INTO `backgroundjoblog` VALUES ('b2594cbf-4b22-4772-ac07-1110a8b9149c', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:26:42', '0.00', '2017-07-26 09:26:42', '');
INSERT INTO `backgroundjoblog` VALUES ('b2bf0ea2-bf5f-4521-955a-e293b78bcf15', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:32:20', '0.00', '2017-07-26 09:32:20', '[extend_logA:JobTestA Executing2017/7/26 9:32:20,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('b3c6f04c-a0f5-4ddb-be1d-789128d749a6', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:27:54', '0.00', '2017-07-26 09:27:54', '');
INSERT INTO `backgroundjoblog` VALUES ('b4af0fcf-423f-4044-9d52-5c9af1cce61b', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:30:57', '0.01', '2017-07-26 09:30:57', '');
INSERT INTO `backgroundjoblog` VALUES ('b4dbb191-38bd-4340-80a4-45e6660035b3', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:30:56', '0.00', '2017-07-26 09:30:56', '[extend_logA:JobTestA Executing2017/7/26 9:30:56,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('b4edadc0-dfa1-4f71-958b-2486eec6590e', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:33:04', '0.00', '2017-07-26 09:33:04', '[extend_logA:JobTestA Executing2017/7/26 9:33:04,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('b5de62a5-6021-46b5-a51f-0810ba52365e', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:24:44', '0.04', '2017-07-26 09:24:44', '[extend_logA:JobTestA Executing2017/7/26 9:24:44,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('b6d00ca6-48e5-434e-acb2-94408390264d', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:33:44', '0.00', '2017-07-26 09:33:44', '[extend_logA:JobTestA Executing2017/7/26 9:33:44,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('b70ae34d-3dd5-4ea5-a1ef-8b0076a880af', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:29:08', '0.00', '2017-07-26 09:29:10', '[extend_logA:JobTestA Executing2017/7/26 9:29:08,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('b75348bf-0fbe-43cb-ae42-e51ce231d7c2', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:32:36', '0.02', '2017-07-26 09:32:36', '[extend_logA:JobTestA Executing2017/7/26 9:32:36,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('b78b8a36-ffbf-46ae-a4e6-49c31ac8f602', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:35:36', '0.01', '2017-07-26 09:35:36', '');
INSERT INTO `backgroundjoblog` VALUES ('b9c39d13-6d36-4809-a460-48bed8c2c84d', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:34:12', '0.01', '2017-07-26 09:34:12', '');
INSERT INTO `backgroundjoblog` VALUES ('ba601fa5-0689-4f60-b7a3-0812e5d9ba88', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:25:06', '0.02', '2017-07-26 09:25:06', '');
INSERT INTO `backgroundjoblog` VALUES ('bb6caf78-f105-4615-b959-c7131547b7af', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:30:18', '0.01', '2017-07-26 09:30:18', '');
INSERT INTO `backgroundjoblog` VALUES ('bbec72fe-395f-4eb6-b391-ad8aeb33f3b4', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:27:15', '0.01', '2017-07-26 09:27:15', '');
INSERT INTO `backgroundjoblog` VALUES ('bc12bf46-b568-4207-91ea-40ced081f16a', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:28:54', '0.01', '2017-07-26 09:28:54', '');
INSERT INTO `backgroundjoblog` VALUES ('bc19a1ca-ee03-40ac-a50c-07354987dc85', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:25:32', '0.01', '2017-07-26 09:25:32', '[extend_logA:JobTestA Executing2017/7/26 9:25:32,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('bd323e29-96ca-4398-8c89-74284ceed364', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:27:24', '0.01', '2017-07-26 09:27:24', '');
INSERT INTO `backgroundjoblog` VALUES ('bd3ffa16-73d4-4048-832b-f7f334f3507c', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:33:06', '0.01', '2017-07-26 09:33:06', '');
INSERT INTO `backgroundjoblog` VALUES ('bd4ae99a-1040-40ed-991e-1e0b4b553ebb', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:34:30', '0.00', '2017-07-26 09:34:30', '');
INSERT INTO `backgroundjoblog` VALUES ('bdabcad3-5c26-4df7-a387-6459f012581e', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:33:30', '0.01', '2017-07-26 09:33:30', '');
INSERT INTO `backgroundjoblog` VALUES ('c0010721-71cc-45dd-acb1-4448c81f2ea6', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:31:03', '0.01', '2017-07-26 09:31:03', '');
INSERT INTO `backgroundjoblog` VALUES ('c081a18b-8d9e-4eb6-ab43-8238e3fcc19e', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:30:36', '0.01', '2017-07-26 09:30:36', '');
INSERT INTO `backgroundjoblog` VALUES ('c0c813ba-0afc-43d1-a002-2883f174ca85', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:35:06', '0.01', '2017-07-26 09:35:06', '');
INSERT INTO `backgroundjoblog` VALUES ('c262f910-3c3e-4e03-8be2-25c91c4fc8f5', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:31:44', '0.00', '2017-07-26 09:31:44', '[extend_logA:JobTestA Executing2017/7/26 9:31:44,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('c27afd76-6846-4a5b-a745-04c6e083ceaa', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:35:08', '0.00', '2017-07-26 09:35:08', '[extend_logA:JobTestA Executing2017/7/26 9:35:08,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('c2879f11-34a9-4c67-8a30-109f14715220', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:32:06', '0.03', '2017-07-26 09:32:06', '');
INSERT INTO `backgroundjoblog` VALUES ('c2bfa360-c06f-4d84-8222-4bdcc7a10f60', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:34:15', '0.00', '2017-07-26 09:34:15', '');
INSERT INTO `backgroundjoblog` VALUES ('c316a6f1-9678-4e43-b14a-c507457548c5', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:31:00', '0.01', '2017-07-26 09:31:00', '');
INSERT INTO `backgroundjoblog` VALUES ('c38953d9-12be-45d2-a74e-fb6d4c2a9c2c', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:27:54', '0.01', '2017-07-26 09:27:54', '');
INSERT INTO `backgroundjoblog` VALUES ('c3ce2e9b-e108-4835-934d-90f8f5e7e1c1', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:33:00', '0.01', '2017-07-26 09:33:00', '[extend_logA:JobTestA Executing2017/7/26 9:33:00,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('c3e89005-c46c-409f-828a-5c89c12c559b', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:33:36', '0.02', '2017-07-26 09:33:36', '');
INSERT INTO `backgroundjoblog` VALUES ('c46c4a6e-5e13-414d-812d-68b09f977ab9', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:35:00', '0.03', '2017-07-26 09:35:00', '');
INSERT INTO `backgroundjoblog` VALUES ('c472f745-1e08-4d1d-b825-5b98920aca9f', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:31:00', '0.01', '2017-07-26 09:31:00', '');
INSERT INTO `backgroundjoblog` VALUES ('c5122e85-8140-4c01-8bda-ab75e490f5b7', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:30:28', '0.00', '2017-07-26 09:30:28', '[extend_logA:JobTestA Executing2017/7/26 9:30:28,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('c53d24c1-df57-43e6-82dc-bf3b5358609c', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:31:30', '0.01', '2017-07-26 09:31:30', '');
INSERT INTO `backgroundjoblog` VALUES ('c63c7689-be3a-46d2-aeb6-3c7a32a64dc6', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:31:20', '0.00', '2017-07-26 09:31:20', '[extend_logA:JobTestA Executing2017/7/26 9:31:20,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('c66d9965-d4f5-476d-83a7-9c7562d8d1ed', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:32:48', '0.01', '2017-07-26 09:32:48', '[extend_logA:JobTestA Executing2017/7/26 9:32:48,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('c688161b-7475-43b1-ad05-8d2e312aa8df', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:30:12', '0.02', '2017-07-26 09:30:12', '');
INSERT INTO `backgroundjoblog` VALUES ('c729a4c1-43a7-4dd1-b8ba-573e3fe37a18', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:25:33', '0.01', '2017-07-26 09:25:33', '');
INSERT INTO `backgroundjoblog` VALUES ('c812657e-85bd-4c13-a8b9-2679e07608a5', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:34:24', '0.02', '2017-07-26 09:34:24', '');
INSERT INTO `backgroundjoblog` VALUES ('c82cd34c-1158-4871-8c04-a4c50ad58eb9', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:35:06', '0.01', '2017-07-26 09:35:06', '');
INSERT INTO `backgroundjoblog` VALUES ('c8e5b672-9557-4c46-9df8-8c2580ebdd9a', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:27:42', '0.01', '2017-07-26 09:27:42', '');
INSERT INTO `backgroundjoblog` VALUES ('c9468243-6af4-4da9-9dd1-17ad65e835f1', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:29:18', '0.00', '2017-07-26 09:29:19', '');
INSERT INTO `backgroundjoblog` VALUES ('cae05941-f8e9-4f15-a74e-e2dc6abe040e', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:28:57', '0.01', '2017-07-26 09:28:57', '');
INSERT INTO `backgroundjoblog` VALUES ('cb18e028-8a50-493b-95ad-2b03eac90185', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:31:27', '0.01', '2017-07-26 09:31:27', '');
INSERT INTO `backgroundjoblog` VALUES ('cb2b596c-8cd4-4e21-ba87-262a84d9f1b5', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:26:45', '0.01', '2017-07-26 09:26:45', '');
INSERT INTO `backgroundjoblog` VALUES ('cb8b2e37-8f55-4e84-9b72-3d64d65e8c6f', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:30:51', '0.01', '2017-07-26 09:30:51', '');
INSERT INTO `backgroundjoblog` VALUES ('cc669915-4ba0-45d1-88bf-704f72818692', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:27:42', '0.01', '2017-07-26 09:27:42', '');
INSERT INTO `backgroundjoblog` VALUES ('cf358e85-6487-426c-a29f-cdbf484f5788', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:28:30', '0.03', '2017-07-26 09:28:30', '');
INSERT INTO `backgroundjoblog` VALUES ('cfa0522e-ffab-4c45-8c54-9dd5d853013e', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:35:42', '0.01', '2017-07-26 09:35:42', '');
INSERT INTO `backgroundjoblog` VALUES ('d07c81ba-50e8-49e2-9fb3-db95b321e8c7', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:26:24', '0.03', '2017-07-26 09:26:24', '[extend_logA:JobTestA Executing2017/7/26 9:26:24,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('d0f17e78-911a-41af-8d47-61618dff8db8', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:32:24', '0.01', '2017-07-26 09:32:24', '[extend_logA:JobTestA Executing2017/7/26 9:32:24,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('d0fb4125-2aa1-4fd4-9eae-990a1cc533d2', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:32:52', '0.00', '2017-07-26 09:32:52', '[extend_logA:JobTestA Executing2017/7/26 9:32:52,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('d1b6ea97-1db4-4d12-a006-55d2d4b084e6', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:32:16', '0.00', '2017-07-26 09:32:16', '[extend_logA:JobTestA Executing2017/7/26 9:32:16,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('d30231cb-c41a-4f28-992b-c3011626d90d', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:33:12', '0.02', '2017-07-26 09:33:12', '');
INSERT INTO `backgroundjoblog` VALUES ('d35ce214-1eac-4c23-8e9c-e0bc8b4fa2a8', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:25:57', '0.02', '2017-07-26 09:25:57', '');
INSERT INTO `backgroundjoblog` VALUES ('d4602997-492b-4d32-ab45-fd97f8c9a08a', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:34:54', '0.01', '2017-07-26 09:34:54', '');
INSERT INTO `backgroundjoblog` VALUES ('d4f6f484-df08-4eb1-8739-0f299e16ae63', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:28:18', '0.01', '2017-07-26 09:28:18', '');
INSERT INTO `backgroundjoblog` VALUES ('d51b54fa-9ab2-4e61-9e29-1638f978f79f', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:30:40', '0.00', '2017-07-26 09:30:40', '[extend_logA:JobTestA Executing2017/7/26 9:30:40,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('d57e09ac-4601-4a9c-831f-e44fd2d5492c', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:26:12', '0.02', '2017-07-26 09:26:12', '[extend_logA:JobTestA Executing2017/7/26 9:26:12,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('d594fa49-b96b-4d92-a764-608eb5161e04', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:30:36', '0.01', '2017-07-26 09:30:36', '[extend_logA:JobTestA Executing2017/7/26 9:30:36,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('d5c38ede-0cd1-451b-8eff-f3c25181c137', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:33:08', '0.00', '2017-07-26 09:33:08', '[extend_logA:JobTestA Executing2017/7/26 9:33:08,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('d68a4054-a389-4295-8262-3527ba1dfbb4', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:34:12', '0.01', '2017-07-26 09:34:12', '');
INSERT INTO `backgroundjoblog` VALUES ('d6fd03d4-7a89-45cc-83ed-742beca15c34', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:31:30', '0.01', '2017-07-26 09:31:30', '');
INSERT INTO `backgroundjoblog` VALUES ('d8b3b25f-fdf8-4122-8004-f7c7552431e4', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:26:36', '0.03', '2017-07-26 09:26:36', '');
INSERT INTO `backgroundjoblog` VALUES ('d8d282b2-8baa-490a-9638-660a820bff37', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:29:18', '0.01', '2017-07-26 09:29:19', '');
INSERT INTO `backgroundjoblog` VALUES ('d92db196-bdf2-48ed-94d4-a5f470a6aa61', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:30:42', '0.01', '2017-07-26 09:30:42', '');
INSERT INTO `backgroundjoblog` VALUES ('d9693396-d957-428d-a0c4-0b8edce3cb97', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:28:48', '0.02', '2017-07-26 09:28:48', '');
INSERT INTO `backgroundjoblog` VALUES ('da0ce117-9079-4be2-a694-fd8b0c91ebd8', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:32:04', '0.00', '2017-07-26 09:32:04', '[extend_logA:JobTestA Executing2017/7/26 9:32:04,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('da27c7b0-2306-49b2-a017-1dba414bbceb', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:33:16', '0.00', '2017-07-26 09:33:16', '[extend_logA:JobTestA Executing2017/7/26 9:33:16,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('da4e8fd6-daa5-4563-985d-21f27d5c5b9a', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:26:33', '0.00', '2017-07-26 09:26:33', '');
INSERT INTO `backgroundjoblog` VALUES ('dacc0645-ddaf-4cbb-85b2-2d5e03eb9902', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:32:28', '0.00', '2017-07-26 09:32:28', '[extend_logA:JobTestA Executing2017/7/26 9:32:28,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('dad15373-2ce5-4300-b10b-706d04781724', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:25:51', '0.00', '2017-07-26 09:25:51', '');
INSERT INTO `backgroundjoblog` VALUES ('db3f038d-cd2f-432a-b9ab-9e5316edef4d', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:28:45', '0.01', '2017-07-26 09:28:45', '');
INSERT INTO `backgroundjoblog` VALUES ('db7b2fcd-cac0-4356-97aa-a9e184a18f53', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:27:39', '0.01', '2017-07-26 09:27:39', '');
INSERT INTO `backgroundjoblog` VALUES ('dbc15bc7-e572-4ced-9805-428622c23dc7', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:34:06', '0.02', '2017-07-26 09:34:06', '');
INSERT INTO `backgroundjoblog` VALUES ('dc15b19d-70f7-467a-bd42-1a72f4fac868', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:33:40', '0.00', '2017-07-26 09:33:40', '[extend_logA:JobTestA Executing2017/7/26 9:33:40,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('dd285c08-662d-42ad-b04f-836fc9984769', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:26:48', '0.01', '2017-07-26 09:26:48', '');
INSERT INTO `backgroundjoblog` VALUES ('de1ff828-68b1-459f-9a12-ce60ab3a659f', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:28:09', '0.01', '2017-07-26 09:28:09', '');
INSERT INTO `backgroundjoblog` VALUES ('df649749-89f0-498c-928f-e60bc96130ad', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:26:06', '0.01', '2017-07-26 09:26:06', '');
INSERT INTO `backgroundjoblog` VALUES ('df9038e1-31da-437f-867e-94dbf4696273', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:33:00', '0.01', '2017-07-26 09:33:00', '');
INSERT INTO `backgroundjoblog` VALUES ('e1a6cbe8-310b-40d7-bcc0-29d2eed784f9', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:29:36', '0.01', '2017-07-26 09:29:36', '');
INSERT INTO `backgroundjoblog` VALUES ('e2a24d52-eddf-409b-abaf-526bcd81290c', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:32:21', '0.01', '2017-07-26 09:32:21', '');
INSERT INTO `backgroundjoblog` VALUES ('e340a275-2ade-438f-aaad-5a898969f640', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:27:36', '0.02', '2017-07-26 09:27:36', '');
INSERT INTO `backgroundjoblog` VALUES ('e370aff7-1cc1-405d-a08e-4bbc11f3b7c1', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:25:21', '0.01', '2017-07-26 09:25:21', '');
INSERT INTO `backgroundjoblog` VALUES ('e37a8014-926e-4711-a2c3-b16054a959be', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:35:24', '0.01', '2017-07-26 09:35:24', '');
INSERT INTO `backgroundjoblog` VALUES ('e3a26974-01c5-47a5-a85e-4bb4acfd6646', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:31:28', '0.00', '2017-07-26 09:31:28', '[extend_logA:JobTestA Executing2017/7/26 9:31:28,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('e3c41a04-fa58-4257-8891-d58b0517a03a', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:32:36', '0.02', '2017-07-26 09:32:36', '');
INSERT INTO `backgroundjoblog` VALUES ('e491df7f-57b7-4aa0-9cf9-c7e7befbb1e5', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:26:48', '0.01', '2017-07-26 09:26:48', '[extend_logA:JobTestA Executing2017/7/26 9:26:48,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('e51c750d-abce-4618-8758-f3d2f3eecd1c', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:28:30', '0.02', '2017-07-26 09:28:30', '');
INSERT INTO `backgroundjoblog` VALUES ('e5ada323-5688-41d4-8709-e2e3127eae8a', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:27:36', '0.01', '2017-07-26 09:27:36', '[extend_logA:JobTestA Executing2017/7/26 9:27:36,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('e5d2bbec-030a-4355-97c3-6e43c7dbdad5', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:29:24', '0.01', '2017-07-26 09:29:24', '');
INSERT INTO `backgroundjoblog` VALUES ('e632118e-aec9-4e24-869f-28cd9908ecba', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:35:40', '0.00', '2017-07-26 09:35:40', '[extend_logA:JobTestA Executing2017/7/26 9:35:40,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('e66b7b6a-88aa-426d-a00d-0a8feb717a5c', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:28:36', '0.01', '2017-07-26 09:28:36', '');
INSERT INTO `backgroundjoblog` VALUES ('e6832d1b-e9ac-4c83-9995-1488beaa8dff', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:29:00', '0.01', '2017-07-26 09:29:00', '');
INSERT INTO `backgroundjoblog` VALUES ('e70ad2f0-09b9-4bdb-92e8-c5dcb2024160', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:33:03', '0.00', '2017-07-26 09:33:03', '');
INSERT INTO `backgroundjoblog` VALUES ('e71327fe-26cb-44ed-bbd8-f980101d18ba', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:24:54', '0.03', '2017-07-26 09:24:54', '');
INSERT INTO `backgroundjoblog` VALUES ('e7428f9b-688b-48ea-bb7c-df9d52e60f6d', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:27:12', '0.01', '2017-07-26 09:27:12', '');
INSERT INTO `backgroundjoblog` VALUES ('e7dff412-498f-4f13-b2ca-0dc0ae7bec4b', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:33:48', '0.02', '2017-07-26 09:33:48', '');
INSERT INTO `backgroundjoblog` VALUES ('eb0fe0cf-860b-4b97-944e-e54b2b007962', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:30:20', '0.00', '2017-07-26 09:30:20', '[extend_logA:JobTestA Executing2017/7/26 9:30:20,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('eb7256de-b2f6-418a-bbb2-d5e1e447166d', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:29:33', '0.01', '2017-07-26 09:29:33', '');
INSERT INTO `backgroundjoblog` VALUES ('eb91c59f-edee-4310-915a-ddc4b462d6bf', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:28:36', '0.00', '2017-07-26 09:28:36', '[extend_logA:JobTestA Executing2017/7/26 9:28:36,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('ebf8033a-b4a9-4896-b28d-555762e16568', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:26:44', '0.00', '2017-07-26 09:26:44', '[extend_logA:JobTestA Executing2017/7/26 9:26:44,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('ec4ba3b2-162e-48d2-9349-eef1eed701bb', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:32:30', '0.01', '2017-07-26 09:32:30', '');
INSERT INTO `backgroundjoblog` VALUES ('ecb4ce96-e2c4-48f1-b5d7-33715df3304b', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:31:40', '0.00', '2017-07-26 09:31:40', '[extend_logA:JobTestA Executing2017/7/26 9:31:40,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('ed1a603d-ff5c-4b9e-a7c8-4541c5f18d7a', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:27:44', '0.00', '2017-07-26 09:27:44', '[extend_logA:JobTestA Executing2017/7/26 9:27:44,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('ed691e97-eaee-4fc1-aca7-d7f896de525a', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:35:12', '0.02', '2017-07-26 09:35:12', '');
INSERT INTO `backgroundjoblog` VALUES ('edd3abaf-6ce7-46e6-9416-e09102239ccf', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:27:24', '0.02', '2017-07-26 09:27:24', '');
INSERT INTO `backgroundjoblog` VALUES ('edffcae6-a42f-4da4-ae13-b30174e00a92', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:26:12', '0.02', '2017-07-26 09:26:12', '');
INSERT INTO `backgroundjoblog` VALUES ('ee0dba76-12d8-4b62-89d7-4acb06adaf28', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:28:04', '0.01', '2017-07-26 09:28:04', '[extend_logA:JobTestA Executing2017/7/26 9:28:04,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('ef331f79-26be-4182-9254-e7feed980272', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:27:57', '0.00', '2017-07-26 09:27:57', '');
INSERT INTO `backgroundjoblog` VALUES ('ef58bdc5-92b1-4102-9495-162095c7dc3d', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:27:12', '0.02', '2017-07-26 09:27:12', '');
INSERT INTO `backgroundjoblog` VALUES ('efed06bd-c80a-4287-9c56-f7764e40b99f', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:25:24', '0.01', '2017-07-26 09:25:24', '[extend_logA:JobTestA Executing2017/7/26 9:25:24,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('f0c0252f-ab29-4f6b-900d-be62c658aaa4', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:27:24', '0.01', '2017-07-26 09:27:24', '[extend_logA:JobTestA Executing2017/7/26 9:27:24,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('f1e023d1-e76d-4bba-a737-a0e39ccdad57', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:26:40', '0.00', '2017-07-26 09:26:40', '[extend_logA:JobTestA Executing2017/7/26 9:26:40,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('f218d5a2-54b0-4eb9-82f2-c2ef6a73618e', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:32:18', '0.01', '2017-07-26 09:32:18', '');
INSERT INTO `backgroundjoblog` VALUES ('f293c946-6f36-4c25-9187-f898223a2bf9', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:30:24', '0.01', '2017-07-26 09:30:24', '');
INSERT INTO `backgroundjoblog` VALUES ('f46d9da0-8a72-414c-8b95-40a141e4a94b', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:26:06', '0.02', '2017-07-26 09:26:06', '');
INSERT INTO `backgroundjoblog` VALUES ('f50b25ff-cda9-4bcb-bb42-abd1191afc71', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:25:54', '0.02', '2017-07-26 09:25:54', '');
INSERT INTO `backgroundjoblog` VALUES ('f519944a-91b0-4072-9d5a-0f41a76ec4c2', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:31:42', '0.01', '2017-07-26 09:31:42', '');
INSERT INTO `backgroundjoblog` VALUES ('f5a5fe13-b245-43a3-bd3b-474de2f81708', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:30:03', '0.01', '2017-07-26 09:30:03', '');
INSERT INTO `backgroundjoblog` VALUES ('f7df00f5-5b2a-4afb-a4d8-57d3d1ce30b2', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:26:18', '0.02', '2017-07-26 09:26:18', '');
INSERT INTO `backgroundjoblog` VALUES ('f8533a97-cf5d-4746-9cc9-5d1f4767690a', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:33:51', '0.01', '2017-07-26 09:33:51', '');
INSERT INTO `backgroundjoblog` VALUES ('f93d956a-2719-4c70-9044-b3781592a382', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:35:00', '0.03', '2017-07-26 09:35:00', '[extend_logA:JobTestA Executing2017/7/26 9:35:00,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('f9a4ab82-c71f-47f5-8b9e-7ffaa7af8020', '1cf9f275-0d48-4490-83b7-dd1ebdb9cafe', 'TestC', '2017-07-26 09:27:30', '0.01', '2017-07-26 09:27:30', '');
INSERT INTO `backgroundjoblog` VALUES ('fac98d03-ea0c-44c4-a23a-4e270eff04df', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:35:39', '0.01', '2017-07-26 09:35:39', '');
INSERT INTO `backgroundjoblog` VALUES ('fafe779d-d61c-4315-af56-bfd83990b336', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:24:48', '0.01', '2017-07-26 09:24:48', '[extend_logA:JobTestA Executing2017/7/26 9:24:48,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('fb45237c-aa7d-4270-935a-5abd34e72684', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:25:36', '0.01', '2017-07-26 09:25:36', '');
INSERT INTO `backgroundjoblog` VALUES ('fbb04b4c-6650-4e91-9c97-41668d617f24', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:31:04', '0.00', '2017-07-26 09:31:04', '[extend_logA:JobTestA Executing2017/7/26 9:31:04,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('fbbad32e-b115-4aa6-afbb-5c576f3a6693', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:27:32', '0.00', '2017-07-26 09:27:32', '[extend_logA:JobTestA Executing2017/7/26 9:27:32,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('fbf82817-77cc-4f6c-8dfa-e95e52750094', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:30:09', '0.01', '2017-07-26 09:30:09', '');
INSERT INTO `backgroundjoblog` VALUES ('fc6d3318-7c83-4eec-b266-bb6682a94294', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:33:09', '0.01', '2017-07-26 09:33:09', '');
INSERT INTO `backgroundjoblog` VALUES ('fc79302d-db0c-4f09-a459-85abd001a5b5', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:31:52', '0.00', '2017-07-26 09:31:52', '[extend_logA:JobTestA Executing2017/7/26 9:31:52,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('fd58e70c-8ce7-4e40-9f6e-133c7638a140', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:29:12', '0.00', '2017-07-26 09:29:12', '[extend_logA:JobTestA Executing2017/7/26 9:29:12,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('fe4480a4-855e-4df2-9d53-30c4ec0f33ad', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:27:28', '0.01', '2017-07-26 09:27:28', '[extend_logA:JobTestA Executing2017/7/26 9:27:28,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('fe589924-c6b2-4be5-9d52-a88c909832da', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:25:08', '0.01', '2017-07-26 09:25:08', '[extend_logA:JobTestA Executing2017/7/26 9:25:08,extend_run_result:success]');
INSERT INTO `backgroundjoblog` VALUES ('feb6c84e-8348-485d-8678-3e88bf90a160', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:32:09', '0.01', '2017-07-26 09:32:09', '');
INSERT INTO `backgroundjoblog` VALUES ('ff04ee3d-d1ac-4844-b4b6-841bd86a9d2e', 'da9462f9-b455-4a02-ac1c-3dfdc91f0b85', 'Job管理器', '2017-07-26 09:35:18', '0.01', '2017-07-26 09:35:18', '');
INSERT INTO `backgroundjoblog` VALUES ('ff2bb242-3c25-485e-b475-a5b0702b4887', '9438ca5a-320d-4784-b353-5bba2ea45b4c', 'TestA', '2017-07-26 09:28:16', '0.00', '2017-07-26 09:28:16', '[extend_logA:JobTestA Executing2017/7/26 9:28:16,extend_run_result:success]');
