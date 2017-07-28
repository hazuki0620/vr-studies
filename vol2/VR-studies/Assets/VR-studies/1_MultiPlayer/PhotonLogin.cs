﻿using UnityEngine;
using System.Collections;

namespace VRStudies { namespace MultiPlayer {

public class PhotonLogin : MonoBehaviour {

	//------------------------------------------------------------------------------------------------------------------------------//
	void Start() {

		// Photonロビーに接続する - 引数の文字列で同じバージョンへアクセス
		Debug.Log("PhotonManager: ロビーに接続します");
		PhotonNetwork.ConnectUsingSettings( "v1.0" );
		PhotonNetwork.sendRate = 30;
		PhotonNetwork.sendRateOnSerialize = 30;
	}

	//------------------------------------------------------------------------------------------------------------------------------//
	void OnJoinedLobby() {

		Debug.Log("PhotonManager: ロビー入室成功");

		// オプションを設定
		RoomOptions roomOptions = new RoomOptions() {
			MaxPlayers = 20,
			IsOpen = true,
			IsVisible = true,
		};

		// ルームの作成
		PhotonNetwork.JoinOrCreateRoom("VR-Room", roomOptions, null);
	}

	//------------------------------------------------------------------------------------------------------------------------------//
	void OnJoinedRoom() {

		Room room = PhotonNetwork.room;
		PhotonPlayer player = PhotonNetwork.player;
		Debug.Log("PhotonManager: ルーム入室に成功 部屋名: " + room.Name + " プレイヤーID:" + player.ID);
		Debug.Log("PhotonManager: 部屋情報: " + room + " ルームマスター: " + player.IsMasterClient);
	}

	void OnPhotonJoinRoomFailed() {
		Debug.Log("PhotonManager: ルーム入室に失敗");
	}

	void OnPhotonCreateRoomFailed() {
		Debug.Log("PhotonManager: ルーム作成に失敗");
	}
}

}}