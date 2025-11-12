using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    internal class Program
    {
       

        static void Main(string[] args)
        {
            List<Monster> list = new List<Monster>();
             Monster monster = new Monster();
            int hp = 100;
            int damage = 20;


            MagicMonster MagicMonster = new MagicMonster();
             ArmorMonster ArmorMonster = new ArmorMonster();

            Console.WriteLine("выбери сложность:");
            Console.WriteLine("1 легкая");
            Console.WriteLine("2 средняя"); 
            Console.WriteLine("3 профи эксперт ультра хард и тд");
            int selectedNum = int.Parse(Console.ReadLine());
            if (selectedNum == 1)
            {
                Console.WriteLine("сложность:легкая");
                list.Add(monster);

            }
            if (selectedNum == 2)
            {
                Console.WriteLine("сложность:средняя");
                list.Add(MagicMonster);

            }
            if (selectedNum == 3)
            {
                Console.WriteLine("сложность:профи эксперт ультра хард и тд");
                list.Add(ArmorMonster);
            }
        }
    }
}
