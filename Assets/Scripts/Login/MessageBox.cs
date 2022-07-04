using UnityEngine;
using TMPro;

public class MessageBox : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private TextMeshProUGUI _messageText;

    public void ShowMessage(object message)
    {
        _messageText.text = message.ToString();
    }
}
