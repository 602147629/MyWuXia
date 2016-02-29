﻿using UnityEngine;
using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;
using DG;
using DG.Tweening;
using System.Collections.Generic;

namespace Game {
	public class CityScenePanelCtrl : WindowCore<CityScenePanelCtrl, JArray> {
		CanvasGroup bg;
		Text sceneNameText;
		Button enterAreaBtn;
		Button enterWorkshopBtn;
		Button enterStoreBtn;
		Button enterHospitalBtn;
		Button enterInnBtn;
		Button enterYamenBtn;
		Button enterWinshopBtn;
		Button enterForbiddenAreaBtn;
		GridLayoutGroup npcsGrid;
		Dictionary<string, NpcContainer> npcContainersMapping;

		SceneData sceneData;
		List<TaskData> taskList;
		Object prefabObj;

		protected override void Init () {
			bg = GetComponent<CanvasGroup>();
			bg.DOFade(0, 0);
			sceneNameText = GetChildText("sceneNameText");
			enterAreaBtn = GetChildButton("enterAreaBtn");
			EventTriggerListener.Get(enterAreaBtn.gameObject).onClick += onClick;
			enterWorkshopBtn = GetChildButton("enterWorkshopBtn");
			enterStoreBtn = GetChildButton("enterStoreBtn");
			enterHospitalBtn = GetChildButton("enterHospitalBtn");
			enterInnBtn = GetChildButton("enterInnBtn");
			enterYamenBtn = GetChildButton("enterYamenBtn");
			enterWinshopBtn = GetChildButton("enterWinshopBtn");
			enterForbiddenAreaBtn = GetChildButton("enterForbiddenAreaBtn");
			npcsGrid = GetChildGridLayoutGroup("npcsGrid");
			npcContainersMapping = new Dictionary<string, NpcContainer>();
		}

		void onClick(GameObject e) {
			if (!e.GetComponent<Button>().enabled) {
				return;
			}
			switch (e.name) {
			case "enterAreaBtn":
				Hide();
				Messenger.Broadcast(NotifyTypes.FromCitySceneBackToArea);
				break;
			default:
				break;
			}
		}

		public void UpdateData(SceneData data) {
			sceneData = data;
		}

		public override void RefreshView () {
			sceneNameText.text = sceneData.Name;
			foreach (NpcContainer container in npcContainersMapping.Values) {
				Destroy(container.gameObject);
			}
			npcContainersMapping.Clear();
			for (int i = 0; i < sceneData.Npcs.Count; i++) {
				createNpcContainer(sceneData.Npcs[i]);
			}
		}

		void createNpcContainer(NpcData npc) {
			if (prefabObj == null) {
				prefabObj = Statics.GetPrefab("Prefabs/UI/GridItems/NpcItemContainer");
			}
			GameObject itemPrefab = Statics.GetPrefabClone(prefabObj);
			itemPrefab.name = npc.Id;
			MakeToParent(npcsGrid.transform, itemPrefab.transform);
			NpcContainer container = itemPrefab.GetComponent<NpcContainer>();
			container.SetNpcData(npc);
			npcContainersMapping.Add(npc.Id, container);
		}

		/// <summary>
		/// 添加任务到Npc身上
		/// </summary>
		/// <param name="list">List.</param>
		public void UpdateTaskToNpcData(List<TaskData> list) {
			taskList = list;
		}

		/// <summary>
		/// 刷新任务
		/// </summary>
		public void RefreshTaskToNpc() {
			TaskData taskData;
			for (int i = 0; i < taskList.Count; i++) {
				taskData = taskList[i];
				if (!npcContainersMapping.ContainsKey(taskData.BelongToNpcId)) {
					createNpcContainer(JsonManager.GetInstance().GetMapping<NpcData>("Npcs", taskData.BelongToNpcId));
				}
				npcContainersMapping[taskData.BelongToNpcId].UpdateTaskData(taskData.Id, taskData.State);
				npcContainersMapping[taskData.BelongToNpcId].RefreshTaskView();
			}
			PlayBgm();
		}

		public void FadeIn() {
			bg.DOFade(1, 0.5f).SetDelay(0.3f);
		}

		public void FadeOut() {
			bg.DOFade(0, 0.5f).OnComplete(() => {
				Close();
			});
		}

		/// <summary>
		/// 播放背景音乐
		/// </summary>
		public void PlayBgm() {
			SoundManager.GetInstance().PlayBGM(sceneData.BgmSoundId);
		}

		public static void Show(SceneData data) {
			if (Ctrl == null) {
				InstantiateView("Prefabs/UI/MainTool/CityScenePanelView", "CityScenePanelCtrl");
				Ctrl.FadeIn();
			}
			Ctrl.UpdateData(data);
			Ctrl.RefreshView();
		}

		public static void ShowTask(List<TaskData> list) {
			if (Ctrl != null) {
				Ctrl.UpdateTaskToNpcData(list);
				Ctrl.RefreshTaskToNpc();
			}
		}

		public static void Hide() {
			if (Ctrl != null) {
				Ctrl.FadeOut();
			}
		}

		/// <summary>
		/// 播放城镇的背景音乐
		/// </summary>
		public static void MakePlayBgm() {
			if (Ctrl != null) {
				Ctrl.PlayBgm();
			}
		}
	}
}