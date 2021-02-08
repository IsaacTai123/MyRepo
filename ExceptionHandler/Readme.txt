https://blog.johnwu.cc/article/ironman-day17-asp-net-core-exception-handler.html

例外處理(Exception Handler)算是程式開發蠻重要的一件事，尤其程式暴露在外，要是不小心顯示了什麼不該讓使用者看到的東西就糟糕了。
要在 ASP.NET Core 做一個通用的 Exception Handler 可以透過 Middleware 或 Filter，但兩者之間的執行週期確大不相同。
本篇將介紹 ASP.NET Core 透過 Middleware 及 Filter 異常處理的差異。

Key:
	ExceptionFilter 只能捕捉到Action & ActionFilter 所發出的Exception 
	所以看看其他Exception Handler的方法