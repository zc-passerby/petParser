using System;
using System.Collections.Generic;

namespace petShikongParser
{
	public class 任务信息
	{
		public string 任务序号
		{
			get;
			set;
		}

		public string 任务名
		{
			get;
			set;
		}

		public List<task> 任务目标
		{
			get;
			set;
		}

		public string 指定宠物
		{
			get;
			set;
		}

		public string 任务奖励
		{
			get;
			set;
		}

		public string 允许重复
		{
			get;
			set;
		}

		public string 已完成
		{
			get;
			set;
		}

		public string 前置任务
		{
			get;
			set;
		}
	}
}
