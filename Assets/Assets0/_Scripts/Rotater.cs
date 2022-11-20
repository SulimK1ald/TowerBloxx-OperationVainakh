using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rotater : MonoBehaviour
{
    public static Rotater instance;

    public Transform spawnPos;
    public GameObject obj;
    public GameObject part;
    public bool canToSpawn = true;
    public float angleTo;
    public float speed;
    private Transform _myTransform;
    private Quaternion _initRotation;
    private Quaternion _destanationRotation;

    public int numberOfBlocks;
    public float speedCrane;
    public Vector2 destinationCranePosition;
    public float destinationSize = 5f;
    public Vector3 destinationCameraPosition;
    public float spawnTimer;
    public Vector2 destinationCamY;
    public float upCam = 3.6f;
    public bool level2bool = false;

    public GameObject[] objs, objs1;
    public GameObject objBlack;
    public int random, random1;
    Scene currentScene;
    public int blackSquadeNum;
    public Text bonText;

    public GameObject spawnButton;
    public GameObject spawnButton2;
    public GameObject jumpButton;
    public GameObject joysButton;
    public Player playerScript;
    public bool over = false; 
    public int moveCam = 0;

    public bool antiBug = true;


    private void Awake()
    {
        currentScene = SceneManager.GetActiveScene();
        instance = this;   
        _myTransform = transform;
        _initRotation = _myTransform.rotation;
        Vector3 newUpwardVector = Quaternion.Euler(0, 0, angleTo) * _myTransform.up;
        _destanationRotation = Quaternion.LookRotation(_myTransform.forward, newUpwardVector);
        if (currentScene.name == "Map2")
        {
            bonText.text = blackSquadeNum.ToString();
        }
    }
    void SpawnBlocks()
    {
        if (currentScene.name == "Map2")
        {
            if (blackSquadeNum >= 0)
            {
                random = Random.Range(0, objs.Length);
                Instantiate(objs[random], spawnPos.transform.position, Quaternion.identity);
            }
        }
        //numberOfBlocks--;
    }
    void SpawnBlackBlock()
    {
        if (currentScene.name == "Map2")
        {
            Instantiate(objBlack, spawnPos.transform.position, Quaternion.identity);
            blackSquadeNum--;
            bonText.text = blackSquadeNum.ToString();
        }
        //numberOfBlocks--;
    }

    public void TryMoveHigher(Vector2 lastCubePosition)
    {
        float dist = Vector2.Distance(transform.position, lastCubePosition);
        if (antiBug)
        {
            if (dist < 3f && moveCam < 31)
            {
                moveCam++;
                /*transform.position = new Vector3(transform.position.x,
                lastCubePosition.y + 10);*/

                destinationCranePosition.y += 5f;
                destinationSize = destinationCranePosition.y / 2;
                destinationCamY = new Vector3(lastCubePosition.x, lastCubePosition.y + upCam, -10);
                if (currentScene.name == "Map2")
                {
                    if (blackSquadeNum < 1)
                    {
                        blackSquadeNum++;
                    }

                    if (playerScript.Keyboard == false)
                    {
                        spawnButton2.SetActive(true);
                    }
                    bonText.text = blackSquadeNum.ToString();
                }
                StartCoroutine(CamHighTime());
            }
        }
    }

    IEnumerator CamHighTime()
    {
        antiBug = !antiBug;
        yield return new WaitForSeconds(1.5f);
        antiBug = !antiBug;
        StopCoroutine(CamHighTime());
    }

    void Update()
    {
            //Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, destinationSize, Time.deltaTime); //Зум

            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position,
            new Vector3(Camera.main.transform.position.x, destinationCamY.y /*/ 2*/, -10), Time.deltaTime); //Поднимает камеру

        Debug.Log(Camera.main.orthographicSize + " / " + destinationSize);
        transform.position = Vector2.Lerp(transform.position, destinationCranePosition, speedCrane * Time.deltaTime);
        part.transform.position = Vector2.Lerp(part.transform.position, destinationCranePosition, speedCrane * Time.deltaTime);

        if (!canToSpawn)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                canToSpawn = true;
                spawnTimer = 1.30f;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            firstPlayerControlOne();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            firstPlayerControlTwo();
        }

        if (playerScript.Keyboard == true)
        {
            if (currentScene.name == "Map2")
            {
                //playerScript.Keyboard = true;
                if (over == false)
                {
                    spawnButton.SetActive(false);
                    spawnButton2.SetActive(false);
                    joysButton.SetActive(false);
                    jumpButton.SetActive(false);
                }
            }
        }
            if (playerScript.Keyboard == false)
            {
                if (currentScene.name == "Map2")
                {
                if (over == false)
                    {
                        //playerScript.Keyboard = false;
                        joysButton.SetActive(true);
                        spawnButton.SetActive(true);
                        jumpButton.SetActive(true);
                        if (blackSquadeNum > 0)
                        {
                            spawnButton2.SetActive(true);
                        }
                        else
                        {
                            spawnButton2.SetActive(false);
                        }
                    }
                    
                }
            }

        transform.rotation = Quaternion.SlerpUnclamped
        (_initRotation, _destanationRotation, Mathf.Sin(Time.time * speed));
    }

    public void firstPlayerControlOne()
    {
        if (canToSpawn && numberOfBlocks > 0)
        {
            SpawnBlocks();
            canToSpawn = false;
        }
    }
    public void firstPlayerControlTwo()
    {
        if (canToSpawn && numberOfBlocks > 0 && blackSquadeNum > 0)
        {
            SpawnBlackBlock();
            canToSpawn = false;
            spawnButton2.SetActive(false);
        }
    }
}
