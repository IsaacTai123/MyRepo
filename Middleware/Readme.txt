測試 在執行controller action 之前 是否可以先經過全域middleware 
跑完之後再執行action,

測試結果是可以的 但要注意 Response.WriteAsync("hello world!") 是可以封鎖 HttpHeaders 的
HttpHeader 的操作都是無效的 所以在action 用return 會得到error "response has already started"

然後額外提醒 常見的middleware用法 都會包裝成extension method 就像在
startup.cs configure 裡面那些 app.use... 都是不同的Middleware