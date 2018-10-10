using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serce : MonoBehaviour {

    public GameObject sercePrefab;                                 //The column game object.
    public int sercePoolSize = 3;                                  //How many columns to keep on standby.
    public float spawnRate = 1f;                                    //Minimum y value of the column position.
    public float column = 3.5f;

    static public GameObject[] serca;                                   //Collection of pooled columns.
    private int currentSerce = 2;

    private Rigidbody2D rb2d;

    private Vector2 objectPoolPosition = new Vector2(-9.5f, 4.5f);
    // Use this for initialization
    void Start () {
        //Initialize the columns collection.
        serca = new GameObject[sercePoolSize];
        //Loop through the collection... 
        for (int i = 0; i < sercePoolSize; i++)
        {
            //...and create the individual columns.
            serca[i] = (GameObject)Instantiate(sercePrefab, objectPoolPosition+new Vector2(0,-i), Quaternion.identity);
        }
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

}
