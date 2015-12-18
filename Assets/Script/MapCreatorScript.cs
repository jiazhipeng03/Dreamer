using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapCreatorScript : MonoBehaviour {
    List<GameObject> mapObj;
    [SerializeField]
    GameObject startObj;
    [SerializeField]
    GameObject prefab;
	// Use this for initialization
	void Start () {
        GenerateMap(startObj);
	}
	
	// Update is called once per frame
	void Update () {
        //if (mapObj[mapObj.Count - 1].transform.position.x - player.transform.position.x <= screenwidth)
        //    GenerateMap(mapObj[mapObj.Count - 1]);
	}

    void GenerateMap(GameObject start)
    {
        int objWidth = 200;
        int screenWidth = 1024;
        int minObjNum = screenWidth / objWidth;
        int stepWidth = objWidth; // + jumpWidth
        int jumpHeight = 500;
        int[] arrX = new int[minObjNum];
        int[] arrY = new int[minObjNum];
        arrX[0] = (int)(start.transform.position.x + stepWidth);
        arrY[0] = (int)(start.transform.position.y + Random.Range((-start.transform.position.y), jumpHeight) );

        for (int i = 1; i < arrX.Length; ++i)
            arrX[i] = (int)(arrX[i - 1] + stepWidth);
        for(int i = 1; i < arrY.Length; ++i)
        {
            arrY[i] = (int)(arrY[i - 1] + Random.Range(-arrY[i-1], jumpHeight));
        }

        for(int i=0; i<minObjNum; ++i)
        {
            Object obj = Instantiate(prefab, new Vector3(arrX[i],arrY[i],prefab.transform.position.z), Quaternion.identity) ;
        }
    }
}
