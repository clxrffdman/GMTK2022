using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperController : MonoBehaviour
{
    [SerializeField] private Transform _leftFlipper;
    [SerializeField] private Transform _rightFlipper;
    [SerializeField] private HingeJoint _leftJoint;
    [SerializeField] private HingeJoint _rightJoint;
    [SerializeField] private HingeJoint _rightJoint2;
    private JointSpring leftSpring;
    private JointSpring rightSpring;
    public float angle;
    public float springAmt;
    public float dampValue;

    // Start is called before the first frame update
    void Start()
    {
        leftSpring = new JointSpring();
        rightSpring = new JointSpring();
        leftSpring.spring = springAmt;
        leftSpring.damper = dampValue;
        rightSpring.spring = springAmt;
        rightSpring.damper = dampValue;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftSpring.targetPosition = -angle;
            //_leftFlipper.localEulerAngles += new Vector3(0, 0, 2f);
        }
        else
        {
            leftSpring.targetPosition = 0;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rightSpring.targetPosition = angle;
            
            //_leftFlipper.localEulerAngles += new Vector3(0, 0, 2f);
        }
        else
        {
            rightSpring.targetPosition = 0;
        }

        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            AudioManager.Instance.PlayBoardSFX(1);
        }

        _leftJoint.spring = leftSpring;
        _rightJoint.spring = rightSpring;
        _rightJoint2.spring = rightSpring;
    }
}
