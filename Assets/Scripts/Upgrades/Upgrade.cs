using TMPro;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;
    [SerializeField] private Sprite _icon;
    public abstract void Apply();

    public TMP_Text Title { get; set; }
    public Sprite Icon { get; set; }

    private void Awake()
    {
        Title = _title;
        Icon = _icon;
    }
}
