using System.Collections;

namespace _Source.Scripts.AttackBehaviours
{
    public interface IShotgunAttack
    {
        
    }
    
    public interface IAttack
    {
        public IEnumerator Perform();
    }
}