using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    internal class ArmorMonster:Monster
    {
        public int Armor {  get; set; }
        public ArmorMonster()
        {
            Name = "бронированный монстр";
            Hp = 120;
            Damage = 15;
            Armor = 10;
        }
        public ArmorMonster(int armor,string name,int hp,int damage):base(name,hp,damage) 
        {
            Armor = armor;
        }
        public override string GetInfo()
        {
            return base.GetInfo()+$",armor:{Armor}";
        }
        public override int Attack()
        {
            return base.Attack();
        }
        public override void protect(int damage)
        {
            if (damage>Armor)
            {
               base.protect(damage - Armor);
            }
            else
            {
                base.protect(0);
            }
            
        }
    }
}
