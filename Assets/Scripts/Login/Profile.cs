using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Profile : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TextMeshProUGUI _playerName;
    [SerializeField] private Image _playerAvatar;

    private void OnEnable()
    {
        _playerName.text = _player.Name;
        _playerAvatar.sprite = _player.Avatar;
    }
}
