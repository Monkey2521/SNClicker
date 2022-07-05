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
    [SerializeField] private List<VideoInfo> _videos;

    private List<LockedVideo> _lockedVideos = new();

    private void Start()
    {
        foreach (VideoInfo info in _videos)
        {
            LockedVideo video = Instantiate(_videoPrefab, _lockedVideosParent);

            video.Init(_videoPlayer, info.Clip, info.Icon, info.UnlockCost);

            _lockedVideos.Add(video);
        }
    }
}
