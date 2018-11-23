using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    public GameObject spawnable;
    public Vector3 center;
    public Vector3 size;

	// Use this for initialization
	void Start () {
		SpawnAlien();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Q)) {
            SpawnAlien();
        }
	}

    public void SpawnAlien() {
		Vector3 pos = transform.localPosition + center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

        Instantiate(spawnable, pos, Quaternion.identity);
	}

    void OnDrawGizmosSelected() {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(transform.localPosition + center, transform.localScale + size);
    }
}
