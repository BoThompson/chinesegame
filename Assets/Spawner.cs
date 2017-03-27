using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public float activationTimer;
    public float waveTimer;
    public int numberOfWaves;
    public GameObject wavePrefab;

    private float timeTilNextWave;
    private int wavesRemaining;
    private bool activated;
	// Use this for initialization
	void Start () {
        activated = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(activated)
        {
            if(wavesRemaining > 0 && (timeTilNextWave-=Time.deltaTime) < 0)
            {
                wavesRemaining--;
                timeTilNextWave = waveTimer;
                GameObject wave = Instantiate<GameObject>(wavePrefab);
                wave.transform.position = transform.position;
            }
        }
	}

    public void Activate()
    {
        activated = true;
        timeTilNextWave = activationTimer;
    }

    void OnDrawGizmos()
    {
        Matrix4x4 transformMatrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        Matrix4x4 oldGizmosMatrix = Gizmos.matrix;
        Gizmos.matrix *= transformMatrix;
        Gizmos.color = new Color(1, .1f, .1f, 0.5f);
        Gizmos.DrawCube(Vector3.up * 2.5f, new Vector3(1,5,1));
        Gizmos.color = new Color(1, .3f, .3f, 0.9f);
        Gizmos.DrawWireCube(Vector3.up * 2.5f, new Vector3(1,5,1));
        Gizmos.DrawIcon(transform.position + transform.up * 2.5f, "Enemy.png", true     );
        Gizmos.matrix = oldGizmosMatrix;
    }
}
