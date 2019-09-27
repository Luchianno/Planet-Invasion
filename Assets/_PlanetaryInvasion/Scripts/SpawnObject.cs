using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour {

    //alien_navigatables
    [TagSelector]
    public string spawner_Tag;
    //alien_spawner
    [TagSelector]
    public string wander_tag;
    [TagSelector]
    public string spawner_id;

    public GameObject[] spawnables;

    public int spawn_limit = 15;


    private GameObject[] destinationPoints;
    private GameObject spawnable;
    public Vector3 size;

	// Use this for initialization
	void Start () {
        spawnable = spawnables[Random.Range(0, spawnables.Length)];
        if (spawner_id.Length == 0) spawner_id = spawnable.tag;
        InvokeRepeating("SpawnAlien", 2.0f, 2.5f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q)) {
            SpawnAlien();
        }
	}

    public void SpawnAlien() {
        StartCoroutine("Fade");
	}

    IEnumerator Fade() {
        yield return new WaitForSeconds(Random.Range(1, 3));
        if (Random.value < 0.4f && GameObject.FindGameObjectsWithTag(spawnable.tag).Length< spawn_limit) {
            destinationPoints = GameObject.FindGameObjectsWithTag(spawner_Tag);
            Transform randomTransform = destinationPoints[Random.Range(0, destinationPoints.Length-1) % destinationPoints.Length].transform;
		    Vector3 pos = randomTransform.position + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            int rotY = 0;
            Quaternion rot = Quaternion.Euler(0, rotY, 0);

            NavigationController s = spawnable.GetComponent<NavigationController>();
            s.spawner_Tag = spawner_Tag;
            s.wander_tag = wander_tag;
            s.tag = spawner_id;
            Instantiate(spawnable, pos, rot);
        }
    }


    void OnDrawGizmosSelected() {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(transform.position, transform.localScale + size);
    }
}
