using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;
using System;

public class WorldSpaceVideo : MonoBehaviour
{
    public Material playButtonMaterial;
    public Material pauseButtonMaterial;
    public Renderer playButtonRender;
    public VideoClip[] videoClips;
    public TMP_Text currentMinutes;
    public TMP_Text currentSeconds;
    public TMP_Text totalMinutes;
    public TMP_Text totalSeconds;
    public PlayHeadMove playHeadMove;

    private VideoPlayer videoPlayer;
    private int videoClipIndex;
    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.targetTexture.Release();
        videoPlayer.clip = videoClips[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.isPlaying)
        {
            SetCurrentTimeUI();
            playHeadMove.MovePlayHead(CalculatePlayedFraction());
            SetTotalTimeUI();
        }
    }

    public void SetNextClip()
    {
        videoClipIndex++;
        if (videoClipIndex>=videoClips.Length)
        {
            videoClipIndex = videoClipIndex % videoClips.Length;
        }
        videoPlayer.clip = videoClips[videoClipIndex];
        SetTotalTimeUI();
        videoPlayer.Play();
        playButtonRender.material = pauseButtonMaterial;
    }

    public void PlayPause()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause   ();
            playButtonRender.material = playButtonMaterial;
        }
        else
        {
            videoPlayer.Play ();
            SetTotalTimeUI();
            playButtonRender.material = pauseButtonMaterial;
        }
    }

    void SetCurrentTimeUI()
    {
        string minutes = Mathf.Floor((int)videoPlayer.time / 60).ToString("00");
        string seconds = ((int)videoPlayer.time % 60).ToString("00");

        currentMinutes.text = minutes;
        currentSeconds.text = seconds;
    }

    void SetTotalTimeUI()
    {
        string minutes = Mathf.Floor((int)videoPlayer.clip.length / 60).ToString("00");
        string seconds = ((int)videoPlayer.clip.length % 60).ToString("00");

        totalMinutes.text = minutes;
        totalSeconds.text = seconds;
    }

    double CalculatePlayedFraction()
    {
        double fraction = (double)videoPlayer.frame / (double)videoPlayer.clip.frameCount;
        return fraction;
    }
}
