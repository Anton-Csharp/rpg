using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    internal class MagicMonster:Monster
    {
        public int Mana {  get; set; }
        public MagicMonster()
        {
            Name = "магический монстр";
            Damage = 20;
            Hp = 85;
            Mana = 10;
        }
        public MagicMonster(int mana,string name,int hp,int damage) : base(name, hp, damage)
        {
            Mana = mana;
        }
        public override string GetInfo()
        {
            return base.GetInfo() +$",Mana:{Mana}";
        }
        public override int Attack()
        {
            return base.Attack() +Mana;
        }
        public override void protect(int damage)
        {
            base.protect(damage);
        }
    }
}
