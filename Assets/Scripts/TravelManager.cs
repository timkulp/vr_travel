using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TravelManager : MonoBehaviour {
    public GameObject TravelerTemplate;
    public IEnumerable<GameObject> TravelerGameObjects;
    public List<Traveler> TravelerList;

	// Use this for initialization
	void Start () {
        TravelerGameObjects = new System.Collections.Generic.List<GameObject>();
        TravelerList = new List<Traveler>();
	}

    public void LoadTravelers() {

        try
        {
            StartCoroutine(getTravelers());
        }
        catch(Exception ex)
        {
            Debug.Log(ex.ToString());
        }


    }


    private IEnumerator getTravelers()
    {
        var www = new WWW("http://contosotravel1.azurewebsites.net/api/Traveler");

        yield return www;

        
        if (www.isDone)
            displayTravelers(www.text);
    }

    private void displayTravelers(string json)
    {
        JSONObject jsonTravelers = new JSONObject(json);

        foreach (var jsonTraveler in jsonTravelers.list)
        {
            //convert jsonobject to traveler object
            Traveler traveler = convertJSON(jsonTraveler);

            GameObject travelerRep = Instantiate(TravelerTemplate, new Vector3(0f, 0.05f, 0f), TravelerTemplate.transform.rotation) as GameObject;
            travelerRep.name = traveler.Name;
            travelerRep.SetActive(true);
   
            GameObject[] airports = GameObject.FindGameObjectsWithTag("Airport");
            foreach (var airport in airports)
            {
                if (airport.name == traveler.ArrivalCity)
                {
                    travelerRep.transform.position = new Vector3(airport.transform.position.x, 0.05f, airport.transform.position.z);
                    break;
                }
            }

            TravelerList.Add(traveler);
        }
    }

    private Traveler convertJSON(JSONObject jsonTraveler)
    {
        Traveler traveler = new Traveler();
        traveler.Id = int.Parse(jsonTraveler.GetField("Id").ToString());
        traveler.Name = jsonTraveler.GetField("Name").str;
        traveler.Title = jsonTraveler.GetField("Title").str;
        traveler.ArrivalCity = jsonTraveler.GetField("ArrivalCity").str;
        traveler.DepartureCity = jsonTraveler.GetField("DepartureCity").str;
        return traveler;
    }
}


public class Traveler
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string DepartureCity { get; set; }
    public string ArrivalCity { get; set; }
}
