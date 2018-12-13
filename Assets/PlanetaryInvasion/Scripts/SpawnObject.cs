using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    public Transform[] destinationPoints;
    public GameObject spawnable;
    public Vector3 size;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnAlien", 2.0f, 2.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)) {
            SpawnAlien();
        }
	}

    public void SpawnAlien() {
        if (Random.value < 0.9f) {
            Transform randomTransform = destinationPoints[Random.Range(0, destinationPoints.Length-1) % destinationPoints.Length];
		    Vector3 pos = randomTransform.position + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            int rotY = 0;
            /*f(Random.value<0.5f)
                rotY=0;
            else
                rotY=180;*/
            Quaternion rot = Quaternion.Euler(0, rotY, 0);

            GameObject spawned = Instantiate(spawnable, pos, rot);
            spawned.GetComponent("");
        }
	}

    void OnDrawGizmosSelected() {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(transform.position, transform.localScale + size);
    }
}
