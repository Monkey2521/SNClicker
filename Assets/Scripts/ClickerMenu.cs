using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickerMenu : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform _businessUIParent;

    public void OnEnable()
    {
        HideGame();
    }

    public void ShowGame()
    {
        foreach (CanvasGroup canvas in _businessUIParent.GetComponentsInChildren<CanvasGroup>(true))
        {
            canvas.alpha = 1f;
        }
    }

    public void HideGame()
    {
        foreach (CanvasGroup canvas in _businessUIParent.GetComponentsInChildren<CanvasGroup>())
        {
            canvas.alpha = 0f;
        }
    }
}
