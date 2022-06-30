using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginPanel : MonoBehaviour
{
    [Header("Debug settings")]
    [SerializeField] private bool _isDebug;

    [Header("Settings")]
    [SerializeField] private GameObject _registryMenu;
    [SerializeField] private GameObject _loginMenu;
    [SerializeField] private Login _login;

    [Space(5)]
    [SerializeField] private AvailableAvatars _avatars;

    private void OnEnable()
    {
        if (_isDebug) Debug.Log("PUK");
        if (_login.IsEmpty)
        {
            _registryMenu.SetActive(true);
            _loginMenu.SetActive(false);
        }
    }

    private void OnDisable()
    {
        _registryMenu.SetActive(false);
        _loginMenu.SetActive(false);
    }

    public void AddPlayer(string name, Sprite avatar)
    {
        _login.AddPlayer(new Player(name, avatar));
    }
}
