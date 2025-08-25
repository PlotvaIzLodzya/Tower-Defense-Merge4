using System.Collections;

namespace _Source.Scripts.AttackBehaviours
{
    public interface IAttack : ITagUser
    {
        public IEnumerator Perform();
    }
}