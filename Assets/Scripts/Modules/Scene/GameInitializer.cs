using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameInitializer : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer introPlayer;


    public string nextScene;

    private void Start()
    {
        introPlayer.loopPointReached += EndReached;

    }

    private void EndReached(VideoPlayer vp)
    {
        SceneLoader.Instance.SwitchScene(nextScene);
    }

}
