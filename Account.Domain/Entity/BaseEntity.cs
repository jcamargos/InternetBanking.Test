
namespace Account.Domain.Entity
{
    public class BaseEntity
    {
        public object Clone() => MemberwiseClone();
    }
}