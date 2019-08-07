////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                   Map.cs                                   //
//                                  Map class                                 //
//              Created by: Jarett (Jay) Mirecki, July 28, 2019               //
//             Modified by: Jarett (Jay) Mirecki, August 07, 2019             //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using GSWS;
using System.Xml.Serialization;
using System.IO;
using JMSuite.Collections;
using System;
using System.Drawing;

public class Map : MonoBehaviour
{
    public GameObject PlanetDisplay;
    public GameObject SpacelaneDisplay;
    public GameObject PlanetInfoBox;
    public PlanetInfoBoxController InfoBoxController;
    public GameObject MiniMapPlanet;
    private bool Centered = true;
    private Vector3 CenteredPosition = new Vector3(0f, 0f, 8f);

    void Start() {
        foreach (Planet aPlanet in Game.Instance.Planets.Values())
            addPlanet(aPlanet);
        foreach (Graph<string, Planet>.Edge edge in Game.Instance.Planets.GetEdges(true))
            addSpacelane(edge.Origin.Coordinates, edge.Destination.Coordinates);
        PlanetInfoBox.SetActive(false);
    }
    private void addPlanet(Planet currPlanet) {
        Vector3 position = currPlanet.Coordinates.AsMapVector();
        position.z = 0;
        var PlanetObject = Instantiate(PlanetDisplay,           
                                       position, 
                                       Quaternion.identity);
        PlanetObject.name = currPlanet.ID;
        PlanetObject.GetComponentInChildren<TextMeshPro>().text =   
            currPlanet.Name;

        var MiniMap = GameObject.Find("MiniMap");
        var PlanetColor = System.Drawing.Color.FromName(Game.Instance.GetFactionFromString(currPlanet.Faction).Color);
        var MiniPlanet = Instantiate(MiniMapPlanet, MiniMap.transform);
        MiniPlanet.transform.localPosition = miniMapPosition(currPlanet.Coordinates);
        MiniPlanet.GetComponent<Text>().color = 
            new UnityEngine.Color(PlanetColor.R, PlanetColor.G, PlanetColor.B, PlanetColor.A);
        
    }
    private void addSpacelane(Coordinate Start, Coordinate End) {
        float angle = Start.MapAngle(End);

        float medX = (Start.AsMapVector().x + End.AsMapVector().x) / 2;
        float medY = (Start.AsMapVector().y + End.AsMapVector().y) / 2;
        float medZ = (Start.AsMapVector().z + End.AsMapVector().z) / 2;
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
                    foreach(Planet aPlanet in Game.Instance.Planets.Values()) {
                        Vector3 position = aPlanet.Coordinates.AsMapVector();
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
            Game.Instance.MapCameraLocation = camPosition;
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
}

