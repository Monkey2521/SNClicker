using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginPanel : MonoBehaviour
{
    [Header("Debug settings")]
    [SerializeField] private bool _isDebug;

    [Header("Settings")]
    [SerializeField] private GameObject _registryMenu;
    [SerializeField] private Transform _regAvatarsParent;
    [SerializeField] private AvailableAvatars _avatars;
    [SerializeField] private AvatarPreview _avatarPrefab;
    [SerializeField] private TextMeshProUGUI _name;
    private List<AvatarPreview> _currentAvatars = new List<AvatarPreview>();

    public Sprite ChoosenAvatar;
    public string Name;

    private void OnEnable()
    {
        NewGame();
    }

    private void OnDisable()
    {
        _registryMenu.SetActive(false);
    }

    void NewGame()
    {
        _registryMenu.SetActive(true);

        SetNewAvatars();
    }

    public void SetNewAvatars(int count = 3)
    {
        while (_currentAvatars.Count > 0)
        {
            Destroy(_currentAvatars[0].gameObject);
            _currentAvatars.Remove(_currentAvatars[0]);
        }

        ChoosenAvatar = null;

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
        ChoosenAvatar = sprite;
    }

    public void Play()
    {
        Name = _name.text.ToUpper();

        if (ChoosenAvatar != null && Name.Length > 0)
        {
            
        }
        else
        {
            Debug.Log("Somthing not ready");
        }
    }
}
