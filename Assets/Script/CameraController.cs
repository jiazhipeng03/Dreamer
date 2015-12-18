using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
    [SerializeField]
    GameObject m_Player;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 minBound = new Vector2(0, 0);
        //  TO-DO set max bound
        transform.position = new Vector3(Mathf.Max(minBound[0],m_Player.transform.position.x), Mathf.Max(minBound[1], m_Player.transform.position.y), transform.position.z);
    }
}
