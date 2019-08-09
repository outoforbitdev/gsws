////////////////////////////////////////////////////////////////////////////////
//                                                                            //
//                                 Planet.cs                                  //
//                                Planet class                                //
//              Created by: Jarett (Jay) Mirecki, July 27, 2019               //
//             Modified by: Jarett (Jay) Mirecki, August 01, 2019             //
//                                                                            //
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

[Serializable] public class Planet {
    [XmlAttribute] public string ID;
    public string Name, System, Sector, Region, Class, Climate, Demonym, Faction, Economy;
    public Coordinate Coordinates;
    public int DayLength, YearLength, AtmosphereType, Diameter;
    public float Gravity, AvailableSurface, PopulationEconomicPosition, PopulationSocialPosition, Population, Wealth, Industrialization, Productivity, PopulationCapacity, IndustrialCapacity, UnusedCapacity, MaxCapacity;
    public string[] Neighbors;

    public Planet() {

    }
    public Planet(string name, Coordinate Coordinates, string[] neighbors) {
        this.Name = name;
        this.ID = this.Name.ToLower().Replace("'", "").Replace(' ', '_');
        this.Coordinates = Coordinates;
        this.Neighbors = neighbors;
    }
    public float Value() {
        return ResidentialValue() + IndustrialValue();
    }
    public float ResidentialValue() {
        return Wealth * Population;
    }
    public float IndustrialValue() {
        return Productivity * Industrialization;
    }
    public string ValueString() {
        float value = Value();
        string valueString;
        if (value > 1000000000000000000000000000f)
            valueString =
                value.ToString("###,###,###,###,###,,,,,,,,,.00") + " octillion";
        else if (value > 1000000000000000000000000f)
            valueString = 
                value.ToString("###,###,###,###,###,,,,,,,,.00") + " septillion";
        else if (value > 1000000000000000000000f)
            valueString = 
                value.ToString("###,###,###,###,###,,,,,,,.00") + " sextillion";
        else if (value > 1000000000000000000f)
            valueString = 
                value.ToString("###,###,###,###,###,,,,,,.00") + " quintillion";
        else if (value > 1000000000000000f)
            valueString = 
                value.ToString("###,###,###,###,###,,,,,.00") + " quadrillion";
        else if (value > 1000000000000f)
            valueString = 
                value.ToString("###,###,###,###,###,,,,.00") + " trillion";
        else if (value > 1000000000f)
            valueString = 
                value.ToString("###,###,###,###,###,,,.00") + " billion";
        else if (value > 1000000f)
            valueString = 
                value.ToString("###,###,###,###,###,,.00") + " million";
        else
            valueString = 
                value.ToString("###,###.00");
        return valueString + " credits per year";
    }
}