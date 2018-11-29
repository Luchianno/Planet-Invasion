using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    public GameObject spawnable;
    public Vector3 center;
    public Vector3 size;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)) {
            SpawnAlien();
        }
	}

    public void SpawnAlien() {
		Vector3 pos = transform.localPosition + center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        int rotY;
        if(Random.value<0.5f)
            rotY=0;
        else
            rotY=180;
        Quaternion rot = Quaternion.Euler(0, rotY, 0);

        Instantiate(spawnable, pos, rot);
	}

    void OnDrawGizmosSelected() {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(transform.position + center, transform.localScale + size);
    }
}
