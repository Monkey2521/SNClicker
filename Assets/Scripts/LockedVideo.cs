using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class LockedVideo : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Image _source;
    [SerializeField] private GameObject _lockIcon;
    [SerializeField] private Button _button;

    private VideoPlayer _videoPlayer;
    private VideoClip _unlockedClip;
    private Sprite _onUnlockSprite;
    private int _unlockCost;

    public void Init(VideoPlayer videoPlayer, VideoClip clip, Sprite onUnlockSprite, int unlockCost)
    {
        _videoPlayer = videoPlayer;
        _unlockedClip = clip;
        _onUnlockSprite = onUnlockSprite;
        _unlockCost = unlockCost;

        _button.onClick.AddListener(Unlock);
    }

    public void Unlock()
    {
        if (GameHandler.instance.CanBuy(_unlockCost))
        {
            GameHandler.instance.AddToBalance(-_unlockCost);

            _source.sprite = _onUnlockSprite;
            _lockIcon.SetActive(false);

            _button.onClick.RemoveListener(Unlock);
            _button.onClick.AddListener(PlayVideo);
        }
    }

    public void PlayVideo()
    {
        _videoPlayer.clip = _unlockedClip;
        _videoPlayer.transform.parent.parent.gameObject.SetActive(true);
    }
}
