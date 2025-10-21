using System.Collections;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorNormal;
    [SerializeField] private Texture2D cursorShoot;
    [SerializeField] private Texture2D cursorReload;
    [SerializeField] private float reloadTime = 2f;
    private Vector2 hotspot = new Vector2(16, 48);
    private bool isReloading = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.SetCursor(cursorNormal, hotspot, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading) return;

        if (Input.GetMouseButtonDown(0))
        {
            Cursor.SetCursor(cursorShoot, hotspot, CursorMode.Auto);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Cursor.SetCursor(cursorNormal, hotspot, CursorMode.Auto);
        }
        if (Input.GetKeyDown(KeyCode.R)&&!isReloading)
        {
            StartCoroutine(ReloadCursor());
        }

    }

    IEnumerator ReloadCursor()
    {
        isReloading = true;
        Cursor.SetCursor(cursorReload, hotspot, CursorMode.Auto);
        yield return new WaitForSeconds(reloadTime);
        Cursor.SetCursor(cursorNormal, hotspot, CursorMode.Auto);
        isReloading = false;

    }
}
