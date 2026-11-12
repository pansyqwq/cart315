
using UnityEngine;
using UnityEngine.InputSystem;


public class HandCursor : MonoBehaviour
{
    public RectTransform handImage;
    public float smoothSpeed = 15f;

    private Canvas canvas;
    private RectTransform canvasRect;
    public Vector2 handOffset = new Vector2(0, -200);

    void Start()
    {
        canvas = handImage.GetComponentInParent<Canvas>();
        canvasRect = canvas.GetComponent<RectTransform>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Mouse.current == null) return;

        Vector2 mousePosition = Mouse.current.position.ReadValue();

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect,
            mousePosition,
            canvas.renderMode == RenderMode.ScreenSpaceOverlay
                ? null
                : canvas.worldCamera,
            out Vector2 localPosition
        );

        handImage.anchoredPosition = Vector2.Lerp(
    handImage.anchoredPosition,
    localPosition + handOffset,
    Mathf.Clamp01(smoothSpeed * Time.deltaTime)
);
    }

    void OnDisable()
    {
        Cursor.visible = true;
    }
}
