using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public IUseble activeUsebleObject;//тут обьект, с которым взаимодействеум
    public GameObject deathParticle;
    bool isCanMove = true;


    public int PlayerHealth = 100;

    #region MovementController
    [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
    [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.  
    [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

    private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
    const float k_GroundedRadius = .1f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;            // Whether or not the player is grounded.
    private Animator m_Anim;            // Reference to the player's animator component.
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private bool m_Jump;
    private Collider2D collider;

    public void Move(float move,  bool jump)
    {
            // The Speed animator parameter is set to the absolute value of the horizontal input.
            m_Anim.SetFloat("Speed", Mathf.Abs(move));

            // Move the character
            m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
                // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        
        // If the player should jump...
        if (m_Grounded && jump && m_Anim.GetBool("Ground"))
        {
            // Add a vertical force to the player.
            ChangeGround(false);
            m_Rigidbody2D.velocity = Vector2.zero;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }

    private void ChangeGround(bool isGround)
    {
        m_Grounded = isGround;
        m_Anim.SetBool("Ground", isGround);
        if (isGround == false)
        {
            collider.sharedMaterial.friction = 0;
        }
        else
        {
            collider.sharedMaterial.friction = 0.5f;
        }
        
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        transform.Rotate(Vector3.up, 180);
    }

    private void Awake()
    {
        
        m_GroundCheck = transform.Find("GroundCheck");// Setting up references.
        collider = GetComponent<Collider2D>();
        m_Anim = GetComponent<Animator>();
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {

        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                m_Grounded = true;
        }
        ChangeGround(m_Grounded);

        // Set the vertical animation
        m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
    }

    #endregion

    void UseObject()
    {
        if (activeUsebleObject != null) activeUsebleObject.Use();
    }

    void Update()
    {
        if (isCanMove == true)
        {

            if (Input.GetKeyUp(KeyCode.E) || Input.GetButtonDown("Use")) UseObject();//если нажата кнопка Е
            if (!m_Jump)
            {
                m_Jump = Input.GetButtonDown("Jump");// Read the jump input in Update so button presses aren't missed.
            }

            float h = Input.GetAxis("Horizontal");

            Move(h, m_Jump);
            m_Jump = false;
        }
    }
	
	public void HealthDamage(int Damage){
		PlayerHealth -= Damage;
        if (PlayerHealth <= 0 && isCanMove==true) Death();
	}

    void Death()
    {
        StartCoroutine(DeathCorutine());
    }

    void DechildHero()
    { 
        int childCounter = this.transform.childCount;
        for(int i = 0; i<childCounter;++i)
        {
            Transform O = this.transform.GetChild(0); 
            Debug.Log(i);
            O.SetParent(null);
            O.gameObject.AddComponent<Rigidbody2D>();
            O.gameObject.AddComponent<CircleCollider2D>();
           
        }
   
    }

    IEnumerator DeathCorutine()
    {
        isCanMove = false;
        DechildHero();
        Instantiate(deathParticle, this.transform.position, this.transform.rotation);
       
        yield return new WaitForSeconds(3);
        Application.LoadLevel(Application.loadedLevel);
    }
}
