using UnityEngine;
public class Ball : MonoBehaviour
{
    
    private Rigidbody _rB;
    private bool _isGame = false;
    private float _timer = 0f;
    [SerializeField]private GameObject _fireEffect;
    [SerializeField]private float _forwardForce = 10f, _horiForce = 5f;
    [SerializeField]private float _boarderX = 9.4f, _minusBoaderX = -9.4f;
    [SerializeField]private float _addForceBoarder = 28f, _boaderZ = 55f;
    // Start is called before the first frame update
    private void Awake()
    {
        _rB = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        if (transform.position.x <= _minusBoaderX)
        {
            currentPosition.x = _minusBoaderX;
            transform.position = currentPosition;
        }
        if(transform.position.x >= _boarderX)
        {
            currentPosition.x = _boarderX;
            transform.position = currentPosition;
        }
        if(transform.position.z >= _boaderZ)
        {
            currentPosition.z = _boaderZ;
            transform.position = currentPosition;
        }
        
        if(Input.GetKey(KeyCode.UpArrow) && transform.position.z < _addForceBoarder)
        {
            _rB.AddForce(new Vector3(0, 0, _forwardForce));
            _isGame = true;
        }
        if(Input.GetKey(KeyCode.RightArrow) && transform.position.z < _addForceBoarder)
        {
            _rB.AddForce(new Vector3(_horiForce, 0, 0));
            _isGame = true;
        }
        if(Input.GetKey(KeyCode.LeftArrow) && transform.position.z < _addForceBoarder)
        {
            _rB.AddForce(new Vector3(-_horiForce, 0, 0));
            _isGame = true;
        }
        
        if(_rB.velocity.magnitude <= 0.1f && _isGame)
        {
            _timer += Time.deltaTime;
        }

        if(_timer > 0.1f && _isGame)
        {
            Instantiate(_fireEffect, transform.position, Quaternion.identity);
            _isGame = false;
        }
    }
    
}
