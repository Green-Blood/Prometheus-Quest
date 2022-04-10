using UnityEngine;

public sealed class GameAudio : MonoBehaviour
{
    [SerializeField] private AudioSource[] audioSource;
    [SerializeField] private AudioSource[] musicSource;

    // TODO Make it normal
    public void PlaySound(SoundsEnum soundsEnum)
    {
        for (var index = 0; index < audioSource.Length; index++)
        {
            if ((int)soundsEnum == index)
            {
                audioSource[index].Play();
            }
        }
    }

    public void PlayMusic(bool isUp)
    {
        if (isUp)
        {
            musicSource[0].Play();
        }
        else
        {
            musicSource[1].Play();
        }
    }
}

public enum SoundsEnum
{
    GoUp,
    GoDown,
    Lightning,
    PickUp,
    YouWin,
    ZeusSCream
}
