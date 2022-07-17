using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpriteController : MonoBehaviour
{
    [SerializeField] private float _verticalBallScalar;
    [SerializeField] private GameObject _hostBall;
    public float baseY;
    public float baseScale;

    // Start is called before the first frame update
    void Start()
    {
        baseY = transform.position.y;
        baseScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_hostBall.transform.position.x, _hostBall.transform.position.y + 0.5f, _hostBall.transform.position.z);
        transform.localScale = new Vector3(baseScale + ((transform.position.y - baseY) * _verticalBallScalar), baseScale + ((transform.position.y - baseY) * _verticalBallScalar), baseScale + ((transform.position.y - baseY) * _verticalBallScalar));
    }
}
