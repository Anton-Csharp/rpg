using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace rpg
{
    internal class Program
    {

        static List<Monster> list = new List<Monster>();
        static Random rnd = new Random();
       
        static void Main(string[] args)
        {
            int hp = 100;
            int damage = 20;
            int Count = 0;
            Console.WriteLine("выбери сложность:");
            Console.WriteLine("1 легкая");
            Console.WriteLine("2 средняя");
            Console.WriteLine("3 профи эксперт ультра хард и тд");
            int selectedNum = int.Parse(Console.ReadLine());

            switch (selectedNum)
            {
                case 1:
                    AddMonster(4);
                  
                    break;
                case 2:
                    AddMonster(6);
                    break;
                case 3:
                    AddMonster(8);
                    break;
                default:
                    break;
            }

            while(true)
            {
                Count = 0;
                Console.Clear();
                Console.WriteLine("Монстры готовы к бою!");
                Console.WriteLine("выберите монстра для атаки:");
                foreach (var item in list)
                {
                   Count++;
                   Console.WriteLine(Count + "  " + item.GetInfo());
                }
                selectedNum = int.Parse(Console.ReadLine());

                list[selectedNum - 1].protect(damage);
                Console.WriteLine("Вы атаковали: " + list[selectedNum - 1].Hp+" осталось хп у монстра");

                //Проверка что монстр не здох.
                Console.WriteLine("Теперь вас атакуют монстры!");
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Hp>0)
                    {
                        hp -= list[i].Attack();
                        if (hp<=0)
                        {
                            Console.WriteLine("вы убиты");
                            break;
                        }
                    }
                    else
                    {
                        list.Remove(list[i]);
                    }
                    
                }
                Console.WriteLine("ваше хп:" + hp);
                if (list.Count <=0)
                {
                    break;
                }
                Console.WriteLine("нажмите пробел для продолжения");
                Console.ReadKey(true);
            }
            

        }

        private static void AddMonster(int v)
        {
            for (int i = 0; i < v; i++)
            {
                int rand = rnd.Next(100);
                if (rand >20)
                {
                    list.Add(new Monster("Бродяга", rnd.Next(10, 35), rnd.Next(4, 15)));
                }
                if (rand<15)
                {
                    list.Add(new MagicMonster(rnd.Next(5,14)," магический Гоблин", rnd.Next(15,45),rnd.Next(6,15)));
                }
                if (rand<5)
                {
                    list.Add(new ArmorMonster(rnd.Next(5,9), " бронированный монстер", rnd.Next(30,60), rnd.Next(4, 15)));
                }
            }
        }
    }
}
