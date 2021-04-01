using System;

namespace GenericPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] intArray = CreateArray(3, 5);
            Console.WriteLine($"{intArray[0]}, {intArray[1]}");

            CreateArray<string>("sjo", "fjeoiw");
            Console.WriteLine($"{intArray[0]}, {intArray[1]}");

            CreateArray3<int, string>(3, "fjosj");

            //MyClass<int> myclass = new MyClass<int>(); // 這邊出現錯誤是因為 int 這個type doesn't inplement the IEnemy interface. 所以我們要使用有 implement IEnemy 的type 看下面
            //myclass.value = 3;

            MyClass<EnemyMinion> myclass = new MyClass<EnemyMinion>(new EnemyMinion());
        }




        private static int[] CreateArray(int firstElement, int secondElement)
        {
            return new int[] { firstElement, secondElement };
        }

        // T 可以替換成任何你想要的name, 但方便讓其他人看動 會在前面加上大寫T ex. TcustomeName
        private static T[] CreateArray<T>(T firstElement, T secondElement)
        {
            return new T[] { firstElement, secondElement };
        }

        private static void CreateArray3<T1, T2>(T1 firstElement, T2 secondElement)
        {
            Console.WriteLine(firstElement.GetType());
            Console.WriteLine(secondElement.GetType());
        }

        private Action<int, string> action;
        private Func<int, bool> func;

        // make your own delegate
        private delegate void MyActionDelegate<T1, T2>(T1 t1, T2 t2); //Action

        private delegate TResult MyFuncDelegate<T1, TResult>(T1 t1); //Func
    }

    // what this saying is that type T must be a class, it must implement IEnemy and it must have a parameter unless constructor.
    public class MyClass<T> where T : class, IEnemy, new()
    {
        public T value;

        public MyClass(T value)
        {
            value.Damage();
        }


        private static T[] CreateArray(T firstElement, T secondElement)
        {
            return new T[] { firstElement, secondElement };
        }
    }

    public interface IEnemy
    {
        void Damage();
    }


    public class EnemyMinion : IEnemy
    {
        public void Damage()
        {
            Console.WriteLine("Damage method with implement IEnemy");
        }
    }

    public interface GenericInterface<T>
    {
        void Damage(T t);
    }

    public class EnemyArcher : GenericInterface<int>
    {
        public void Damage(int i)
        {
            Console.WriteLine("Damage method with implement IEnemy");
        }
    }
}
