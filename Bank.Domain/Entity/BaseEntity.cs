namespace Bank.Domain.Entity
{
    public class BaseEntity
    {
        public object Clone() => MemberwiseClone();
    }
}
