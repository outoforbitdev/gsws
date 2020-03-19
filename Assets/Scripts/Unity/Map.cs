////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                   Map.cs                                   //
//                                  Map class                                 //
//              Created by: Jarett (Jay) Mirecki, July 28, 2019               //
//            Modified by: Jarett (Jay) Mirecki, October 09, 2019             //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Xml.Serialization;
using System.IO;
using System;
using System.Drawing;
using GSWS;
using JMSuite.Collections;

public class Map : MonoBehaviour
{
    public GameObject PlanetDisplay;
    public GameObject SpacelaneDisplay;
    public GameObject PlanetInfoBox;
    public PlanetInfoBoxController InfoBoxController;
    public GameObject MiniMapPlanet;
    private bool Centered = true;
    private Vector3 CenteredPosition = new Vector3(0f, 0f, 8f);
    static private float scaleFactor = 0.2f;
    static public float XMax, YMax, ZMax, XMin, YMin, ZMin;

    void Start() {
        XMax = YMax = ZMax = XMin = YMin = ZMin = 0f;
        foreach (Planet aPlanet in Game.DB.Planets.Values)
            addPlanet(aPlanet);
        foreach (JGraph<string>.Edge e in Game.DB.Map.Edges)
            addSpacelane(Game.DB.Planets[e.Origin].Position, 
                         Game.DB.Planets[e.Destination].Position);
        PlanetInfoBox.SetActive(false);
    }
    private void addPlanet(Planet currPlanet) {
        Vector3 position = AsMapVector(currPlanet.Position);
        if (position.x > XMax) XMax = position.x;
        if (position.y > YMax) YMax = position.y;
        if (position.x < XMin) XMin = position.x;
        if (position.y < YMin) YMin = position.y;
        var PlanetObject = Instantiate(PlanetDisplay,           
                                       position, 
                                       Quaternion.identity);
        PlanetObject.name = currPlanet.ID;
        PlanetObject.GetComponentInChildren<TextMeshPro>().text =   
            currPlanet.Name;

        var MiniMap = GameObject.Find("MiniMap");
        var PlanetColor = System.Drawing.Color.FromName(currPlanet.Faction.Color);
        var MiniPlanet = Instantiate(MiniMapPlanet, MiniMap.transform);
        MiniPlanet.transform.localPosition = miniMapPosition(currPlanet.Position);
        MiniPlanet.name = currPlanet.ID;
        MiniPlanet.GetComponent<Text>().color = 
            new UnityEngine.Color(PlanetColor.R, PlanetColor.G, PlanetColor.B, PlanetColor.A);
        
    }
    private void addSpacelane(Coordinate Start, Coordinate End) {
        float angle = MapAngleBetween(Start, End);
        float elevation = ElevationBetween(Start, End);

        float medX = (AsMapVector(Start).x + AsMapVector(End).x) / 2;
        float medY = (AsMapVector(Start).y + AsMapVector(End).y) / 2;
        float medZ = (AsMapVector(Start).z + AsMapVector(End).z) / 2;
        // medZ = 0;

        float distance = MapDistanceBetween(Start, End);
    
        Vector3 position = new Vector3(medX, medY, medZ);
        Quaternion rotation = Quaternion.Euler(0, 0, angle);

        float spacelaneWidth = 0.05f;
        float spacelaneDepth = 0.1f;
        
        var SpacelaneObject = Instantiate(SpacelaneDisplay);
        SpacelaneObject.GetComponent<Transform>().localScale = new Vector3(spacelaneWidth, distance, spacelaneDepth);
        SpacelaneObject.GetComponent<Transform>().Rotate(0, elevation, 0);
        SpacelaneObject.GetComponent<Transform>().Rotate(0, 0, angle);
        SpacelaneObject.GetComponent<Transform>().localPosition = position;
    }
    private Vector3 miniMapPosition(Coordinate coords) {
        float scaleFactor = 0.1f;
        return new Vector3(coords.X * scaleFactor + 100, coords.Y * scaleFactor + 100, 0);
    }

    void Update() {
        if (!Centered) {
            centerCamera();
        }
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                Planet aPlanet;
                if (Game.DB.Planets.TryGetValue(hit.transform.parent.name, out aPlanet)) {
                    Vector3 position = AsMapVector(aPlanet.Position);
                    PlanetInfoBoxController InfoBox = GameObject.Find("PlanetInfoBoxController").GetComponent<PlanetInfoBoxController>();
                    InfoBoxController.UpdatePlanet(aPlanet);
                    PlanetInfoBox.SetActive(true);
                    CenteredPosition = position;
                    Centered = false;
                }
            }
        }
    }
    private void centerCamera() {
        Vector3 position = CenteredPosition;
        Vector3 camPosition = Camera.main.transform.position;
        if (position.x == camPosition.x && position.y == camPosition.y && camPosition.z == 8f) {
            Centered = true;
            Game.MapCameraLocation = camPosition;
            return;
        }
        Vector3 newCamPosition = 
            new Vector3(camPosition.x - position.x, 
                        position.y - camPosition.y, 
                        camPosition.z - 8f);
        float maxTranslate = 0f;
        if (Math.Abs((double)newCamPosition.x) > Math.Abs((double)newCamPosition.y) && Math.Abs((double)newCamPosition.x) > Math.Abs((double)newCamPosition.z))
            maxTranslate = newCamPosition.x;
        else if (Math.Abs((double)newCamPosition.y) > Math.Abs((double)newCamPosition.x) && Math.Abs((double)newCamPosition.y) > Math.Abs((double)newCamPosition.z))
            maxTranslate = newCamPosition.y;
        else if (Math.Abs((double)newCamPosition.z) > Math.Abs((double)newCamPosition.y) && Math.Abs((double)newCamPosition.z) > Math.Abs((double)newCamPosition.x))
            maxTranslate = newCamPosition.z;
        if (maxTranslate > 5f)
            newCamPosition = newCamPosition / (float)(Math.Abs((double)maxTranslate)) * 5;

        Camera.main.transform.Translate(newCamPosition);
    }

    static public Vector3 AsMapVector(Coordinate c) {
        return new Vector3(c.X * scaleFactor * -1,
                           c.Y * scaleFactor,
                        //    c.Z * scaleFactor);
                           0);
    }
    static public float MapDistanceBetween(Coordinate a, Coordinate b) {
        return a.DistanceTo(b) * scaleFactor;
    }
    static public float MapAngleBetween(Coordinate a, Coordinate b) {
        return a.Angle(b);;
    }
    static public float ElevationBetween(Coordinate a, Coordinate b) {
        float elevation = a.AngleOfElevation(b);
        // return elevation * -1;
        return 0;
    }
}

