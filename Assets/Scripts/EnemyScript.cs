using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public GameObject target;

    // Use this for initialization
    void Start () {
       
        StartCoroutine("Move");
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(Vector3.right * Time.deltaTime);

        transform.LookAt(target.transform);
    }

    IEnumerator Move() {
        while (true) {
            yield return new WaitForSeconds(8f);
            transform.eulerAngles += new Vector3(0, 180f, 0);
        }
    }
}
