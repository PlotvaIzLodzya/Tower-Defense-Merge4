using UnityEngine;

namespace _Source.Scripts.Buildings
{
    public class AttackTower : Tower
    {
        [SerializeField] private AttackBehaviour _defaultAttack;

        private IAttack _attackBehaviour;

        private void Awake()
        {
            var defaultAttack = _defaultAttack.GetAttackBehaviour(this);
            SetAttackBehaviour(defaultAttack);
        }

        private void Start()
        {
            StartCoroutine(_attackBehaviour.Attack());
        }

        public void SetAttackBehaviour(IAttack attackBehaviour)
        {
            _attackBehaviour = attackBehaviour;
        }
    }
}