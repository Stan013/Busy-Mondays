using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMovement : MonoBehaviour
{
    [SerializeField] Transform[] PathArrival;
    [SerializeField] Transform[] PathDepart;
    [SerializeField] private float moveSpeed;
    [SerializeField] private TimeManager timeManager;
    private int pointsIndex;
    private float breakTime = 6.0f;
    private float smokeTime = 3.0f;
    private float toiletTime = 3.0f;
    private float coffeeTime = 1.0f;
    private bool timeEnded = false;
    public Transform[] currentPath;
    private static string pathRoute = "Arrival";

    private void Start()
    {
        if (currentPath.Length == 0 && EventManager.newNPCPath == true)
        {
            currentPath = this.PathArrival;
        }
    }

    private void Update()
    {
        if (currentPath != null)
        {
            if (pointsIndex <= currentPath.Length - 1)
            {

                transform.position = Vector2.MoveTowards(transform.position, currentPath[pointsIndex].transform.position, moveSpeed * Time.deltaTime);
                if (Mathf.Round(transform.position.x) == Mathf.Round(currentPath[pointsIndex].transform.position.x) && Mathf.Round(transform.position.y) == Mathf.Round(currentPath[pointsIndex].transform.position.y))
                {
                    if (currentPath[pointsIndex].name == "PointStairs" && pathRoute == "Arrival")
                    {
                        gameObject.SetActive(false);
                    }
                    if (pathRoute == "Depart")
                    {
                        if (currentPath[pointsIndex].name == "Start1" || currentPath[pointsIndex].name == "Start2" || currentPath[pointsIndex].name == "Start3" || currentPath[pointsIndex].name == "Start4")
                        {
                            gameObject.SetActive(false);
                        }
                        else
                        {
                            pointsIndex += 1;
                            timeEnded = false;
                        }
                    }
                    else if (currentPath[pointsIndex].name == "PointSmoke" && timeEnded == false)
                    {
                        smokeTime -= Time.deltaTime;
                        if (smokeTime <= 0.0f)
                        {
                            timeEnded = true;
                            smokeTime = 3.0f;
                        }
                        else
                        {
                            timeEnded = false;
                        }
                    }
                    else if (currentPath[pointsIndex].name == "PointBreak" && timeEnded == false)
                    {
                        breakTime -= Time.deltaTime;
                        if (breakTime <= 0.0f)
                        {
                            timeEnded = true;
                            breakTime = 10.0f;
                        }
                        else
                        {
                            timeEnded = false;
                        }
                    }
                    else if (currentPath[pointsIndex].name == "PointToilet" && timeEnded == false)
                    {
                        toiletTime -= Time.deltaTime;
                        if (toiletTime <= 0.0f)
                        {
                            timeEnded = true;
                            toiletTime = 3.0f;
                        }
                        else
                        {
                            timeEnded = false;
                        }
                    }
                    else if (currentPath[pointsIndex].name == "PointCoffee" && timeEnded == false)
                    {
                        coffeeTime -= Time.deltaTime;
                        if (coffeeTime <= 0.0f)
                        {
                            timeEnded = true;
                            coffeeTime = 1.0f;
                        }
                        else
                        {
                            timeEnded = false;
                        }
                    }
                    else
                    {
                        pointsIndex += 1;
                        timeEnded = false;
                    }
                }
            }
        }
    }

    public void SetPath(string pathName)
    {
        switch (pathName)
        {
            case "Depart":
                pathRoute = pathName;
                pointsIndex = 0;
                currentPath = this.PathDepart;
                break;
        }
    }
}