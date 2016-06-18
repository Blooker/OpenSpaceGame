using UnityEngine;
using System.Collections;

public class SnapPointScript : MonoBehaviour {

    public string triggerMessage;
    public GameObject mouseObject;

    MouseFollow mouseScript;
    GameObject blockParent;

    void Start () {
        mouseScript = mouseObject.GetComponent<MouseFollow>();
        blockParent = transform.parent.parent.gameObject;
    }

    void OnMouseEnter () {
        Debug.Log(triggerMessage);
    }
}
