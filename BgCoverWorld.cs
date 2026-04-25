using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BgCoverWorld : MonoBehaviour
{
    public Camera cam;      // boş bırakırsan otomatik Main Camera
    public bool centerToCam = true; // arka planı kameranın orta noktasına hizala

    void Awake()
    {
        if (!cam) cam = Camera.main;
        var sr = GetComponent<SpriteRenderer>();
        if (sr.sprite == null || cam == null) return;

        // Sprite’ın dünya boyutu
        Vector2 spriteSize = sr.sprite.bounds.size;

        // Kameranın dünyada gördüğü alan
        float worldHeight = cam.orthographicSize * 2f;
        float worldWidth = worldHeight * cam.aspect;

        // En-boyu bozmadan ekrana doldur (letterbox yok)
        float k = Mathf.Max(worldWidth / spriteSize.x, worldHeight / spriteSize.y);
        transform.localScale = new Vector3(k, k, 1f);

        // Ortala (isteğe bağlı)
        if (centerToCam)
            transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y, transform.position.z);
    }
}

