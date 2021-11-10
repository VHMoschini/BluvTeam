using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTools : MonoBehaviour
{

    private Player player; 
    private void Awake() => player = FindObjectOfType<Player>();

    public void LockPlayer() => player.LockPlayer();
    public void UnlockPlayer() => player.UnlockPlayer();

}
