////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                MapCamera.cs                                //
//                            Map Camera controller                           //
//                   Created by: Jay Mirecki, July 28, 2019                   //
//                  Modified by: Jay Mirecki, March 19, 2020                  //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using GSWS;

public class MapCamera : MonoBehaviour {
    private float speed = 1f;
    private float zLowBoundary = 8f;
    private float xLowBoundary = 100f;
    private float yLowBoundary = 
        Map.AsMapVector(new Coordinate(106, -610, 4)).y;
    private float zHighBoundary = 100f;
    private float xHighBoundary = 
        Map.AsMapVector(new Coordinate(582, 210, 5)).x;
    private float yHighBoundary = 
        Map.AsMapVector(new Coordinate(582, 210, 5)).y;
    void Start() {
        transform.position = Game.MapCameraLocation;
    }
    void Update() {
        float zoomedSpeed = speed * transform.position.z;
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(new Vector3(zoomedSpeed * Time.deltaTime,0,0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-zoomedSpeed * Time.deltaTime,0,0));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0,-zoomedSpeed * Time.deltaTime,0));
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0,zoomedSpeed * Time.deltaTime,0));
        }
        if (Input.GetAxis("Mouse ScrollWheel") != 0f )
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));

            transform.Translate(new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel") * 100));

            Vector3 camPosition = transform.position;
            camPosition.x = mousePosition.x;
            camPosition.y = mousePosition.y;
            if (transform.position.z > 8 && Input.GetAxis("Mouse ScrollWheel") > 0)
                transform.position = camPosition;
        }
        xHighBoundary = Map.XMax;
        xLowBoundary = Map.XMin;
        yHighBoundary = Map.YMax;
        yLowBoundary = Map.YMin;
        Vector3 boundary = transform.position;
        if (boundary.z < zLowBoundary)
            boundary.z = zLowBoundary;
        if (boundary.x < xLowBoundary)
            boundary.x = xLowBoundary;
        if (boundary.y < yLowBoundary)
            boundary.y = yLowBoundary;
        if (boundary.z > zHighBoundary)
            boundary.z = zHighBoundary;
        if (boundary.x > xHighBoundary)
            boundary.x = xHighBoundary;
        if (boundary.y > yHighBoundary)
            boundary.y = yHighBoundary;
        transform.position = boundary;
        Game.MapCameraLocation = transform.position;
    }
}