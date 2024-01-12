using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace TestWork.Gameplay
{
    // Archer rotating
    public sealed class Aim : IAim
    {
        private readonly float _shootForce;
        private readonly float _rotationSpeed;
        private readonly Transform _transform;
        private Vector3 _currentTarget;

        public Aim(float shootForce, float rotationSpeed, Transform transform)
        {
            _shootForce = shootForce;
            _rotationSpeed = rotationSpeed;
            _transform = transform;
        }

        public bool Observing { get; private set; }

        public void Observe(Transform target) =>
            Rotate(target.position).Forget();

        private async UniTaskVoid Rotate(Vector3 target)
        {
            if (_currentTarget == target)
                return;

            _currentTarget = target;
            Observing = false;

            // Algorithm for calculating the angle of throwing an arrow along the trajectory between the enemy and the archer
            Vector3 offset = target - _transform.position;
            float horizontalDistance = Mathf.Abs(offset.x);
            bool leftSide = offset.x < 0;

            if (leftSide)
                horizontalDistance = -offset.x;

            float velocitySquared = _shootForce * _shootForce;
            float gravityMagnitude = Mathf.Abs(Physics.gravity.y);

            float discriminant = velocitySquared * velocitySquared - gravityMagnitude *
                (gravityMagnitude * horizontalDistance * horizontalDistance + 2 * offset.y * velocitySquared);
            float squareRootTerm = Mathf.Sqrt(discriminant);

            float atanValue =
                Mathf.Atan((velocitySquared - squareRootTerm) / (gravityMagnitude * horizontalDistance)) *
                Mathf.Rad2Deg;

            float angle = leftSide ? 180f - atanValue : atanValue;
            float rotateDuration = Vector2.Distance(_transform.position, target) / _rotationSpeed;

            await _transform.DORotate(new Vector3(0, 0, angle), rotateDuration);

            Observing = true;
        }
    }
}