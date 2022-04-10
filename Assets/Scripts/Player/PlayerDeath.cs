using UI;

namespace Player
{
    public sealed class PlayerDeath
    {
        private readonly WinLose _winLose;

        public PlayerDeath(WinLose winLose)
        {
            _winLose = winLose;
        }
        public void Die()
        {
           // TODO Add animation
           _winLose.LoseGame();
        }
    }
}