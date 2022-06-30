using System.Collections.Generic;
using UnityEngine;

public class Login : ScriptableObject
{
    public List<Player> Usernames;

    public bool IsEmpty => Usernames.Count == 0;

    public void AddPlayer(Player player)
    {
        Usernames.Add(player);
    }
}
