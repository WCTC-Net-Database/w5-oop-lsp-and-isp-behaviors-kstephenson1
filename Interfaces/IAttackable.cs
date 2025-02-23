using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w5_assignment_ksteph.Interfaces
{
    public interface IAttackable
    {
        public int HitPoints { get; set; }
        public int MaxHitPoints { get; set; }
        public void TakeDamage(int damage);
        void OnDamageTaken();
        void OnDeath();
        bool IsDead();
        
    }
}
