using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using UnityEngine.UIElements;

public class ScaleConverter : JsonConverter<Vector3>
{
    public override Vector3 ReadJson(JsonReader reader, Type objectType, Vector3 existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        JObject jObj4 = JObject.Load(reader);
        Vector3 s = Vector3.zero;

        s.x = (float)jObj4["X2"];
        s.y = (float)jObj4["Y2"];
        s.z = (float)jObj4["Z2"];

        return s;
    }

    public override void WriteJson(JsonWriter writer, Vector3 value, JsonSerializer serializer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("X2");
        writer.WriteValue(value.x);
        writer.WritePropertyName("Y2");
        writer.WriteValue(value.y);
        writer.WritePropertyName("Z2");
        writer.WriteValue(value.z);
        writer.WriteEndObject();
    }
}
public class ColorConverter : JsonConverter<Color>
{

    public override Color ReadJson(JsonReader reader, Type objectType, Color existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        JObject jObj3 = JObject.Load(reader);
        Color c = Color.clear;

        c.r = (float)jObj3["R"];
        c.g = (float)jObj3["G"];
        c.b = (float)jObj3["B"];

        return c;
    }

    public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("R");
        writer.WriteValue(value.r);
        writer.WritePropertyName("G");
        writer.WriteValue(value.g);
        writer.WritePropertyName("B");
        writer.WriteValue(value.b);
        writer.WriteEndObject();
    }
}
public class QuaternionConverter : JsonConverter<Quaternion>
{
    public override Quaternion ReadJson(JsonReader reader, Type objectType, Quaternion existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        JObject jObj2 = JObject.Load(reader);
        Quaternion q = Quaternion.identity;

        q.x = (float)jObj2["X"];
        q.y = (float)jObj2["Y"];
        q.z = (float)jObj2["Z"];
        q.w = (float)jObj2["W"];

        return q;
    }

    public override void WriteJson(JsonWriter writer, Quaternion value, JsonSerializer serializer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("X");
        writer.WriteValue(value.x);
        writer.WritePropertyName("Y");
        writer.WriteValue(value.y);
        writer.WritePropertyName("Z");
        writer.WriteValue(value.z);
        writer.WritePropertyName("W");
        writer.WriteValue(value.w);
        writer.WriteEndObject();
    }
}
public class Vector3Converter : JsonConverter<Vector3>
{
    // {
    //     "POSITION" : {
    //         "X" : ...,
    //         "Y" : ...,
    //         "Z" : ...

    //     }

    // }
    public override Vector3 ReadJson(JsonReader reader, Type objectType, Vector3 existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        JObject jObj = JObject.Load(reader);

        Vector3 v = Vector3.zero;

        v.x = (float)jObj["X"];
        v.y = (float)jObj["Y"];
        v.z = (float)jObj["Z"];

        return v;
    }

    public override void WriteJson(JsonWriter writer, Vector3 value, JsonSerializer serializer)
    {
        writer.WriteStartObject();
        writer.WritePropertyName("X");
        writer.WriteValue(value.x);
        writer.WritePropertyName("Y");
        writer.WriteValue(value.y);
        writer.WritePropertyName("Z");
        writer.WriteValue(value.z);
        writer.WriteEndObject();
    }
}