using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarPreview : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Image _image;
    private LoginPanel _loginPanel;

    public void Init(LoginPanel loginPanel, Sprite avatar)
    {
        _loginPanel = loginPanel;

        _image.sprite = avatar;
    }

    public void ChooseAvatar()
    {
        _loginPanel.ChooseAvatar(_image.sprite);
    }
}
