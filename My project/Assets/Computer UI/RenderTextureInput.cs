using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class RenderTextureInput : MonoBehaviour
{
    public Camera mainCamera;
    public Camera uiCamera;
    public GraphicRaycaster uiRaycaster;
    public EventSystem eventSystem;

    private PointerEventData pointerData;

    void Awake()
    {
        pointerData = new PointerEventData(eventSystem);
    }

    void Update()
    {
        if (!Input.GetMouseButtonDown(0) && !Input.GetMouseButtonUp(0))
            return;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit))
            return;

        if (hit.collider.gameObject != gameObject)
            return;

        Vector2 uv = hit.textureCoord;
        uv.y = 1f - uv.y;

        Vector2 uiPosition = new Vector2(
            uv.x * uiCamera.pixelWidth,
            uv.y * uiCamera.pixelHeight
        );

        pointerData.Reset();
        pointerData.position = uiPosition;

        List<RaycastResult> results = new List<RaycastResult>();
        uiRaycaster.Raycast(pointerData, results);

        foreach (var result in results)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ExecuteEvents.Execute(
                    result.gameObject,
                    pointerData,
                    ExecuteEvents.pointerDownHandler
                );
            }

            if (Input.GetMouseButtonUp(0))
            {
                ExecuteEvents.Execute(
                    result.gameObject,
                    pointerData,
                    ExecuteEvents.pointerUpHandler
                );

                ExecuteEvents.Execute(
                    result.gameObject,
                    pointerData,
                    ExecuteEvents.pointerClickHandler
                );
            }
        }
    }
}
