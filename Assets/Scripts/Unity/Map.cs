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

    void Start() {
        foreach (Planet aPlanet in Game.DB.Planets.Values)
            addPlanet(aPlanet);
        foreach (JGraph<string>.Edge e in Game.DB.Map.Edges)
            addSpacelane(Game.DB.Planets[e.Origin].Position, 
                         Game.DB.Planets[e.Destination].Position);
        PlanetInfoBox.SetActive(false);
    }
    private void addPlanet(Planet currPlanet) {
        Vector3 position = AsMapVector(currPlanet.Position);
        position.z = 0;
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
        MiniPlanet.GetComponent<Text>().color = 
            new UnityEngine.Color(PlanetColor.R, PlanetColor.G, PlanetColor.B, PlanetColor.A);
        
    }
    private void addSpacelane(Coordinate Start, Coordinate End) {
        float angle = Start.MapAngle(End);

        float medX = (AsMapVector(Start).x + AsMapVector(End).x) / 2;
        float medY = (AsMapVector(Start).y + AsMapVector(End).y) / 2;
        float medZ = (AsMapVector(Start).z + AsMapVector(End).z) / 2;
        medZ = 0;

        float distance = Start.MapDistanceTo(End);
    
        Vector3 position = new Vector3(medX, medY, medZ);
        Quaternion rotation = Quaternion.Euler(0, 0, angle);
        
        var SpacelaneObject = Instantiate(SpacelaneDisplay, position, rotation);
        SpacelaneObject.GetComponent<Transform>().localScale = new Vector3(distance, 0.1f, 0.1f);
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
                Debug.Log(hit.transform.name);
                if (hit.transform.name == "Sphere") {
                    foreach(Planet aPlanet in Game.DB.Planets.Values) {
                        Vector3 position = AsMapVector(aPlanet.Position);
                        position.z = 0;
                        if (position == hit.transform.position) {
                            PlanetInfoBoxController InfoBox = GameObject.Find("PlanetInfoBoxController").GetComponent<PlanetInfoBoxController>();
                            InfoBox.UpdatePlanet(aPlanet);
                            PlanetInfoBox.SetActive(true);
                            CenteredPosition = position;
                            Centered = false;
                            break;
                        }
                    }
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
        Debug.Log(newCamPosition);
        float maxTranslate = 0f;
        if (Math.Abs((double)newCamPosition.x) > Math.Abs((double)newCamPosition.y) && Math.Abs((double)newCamPosition.x) > Math.Abs((double)newCamPosition.z))
            maxTranslate = newCamPosition.x;
        else if (Math.Abs((double)newCamPosition.y) > Math.Abs((double)newCamPosition.x) && Math.Abs((double)newCamPosition.y) > Math.Abs((double)newCamPosition.z))
            maxTranslate = newCamPosition.y;
        else if (Math.Abs((double)newCamPosition.z) > Math.Abs((double)newCamPosition.y) && Math.Abs((double)newCamPosition.z) > Math.Abs((double)newCamPosition.x))
            maxTranslate = newCamPosition.z;
        Debug.Log(maxTranslate);
        if (maxTranslate > 5f)
            newCamPosition = newCamPosition / (float)(Math.Abs((double)maxTranslate)) * 5;
        Debug.Log(newCamPosition);

        Camera.main.transform.Translate(newCamPosition);
    }

    static public Vector3 AsMapVector(Coordinate c) {
        return new Vector3(c.X * scaleFactor * -1,
                           c.Y * scaleFactor,
                           c.Z * scaleFactor);
    }
}

