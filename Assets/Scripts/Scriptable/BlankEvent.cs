using UnityEngine;

[CreateAssetMenu(fileName = "BlankEvent", menuName = "Events/BlankEvent", order = 50)]
public class BlankEvent : ScriptableObject
{
    public delegate void OnBlankEvent();

    private event OnBlankEvent listeners;

    public event OnBlankEvent Listeners
    {
        add
        {
            listeners -= value;
            listeners += value;
        }
        remove
        {
            listeners -= value;
        }
    }

    public void Raise()
    {
        listeners?.Invoke();
    }
}
