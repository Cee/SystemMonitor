# Readme

## 运行环境
- 装有.NET Framework 4.0或以上的电脑
- 最好是64位Windows系统
- 本程序在Windows 7 + VS2013 + .NET Framework 4.0上运行通过

## 运行向导
1.  解压后会有`Lab 2`，`SystemMonitorV1`和`SystemMonitorV2` 三个文件夹。
2.  进入`Lab 2`后打开解决方案文件`Lab 2.sln`。
3.  选择合适的浏览器运行ASP.NET网页。
4.  默认使用2.0版本的`SystemMonitor`组件。若需要更换组件，选择Lab 2 - 引用 - 删除`SystemMonitor`后添加对应版本文件夹中的`SystemMonitor\bin\Release\`下的dll文件进行更换。

## 实现过程
### 组件部分
- 实现了`MyProcess`类用于封装每个进程的数据。
- 在函数`getProcess()`中使用`List<MyProcess>`作为返回类型，用于传递进程列表。

### 后端部分
- 采用`GridView`和`ObjectDataSource`绑定的方式，实现数据的呈现。通过设定中间体`ObjectDataSource`对`GridView`的处理函数`SelectMethod`完成对返回数据的处理，避免了使用`DataTable`不支持自定义类型的问题，极大的减少了代码工作量。
- 排序功能通过更改`SelectMethod`所调用的函数轻松快捷地处理表格刷新的问题。

### 前端部分
- 使用`BootStrap`框架，界面更加美观，使用响应式布局。

## 其他问题
- 偶尔少部分情况下会有异常，仅需重新启动应用即可。

## 关于我
- 博客: [Cee‘s Home](https://chu2byo.me)
- Github: [Cee's Github](https://github.com/cirnocee)
