using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AvailableAvatars
{
    [SerializeField] private List<Sprite> _avatars;

    public List<Sprite> GetAvatars(int count = 3)
    {
        List<Sprite> avatars = new List<Sprite>();
        List<int> indexes = new List<int>();
        int i = 0;
        while (i < count)
        {
            int index;
            do
            {
                index = Random.Range(0, _avatars.Count);
            } while (indexes.Contains(index));

            avatars.Add(_avatars[index]);
            indexes.Add(index);

            i++;
        }

        return avatars;
    }
}
