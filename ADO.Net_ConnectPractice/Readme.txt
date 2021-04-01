After reading the article of Dapper, it mention that before using dapper usually people
use "Entity Framework to SQL or ADO.NET to access to the database"

so this project is to see how to use ADO.NET to access to the database.


這邊我還用mysql 的stored procedure 搭配 ado.net 去取得資料

這邊讓人困惑的點就是 使用 conn.close(), 跟 conn.dispose() 到底哪裡不一樣 如果用using的話又是怎麼一回是呢 ??
ANS: https://dotblogs.com.tw/jeff-yeh/2009/06/10/8775

然後我也測試使用dapper 的話會dispose 跟 close 會怎樣 發現Dapper 可能是在使用query的時候才會建立通道 因為除了跑到query<> 為止
前面的 connection state 都是 close(), 這樣讓我不經懷疑 dapper 是不是不需要用using 也可以呢??
是不是dapper 在呼叫完之後就自動幫你close了 ?

裡面的ReadFileClass 是 Ddispose pattern .