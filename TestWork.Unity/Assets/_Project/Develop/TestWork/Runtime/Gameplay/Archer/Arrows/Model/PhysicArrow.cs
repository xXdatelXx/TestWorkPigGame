using System;
using UnityEngine;

namespace TestWork.Gameplay
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class PhysicArrow : MonoBehaviour, IArrow
    {
        [SerializeField] private SpriteRenderer _render;
        private Rigidbody2D _physic;
        private float _damage;

        public void Construct(float damage, Sprite sprite)
        {
            _physic = GetComponent<Rigidbody2D>();
            _damage = damage;
            _render.sprite = sprite;
        }

        public void Throw(float force)
        {
            if (force < 0)
                throw new ArgumentOutOfRangeException("Throw force cant be sub zero");

            _physic.velocity = transform.right * force;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<IHealth>(out var target))
            {
                target.TakeDamage(_damage);
                gameObject.SetActive(false);
            }
        }
    }
}