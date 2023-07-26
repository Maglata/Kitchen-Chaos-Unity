using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField] private PlatesCounter platesCounter;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private Transform plateVisualPrefab;
    [SerializeField] private float plateOffsetY = 0.1f;

    private List<GameObject> plateVisualGameObjectList;

    private void Start()
    {
        platesCounter.onPlateSpawned += PlatesCounter_onPlateSpawned;
        platesCounter.onPlateRemoved += PlatesCounter_onPlateRemoved;
    }

    private void PlatesCounter_onPlateRemoved(object sender, System.EventArgs e)
    {
        GameObject plateGameObject = plateVisualGameObjectList[plateVisualGameObjectList.Count - 1];
        plateVisualGameObjectList.Remove(plateGameObject);
        Destroy(plateGameObject);
    }

    private void Awake()
    {
        plateVisualGameObjectList = new List<GameObject>();
    }

    private void PlatesCounter_onPlateSpawned(object sender, System.EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(plateVisualPrefab, counterTopPoint);
        
        plateVisualTransform.localPosition = new Vector3(0, plateOffsetY * plateVisualGameObjectList.Count, 0);

        plateVisualGameObjectList.Add(plateVisualTransform.gameObject);
    }
}
