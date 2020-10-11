using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    public Camera livingRoomCamera, nurseryCamera;
    public AudioSource mainAudioSource;
    public AudioClip winSong;

    private VideoPlayer videoPlayer;

    private void Start()
    {
        videoPlayer = transform.GetComponent<VideoPlayer>();
    }

    public void PlayAnimation()
    {
        if (livingRoomCamera.gameObject.activeInHierarchy)
            videoPlayer.targetCamera = livingRoomCamera;
        else
            videoPlayer.targetCamera = nurseryCamera;

        videoPlayer.Play();
        StartCoroutine(PlayAnimationSounds());
    }

    private IEnumerator PlayAnimationSounds()
    {
        yield return new WaitForSeconds(0.75f);

        SoundManager.instance.PlayDrumroll();

        yield return new WaitForSeconds(4f);

        mainAudioSource.clip = winSong;
        mainAudioSource.Play();
    }

}
