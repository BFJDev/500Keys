using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{
    Vector2 dir = Vector2.up;
    public GameObject loadingSections;
    public List<GameObject> sections;
    float timer;
    public Vector3 position;
    //GameManager gm;
    
    // Start is called before the first frame update
    void Start()
    {
        
        sections = new List<GameObject>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        
        int seconds = (int)timer%60;
        
        position = new Vector3(125, -45 + (3*seconds),0);
        
        if(timer == 90) {
            //Invoke("GameOver");
        }
        
        if(seconds < 90) {
            sections.Add(Instantiate(loadingSections, position, Quaternion.identity));
        }
        
        
    }
    
    void GameOver() 
    {
        //GameOver Code
    }       
}
