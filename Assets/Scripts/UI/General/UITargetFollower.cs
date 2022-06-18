using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITargetFollower : MonoBehaviour
{
    private RectTransform canvasRectTransform;
    private Camera uiCamera;

    [SerializeField]
    private Transform target;

    [SerializeField]
    protected Vector3 targetOffset;

    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        uiCamera = Camera.main;//UIController.Instance.uiCamera;
        canvasRectTransform = UIController.Instance.rootCanvas.GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            Vector2 adjustedPosition = uiCamera.WorldToScreenPoint(target.position + targetOffset);

            adjustedPosition.x *= canvasRectTransform.rect.width / (float)uiCamera.pixelWidth;
            adjustedPosition.y *= canvasRectTransform.rect.height / (float)uiCamera.pixelHeight;

            // set it
            rectTransform.anchoredPosition = adjustedPosition - canvasRectTransform.sizeDelta / 2f;
        }
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }


}
