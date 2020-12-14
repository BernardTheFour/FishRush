using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoletController : MonoBehaviour
{
    private enum Type
    {
        SmallPelet,
        BigPelet
    }

    [SerializeField] private Type PeletType = default;

    private int peletScore;
    [HideInInspector] public bool isTrap = false;

    // Start is called before the first frame update
    void Start()
    {
        switch (PeletType)
        {
            case Type.SmallPelet:
                peletScore = 1;
                break;
            case Type.BigPelet:
                float random = Random.Range(0f, 1f);

                if (random <= 0.3f)
                {
                    peletScore = 50;
                    isTrap = false;
                } else
                {
                    peletScore = 0;
                    isTrap = true;

                    Renderer cubeMats = GetComponent<Renderer>();
                    cubeMats.material.SetColor("_Color", Color.red);
                }
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Score += peletScore;
            gameObject.SetActive(false);

            if (isTrap == true)
            {
                ScoreManager.Life -= 1;
            }
        }
    }
}
