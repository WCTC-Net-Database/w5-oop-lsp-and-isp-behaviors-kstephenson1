namespace w5_assignment_ksteph.Interfaces.CharacterBehaviors
{
    public interface IAttackable
    {
        // Interface tha allows units to be attacked.
        public int HitPoints { get; set; }
        public int MaxHitPoints { get; set; }
        public void TakeDamage(int damage);
        void OnDamageTaken();
        void OnDeath();
        bool IsDead();

    }
}
