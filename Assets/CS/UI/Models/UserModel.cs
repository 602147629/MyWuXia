﻿using System;

namespace Game {
	public class UserModel {
		/// <summary>
		/// 当前用户数据缓存
		/// </summary>
		public static UserData CurrentUserData = null;

		/// <summary>
		/// 背包中可见物品的获得数量上限
		/// </summary>
		public static int LuggageMaxNum = 40;

		/// <summary>
		/// 兵器匣里主角可以获得的武器数量上限
		/// </summary>
		public static int WeaponsMaxNum = 20;
	}
}

