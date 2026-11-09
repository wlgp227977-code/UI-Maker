using UnityEngine;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using TMPro;


public class PrefabObjectData
{
    public string prefabId;
    public Vector3 position;
    public Vector3 scale;
    public Quaternion rotation;
    public Color color;
    public override string ToString()
    {
        return $"{prefabId} / {position} / {scale} / {rotation} / {color}";
    }

}

public class PrefabObject : MonoBehaviour
{
    public GameObject[] prefabs;

    public List<GameObject> objects = new List<GameObject>();
    private JsonSerializerSettings jsonSettings;

    private void Awake()
    {
        jsonSettings = new JsonSerializerSettings();
        jsonSettings.Formatting = Formatting.Indented;
        jsonSettings.Converters.Add(new Vector3Converter());
        jsonSettings.Converters.Add(new ScaleConverter());
        jsonSettings.Converters.Add(new QuaternionConverter());
        jsonSettings.Converters.Add(new ColorConverter());
    }

    public void Create()
    {
        int randomIndex = UnityEngine.Random.Range(0, prefabs.Length);
        Vector3 randomPosition = UnityEngine.Random.insideUnitSphere * 10f;
        Quaternion randomRotation = UnityEngine.Random.rotation;
        Vector3 randomScale = Vector3.one * UnityEngine.Random.Range(0.5f, 2f);
        Color randomColor = UnityEngine.Random.ColorHSV(
            0f, 1f,
            1f, 1f,
            1f, 1f
        );

        GameObject newGo = Instantiate(prefabs[randomIndex]);
        newGo.transform.position = randomPosition;
        newGo.transform.rotation = randomRotation;
        newGo.transform.localScale = randomScale;
        newGo.GetComponent<Renderer>().material.color = randomColor;

        objects.Add(newGo);
    }

    public void Clear()
    {
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }

        objects.Clear();
    }
    public void Save()
    {
        List<PrefabObjectData> saveData = new List<PrefabObjectData>();

        foreach (GameObject obj in objects)
        {
            PrefabObjectData data = new PrefabObjectData
            {
                prefabId = obj.name,
                position = obj.transform.position,
                scale = obj.transform.localScale,
                rotation = obj.transform.rotation,
                color = obj.GetComponent<Renderer>().material.color
            };
            saveData.Add(data);
        }

        var path = Path.Combine(Application.persistentDataPath, "PrefabData.json");

        string json = JsonConvert.SerializeObject(saveData, Formatting.Indented, jsonSettings);
        File.WriteAllText(path, json);
    }
    public void Load()
    {
        Clear();

        var path = Path.Combine(Application.persistentDataPath, "PrefabData.json");
        string json = File.ReadAllText(path);

        List<PrefabObjectData> loadData = JsonConvert.DeserializeObject<List<PrefabObjectData>>(json, jsonSettings);

        foreach (PrefabObjectData data in loadData)
        {
            GameObject prefab = null;
            foreach (GameObject p in prefabs)
            {
                if (data.prefabId.Contains(p.name))
                {
                    prefab = p;
                    break;
                }
            }
            GameObject newGo = Instantiate(prefab);
            newGo.transform.position = data.position;
            newGo.transform.localScale = data.scale;
            newGo.transform.rotation = data.rotation;
            newGo.GetComponent<Renderer>().material.color = data.color;

            objects.Add(newGo);
        }
    }
}
