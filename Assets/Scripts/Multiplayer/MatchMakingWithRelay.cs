using System.Threading.Tasks;
using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// basic matchmaking example working
/// need a networkmanager script in the scene with unity transport set
/// join and host buttons
/// text for join code
/// input field to join host
/// </summary>
public class MatchMakingWithRelay : NetworkBehaviour
{
    [SerializeField] private TMP_Text _joinCodeText;
    [SerializeField] private TMP_InputField _joinInput;
    [SerializeField] private GameObject _createButtons;
    [SerializeField] private GameObject _JoinButtons;
    [SerializeField] private GameObject _startGameButton;
    [SerializeField] private GameObject _joincodeSection;

    private UnityTransport _transport;
    private const int MaxPlayers = 5;



    private async void Awake()
    {
        _transport = FindObjectOfType<UnityTransport>();

        _createButtons.SetActive(false);

        await Authenticate();

        _createButtons.SetActive(true);
        _startGameButton.SetActive(false);
        _joincodeSection.gameObject.SetActive(false);
    }

    private static async Task Authenticate()
    {
        await UnityServices.InitializeAsync();
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    public async void CreateGame()
    {
        _createButtons.SetActive(false);
        _joincodeSection.gameObject.SetActive(true);

        Allocation a = await RelayService.Instance.CreateAllocationAsync(MaxPlayers, "europe-west4");
        _joinCodeText.text = await RelayService.Instance.GetJoinCodeAsync(a.AllocationId);

        _transport.SetHostRelayData(a.RelayServer.IpV4, (ushort)a.RelayServer.Port, a.AllocationIdBytes, a.Key, a.ConnectionData);

        NetworkManager.Singleton.StartHost();
        _startGameButton.SetActive(true);
        _JoinButtons.SetActive(false);

    }

    public async void JoinGame()
    {
        _createButtons.SetActive(false);


        JoinAllocation a = await RelayService.Instance.JoinAllocationAsync(_joinInput.text);

        _transport.SetClientRelayData(a.RelayServer.IpV4, (ushort)a.RelayServer.Port, a.AllocationIdBytes, a.Key, a.ConnectionData, a.HostConnectionData);

        NetworkManager.Singleton.StartClient();
    }

    public void StartGame()
    {
        //SceneManager.LoadScene("GameScene");
        NetworkManager.Singleton.SceneManager.LoadScene("GameScene", UnityEngine.SceneManagement.LoadSceneMode.Single);

    }
}
