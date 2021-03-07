using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    protected int points;
    PointsAdded pointsAdded;

    LastBlockDestroyed lastBlockDestroyed;

    // Start is called before the first frame update
    virtual protected void Start()
    {
        pointsAdded = new PointsAdded();
        EventManager.AddPointsAddedInvoker(this);

        lastBlockDestroyed = new LastBlockDestroyed();
        EventManager.AddLastBlockDestroyedInvoker(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    virtual protected void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            pointsAdded.Invoke(points);
            if(GameObject.FindGameObjectsWithTag("Block").Length == 1)
            {
                lastBlockDestroyed.Invoke();
            }
            Destroy(gameObject);
        }
    }

    public void AddPointsAddedListener(UnityAction<int> listener)
    {
        pointsAdded.AddListener(listener);
    }

    public void AddLastBlockDestroyedListener(UnityAction listener)
    {
        lastBlockDestroyed.AddListener(listener);
    }
}
