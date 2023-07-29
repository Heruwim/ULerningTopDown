using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private Image _icon;

    private Action _applyAction;

    public void Setup(TMP_Text title, Sprite icon, Action onApply)
    {
        _title = title;
        _icon.sprite = icon;
        _applyAction = onApply;
    }

    public void Apply()
    {
        _applyAction?.Invoke();
    }
}
