using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ColectableNotification : MonoBehaviour
{
    public Text title;
    public Text name;

    public ColectableManager colectableList;

    [Space(10)]
    public float Duration = 1;

    private RectTransform _transform;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
    }

    public void Notificate(int index)
    {
        title.transform.parent.gameObject.SetActive(true);

        title.text = colectableList.ItensInOrder[index].feedbackMessage;
        name.text = colectableList.ItensInOrder[index].Nome;

        _transform.DOAnchorPosX(0,0.5f);

        StartCoroutine(FadeOut(Duration));
    }

    private IEnumerator FadeOut(float interval)
    {
        yield return new WaitForSeconds(interval);

        _transform.DOAnchorPosX(360, 0.5f);

    }

}
