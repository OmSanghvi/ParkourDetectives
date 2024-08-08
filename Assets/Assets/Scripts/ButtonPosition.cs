using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ButtonPosition : MonoBehaviour
{
    
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject button1;
    [SerializeField] private GameObject button2;
    [SerializeField] private GameObject button3;
    
    private int randomNumber;

    private void Awake()
    {
        randomNumber = Random.Range(1, 5);
        SetRandomButtonPosition();
    }

    private void SetRandomButtonPosition()
    {
        
        
        if (randomNumber == 1)
        {
            button.transform.position += new Vector3(0f,-138,0f);//Become button 3
            button1.transform.position += new Vector3(0f,-48,0f);//Become button 2
            button2.transform.position += new Vector3(0f,92,0f);//Become button
            button3.transform.position += new Vector3(0f,94,0f);//Become button 1
        }
        else if (randomNumber == 2)
        {
            button.transform.position += new Vector3(0f,-92,0f);//Become button 2
            button1.transform.position += new Vector3(0f,-94,0f);//Become button 3
            button2.transform.position += new Vector3(0f,48,0f);//Become button 1
            button3.transform.position += new Vector3(0f,138,0f);//Become button
        }
        else if (randomNumber == 3)
        {
            button.transform.position += new Vector3(0f,0,0f);//Become button
            button1.transform.position += new Vector3(0f,-94,0f);//Become button 3
            button2.transform.position += new Vector3(0f,48,0f);//Become button 1
            button3.transform.position += new Vector3(0f,46,0f);//Become button 2
        }
        else if(randomNumber == 4)
        {
            button.transform.position += new Vector3(0f,-44,0f);//Become button 1
            button1.transform.position += new Vector3(0f,44,0f);//Become button
            button2.transform.position += new Vector3(0f,-46,0f);//Become button 3
            button3.transform.position += new Vector3(0f,46,0f);//Become button 2
        }
    }

    public void SetButtonBack()
    {
        if (randomNumber == 1)
        {
            button.transform.position -= new Vector3(0f,-138,0f);//Become button 3
            button1.transform.position -= new Vector3(0f,-48,0f);//Become button 2
            button2.transform.position -= new Vector3(0f,92,0f);//Become button
            button3.transform.position -= new Vector3(0f,94,0f);//Become button 1
        }
        else if (randomNumber == 2)
        {
            button.transform.position -= new Vector3(0f,-92,0f);//Become button 2
            button1.transform.position -= new Vector3(0f,-94,0f);//Become button 3
            button2.transform.position -= new Vector3(0f,48,0f);//Become button 1
            button3.transform.position -= new Vector3(0f,138,0f);//Become button
        }
        else if (randomNumber == 3)
        {
            button.transform.position -= new Vector3(0f,0,0f);//Become button
            button1.transform.position -= new Vector3(0f,-94,0f);//Become button 3
            button2.transform.position -= new Vector3(0f,48,0f);//Become button 1
            button3.transform.position -= new Vector3(0f,46,0f);//Become button 2
        }
        else if(randomNumber == 4)
        {
            button.transform.position -= new Vector3(0f,-44,0f);//Become button 1
            button1.transform.position -= new Vector3(0f,44,0f);//Become button
            button2.transform.position -= new Vector3(0f,-46,0f);//Become button 3
            button3.transform.position -= new Vector3(0f,46,0f);//Become button 2
        }
    }

}
