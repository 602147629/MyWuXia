﻿using UnityEngine;
using System.Collections;
using System.ComponentModel;

namespace Game {
	/// <summary>
	/// Gender type.
	/// </summary>
	public enum GenderType {
		/// <summary>
		/// 男
		/// </summary>
		[Description("男")]
		Male,
		/// <summary>
		/// 女
		/// </summary>
		[Description("女")]
		Female
	}

	/// <summary>
	/// 品质类型
	/// </summary>
	public enum QualityType {
		/// <summary>
		/// 白
		/// </summary>
		[Description("白")]
		White,
		/// <summary>
		/// 绿
		/// </summary>
		[Description("绿")]
		Green,
		/// <summary>
		/// 蓝
		/// </summary>
		[Description("蓝")]
		Blue,
		/// <summary>
		/// 紫
		/// </summary>
		[Description("紫")]
		Purple,
		/// <summary>
		/// 金
		/// </summary>
		[Description("金")]
		Gold,
		/// <summary>
		/// 橙
		/// </summary>
		[Description("橙")]
		Orange,
		/// <summary>
		/// 红
		/// </summary>
		[Description("红")]
		Red
	}

	/// <summary>
	/// 物品类型
	/// </summary>
	public enum ItemType {
		/// <summary>
		/// 普通物品(卖出换钱)
		/// </summary>
		[Description("普通物品(卖出换钱)")]
		Normal = 0,
		/// <summary>
		/// 任务物品
		/// </summary>
		[Description("任务物品")]
		Task = 1,
		/// <summary>
		/// 生产材料(合成制作用的原料,家园里挂机产出的资源合成后获得的半成品)
		/// </summary>
		[Description("生产材料(合成制作用的原料,家园里挂机产出的资源合成后获得的半成品)")]
		Material = 2,
		/// <summary>
		/// 伤药
		/// </summary>
		[Description("伤药")]
		Vulnerary = 3,
		/// <summary>
		/// 酒
		/// </summary>
		[Description("酒")]
		Wine = 4,
		/// <summary>
		/// 菜
		/// </summary>
		[Description("菜")]
		Dinner = 5,
		/// <summary>
		/// 掉落伙伴(使用后获得)
		/// </summary>
		[Description("掉落伙伴(使用后获得)")]
		Role = 6,
		/// <summary>
		/// 掉落武器(使用后获得)
		/// </summary>
		[Description("掉落武器(使用后获得)")]
		Weapon = 7,
		/// <summary>
		/// 掉落秘籍(使用后获得)
		/// </summary>
		[Description("掉落秘籍(使用后获得)")]
		Book = 8,
		/// <summary>
		/// 消耗品(比如一定数量的秘籍残卷可以找到特定npc去兑换成秘籍)
		/// </summary>
		[Description("消耗品(比如一定数量的秘籍残卷可以找到特定npc去兑换成秘籍)")]
		Cost = 9
	}

	/// <summary>
	/// 场景中事件枚举类型
	/// </summary>
	public enum SceneEventType {
		/// <summary>
		/// 进入城镇
		/// </summary>
		[Description("进入城镇")]
		EnterCity,
		/// <summary>
		/// 进入大地图
		/// </summary>
		[Description("进入大地图")]
		EnterArea,
		/// <summary>
		/// 触发战斗
		/// </summary>
		[Description("触发战斗")]
		Battle,
		/// <summary>
		/// 剧情对话
		/// </summary>
		[Description("剧情对话")]
		Dialog,
		/// <summary>
		/// 触发任务
		/// </summary>
		[Description("触发任务")]
		Task,
		/// <summary>
		/// 进入商店
		/// </summary>
		[Description("进入商店")]
		Store,
		/// <summary>
		/// 掉落物
		/// </summary>
		[Description("掉落物")]
		Gift,
		/// <summary>
		/// 采集点
		/// </summary>
		[Description("采集点")]
		Collection,
		/// <summary>
		/// 驿站[花钱回复行动体力,并且可以雇佣马车传送到其他城镇]
		/// </summary>
		[Description("驿站[花钱回复行动体力,并且可以雇佣马车传送到其他城镇]")]
		Inn,
		/// <summary>
		/// 酒馆[可能结交到伙伴]
		/// </summary>
		[Description("酒馆[可能结交到伙伴]")]
		WineShop,
		/// <summary>
		/// 出生点事件[衔接大地图传送事件]
		/// </summary>
		[Description("出生点事件[衔接大地图传送事件]")]
		BirthPoint
	}

