using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class LockedVideo : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Image _source;
    [SerializeField] private Sprite _unlockedSprite;
    [SerializeField] private VideoClip _unlockedClip;
    [SerializeField] private VideoPlayer _videoPlayer;

    private bool _isUnlocked;

    public void Unlock()
    {
        // TODO

        _source.sprite = _unlockedSprite;
        _isUnlocked = true;
    }
}
