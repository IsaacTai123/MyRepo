
1. HttpClientFactory 使用說明 及 對 HttpClient 的回顧和對比:
url: https://www.itread01.com/content/1564990083.html


2. 還有測試把httpclient or webclient 載下來的Web資料 用view 顯示, 在httpController裡面
測試過程中 發現 MVC 的view 並不是Razor page, 因為在裡面使用 @page會得到以下錯誤:

=> 
Object reference not set to an instance of an object.'
AspNetCore.Views_http_Index.ViewData.get returned null.


google 了一夏發現這篇 :
url: https://stackoverflow.com/questions/54813316/object-reference-not-set-to-an-instance-of-an-object-viewdatatitle-index
這篇也寫到 不要把Razor page mix with controller view.


Q1.  還有如何把data 丟進view 呢 ?? -> https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/adding-view?view=aspnetcore-5.0&tabs=visual-studio


Q2. 當我把網頁的data 抓下來 是html的格式 但把她用 ViewData[""] 丟給 View 卻沒有辦法顯示
最後解決辦法 : 使用 @Html.Raw() 把Html string回歸

3. 測試 Redirect 基於controllerBase class 的各個 Redirect method. 在redirectController