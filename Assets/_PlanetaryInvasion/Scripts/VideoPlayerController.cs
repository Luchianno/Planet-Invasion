using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer player;
    public RawImage image;

    void Start()
    {
        image.texture = player.targetTexture;
    }

    // Update is called once per frame
    void Play()
    {
        // player.Prepare();
    }
}
