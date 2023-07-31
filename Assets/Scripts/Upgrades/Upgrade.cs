using TMPro;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{
    [SerializeField]  string _title;
    [SerializeField] private Sprite _icon;
    public abstract void Apply(PlayerController player);

    public TMP_Text Title { get; set; }
    public Sprite Icon { get; set; }

    private void Awake()
    {
        Title = GetComponent<TMP_Text>(); 
        if (Title != null) 
        {
            Title.text = _title;
        }

        Icon = _icon;
    }
}
