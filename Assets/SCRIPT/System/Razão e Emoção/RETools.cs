using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RETools : MonoBehaviour
{
    private RazaoEEmocao RE;
    private void Awake() => RE = FindObjectOfType<RazaoEEmocao>();

    public void changeReality() => RE.animationReality();
}
