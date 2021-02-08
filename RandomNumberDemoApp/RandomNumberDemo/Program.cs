using System;
using System.Collections.Generic;
using System.Linq;

// More

namespace RandomNumberDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // if you really need an absolute randomness, you should check on cryptographic library, otherwise Random() will be enough

            // Tip one: only do this once
            Random random = new Random(); //pseudo-random 不是真的random 但幾乎可以應用在你所需要的所有地方了
                                          //don't put any number inside Random(), don't pass a seed value in, 因為那是類似池子的概念,
                                          //你不放東西進去的話 裡面就會產生隨機的數字 而數字一直會改變
                                          //但如果你放數字 例如1 那你在下面用random.Next() 出來的就會都是一樣的

            //for (int i = 0; i < 10; i++)
            //{
            //    // if you want the value from 0 ~ 10 you can put 11, because the max value will not be picked
            //    Console.WriteLine(random.Next());
            //    //SimpleMethod(random);
            //}


            // -----------------------------------------------------------------------------------------------------------

            //Sorting a list
            List<PersonModel> people = new List<PersonModel>
            {
                new PersonModel {FirstName = "Tim"},
                new PersonModel {FirstName = "Sue"},
                new PersonModel {FirstName = "Mary"},
                new PersonModel {FirstName = "George"},
                new PersonModel {FirstName = "Jane"},
                new PersonModel {FirstName = "Nsmcve"},
                new PersonModel {FirstName = "Rabo"}
            };

            //var shufflePeople = people.OrderBy(x => x.FirstName);
            //instead of passing in firstName to be the one compares, we're just comparing out a number a random number
            //and it's always the next random number which means it's not the same value
            var shufflePeople = people.OrderBy(x => random.Next());

            //var shufflePeople2 = people.OrderBy(x => (random.Next(2) % 2 == 0)); // 網路上有這個用法 這個用法應該是 產生0/1 然後如果除以2是0就讓他比較 如果不是就跳下一個來打亂原有的順序 but 我覺得這個不太好

            foreach (var p in shufflePeople)
            {
                Console.WriteLine(p.FirstName);
            }

        }

        private static void SimpleMethod(Random random)
        {
            ////Random random = new Random(); // don't do this, 不要這樣做 這樣你在每次呼叫這個method的時候都會 create a new instance of random, 這樣會讓出來的數字有機會重複
            // 所以要用 input 的方式

            Console.WriteLine(random.Next());
        }
    }

    public class PersonModel
    {
        public string FirstName { get; set; }
    }
}
