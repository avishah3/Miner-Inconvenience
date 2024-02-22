using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

public class TileSpawn : MonoBehaviour
{
    public GameObject Tile1;
    public GameObject Tile2;
    public GameObject Tile3;
    public GameObject StartTile;
    private int RandomInt;
    /*
    for (int i = 0; i< 3; i++)
            {
                RandomInt = Random.Range(0,1);
                if (RandomInt == 0)
                {
                    GameObject TempTile1 = Instantiate(Tile1, transform);
    TempTile1.transform.position = new Vector3(-16+tileLength, 0, 0);
    Destroy(TempTile1, destroySpeed);
}
                else if (RandomInt == 1)
{
    GameObject TempTile2 = Instantiate(Tile2, transform);
    TempTile2.transform.position = new Vector3(-16 + tileLength, 0, 0);
    Destroy(TempTile2, destroySpeed);
}
else if (RandomInt == 2)
{
    GameObject TempTile3 = Instantiate(Tile3, transform);
    TempTile3.transform.position = new Vector3(-16 + tileLength, 0, 0);
    Destroy(TempTile3, destroySpeed);
}
tileLength -= 8;
            } */

    private float Index = 0;

    private void Start()
    {
        GameObject StartPlane1 = Instantiate(StartTile, transform);
        StartPlane1.transform.position = new Vector3(7, 0, 0);
        Destroy(StartPlane1, 3.5f);
        GameObject StartPlane2 = Instantiate(StartTile, transform);
        StartPlane2.transform.position = new Vector3(-1, 0, 0);
        Destroy(StartPlane2, 3.5f);
        GameObject StartPlane3 = Instantiate(StartTile, transform);
        StartPlane3.transform.position = new Vector3(-9, 0, 0);
        Destroy(StartPlane3, 3.5f);
        GameObject StartPlane4 = Instantiate(StartTile, transform);
        StartPlane4.transform.position = new Vector3(-17, 0, 0);
        Destroy(StartPlane4, 3.5f);
        GameObject StartPlane5 = Instantiate(StartTile, transform);
        StartPlane5.transform.position = new Vector3(-25, 0, 0);
        Destroy(StartPlane5, 3.5f);
    }

    private void Update()
    {
        //X used for tile rotation z used to change spawn location
        //TempTile1.transform.position = new Vector3(-16, 0, 8);
        // gameObject.transform.position used for tile moving closer
        float destroySpeed = 12.0f;
        //right
        //gameObject.transform.position += new Vector3(0, 0, 4 * Time.deltaTime);
        //left
        //gameObject.transform.position += new Vector3(0, 0, -4 * Time.deltaTime);
        //straight on
        gameObject.transform.position += new Vector3(4 * Time.deltaTime, 0, 0);
        int tileLength = 0;
        if (transform.position.x >= Index)
        {
            UnityEngine.Debug.Log("Howman");
            for (int i = 0; i < 3; i++)
            {
                UnityEngine.Debug.Log("Howman1");
                RandomInt = Random.Range(0, 3);
                if (RandomInt == 0)
                {
                    GameObject TempTile1 = Instantiate(Tile1, transform);
                    TempTile1.transform.position = new Vector3(-16 + tileLength, 0, 0);
                    Destroy(TempTile1, destroySpeed);
                }
                else if (RandomInt == 1)
                {
                    GameObject TempTile2 = Instantiate(Tile2, transform);
                    TempTile2.transform.position = new Vector3(-16 + tileLength, 0, 0);
                    Destroy(TempTile2, destroySpeed);
                }
                else if (RandomInt == 2)
                {
                    GameObject TempTile3 = Instantiate(Tile3, transform);
                    TempTile3.transform.position = new Vector3(-16 + tileLength, 0, 0);
                    Destroy(TempTile3, destroySpeed);
                }
                tileLength -= 8;
            }

            Index = Index + 15.95f;
        }
    }
}