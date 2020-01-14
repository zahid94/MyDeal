using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDeal.Service.RandomNumer
{
    public class RandomNumberCreate
    {
        Random Random = new Random();
        int charecter, num, sym;
        string[] cities = { "a", "B", "c", "d","e", "f", "g", "h",
                    "i", "j", "k","l", "m", "n", "o",
                    "p", "q", "r", "s" ,"t","u","v","w","x","y","z" };
        int[] number = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        string[] symble = { "@", "#", "$", "&" };

        public string randMethod()
        {
            charecter = Random.Next(cities.Length);
            num = Random.Next(number.Length);
            sym = Random.Next(symble.Length);
            return number[num] + cities[charecter] + symble[sym];
        }
    }
}
