using UnityEngine;
using System.Collections;

public class SnapPoint : MonoBehaviour {

    public float offsetAmountX;
    public float offsetAmountY;
    public string triggerMessage;

    GameObject snappedBlock;
    GameObject ghostBlockGO;

    GhostBlock ghostBlockScript;
    Vector3 snapOffset;

    void Start () {
        ghostBlockGO = GameObject.Find("GhostBlock");
        ghostBlockScript = ghostBlockGO.GetComponent<GhostBlock>();
    }

    public void SnapBlock (GameObject block) {
        snappedBlock = block;

        foreach (Collider c in GetComponents<Collider>()) {
            c.enabled = false;
        }
    }

    void OnMouseEnter () {
        //Debug.Log(triggerMessage);
        snapOffset = new Vector3(offsetAmountX, offsetAmountY, 0);
        ghostBlockScript.SnapToPivot(this.gameObject.transform, snapOffset, transform.localPosition, transform.rotation);
    }

    void OnMouseExit () {
        ghostBlockScript.UnsnapFromPivot();
    }
}
