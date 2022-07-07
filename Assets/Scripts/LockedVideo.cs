using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class LockedVideo : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Image _source;
    [SerializeField] private GameObject _lockIcon;
    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _costText;
    [SerializeField] private GameObject _unlockGO;

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

        var m = MoneyFormat.GetNumberDetails(_unlockCost);

        _costText.text = m.FormattedNumber + " " + m.Scale;

        _button.onClick.AddListener(Unlock);

        _source.sprite = _onUnlockSprite;
        _source.gameObject.SetActive(false);
    }

    public void Unlock()
    {
        if (GameHandler.instance.CanBuy(_unlockCost))
        {
            GameHandler.instance.AddToBalance(-_unlockCost);

            _source.gameObject.SetActive(true);
            _lockIcon.SetActive(false);
            _unlockGO.SetActive(false);
            _costText.gameObject.SetActive(false);

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
