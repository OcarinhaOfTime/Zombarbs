using UnityEngine;
using System.Collections;

public class PutPSToTheFront : MonoBehaviour {
    public string sortingLayerName = "Foreground";
	void Awake() {

		//SpriteRenderer rend = GetComponent<SpriteRenderer>();
		Renderer[] renderers = GetComponentsInChildren<Renderer>();
		foreach(Renderer r in renderers)
			r.sortingLayerName = sortingLayerName;

		GetComponent<Renderer>().sortingLayerName = sortingLayerName;
	}
}
