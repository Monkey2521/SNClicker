using UnityEngine;

public class Player
{
    private string _name;
    private Sprite _avatar;

    public string Name => _name;
    public Sprite Avatar => _avatar;

    public Player(string name, Sprite avatar)
    {
        _name = name;
        _avatar = avatar;
    }
}
