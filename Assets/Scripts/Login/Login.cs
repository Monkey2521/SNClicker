using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Login/LoginData", fileName = "New login data")]
public class Login : ScriptableObject
{
    public List<Player> Usernames = new List<Player>();

    public bool IsEmpty => Usernames.Count == 0;

    public void AddPlayer(Player player)
    {
        Usernames.Add(player);
    }
}
