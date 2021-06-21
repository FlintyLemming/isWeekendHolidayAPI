# isWeekendHolidayAPI
WebAPI 用于判断日期是否是周末或者是节假日（.NET 学习项目）

## To-Do

- [ ]  dockerfile

## 简介

判断某一天是否是节假日

## 功能

1. 支持 2017-2021 年的节假日
2. 具体返回内容参考下面的参数部分

## 使用方法

发送 GET 请求到 5000 端口 /DateInfo/{Date}

日期格式需要为 **yyyy-MM-dd**

![范例](https://img.mitsea.com/blog/posts/isWeekendHolidayAPI/Untitled.png)

## 参数

### date - 返回输入的日期

string 
nullable: true

### isWorkday - 是否是工作日，是为 true

boolean

### isHoliday - 是否是节假日，是为 true

boolean

### isWeekend - 是否是周末，是为 true

boolean

### holidayName - 返回节假日名称

string
nullable: true

### week - 星期

integer($int32)
