using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITargetFollower : MonoBehaviour
{
    private RectTransform canvasRectTransform;
    private Camera uiCamera;

    public bool useTransform;
    [SerializeField]
    private Vector3 targetPosition;
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
        uiCamera = UIController.Instance.uiCamera;
        canvasRectTransform = UIController.Instance.rootCanvas.GetComponent<RectTransform>();
    }

    private void FixedUpdate()
    {
        if(useTransform && target != null) { 
            targetPosition = target.position;
        }

        Vector2 adjustedPosition = uiCamera.WorldToScreenPoint(targetPosition + targetOffset);

        adjustedPosition.x *= canvasRectTransform.rect.width / (float)uiCamera.pixelWidth;
        adjustedPosition.y *= canvasRectTransform.rect.height / (float)uiCamera.pixelHeight;

        // set it
        rectTransform.anchoredPosition = adjustedPosition - canvasRectTransform.sizeDelta / 2f;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void UpdatePosition(Vector3 worldTargetPosition) {
        targetPosition = worldTargetPosition;
    }


}
