﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;

namespace Game {
	public class ReadyToTraveRoleContainer : ComponentCore {
		public Image Icon;
		public Text Desc;
		public Text WeaponNameText;
		public Image WeaponWidth;
		public Image WeaponIcon;
		public Image[] BookIcons;
		public Button SelectBtn;
		public Button CancelBtn;

		Image bg;

		RoleData roleData;
		protected override void Init () {
			bg = GetComponent<Image>();
		}

		// Use this for initialization
		void Start () {
			EventTriggerListener.Get(SelectBtn.gameObject).onClick = onClick;
			EventTriggerListener.Get(CancelBtn.gameObject).onClick = onClick;
		}

		void onClick(GameObject e) {
			if (!e.GetComponent<Button>().enabled) {
				return;
			}
			switch(e.name) {
			case "SelectBtn":
				roleData.State = RoleStateType.InTeam;
				Messenger.Broadcast<RoleData>(NotifyTypes.MakeSelectRoleInTeam, roleData);
				RefreshView();
				break;
			case "CancelBtn":
				roleData.State = RoleStateType.OutTeam;
				Messenger.Broadcast<RoleData>(NotifyTypes.MakeUnSelectRoleInTeam, roleData);
				RefreshView();
				break;
			default:
				break;
			}
		}

		public void UpdateData(RoleData role) {
			roleData = role;
		}

		public void RefreshView() {
			Icon.sprite = Statics.GetIconSprite(roleData.IconId);
			if (roleData.State == RoleStateType.InTeam) {
				bg.sprite = Statics.GetSprite("Border12");
			}
			else {
				bg.sprite = Statics.GetSprite("Border11");
			}
			Desc.text = string.Format("称谓:{0}\n门派:{1}\n地位:{2}\n状态:{3}", roleData.Name, Statics.GetOccupationName(roleData.Occupation), roleData.IsHost ? "当家" : "门客", Statics.GetInjuryName(roleData.Injury));
			WeaponNameText.text = string.Format("<color=\"{0}\">{1}</color>", Statics.GetQualityColorString(roleData.Weapon.Quality), roleData.Weapon.Name);
			WeaponWidth.rectTransform.sizeDelta = new Vector2(100f * (roleData.Weapon.Width / 100f) * 0.5f, WeaponWidth.rectTransform.sizeDelta.y);
			if (roleData.Weapon != null) {
				WeaponIcon.gameObject.SetActive(true);
				WeaponIcon.sprite = Statics.GetIconSprite(roleData.Weapon.IconId);
			}
			else {
				WeaponIcon.gameObject.SetActive(false);
			}
			for (int i = 0; i < 3; i++) {
				if (roleData.Books.Count > i) {
					BookIcons[i].gameObject.SetActive(true);
					BookIcons[i].sprite = Statics.GetIconSprite(roleData.Books[i].IconId);
				}
				else {
					BookIcons[i].gameObject.SetActive(false);
				}
			}
			if (roleData.IsHost) {
				SelectBtn.gameObject.SetActive(false);
				CancelBtn.gameObject.SetActive(false);
			}
			else {
				SelectBtn.gameObject.SetActive(roleData.State == RoleStateType.OutTeam);
				CancelBtn.gameObject.SetActive(roleData.State == RoleStateType.InTeam);
				if (roleData.Injury == InjuryType.Moribund) {
					MakeButtonEnable(SelectBtn, false);
					MakeButtonEnable(CancelBtn, false);
				}
			}
		}

		/// <summary>
		/// 禁用/启用下阵按钮
		/// </summary>
		public void EnableSelectBtn(bool enable) {
			if (roleData.Injury != InjuryType.Moribund) {
				MakeButtonEnable(SelectBtn, enable);
			}
		}

	}
}