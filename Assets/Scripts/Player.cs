using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DaveAI.Player
{
    public class Player : MonoBehaviour
    {
        
        private Rigidbody _rb;

        
        [SerializeField, Header("Player Settings")]
        private float _speed;
        
        [SerializeField]
        private Vector3 _velocity;
        
        [SerializeField]
        private GameObject _playerModel;

        private Animator _animator;
        
       

        // Start is called before the first frame update
        void Start()
        {
            _rb = GetComponent<Rigidbody>();

            _rb.freezeRotation = true;           

            _animator = _playerModel.GetComponent<Animator>();

            if(_rb == null)
            {
                Debug.LogError("RigidBody is NULL");
            }

            if(_playerModel == null)
            {
                Debug.LogError("PlayerModel is NULL.");
            }

            if(_animator == null)
            {
                Debug.LogError("Animator is NULL.");
            }
           
            
        }

        // Update is called once per frame
        void Update()
        {
            Movement();         
          
            Animation(_velocity);           
           
        }

        void Movement()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontal, 0, vertical);

            _velocity = direction * _speed;

            _rb.velocity = _velocity;

            if(_velocity != null)
            {
                Rotation(_velocity);
            }

        }

    

        void Rotation(Vector3 velocity)
        {
            if (_velocity.x > 0)
                _playerModel.transform.localRotation = Quaternion.Euler(0, 90, 0);

            if (_velocity.x < 0)
                _playerModel.transform.localRotation = Quaternion.Euler(0, -90, 0);

            if (_velocity.z > 0)
                _playerModel.transform.localRotation = Quaternion.Euler(0, 0, 0);

            if (_velocity.z < 0)
                _playerModel.transform.localRotation = Quaternion.Euler(0, 180, 0);

            if (_velocity.x > 0 && _velocity.z > 0)
                _playerModel.transform.localRotation = Quaternion.Euler(0, 45, 0);

            if (_velocity.x < 0 && _velocity.z > 0)
                _playerModel.transform.localRotation = Quaternion.Euler(0, -45, 0);

            if (_velocity.x < 0 && _velocity.z < 0)
                _playerModel.transform.localRotation = Quaternion.Euler(0, -135, 0);

            if (_velocity.x > 0 && _velocity.z < 0)
                _playerModel.transform.localRotation = Quaternion.Euler(0, 135, 0);

        }


        void Animation(Vector3 velocity)
        {
            if(velocity != Vector3.zero)
            {
                _animator.Play("Armature|walk_cycle");
            }
            else
            {
                _animator.Play("Armature|idle");
            }
        }

       
    }

}