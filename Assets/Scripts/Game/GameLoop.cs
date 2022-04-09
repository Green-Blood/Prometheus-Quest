using Player;
using Sirenix.OdinInspector;
using UI;
using UnityEngine;

namespace Game
{
    public sealed class GameLoop : MonoBehaviour
    {
        [BoxGroup("Timer Parameters ")] [GUIColor(0f, 0.3f, 1f)]
        [SerializeField] private int time = 15;

        [BoxGroup("Player Parameters ")] [GUIColor(1f, 0f, 0f)]
        [SerializeField] private float defaultFlySpeed = 5f;
        [BoxGroup("Player Parameters ")] [GUIColor(1f, 0f, 0f)]
        [SerializeField] private float flySpeedModifier = 2f;
        [BoxGroup("Player Parameters ")] [GUIColor(1f, 0f, 0f)]
        [SerializeField] private float flySpeedModifierTime = 1f;
        [BoxGroup("Player Parameters ")] [GUIColor(1f, 0f, 0f)]
        [SerializeField] private int playerHealth = 3;
        [BoxGroup("Player Parameters ")] [GUIColor(1f, 0f, 0f)]
        [SerializeField] private int lightningStrikeLimit = 5;

        [Title("References")]
        [SerializeField] private Timer timer;
        [SerializeField] private LivesUI livesUI;
        [SerializeField] private Character character;
        [SerializeField] private WinLose winLose;
        [SerializeField] private ClickArea clickArea;
        [SerializeField] private ObjectsUI objectsUI;

        private Events _events;
        private PlayerMove _playerMove;
        private PlayerHealth _playerHealth;
        private LightningStrike _lightningStrike;
        private PlayerDeath _playerDeath;
        private PickedUpObjects _pickedUpObjects;



        private void Awake()
        {
            _events = Events.Instance;
            _playerMove = new PlayerMove(defaultFlySpeed, flySpeedModifierTime, flySpeedModifier);
            winLose.Init(_playerMove);
            objectsUI.Init();

            _playerDeath = new PlayerDeath(winLose);
            _playerHealth = new PlayerHealth(playerHealth, _playerDeath);
            _lightningStrike = new LightningStrike(lightningStrikeLimit, _playerHealth);
            _pickedUpObjects = new PickedUpObjects(objectsUI);

            character.Init(_playerMove, _playerHealth, _lightningStrike);
            livesUI.Init(_playerHealth, playerHealth);
            clickArea.Init(character, _pickedUpObjects);
        }

        private void Start()
        {
            _events.OnCharacterEnter += OnCharacterEnter;
            StartCoroutine(timer.TimerCoroutine(time, OnTimerFinished));
        }

        private void OnCharacterEnter() => winLose.WinGame();
        private void OnTimerFinished() => winLose.LoseGame();
    }
}