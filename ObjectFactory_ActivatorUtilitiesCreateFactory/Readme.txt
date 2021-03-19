Reference Article : https://zhuanlan.zhihu.com/p/104755954

小實驗: TypeFilter 是用ObjectFactory来创建实例, ObjectFactory是ActivatorUtilities.CreateFactory创建出来的委托
，对于没有注册的服务想创建实例，.net core提供的ActivatorUtilities就派上用场了

我們創建一個Employee类构造器里有logger也有name，这种情况下，甚至构造器中有更多参数，
我们想创造一个Employee的实例是不太容易的，这个时候就该ActivatorUtilities登场了。

这只是一个简单的例子，帮助您理解ObjectFactory，ActivatorUtilities之间的关系，如果您感兴趣可以自己深入的研究一下。


ServiceFilter vs TypeFilter

文章的最后，我们对他们进行一下总结

    1. ServiceFilter和TypeFilter都实现了IFilterFactory
    2. ServiceFilter需要对自定义的Filter进行注册，TypeFilter不需要
    3. ServiceFilter的Filter生命周期源自于您如何注册，而TypeFilter每次都会创建一个新的实例