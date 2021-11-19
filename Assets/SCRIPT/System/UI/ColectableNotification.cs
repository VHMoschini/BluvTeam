using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColectableNotification : MonoBehaviour
{
    public Text title;
    //public Text name;

    public ColectableManager colectableList;

    [Space(10)]
    public float Duration = 1;

    private RectTransform _transform;
    //private float XPosInit;


    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
        //XPosInit = _transform.position.x;
    }

    public void Notificate(int index)
    {
        title.transform.parent.gameObject.SetActive(true);

        title.text = colectableList.ItensInOrder[index].feedbackMessage + " - " + colectableList.ItensInOrder[index].Nome;

        //title.text = colectableList.ItensInOrder[index].feedbackMessage;
        //name.text = colectableList.ItensInOrder[index].Nome;

        _transform.DOAnchorPosX(0,1f);

        StartCoroutine(FadeOut(Duration));
    }

    private IEnumerator FadeOut(float interval)
    {
        yield return new WaitForSeconds(interval);

        _transform.DOAnchorPosX(-767, 1.5f);
    }

}
