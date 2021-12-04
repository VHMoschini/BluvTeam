using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTools : MonoBehaviour
{
    public AnimatorOverrideController ArmsAnimationOne;
    public AnimatorOverrideController ArmsAnimationTwo;


    private Player player;
    private void Awake() => player = FindObjectOfType<Player>();

    public void LockPlayer()
    {
        if (player != null)
            player.LockPlayer();
    }
    public void UnlockPlayer()
    {
        if (player != null)
            player.UnlockPlayer();
    }
    public void PlaySnapShot() => player.playSnapShot(ArmsAnimationOne);
    //public void PlaySnapShotTwo() => player.playSnapShot(ArmsAnimationTwo);

}
