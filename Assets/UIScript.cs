using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;
using UnityEngine.UI;
using System;

public class UIScript : MonoBehaviour
{
    public List<Color> colors = new List<Color>();
    public List<Texture> textures = new List<Texture>();
    public GameObject dropmenu;
    public GameObject inputf;
    void Start()
    {
    }
    public void UseCursorButton()
    {
        ARCursor.useCursor = !ARCursor.useCursor;
    }

    public void RotateObject()
    {
        foreach(GameObject go in ARCursor.ObjectList){
            go.transform.Rotate(new Vector3(10f, 0f, 0f));
        }
    }
    public void OpenColorMenu()
    {
        dropmenu.SetActive(true);
    }
    public void SetColor()
    {
        foreach (GameObject go in ARCursor.ObjectList)
        {
            go.GetComponentInChildren<Renderer>().material.EnableKeyword("_Color");
            go.GetComponentInChildren<Renderer>().material.SetColor("_Color",colors[dropmenu.GetComponent<Dropdown>().value]);
        }
        dropmenu.SetActive(false);
    }
    public void OpenTextureId()
    {
        inputf.SetActive(true);
    }
    public void SetTexture()
    {
        if(Int32.Parse(inputf.GetComponent<InputField>().text) < 21 && Int32.Parse(inputf.GetComponent<InputField>().text) > 0){
            foreach (GameObject go in ARCursor.ObjectList)
            {
                go.GetComponentInChildren<Renderer>().material.EnableKeyword("_MainTex");
                go.GetComponentInChildren<Renderer>().material.SetTexture("_MainTex", textures[Int32.Parse(inputf.GetComponent<InputField>().text)]);
            }
            inputf.SetActive(false);
        }
        else
        {
            inputf.SetActive(false);
        }
    }
}