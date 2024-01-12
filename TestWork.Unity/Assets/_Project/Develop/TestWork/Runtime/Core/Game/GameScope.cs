using TestWork.Engine.Factory;
using TestWork.Engine.Time;
using TestWork.Engine.UI;
using TestWork.Gameplay;
using TMPro;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace TestWork.Runtime.Core
{
    public sealed class GameScope : LifetimeScope
    {
        [SerializeField] private float _bowForce;
        [SerializeField] private float _bowReload;
        [SerializeField] private Enemy _enemy;
        [SerializeField] private ArcherView _archer;
        [SerializeField] private float _archerShootDistance;
        [SerializeField] private PhysicArrow _arrow;
        [SerializeField] private Transform _arrowSpawnPoint;
        [SerializeField] private Sprite _arrowSprite;
        [SerializeField] private Sprite _boltSprite;
        [SerializeField] private float _arrowDamage;
        [SerializeField] private float _burnedArrowDamageAffect;
        [SerializeField] private UnityButton _createEnemyButton;
        [SerializeField] private TMP_Dropdown _arrowSpriteDropdown;
        [SerializeField] private UnityButton _burnedArrowButton;

        protected override void Configure(IContainerBuilder scope)
        {
            var arrowConfig = new ArrowConfig()
            {
                Damage = _arrowDamage,
                Sprite = _arrowSprite
            };

            var switchArrowSprite = new ArrowSpriteButton(_arrowSprite, arrowConfig);
            var switchBoltSprite = new ArrowSpriteButton(_boltSprite, arrowConfig);

            _arrowSpriteDropdown.onValueChanged.AddListener(i =>
            {
                switch (i)
                {
                    case 0:
                        switchArrowSprite.Press();
                        break;
                    case 1:
                        switchBoltSprite.Press();
                        break;
                }
            });

            _burnedArrowButton.Subscribe(new BurningButton(arrowConfig, _burnedArrowDamageAffect));

            var archerView = Instantiate(_archer, _arrowSpawnPoint.position, Quaternion.identity);

            var arrowFactory = new MonoBehaviourFactory<PhysicArrow>(_arrow, _arrowSpawnPoint);
            var arrowPool = new Pool<PhysicArrow>(arrowFactory);
            var quiver = new ArrowFactory(arrowConfig, arrowPool, archerView.transform, maxActiveArrows: 10);

            var enemyMap = new Map<Enemy>();
            var enemy = new MonoBehaviourFactory<Enemy>(_enemy, default).Create();
            var enemyFactory = new EnemyFactory(enemyMap, enemy, archerView.transform, _archerShootDistance);

            _createEnemyButton.Subscribe(new FactoryButton<Enemy>(enemyFactory));

            var archerAim = new Aim(_bowForce, rotationSpeed: 3, archerView.transform);

            var bow = new Bow(quiver, _bowForce, _bowReload);

            var archer = new Archer(archerView.transform, enemyMap, bow, archerAim);
            var archerWithView = new ArcherWithView(archer, archerView);

            var gameLoop = new GameLoop();

            scope.RegisterInstance(archerWithView).AsImplementedInterfaces();
            scope.RegisterInstance(gameLoop).AsImplementedInterfaces();
            scope.RegisterEntryPoint<Game>();
        }
    }
}