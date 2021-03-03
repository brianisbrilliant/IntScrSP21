using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    public int one = 10,two = 10;
    public float interval = .2f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BuildCubes(one, two));
    }

    IEnumerator BuildCubes(int x, int y) {
        for(int i = 0; i < x * y; i++) {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = this.transform.position;
            cube.transform.Translate(i % y, (i / y), 0);
            yield return new WaitForSeconds(interval);
        }
    }
}
