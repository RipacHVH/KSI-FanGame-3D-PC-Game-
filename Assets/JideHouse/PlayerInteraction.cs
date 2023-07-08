using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    AudioSource audioData;
    private LetterSystem _letterSystem;
    private bool SpicyON = false;
    public GameObject[] InteractText;
    private void Start()
    {
        audioData = GetComponent<AudioSource>();
        foreach (var item in InteractText)
        {
            item.SetActive(false);
        }
    }
    void Update()
    {
        InteractRaycast();
    }
    void InteractRaycast()
    {
        Vector3 playerPosition = transform.position;
        Vector3 fowardDirection = transform.forward;
        Ray interactionRay = new Ray(playerPosition, fowardDirection);
        RaycastHit interactionRayHit;
        float interactionRayLength = 2f;
        Vector3 interactionRayEndpoint = fowardDirection * interactionRayLength;
        Debug.DrawLine(playerPosition, interactionRayEndpoint);
        bool hitFound = Physics.Raycast(interactionRay, out interactionRayHit, interactionRayLength);
        if (hitFound)
        {
            GameObject hitGameobject = interactionRayHit.transform.gameObject;
            _letterSystem = hitGameobject.GetComponent<LetterSystem>();
            #region Sides
            if (hitGameobject.layer == 3)
            {
                InteractText[0].SetActive(true);
                if(Input.GetKey(KeyCode.E))
                {
                    audioData.Play(0);
                    SpicyON = true;
                    Destroy(hitGameobject);
                    InteractText[0].SetActive(false);
                }
            }
            #endregion
            #region Letter
            if (hitGameobject.layer == 6 && InteractText[1] !=null)
            {
                InteractText[1].SetActive(true);
                if (Input.GetKey(KeyCode.E))
                {
                    Destroy(InteractText[1]);
                    _letterSystem.ShowNote();
                    //Destroy(hitGameobject);
                }
            }
            #endregion
            #region Door
            if (hitGameobject.layer == 7)
            {
                if(!SpicyON)
                    //Closed Text
                InteractText[2].SetActive(true);
                else
                {
                    InteractText[3].SetActive(true);
                    if (Input.GetKey(KeyCode.E))
                    {
                        //Go to the next Scene
                        SceneManager.LoadScene(sceneBuildIndex:1);
                        InteractText[3].SetActive(false);
                    }
                }

            }
            #endregion

        }
        else
        {
            foreach (var item in InteractText)
            {
                if(item!=null)
                item.SetActive(false);
            }
        }
    }
    void InteractRaycastAlternative()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 5.0f))
        {
            Debug.Log(hit.transform.gameObject.name);
        }
        else
        {
            Debug.Log("-");
        }
    }
}
