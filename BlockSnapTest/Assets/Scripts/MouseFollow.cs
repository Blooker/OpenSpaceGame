using UnityEngine;
using System.Collections;

public class MouseFollow : MonoBehaviour {

    public bool followMouse = true;

    SpriteRenderer spriteRender;
    Vector3 mousePosition;

	// Use this for initialization
	void Start () {
        spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.color = new Color(1f, 1f, 1f, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
        if (followMouse) {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, 1);
        }
    }
}
