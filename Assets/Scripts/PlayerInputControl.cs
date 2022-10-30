using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;

using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.SignalR.Protocol;
using Common;

public class PlayerInputControl : MonoBehaviour
{
    [SerializeField] private GameObject ExitDialog;
    [SerializeField] private Rigidbody Sphere;
    [SerializeField] private Transform pivot;
    [SerializeField] private Camera Cam;
    [SerializeField] [Range(1, 100)] private float Speed = 20;
    [SerializeField] private Terrain ter;
    [SerializeField] private Text ScoreLabel;


    public static PlayerInputControl Instance;

    private PlayerControls controls;
    private InputAction Move;
    private InputAction Exit;

    private int score = 0;
    private HubConnection hub;
    private Vector3 PivotDistance;
    private Vector3 CollideDistance;
    private Vector3 VelocityDierction = Vector3.zero;

    private bool IsGrounded
    {
        get
        {
            if (Physics.Raycast(Sphere.transform.position, Vector3.down, out RaycastHit item))
            {
                return item.transform.tag == ter.tag && ((item.point - CollideDistance).magnitude <= (Vector3.up * 0.2f).magnitude);
            }
            return false;
        }
    }

    public bool AccessDataRecieve { get; set; } = true;

    public int Score
    {
        get => score;
        set
        {
            score = value;
            Debug.Log($"Score = {score}");
            ScoreLabel.text = $"Score = {score}";
        }
    }

    private void Awake()
    {
        controls = new PlayerControls();

        Score = 0;

        if (Instance == null)
        {
            Instance = this;
        }

        Sphere.gameObject.tag = "player";

        PivotDistance = Cam.gameObject.transform.position - pivot.position;

        if (Physics.Raycast(Sphere.transform.position, Vector3.down, out RaycastHit item))
        {
            if (item.transform.tag == ter.tag)
            {
                CollideDistance = item.point - Sphere.gameObject.transform.position + Vector3.down * 0.1f;
            }
        }

    }

    private void OnEnable()
    {
        Move = controls.MoveMap.Move;
        Exit = controls.MoveMap.Exit;
        Move.Enable();
        Exit.Enable();

        Exit.performed += DoExitEvent;
}

    private void OnDisable()
    {
        Move.Disable();
        Exit.Disable();
    }

    private void OnCollisionEnter(Collision collision)
    {
    }

    private void Start()
    {
        StartCoroutine(setVelocity());
        StartCoroutine(sendDataToAPI());
    }

    private void FixedUpdate()
    {
        var VelocityDierction2D = Move.ReadValue<Vector2>();
        VelocityDierction = new Vector3(VelocityDierction2D.x, 0, VelocityDierction2D.y);

        Cam.gameObject.transform.position = pivot.position + PivotDistance;
    }

    private IEnumerator sendDataToAPI()
    {
        hub = new HubConnectionBuilder()
            .WithUrl("http://26.252.50.103:59954/rjuHub")
            .Build();
        var startTask = hub.StartAsync();


        while (!startTask.IsCompleted)
        {
            yield return null;
        }

        while (true)
        {
            if (AccessDataRecieve)
            {
                var sendTask = hub.InvokeAsync("SendCoords", new Coords2() { X = Sphere.transform.position.x, Y = Sphere.transform.position.z });
                while (!sendTask.IsCompleted)
                {
                    yield return null;
                }
            }

            yield return null;
        }
    }

    private IEnumerator setVelocity()
    {
        while (true)
        {
            Sphere.AddForce(VelocityDierction * Speed, ForceMode.Acceleration);
            if (Sphere.velocity.magnitude >= Speed)
            {
                Sphere.velocity = Sphere.velocity.normalized * Speed;
            }
            if (VelocityDierction == Vector3.zero)
            {
                Sphere.AddForce(-Sphere.velocity * Speed, ForceMode.Acceleration);
            }
            yield return new WaitForFixedUpdate();
        }
    }
  
    public void DoJump(InputAction.CallbackContext ctxt)
    {
        if (ctxt.performed)
        {
            Debug.Log(ctxt.control.displayName);
            Sphere.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }

    }
    public void DoExitEvent(InputAction.CallbackContext ctxt)
    {
        Debug.LogWarning("Im here BITCHES!");
        ExitDialog.SetActive(!ExitDialog.activeSelf);
    }

    public void AnsverYES()
    {
        LoadScene();
    }

    public void AnsverCancel()
    {
        ExitDialog.SetActive(false);
    }


    private void LoadScene()
    {
        StartCoroutine(LoadingScreen.Instance.LoadScene(1));
    }


}
