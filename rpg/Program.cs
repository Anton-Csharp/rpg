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
            int critChance = 0;
            int slillPoints = 0;
            int coins = 0;
            int damage = 18;
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
                int num = rnd.Next(2, 3);
                critChance = rnd.Next(1,4);
                Console.Clear();
                Console.WriteLine("Монстры готовы к бою!");
                Console.WriteLine("выберите монстра для атаки:");
                foreach (var item in list)
                {
                   Count++;
                   Console.WriteLine(Count + "  " + item.GetInfo());
                }
                selectedNum = int.Parse(Console.ReadLine());
                if (critChance == 2)
                {
                    damage *= 2;
                    list[selectedNum - 1].protect(damage);
                    Console.WriteLine("вы нанесли крит урон");
                    damage /= 2;
                }
                else
                {
                    list[selectedNum - 1].protect(damage);
                }

                if (list[selectedNum - 1].Hp <= 0)
                {
                    Console.WriteLine("Вы убили монстра");
                    coins += 5;
                    slillPoints += num;
                }
                else
                {
                    Console.WriteLine("Вы атаковали: " + list[selectedNum - 1].Hp + " осталось хп у монстра");
                }
                Console.WriteLine("нажмите пробел для продолжения");
                Console.ReadKey(true);
                Console.WriteLine("ваши монеты:" + coins);
                Console.WriteLine("хотети купить что нибудь?");
                Console.WriteLine("1 хилка на 20 хп: 15 монет");
                Console.WriteLine("2 бафф урона на +10: 20 монет");
                Console.WriteLine("3 ничего");
                selectedNum = int.Parse(Console.ReadLine());
                if (selectedNum == 1)
                {
                    if (coins >= 15)
                    {
                        hp += 20;
                        coins -= 15;
                        Console.WriteLine($"ваше хп:{hp},ваши монеты:{coins}");
                    }
                    else
                    {
                        Console.WriteLine("у вас недостаточно монет");
                    }

                }
                if (selectedNum == 2)
                {
                    if (coins >= 20)
                    {
                        damage += 10;
                        coins -= 20;
                        Console.WriteLine($"ваше дамаг:{damage},ваши монеты:{coins}");
                    }
                    else
                    {
                        Console.WriteLine("у вас недостаточно монет");
                    }
                }
                Console.WriteLine("нажмите пробел для продолжения");
                Console.ReadKey(true);
                Console.WriteLine("ваши поинты:" + slillPoints);
                Console.WriteLine("хотети прокачать что нибудь?");
                Console.WriteLine("1 +5хп: 2 поинта");
                Console.WriteLine("2 бафф урона на +3: 3 поинта ");
                Console.WriteLine("3 ничего");
                selectedNum = int.Parse(Console.ReadLine());
                if (selectedNum == 1)
                {
                    if (slillPoints >= 2)
                    {
                        hp += 5;
                        slillPoints -= 2;
                        Console.WriteLine($"ваше хп:{hp},ваши поинты:{slillPoints}");
                    }
                    else
                    {
                        Console.WriteLine("у вас недостаточно поинтов");
                    }

                }
                if (selectedNum == 2)
                {
                    if (slillPoints >= 3)
                    {
                        damage += 3;
                        slillPoints -= 3;
                        Console.WriteLine($"ваше дамаг:{damage},ваши поинты:{slillPoints}");
                    }
                    else
                    {
                        Console.WriteLine("у вас недостаточно поинтов");
                    }
                }


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
