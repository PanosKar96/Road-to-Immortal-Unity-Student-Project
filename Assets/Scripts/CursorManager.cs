using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
   [Header("Cursor Textures")]
   public Texture2D defaultCursor;
   public Texture2D hoverCursor;
   public Texture2D pressedCursor;

   [Header("Hotsports (where the click point is)")]
   public Vector2 defaultHortspot = Vector2.zero;
   public Vector2 hoverHotspot = Vector2.zero;
   public Vector2 pressedHotspot = Vector2.zero;

   void Start()
    {
        SetDefault();
    }
    public void SetDefault()
    {
        if(defaultCursor == null) return;
        Cursor.SetCursor(defaultCursor, defaultHortspot, CursorMode.Auto);
    }

    public void SetHover()
    {
        if (hoverCursor == null) return;
        Cursor.SetCursor(hoverCursor, hoverHotspot, CursorMode.Auto);
    }

    public void SetPressed()
    {
        if(pressedCursor == null) return;
        Cursor.SetCursor(pressedCursor, pressedHotspot, CursorMode.Auto);
    }
}
