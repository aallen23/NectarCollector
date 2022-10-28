using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallURLs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenApis()
    {
        Application.OpenURL("https://www.projectapism.org/");
    }

    public void OpenPollinator()
    {
        Application.OpenURL("https://www.pollinator.org/");
    }

    public void OpenConservancy()
    {
        Application.OpenURL("https://thebeeconservancy.org/");
    }

    public void OpenBeesForDevelopment()
    {
        Application.OpenURL("https://www.beesfordevelopment.org/");
    }

}