	/// <summary>
	/// 阅历类型枚举
	/// </summary>
	public enum ExperienceType {
		/// <summary>
		/// 是否开启传送点
		/// </summary>
		[Description("是否开启传送点")]
		OpenedTransferPoint,
		/// <summary>
		/// 累计使用招式次数
		/// </summary>
		[Description("累计使用招式次数")]
		UsedSkillNums,
		/// <summary>
		/// 累计使用招式成功暴击次数
		/// </summary>
		[Description("累计使用招式成功暴击次数")]
		SuccessedWeaponPowerPlusNums,
		/// <summary>
		/// 曾经拥有过的金钱数
		/// </summary>
		[Description("曾经拥有过的金钱数")]
		TopMoney,
		/// <summary>
		/// 获得过的东西
		/// </summary>
		[Description("获得过的东西")]
		GotMadeItem,
		/// <summary>
		/// 招募到的伙伴
		/// </summary>
		[Description("招募到的伙伴")]
		RecruitedPartner,
		/// <summary>
		/// 道德点数区间
		/// </summary>
		[Description("道德点数区间")]
		MoralRange,
		/// <summary>
		/// 获得过的秘籍
		/// </summary>
		[Description("获得过的秘籍")]
		GotBookId,
		/// <summary>
		/// 某大区域大地图的探索度是否为100%
		/// </summary>
		[Description("某大区域大地图的探索度是否为100%")]
		TravelOverAreaName,
		/// <summary>
		/// 完成过的任务
		/// </summary>
		[Description("完成过的任务")]
		CompletedTaskId
	}

	/// <summary>
	/// 任务类型枚举
	/// </summary>
	public enum TaskType {
		/// <summary>
		/// 无接取限制
		/// </summary>
		[Description("无接取限制")]
		None,
		/// <summary>
		/// 根据时辰来判定是否可接取任务
		/// 索引顺序:["午时", "未时", "申时", "酉时", "戌时", "亥时", "子时", "丑时", "寅时", "卯时", "辰时", "巳时"]
		/// </summary>
		[Description("根据时辰来判定是否可接取任务")]
		TheHour,
		/// <summary>
		/// 根据主角性别来判定是否可接取任务
		/// </summary>
		[Description("根据主角性别来判定是否可接取任务")]
		Gender,
		/// <summary>
		/// 根据道德点数区间来判定是否可接取任务
		/// </summary>
		[Description("根据道德点数区间来判定是否可接取任务")]
		MoralRange,
		/// <summary>
		///  根据是否拥有特定道具来判定是否可接取任务
		/// </summary>
		[Description("根据是否拥有特定道具来判定是否可接取任务")]
		ItemInHand,
		/// <summary>
		/// 根据主角所属门派来判定是否可接取任务
		/// </summary>
		[Description("根据主角所属门派来判定是否可接取任务")]
		Occupation
	}

	/// <summary>
	/// 任务步骤对话条件类型枚举
	/// </summary>
	public enum TaskDialogType {
		/// <summary>
		/// 普通谈话
		/// </summary>
		[Description("普通谈话")]
		JustTalk,
		/// <summary>
		/// 需要特定数量的物品(普通物品,任务物品,生活物品,击杀怪物的类型也做成掉落物品后再去交接任务)
		/// </summary>
		[Description("需要特定数量的物品")]
		SendItem,
		/// <summary>
		/// 护送Npc到指定场景
		/// </summary>
		[Description("护送Npc到指定场景")]
		ConvoyNpc,
		/// <summary>
		/// 是否使用过特定招式至少一次
		/// </summary>
		[Description("是否使用过特定招式至少一次")]
		UsedTheSkillOneTime,
		/// <summary>
		/// 是否成功使用招式暴击
		/// 招式暴击的比例可能有不同,用int值记录
		/// </summary>
		[Description("是否成功使用招式暴击")]
		WeaponPowerPlusSuccessed,
		/// <summary>
		/// 主角是否装备上特定武器
		/// </summary>
		[Description("主角是否装备上特定武器")]
		UsedTheWeapon,
		/// <summary>
		/// 主角是否装备上特定秘籍
		/// </summary>
		[Description("主角是否装备上特定秘籍")]
		UsedTheBook,
		/// <summary>
		/// 是否招募到特定伙伴
		/// </summary>
		[Description("是否招募到特定伙伴")]
		RecruitedThePartner,
		/// <summary>
		/// 特定战斗是否获胜
		/// </summary>
		[Description("特定战斗是否获胜")]
		FightWined,
		/// <summary>
		/// 抉择(使剧情产生分叉)
		/// </summary>
		[Description("抉择(使剧情产生分叉)")]
		Choice,
		/// <summary>
		/// 提示信息(用于显示步骤结果)
		/// </summary>
		[Description("提示信息(用于显示步骤结果)")]
		Notice
	}

