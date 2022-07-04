using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Gallery : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] LockedVideo _videoPrefab;
    [SerializeField] Transform _lockedVideosParent;
    [SerializeField] VideoPlayer _videoPlayer;

    [Space(5)]
    [SerializeField] private string _videosPath;
    [SerializeField] private string _spritePath;

    private List<LockedVideo> _lockedVideos = new();

    private void Start()
    {
        List<VideoClip> clips = new List<VideoClip>(Resources.LoadAll<VideoClip>(_videosPath));
        List<Sprite> sprites = new List<Sprite>(Resources.LoadAll<Sprite>(_spritePath));

        Debug.Log(clips.Count + " " + sprites.Count);

        for (int i = 0; i < clips.Count; i++)
        {
            LockedVideo video = Instantiate(_videoPrefab, _lockedVideosParent);

            video.Init(_videoPlayer, clips[i], sprites[i], 0); // cost

            _lockedVideos.Add(video);
        }
        
    }
}
