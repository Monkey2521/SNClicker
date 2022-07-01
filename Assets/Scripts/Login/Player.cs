using UnityEngine;

[CreateAssetMenu(menuName = "Player", fileName = "New player")]
public class Player : ScriptableObject
{
    public string Name;
    public Sprite Avatar;

    public bool Initialized => Name.Length > 0 && Avatar != null;
}
