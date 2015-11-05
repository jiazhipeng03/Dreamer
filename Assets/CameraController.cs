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
        Vector2 bound = new Vector2(0, Mathf.Infinity);
        //  TO-DO set max bound
        transform.position = new Vector3(Mathf.Max(bound[0],m_Player.transform.position.x), transform.position.y, transform.position.z);
    }
}
