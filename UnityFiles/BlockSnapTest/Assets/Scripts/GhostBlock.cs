using UnityEngine;
using System.Collections;

public class GhostBlock : MonoBehaviour {

    public GameObject block;
    public bool followMouse = true;

    GameObject lastBlockPlaced;
    GameObject currentSnappedPivot;

    SpriteRenderer spriteRender;
    Vector3 mousePos;
    Vector3 snapPos;

	// Use this for initialization
	void Start () {
        spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.color = new Color(1f, 1f, 1f, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
        if (followMouse) {
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            //transform.position = Vector2.Lerp(transform.position, mousePos, 5);
            transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        }

        if (Input.GetMouseButtonDown(0)) {
            lastBlockPlaced = Instantiate(block, transform.position, transform.rotation) as GameObject;
            if (currentSnappedPivot != null) {
                currentSnappedPivot.GetComponent<SnapPoint>().SnapBlock(lastBlockPlaced);
            }
        }
    }

    public void SnapToPivot(Transform snapObject, Vector3 snapOffset, Vector3 pivotPos, Quaternion pivotRot) {
        spriteRender.color = new Color(0f, 1f, 0f, 0.5f);

        currentSnappedPivot = snapObject.gameObject;
        transform.parent = snapObject.parent.parent;
        followMouse = false;
        snapPos = pivotPos + snapOffset;

        transform.localPosition = snapPos;
        transform.rotation = pivotRot;
    }

    public void UnsnapFromPivot () {
        spriteRender.color = new Color(1f, 1f, 1f, 0.5f);

        followMouse = true;
        currentSnappedPivot = null;
        transform.parent = null;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
