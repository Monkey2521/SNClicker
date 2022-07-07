using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoginPanel : MonoBehaviour
{
    [Header("Debug settings")]
    [SerializeField] private bool _isDebug;

    [Header("Settings")]
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _registryMenu;
    [SerializeField] private Transform _regAvatarsParent;
    [SerializeField] private AvailableAvatars _avatars;
    [SerializeField] private AvatarPreview _avatarPrefab;
    [SerializeField] private TextMeshProUGUI _name;
    private List<AvatarPreview> _currentAvatars = new List<AvatarPreview>();

    [Space(5)]
    [SerializeField] private GameObject _game;

    private Sprite _choosenAvatar;
    private string _choosenName;

    private void OnEnable()
    {
        if (_player.Initialized)
        {
            gameObject.SetActive(false);
            _game.SetActive(true);
        }
        else
        {
            NewGame();
        }
    }

    private void OnDisable()
    {
        _registryMenu.SetActive(false);
    }

    void NewGame()
    {
        _registryMenu.SetActive(true);
        _game.SetActive(false);

        SetNewAvatars();
    }

    public void SetNewAvatars(int count = 3)
    {
        while (_currentAvatars.Count > 0)
        {
            Destroy(_currentAvatars[0].gameObject);
            _currentAvatars.Remove(_currentAvatars[0]);
        }

        _choosenAvatar = null;

        List<Sprite> avatars = _avatars.GetAvatars(count);

        foreach (Sprite avatar in avatars)
        {
            AvatarPreview newAvatar = Instantiate(_avatarPrefab, _regAvatarsParent);

            newAvatar.Init(this, avatar);

            _currentAvatars.Add(newAvatar);
        }
    }

    public void ChooseAvatar(Sprite sprite)
    {
        _choosenAvatar = sprite;
    }

    public void Play()
    {
        _choosenName = _name.text.ToUpper();

        if (_choosenAvatar != null && _choosenName.Length > 0)
        {
            _player.Name = _choosenName;
            _player.Avatar = _choosenAvatar;

            gameObject.SetActive(false);
            _game.SetActive(true);
        }
        else
        {
            Debug.Log("Somthing is not ready");
        }
    }
}
