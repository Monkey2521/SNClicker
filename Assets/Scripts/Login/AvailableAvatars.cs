using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableAvatars : ScriptableObject
{
    [SerializeField] private List<Sprite> _allAvatars;
    [HideInInspector] List<Sprite> Avatars;
    List<Sprite> _usedAvatars;

    public void Init()
    {
        if (Avatars.Count == 0 && _usedAvatars.Count == 0)
            foreach (Sprite sprite in _allAvatars)
                Avatars.Add(sprite);
    }

    public List<Sprite> GetAvatars(int count = 3)
    {
        List<Sprite> avatars = new List<Sprite>();

        int i = 0;
        while (i < count)
        {
            int index = Random.Range(0, Avatars.Count);
            avatars.Add(Avatars[index]);
            _usedAvatars.Add(Avatars[index]);

            Avatars.Remove(Avatars[index]);

            i++;
        }

        return avatars;
    }
}
