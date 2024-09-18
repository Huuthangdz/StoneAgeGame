using UnityEngine;

public class ParalaxController : MonoBehaviour
{
    Transform cam; //main camera
    Vector3 camStarPos;
    float distance; //distance between ther camera start possition and its current position

    GameObject[] backGround;
    Material[] mat;
    float[] backSpeed;

    float fartherBack;

    [Range(0.01f, 0.05f)]
    public float paralaxSpeed;
    void Start()
    {
        cam = Camera.main.transform;
        camStarPos = cam.position;

        int backCount = transform.childCount;
        mat = new Material[backCount];
        backSpeed = new float[backCount];
        backGround = new GameObject[backCount];

        for ( int i = 0; i < backCount; i++)
        {
            backGround[i] = transform.GetChild(i).gameObject;
            mat[i] = backGround[i].GetComponent<Renderer>().material;
        }
        BackSpeedCalculate(backCount);
    }

    void BackSpeedCalculate(int backCount)
    {
        for (int i = 0; i < backCount; i++)
        {
            if ((backGround[i].transform.position.z - cam.position.z) > fartherBack)
            {
                fartherBack = backGround[i].transform.position.z - cam.position.z;
            }
        }
        for (int i = 0; i < backCount; i++)
        {
            backSpeed[i] = 1 - (backGround[i].transform.position.z - cam.position.z) / fartherBack ;
        }
    }

    private void LateUpdate()
    {
        distance = cam.position.x - camStarPos.x;
        //transform.position = new Vector3(cam.position.x, cam.position.y, 0);
        for ( int i = 0; i < backGround.Length; i++)
        {
            float speed = backSpeed[i] * paralaxSpeed;
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        }
        transform.position = new Vector3(cam.position.x, transform.position.y, 0);
    }
}
