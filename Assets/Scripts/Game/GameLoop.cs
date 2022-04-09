using UnityEngine;

public sealed class GameLoop : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private int time = 15;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject winPanel;
    private bool _isWin;
    private Events _events;

    private void Awake()
    {
        _events = Events.Instance;
    }

    private void Start()
    {
        _events.OnCharacterEnter += OnCharacterEnter;
        StartCoroutine(timer.TimerCoroutine(time, OnTimerFinished));
    }

    private void OnCharacterEnter()
    {
        winPanel.SetActive(true);
        _isWin = true;
    }

    private void OnTimerFinished()
    {
        if (!_isWin) losePanel.SetActive(true);
    }
}