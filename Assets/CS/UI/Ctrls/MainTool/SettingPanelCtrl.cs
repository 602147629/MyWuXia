﻿using UnityEngine;
using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;
using System.Collections.Generic;
using DG;
using DG.Tweening;

namespace Game {
	public class SettingPanelCtrl : WindowCore<SettingPanelCtrl, JArray> {
		Image bg;
		Button block;
		Button closeBtn;
		Button bGMOpenBtn;
		Button bGMCloseBtn;
		Button soundOpenBtn;
		Button soundCloseBtn;
		Button loadRecordListBtn;
		Button backToMainMenuBtn;

		bool showBackMainTool;
		protected override void Init () {
			bg = GetChildImage("Bg");
			block = GetChildButton("Block");
			EventTriggerListener.Get(block.gameObject).onClick = onClick;
			closeBtn = GetChildButton("CloseBtn");
			EventTriggerListener.Get(closeBtn.gameObject).onClick = onClick;

			bGMOpenBtn = GetChildButton("BGMOpenBtn");
			EventTriggerListener.Get(bGMOpenBtn.gameObject).onClick = onClick;
			bGMCloseBtn = GetChildButton("BGMCloseBtn");
			EventTriggerListener.Get(bGMCloseBtn.gameObject).onClick = onClick;
			soundOpenBtn = GetChildButton("SoundOpenBtn");
			EventTriggerListener.Get(soundOpenBtn.gameObject).onClick = onClick;
			soundCloseBtn = GetChildButton("SoundCloseBtn");
			EventTriggerListener.Get(soundCloseBtn.gameObject).onClick = onClick;
			loadRecordListBtn = GetChildButton("LoadRecordListBtn");
			EventTriggerListener.Get(loadRecordListBtn.gameObject).onClick = onClick;
			backToMainMenuBtn = GetChildButton("BackToMainMenuBtn");
			EventTriggerListener.Get(backToMainMenuBtn.gameObject).onClick = onClick;
		}

		void onClick(GameObject e) {
			if (!e.GetComponent<Button>().enabled) {
				return;
			}
			switch (e.name) {
			case "Block":
			case "CloseBtn":
				Back();
				break;
			case "BGMOpenBtn":
				SoundManager.GetInstance().EnableBGM();
//				Messenger.Broadcast(NotifyTypes.PlayBgm);
				refreshBGMAndSoundView();
				break;
			case "BGMCloseBtn":
				SoundManager.GetInstance().DisableBGM();
				refreshBGMAndSoundView();
				break;
			case "SoundOpenBtn":
				SoundManager.GetInstance().EnableSound();
				refreshBGMAndSoundView();
				break;
			case "SoundCloseBtn":
				SoundManager.GetInstance().DisableSound();
				refreshBGMAndSoundView();
				break;
			case "LoadRecordListBtn":
				Messenger.Broadcast(NotifyTypes.GetRecordListData);
				break;
			case "BackToMainMenuBtn":
				Messenger.Broadcast(NotifyTypes.ShowMainPanel);
				break;
			default:
				break;
			}
		}

		public void UpdateData(bool flag = true) {
			showBackMainTool = flag;
		}

		void refreshBGMAndSoundView() {
			if (string.IsNullOrEmpty(PlayerPrefs.GetString("DisableBGM"))) {
				bGMOpenBtn.gameObject.SetActive(false);
				bGMCloseBtn.gameObject.SetActive(true);
			}
			else {
				bGMOpenBtn.gameObject.SetActive(true);
				bGMCloseBtn.gameObject.SetActive(false);
			}
			if (string.IsNullOrEmpty(PlayerPrefs.GetString("DisableSound"))) {
				soundOpenBtn.gameObject.SetActive(false);
				soundCloseBtn.gameObject.SetActive(true);
			}
			else {
				soundOpenBtn.gameObject.SetActive(true);
				soundCloseBtn.gameObject.SetActive(false);
			}
		}

		public override void RefreshView () {
			refreshBGMAndSoundView();
			MakeButtonEnable(loadRecordListBtn, showBackMainTool);
			MakeButtonEnable(backToMainMenuBtn, showBackMainTool);
		}

		public void Pop() {
			bg.transform.DOScale(0, 0);
			bg.transform.DOScale(1, 0.3f).SetEase(Ease.OutBack);
		}

		public void Back() {
			bg.transform.DOScale(0, 0.3f).SetEase(Ease.InBack).OnComplete(() => {
				Close();
			});
		}

		public static void Show(bool flag = true) {
			if (Ctrl == null) {
				InstantiateView("Prefabs/UI/MainTool/SettingPanelView", "SettingPanelCtrl", 0, 0, UIModel.FrameCanvas.transform);
				Ctrl.Pop();
			}
			Ctrl.UpdateData(flag);
			Ctrl.RefreshView();
		}

		public static void Hide() {
			if (Ctrl != null) {
				Ctrl.Close();
			}
		}
	}
}
