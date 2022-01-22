# ADuiDuiDui
# 啊对对对
## Unity版本：2020.3.26f1c1		2D项目

## 文件提交：
除程序外完成后打包资源时不要包含Unity生成的.meta文件，用微信应该就够了
用git提交的，这边已经做好ignore了，直接commit即可
要加入协作的可以发GitHub邮箱给我

## UGUI：
估计也不会超过10个面板，直接修改预制体里面的UI面板即可
做好的面板会放在Resources/UI下作为预制体使用UIMgr动态管理
搭建时的命名规则：xx_xxx（从简）
一组UI用一个空的物体包裹 ：layout_start
图片：img_xxx
按钮：btn_xxx
文本：txt_xxx
滑动；slider_xxx

## 代码：
纯C#编写，代码统一使用缩进格式，编码格式UTF-8
我上传了一些可能会用到的工具类：LiteTools
其中包括：事件系统，UI管理器，封装好的数据管理器等，都是简单的东西，直接用即可
不用过于考虑性能，实现逻辑优先

## 美术
2D资源：
图片统一为png格式，一般除背景大图以外，单张图片要控制大小几十kb以内
用一个文件夹装起相关联的png，不要不同的东西放在一个地方
命名格式：xx_xxx_1.png
如弹出提示的UI背景：bg_tips_1.png（中间是简写的名称）
UI
背景：bg
图标：icon
按钮：btn
线段：line
字图：txt
瓷砖：
背景：bg
地板：floor
墙壁：wall
建筑：build
物品：obj
其他之类的按规律即可
