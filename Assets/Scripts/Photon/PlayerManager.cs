using UnityEngine;
using Photon.Pun;

public class PlayerManager : MonoBehaviour
{
    private PhotonView photonView;

    void Start()
    {
        photonView = GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            PhotonNetwork.Instantiate("Player", Vector2.zero, Quaternion.identity);
        }
    }


}
