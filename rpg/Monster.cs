using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
    internal class Monster
    {
        public string Name { get; set; }
        public int Hp {  get; set; }
        public int Damage {  get; set; }
        public Monster()
        {
            Name = "монстер";
            Hp = 100;
            Damage = 10;
        }
        public Monster(string name, int hp, int damage)
        {
            Name = name;
            Hp = hp;
            Damage = damage;
        }
        public virtual string GetInfo()
        {
            return $"Name:{Name},Hp:{Hp},Damage{Damage}";
        }
        public virtual int Attack()
        {
            return Damage;
        }
        public virtual void protect(int damage)
        {
            Hp -= damage;
        }
        
    }
}