	/// <summary>
	/// 用户当前位子状态枚举
	/// </summary>
	public enum UserPositionStatusType {
		/// <summary>
		/// 在城镇内
		/// </summary>
		InCity,
		/// <summary>
		/// 在大地图内
		/// </summary>
		InArea
	}

	/// <summary>
	/// 任务当前状态
	/// </summary>
	public enum TaskStateType {
		/// <summary>
		/// 条件未满足, 不可接取
		/// </summary>
		CanNotAccept = 0,
		/// <summary>
		/// 可接取
		/// </summary>
		CanAccept = 1,
		/// <summary>
		/// 已接取, 不能交付
		/// </summary>
		Accepted = 2,
		/// <summary>
		/// 已接取, 可以交付
		/// </summary>
		Ready = 3,
		/// <summary>
		/// 已完成
		/// </summary>
		Completed = 4
	}

	/// <summary>
	/// 任务步骤状态类型
	/// </summary>
	public enum TaskDialogStatusType {
		/// <summary>
		/// 初始状态
		/// </summary>
		Initial = 0,
		/// <summary>
		/// 等待执行
		/// </summary>
		HoldOn = 1,
		/// <summary>
		/// 已经完成(布尔是)
		/// </summary>
		ReadYes = 2,
		/// <summary>
		/// 已经完成(布尔非)
		/// </summary>
		ReadNo = 3
	}

	/// <summary>
	/// 侠客状态
	/// </summary>
	public enum RoleStateType {
		/// <summary>
		/// 未招募
		/// </summary>
		NotRecruited = 0,
		/// <summary>
		/// 正处于队伍中
		/// </summary>
		InTeam = 1,
		/// <summary>
		/// 替补中
		/// </summary>
		OutTeam = 2,
		/// <summary>
		/// 已受伤
		/// </summary>
		Injured = 3
	}

	/// <summary>
	/// 资源类型
	/// </summary>
	public enum ResourceType {
		/// <summary>
		/// 小麦
		/// </summary>
		[Description("小麦")]
		Wheat = 0,
		/// <summary>
		/// 干粮
		/// </summary>
		[Description("干粮")]
		Food = 1,
		/// <summary>
		/// 石料
		/// </summary>
		[Description("石料")]
		Stone = 2,
		/// <summary>
		/// 木材
		/// </summary>
		[Description("木材")]
		Wood = 3,
		/// <summary>
		/// 铁
		/// </summary>
		[Description("铁")]
		Iron = 4,
		/// <summary>
		/// 银
		/// </summary>
		[Description("银")]
		SilverOre = 5,
		/// <summary>
		/// 钢
		/// </summary>
		[Description("钢")]
		Steel = 6,
		/// <summary>
		/// 银子
		/// </summary>
		[Description("银子")]
		Silver = 7,
		/// <summary>
		/// 钨
		/// </summary>
		[Description("钨")]
		Tungsten = 8,
		/// <summary>
		/// 玉
		/// </summary>
		[Description("玉")]
		Jade = 9,
		/// <summary>
		/// 赤铁
		/// </summary>
		[Description("赤铁")]
		RedSteel = 10,
		/// <summary>
		/// 百炼钢
		/// </summary>
		[Description("百炼钢")]
		RefinedSteel = 11,
		/// <summary>
		/// 钨钢
		/// </summary>
		[Description("钨钢")]
		TungstenSteel = 12,
		/// <summary>
		/// 乌金木
		/// </summary>
		[Description("乌金木")]
		Zingana = 13,
		/// <summary>
		/// 玄铁锭
		/// </summary>
		[Description("玄铁锭")]
		DarksteelIngot = 14
	}
}
