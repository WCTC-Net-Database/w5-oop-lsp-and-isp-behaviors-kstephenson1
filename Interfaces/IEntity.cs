namespace w5_assignment_ksteph.Interfaces;

public interface IEntity
{
    int Id { get; set; }
    string Name { get; set; }
    void Move();
    void Attack(IEntity target);
}
