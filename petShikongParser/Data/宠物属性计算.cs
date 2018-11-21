using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace petShikongParser
{
	public class 宠物属性计算
	{
		public static 宠物信息 计算宠物属性(宠物信息 宠物属性)
		{
			宠物信息 宠物信息 = new 宠物信息();
			宠物信息.技能列表 = 宠物属性.技能列表;
			int value = 0;
			int value2 = 0;
			int value3 = 0;
			int value4 = 0;
			int value5 = 0;
			int value6 = 0;
			int value7 = 0;
			bool flag = 宠物属性.五行.Equals("神");
			if (flag)
			{
				value = 33;
				value2 = 6;
				value3 = 7;
				value7 = 4;
				value4 = 4;
				value5 = 15;
				value6 = 7;
			}
			else
			{
				bool flag2 = 宠物属性.五行.Equals("神圣");
				if (flag2)
				{
					value = 44;
					value2 = 7;
					value3 = 8;
					value7 = 4;
					value4 = 3;
					value5 = 15;
					value6 = 7;
				}
				else
				{
					bool flag3 = 宠物属性.五行.Equals("魔");
					if (flag3)
					{
						value = 44;
						value2 = 7;
						value3 = 8;
						value7 = 4;
						value4 = 3;
						value5 = 15;
						value6 = 7;
					}
					else
					{
						bool flag4 = 宠物属性.五行.Equals("妖");
						if (flag4)
						{
							value = 44;
							value2 = 7;
							value3 = 5;
							value7 = 6;
							value6 = 4;
							value5 = 15;
							value4 = 7;
						}
						else
						{
							bool flag5 = 宠物属性.五行.Equals("聖");
							if (flag5)
							{
								value = 54;
								value2 = 7;
								value3 = 11;
								value7 = 2;
								value4 = 3;
								value5 = 15;
								value6 = 6;
							}
							else
							{
								bool flag6 = 宠物属性.五行.Equals("金");
								if (flag6)
								{
									value = 21;
									value2 = 6;
									value3 = 4;
									value7 = 3;
									value6 = 4;
									value5 = 7;
									value4 = 4;
								}
								else
								{
									bool flag7 = 宠物属性.五行.Equals("木");
									if (flag7)
									{
										value = 20;
										value2 = 6;
										value3 = 4;
										value7 = 3;
										value6 = 5;
										value5 = 8;
										value4 = 3;
									}
									else
									{
										bool flag8 = 宠物属性.五行.Equals("水");
										if (flag8)
										{
											value = 21;
											value2 = 6;
											value3 = 3;
											value7 = 2;
											value6 = 3;
											value5 = 9;
											value4 = 5;
										}
										else
										{
											bool flag9 = 宠物属性.五行.Equals("火");
											if (flag9)
											{
												value = 20;
												value2 = 6;
												value3 = 5;
												value7 = 1;
												value6 = 4;
												value5 = 10;
												value4 = 3;
											}
											else
											{
												bool flag10 = 宠物属性.五行.Equals("土");
												if (flag10)
												{
													value = 23;
													value2 = 6;
													value3 = 3;
													value7 = 4;
													value6 = 4;
													value5 = 6;
													value4 = 3;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			宠物信息.生命 = ((long)((double)Convert.ToInt64(value) * Convert.ToDouble(宠物属性.成长) * (double)(Convert.ToInt64(宠物属性.等级) - 1L) + (double)Convert.ToInt64(宠物属性.生命))).ToString();
			宠物信息.魔法 = ((long)((double)Convert.ToInt64(value2) * Convert.ToDouble(宠物属性.成长) * (double)(Convert.ToInt64(宠物属性.等级) - 1L) + (double)Convert.ToInt64(宠物属性.魔法))).ToString();
			宠物信息.最大魔法 = ((long)((double)Convert.ToInt64(value2) * Convert.ToDouble(宠物属性.成长) * (double)(Convert.ToInt64(宠物属性.等级) - 1L) + (double)Convert.ToInt64(宠物属性.最大魔法))).ToString();
			宠物信息.生命 = ((long)((double)Convert.ToInt64(value) * Convert.ToDouble(宠物属性.成长) * (double)(Convert.ToInt64(宠物属性.等级) - 1L) + (double)Convert.ToInt64(宠物属性.生命))).ToString();
			宠物信息.最大生命 = ((long)((double)Convert.ToInt64(value) * Convert.ToDouble(宠物属性.成长) * (double)(Convert.ToInt64(宠物属性.等级) - 1L) + (double)Convert.ToInt64(宠物属性.最大生命))).ToString();
			宠物信息.攻击 = ((long)((double)Convert.ToInt64(value3) * Convert.ToDouble(宠物属性.成长) * (double)(Convert.ToInt64(宠物属性.等级) - 1L) + (double)Convert.ToInt64(宠物属性.攻击))).ToString();
			宠物信息.命中 = ((long)((double)Convert.ToInt64(value6) * Convert.ToDouble(宠物属性.成长) * (double)(Convert.ToInt64(宠物属性.等级) - 1L) + (double)Convert.ToInt64(宠物属性.命中))).ToString();
			宠物信息.速度 = ((long)((double)Convert.ToInt64(value5) * Convert.ToDouble(宠物属性.成长) * (double)(Convert.ToInt64(宠物属性.等级) - 1L) + (double)Convert.ToInt64(宠物属性.速度))).ToString();
			宠物信息.闪避 = ((long)((double)Convert.ToInt64(value4) * Convert.ToDouble(宠物属性.成长) * (double)(Convert.ToInt64(宠物属性.等级) - 1L) + (double)Convert.ToInt64(宠物属性.闪避))).ToString();
			宠物信息.防御 = ((long)((double)Convert.ToInt64(value7) * Convert.ToDouble(宠物属性.成长) * (double)(Convert.ToInt64(宠物属性.等级) - 1L) + (double)Convert.ToInt64(宠物属性.防御))).ToString();
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			List<技能信息> 信息 = 宠物信息.信息;
			foreach (技能信息 current in 信息)
			{
				技能配置 信息2 = current.信息;
				bool flag11 = 信息2 != null;
				if (flag11)
				{
					bool flag12 = 信息2.技能附带效果 == "攻击";
					if (flag12)
					{
						bool flag13 = 信息2.附带效果增量.IndexOf(".") != -1;
						if (flag13)
						{
							num += Convert.ToDouble(信息2.附带效果增量) + Convert.ToDouble(current.技能等级) * 数值加密.零点零零五();
						}
						else
						{
							宠物信息.攻击 = (Convert.ToInt64(宠物信息.攻击) + Convert.ToInt64(信息2.附带效果增量)).ToString();
						}
					}
					else
					{
						bool flag14 = 信息2.技能附带效果 == "命中";
						if (flag14)
						{
							bool flag15 = 信息2.附带效果增量.IndexOf(".") != -1;
							if (flag15)
							{
								num7 += Convert.ToDouble(信息2.附带效果增量) + Convert.ToDouble(current.技能等级) * 数值加密.零点零零五();
							}
							else
							{
								宠物信息.命中 = (Convert.ToInt64(宠物信息.命中) + Convert.ToInt64(信息2.附带效果增量)).ToString();
							}
						}
						else
						{
							bool flag16 = 信息2.技能附带效果 == "防御";
							if (flag16)
							{
								bool flag17 = 信息2.附带效果增量.IndexOf(".") != -1;
								if (flag17)
								{
									num2 += Convert.ToDouble(信息2.附带效果增量) + Convert.ToDouble(current.技能等级) * 数值加密.零点零零五();
								}
								else
								{
									宠物信息.防御 = (Convert.ToInt64(宠物信息.防御) + Convert.ToInt64(信息2.附带效果增量)).ToString();
								}
							}
							else
							{
								bool flag18 = 信息2.技能附带效果 == "速度";
								if (flag18)
								{
									bool flag19 = 信息2.附带效果增量.IndexOf(".") != -1;
									if (flag19)
									{
										num6 += Convert.ToDouble(信息2.附带效果增量) + Convert.ToDouble(current.技能等级) * 数值加密.零点零零五();
									}
									else
									{
										宠物信息.速度 = (Convert.ToInt64(宠物信息.速度) + Convert.ToInt64(信息2.附带效果增量)).ToString();
									}
								}
								else
								{
									bool flag20 = 信息2.技能附带效果 == "闪避";
									if (flag20)
									{
										bool flag21 = 信息2.附带效果增量.IndexOf(".") != -1;
										if (flag21)
										{
											num4 += Convert.ToDouble(信息2.附带效果增量) + Convert.ToDouble(current.技能等级) * 数值加密.零点零零五();
										}
										else
										{
											宠物信息.闪避 = (Convert.ToInt64(宠物信息.闪避) + Convert.ToInt64(信息2.附带效果增量)).ToString();
										}
									}
									else
									{
										bool flag22 = 信息2.技能附带效果 == "生命";
										if (flag22)
										{
											bool flag23 = 信息2.附带效果增量.IndexOf(".") != -1;
											if (flag23)
											{
												num5 += Convert.ToDouble(信息2.附带效果增量) + Convert.ToDouble(current.技能等级) * 数值加密.零点零零五();
											}
											else
											{
												宠物信息.生命 = (Convert.ToInt64(宠物信息.生命) + Convert.ToInt64(信息2.附带效果增量)).ToString();
											}
										}
										else
										{
											bool flag24 = 信息2.技能附带效果 == "魔法";
											if (flag24)
											{
												bool flag25 = 信息2.附带效果增量.IndexOf(".") != -1;
												if (flag25)
												{
													num3 += Convert.ToDouble(信息2.附带效果增量) + Convert.ToDouble(current.技能等级) * 数值加密.零点零零五();
												}
												else
												{
													宠物信息.魔法 = (Convert.ToInt64(宠物信息.魔法) + Convert.ToInt64(信息2.附带效果增量)).ToString();
												}
											}
											else
											{
												bool flag26 = 信息2.技能附带效果 == "加深";
												if (flag26)
												{
													宠物信息 expr_90B = 宠物信息;
													expr_90B.加深 += (Convert.ToDouble(宠物信息.加深) + Convert.ToDouble(信息2.附带效果增量) + Convert.ToDouble(current.技能等级) * 数值加密.零点零零五()).ToString();
												}
												else
												{
													bool flag27 = 信息2.技能附带效果 == "抵消";
													if (flag27)
													{
														宠物信息 expr_96E = 宠物信息;
														expr_96E.抵消 += (Convert.ToDouble(宠物信息.抵消) + Convert.ToDouble(信息2.附带效果增量) + Convert.ToDouble(current.技能等级) * 数值加密.零点零零五()).ToString();
													}
													else
													{
														bool flag28 = 信息2.技能附带效果 == "吸血";
														if (flag28)
														{
															宠物信息 expr_9D1 = 宠物信息;
															expr_9D1.吸血 += (Convert.ToDouble(宠物信息.吸血) + Convert.ToDouble(信息2.附带效果增量) + Convert.ToDouble(current.技能等级) * 数值加密.零点零零五()).ToString();
														}
														else
														{
															bool flag29 = 信息2.技能附带效果 == "吸魔";
															if (flag29)
															{
																宠物信息 expr_A31 = 宠物信息;
																expr_A31.吸魔 += (Convert.ToDouble(宠物信息.吸魔) + Convert.ToDouble(信息2.附带效果增量) + Convert.ToDouble(current.技能等级) * 数值加密.零点零零五()).ToString();
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			List<装备信息> list = new 数据处理().取指定宠物的装备(宠物属性.宠物序号, null);
			List<string> list2 = new List<string>();
			foreach (装备信息 current2 in list)
			{
				装备类型 装备类型 = new 数据处理().取指定装备类型(current2.类ID);
				bool flag30 = true;
				foreach (string current3 in list2)
				{
					bool flag31 = current3 == 装备类型.suitID;
					if (flag31)
					{
						flag30 = false;
						break;
					}
					bool flag32 = 装备类型.suitID == null;
					if (flag32)
					{
						flag30 = false;
						break;
					}
				}
				bool flag33 = flag30;
				if (flag33)
				{
					list2.Add(装备类型.suitID);
					int num8 = -1;
					suits suits = new 数据处理().取指定套装(装备类型.suitID);
					foreach (装备信息 current4 in list)
					{
						装备类型 装备类型2 = new 数据处理().取指定装备类型(current4.类ID);
						bool flag34 = 装备类型2 != null && 装备类型2.suitID != null && 装备类型2.suitID.Equals(装备类型.suitID);
						if (flag34)
						{
							bool flag35 = num8 > -1;
							if (flag35)
							{
								suit suit = suits.套装属性[num8];
								bool flag36 = suit.Type == "攻击";
								if (flag36)
								{
									bool flag37 = suit.addNump.IndexOf(".") != -1;
									if (flag37)
									{
										num += Convert.ToDouble(suit.addNump);
									}
									else
									{
										宠物信息.攻击 = (Convert.ToInt64(宠物信息.攻击) + Convert.ToInt64(suit.addNump)).ToString();
									}
								}
								else
								{
									bool flag38 = suit.Type == "命中";
									if (flag38)
									{
										bool flag39 = suit.addNump.IndexOf(".") != -1;
										if (flag39)
										{
											num7 += Convert.ToDouble(suit.addNump);
										}
										else
										{
											宠物信息.命中 = (Convert.ToInt64(宠物信息.命中) + Convert.ToInt64(suit.addNump)).ToString();
										}
									}
									else
									{
										bool flag40 = suit.Type == "防御";
										if (flag40)
										{
											bool flag41 = suit.addNump.IndexOf(".") != -1;
											if (flag41)
											{
												num2 += Convert.ToDouble(suit.addNump);
											}
											else
											{
												宠物信息.防御 = (Convert.ToInt64(宠物信息.防御) + Convert.ToInt64(suit.addNump)).ToString();
											}
										}
										else
										{
											bool flag42 = suit.Type == "速度";
											if (flag42)
											{
												bool flag43 = suit.addNump.IndexOf(".") != -1;
												if (flag43)
												{
													num6 += Convert.ToDouble(suit.addNump);
												}
												else
												{
													宠物信息.速度 = (Convert.ToInt64(宠物信息.速度) + Convert.ToInt64(suit.addNump)).ToString();
												}
											}
											else
											{
												bool flag44 = suit.Type == "闪避";
												if (flag44)
												{
													bool flag45 = suit.addNump.IndexOf(".") != -1;
													if (flag45)
													{
														num4 += Convert.ToDouble(suit.addNump);
													}
													else
													{
														宠物信息.闪避 = (Convert.ToInt64(宠物信息.闪避) + Convert.ToInt64(suit.addNump)).ToString();
													}
												}
												else
												{
													bool flag46 = suit.Type == "生命";
													if (flag46)
													{
														bool flag47 = suit.addNump.IndexOf(".") != -1;
														if (flag47)
														{
															num5 += Convert.ToDouble(suit.addNump);
														}
														else
														{
															宠物信息.生命 = (Convert.ToInt64(宠物信息.生命) + Convert.ToInt64(suit.addNump)).ToString();
														}
													}
													else
													{
														bool flag48 = suit.Type == "魔法";
														if (flag48)
														{
															bool flag49 = suit.addNump.IndexOf(".") != -1;
															if (flag49)
															{
																num3 += Convert.ToDouble(suit.addNump);
															}
															else
															{
																宠物信息.魔法 = (Convert.ToInt64(宠物信息.魔法) + Convert.ToInt64(suit.addNump)).ToString();
															}
														}
														else
														{
															bool flag50 = suit.Type == "加深";
															if (flag50)
															{
																宠物信息.加深 = (Convert.ToDouble(宠物信息.加深) + Convert.ToDouble(suit.addNump)).ToString();
															}
															else
															{
																bool flag51 = suit.Type == "抵消";
																if (flag51)
																{
																	宠物信息.抵消 = (Convert.ToDouble(宠物信息.抵消) + Convert.ToDouble(suit.addNump)).ToString();
																}
																else
																{
																	bool flag52 = suit.Type == "吸血";
																	if (flag52)
																	{
																		宠物信息.吸血 = (Convert.ToDouble(宠物信息.吸血) + Convert.ToDouble(suit.addNump)).ToString();
																	}
																	else
																	{
																		bool flag53 = suit.Type == "吸魔";
																		if (flag53)
																		{
																			宠物信息.吸魔 = (Convert.ToDouble(宠物信息.吸魔) + Convert.ToDouble(suit.addNump)).ToString();
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
							num8++;
						}
					}
				}
				bool flag54 = 装备类型.防御 != null && 装备类型.防御 != "Null" && 装备类型.防御.Length > 0;
				if (flag54)
				{
					long num9 = 0L;
					bool flag55 = 装备类型.防御.IndexOf(".") != -1;
					if (flag55)
					{
						num2 += Convert.ToDouble(装备类型.防御);
					}
					else
					{
						num9 = Convert.ToInt64(装备类型.防御);
					}
					宠物信息.防御 = (num9 + Convert.ToInt64(宠物信息.防御)).ToString();
				}
				bool flag56 = 装备类型.攻击 != null && 装备类型.攻击 != "Null" && 装备类型.攻击.Length > 0;
				if (flag56)
				{
					long num10 = 0L;
					bool flag57 = 装备类型.攻击.IndexOf(".") != -1;
					if (flag57)
					{
						num += Convert.ToDouble(装备类型.攻击);
					}
					else
					{
						num10 = Convert.ToInt64(装备类型.攻击);
					}
					宠物信息.攻击 = (num10 + Convert.ToInt64(宠物信息.攻击)).ToString();
				}
				bool flag58 = 装备类型.魔法 != null && 装备类型.魔法 != "Null" && 装备类型.魔法.Length > 0;
				if (flag58)
				{
					long num11 = 0L;
					bool flag59 = 装备类型.魔法.IndexOf(".") != -1;
					if (flag59)
					{
						num3 += Convert.ToDouble(装备类型.魔法);
					}
					else
					{
						num11 = Convert.ToInt64(装备类型.魔法);
					}
					宠物信息.最大魔法 = (num11 + Convert.ToInt64(宠物信息.最大魔法)).ToString();
				}
				bool flag60 = 装备类型.闪避 != null && 装备类型.闪避 != "Null" && 装备类型.闪避.Length > 0;
				if (flag60)
				{
					long num12 = 0L;
					bool flag61 = 装备类型.闪避.IndexOf(".") != -1;
					if (flag61)
					{
						num4 += Convert.ToDouble(装备类型.闪避);
					}
					else
					{
						num12 = Convert.ToInt64(装备类型.闪避);
					}
					宠物信息.闪避 = (num12 + Convert.ToInt64(宠物信息.闪避)).ToString();
				}
				bool flag62 = 装备类型.生命 != null && 装备类型.生命 != "Null" && 装备类型.生命.Length > 0;
				if (flag62)
				{
					long num13 = 0L;
					bool flag63 = 装备类型.生命.IndexOf(".") != -1;
					if (flag63)
					{
						num5 += Convert.ToDouble(装备类型.生命);
					}
					else
					{
						num13 = Convert.ToInt64(装备类型.生命);
					}
					宠物信息.最大生命 = (num13 + Convert.ToInt64(宠物信息.最大生命)).ToString();
				}
				bool flag64 = 装备类型.速度 != null && 装备类型.速度 != "Null" && 装备类型.速度.Length > 0;
				if (flag64)
				{
					long num14 = 0L;
					bool flag65 = 装备类型.速度.IndexOf(".") != -1;
					if (flag65)
					{
						num6 += Convert.ToDouble(装备类型.速度);
					}
					else
					{
						num14 = Convert.ToInt64(装备类型.速度);
					}
					宠物信息.速度 = (num14 + Convert.ToInt64(宠物信息.速度)).ToString();
				}
				bool flag66 = 装备类型.命中 != null && 装备类型.命中 != "Null" && 装备类型.命中.Length > 0;
				if (flag66)
				{
					long num15 = 0L;
					bool flag67 = 装备类型.命中.IndexOf(".") != -1;
					if (flag67)
					{
						num7 += Convert.ToDouble(装备类型.命中);
					}
					else
					{
						num15 = Convert.ToInt64(装备类型.命中);
					}
					宠物信息.命中 = (num15 + Convert.ToInt64(宠物信息.命中)).ToString();
				}
				bool flag68 = 装备类型.吸魔 != null && 装备类型.吸魔 != "Null" && 装备类型.吸魔.Length > 0;
				if (flag68)
				{
					宠物信息.吸魔 = (Convert.ToDouble(宠物信息.吸魔) + Convert.ToDouble(装备类型.吸魔)).ToString();
				}
				bool flag69 = 装备类型.吸血 != null && 装备类型.吸血 != "Null" && 装备类型.吸血.Length > 0;
				if (flag69)
				{
					宠物信息.吸血 = (Convert.ToDouble(宠物信息.吸血) + Convert.ToDouble(装备类型.吸血)).ToString();
				}
				bool flag70 = 装备类型.抵消 != null && 装备类型.抵消 != "Null" && 装备类型.抵消.Length > 0;
				if (flag70)
				{
					宠物信息.抵消 = (Convert.ToDouble(宠物信息.抵消) + Convert.ToDouble(装备类型.抵消)).ToString();
				}
				bool flag71 = 装备类型.加深 != null && 装备类型.加深 != "Null" && 装备类型.加深.Length > 0;
				if (flag71)
				{
					宠物信息.加深 = (Convert.ToDouble(宠物信息.加深) + Convert.ToDouble(装备类型.加深)).ToString();
				}
			}
			宠物信息.闪避 = (Convert.ToInt64(宠物信息.闪避) + Convert.ToInt64(Convert.ToDouble(宠物信息.闪避) * num4)).ToString();
			宠物信息.攻击 = (Convert.ToInt64(宠物信息.攻击) + Convert.ToInt64(Convert.ToDouble(宠物信息.攻击) * num)).ToString();
			宠物信息.命中 = (Convert.ToInt64(宠物信息.命中) + Convert.ToInt64(Convert.ToDouble(宠物信息.命中) * num7)).ToString();
			宠物信息.最大魔法 = (Convert.ToInt64(宠物信息.魔法) + Convert.ToInt64(Convert.ToDouble(宠物信息.魔法) * num3)).ToString();
			宠物信息.生命 = (Convert.ToInt64(宠物信息.生命) + Convert.ToInt64(Convert.ToDouble(宠物信息.生命) * num5)).ToString();
			宠物信息.速度 = (Convert.ToInt64(宠物信息.速度) + Convert.ToInt64(Convert.ToDouble(宠物信息.速度) * num6)).ToString();
			宠物信息.防御 = (Convert.ToInt64(宠物信息.防御) + Convert.ToInt64(Convert.ToDouble(宠物信息.防御) * num2)).ToString();
			int num16 = 数据处理.取整数("47EC908C9DAE");
			bool flag72 = Convert.ToInt64(宠物信息.生命) < (long)num16;
			if (flag72)
			{
				宠物信息.生命 = 9223372036854775807L.ToString();
			}
			bool flag73 = Convert.ToInt64(宠物信息.魔法) < (long)num16;
			if (flag73)
			{
				宠物信息.魔法 = 9223372036854775807L.ToString();
			}
			bool flag74 = Convert.ToInt64(宠物信息.最大魔法) < (long)num16;
			if (flag74)
			{
				宠物信息.最大魔法 = 9223372036854775807L.ToString();
			}
			bool flag75 = Convert.ToInt64(宠物信息.生命) < (long)num16;
			if (flag75)
			{
				宠物信息.生命 = 9223372036854775807L.ToString();
			}
			bool flag76 = Convert.ToInt64(宠物信息.最大生命) < (long)num16;
			if (flag76)
			{
				宠物信息.最大生命 = 9223372036854775807L.ToString();
			}
			bool flag77 = Convert.ToInt64(宠物信息.攻击) < (long)num16;
			if (flag77)
			{
				宠物信息.攻击 = 9223372036854775807L.ToString();
			}
			bool flag78 = Convert.ToInt64(宠物信息.防御) < (long)num16;
			if (flag78)
			{
				宠物信息.防御 = 9223372036854775807L.ToString();
			}
			bool flag79 = Convert.ToInt64(宠物信息.闪避) < (long)num16;
			if (flag79)
			{
				宠物信息.闪避 = 9223372036854775807L.ToString();
			}
			bool flag80 = Convert.ToInt64(宠物信息.速度) < (long)num16;
			if (flag80)
			{
				宠物信息.速度 = 9223372036854775807L.ToString();
			}
			bool flag81 = Convert.ToInt64(宠物信息.命中) < (long)num16;
			if (flag81)
			{
				宠物信息.命中 = 9223372036854775807L.ToString();
			}
			宠物信息.宠物名字 = 宠物属性.宠物名字;
			宠物信息.宠物序号 = 宠物属性.宠物序号;
			宠物信息.当前经验 = 宠物属性.当前经验;
			宠物信息.等级 = 宠物属性.等级;
			宠物信息.生命 = 宠物信息.最大生命;
			宠物信息.位置 = 宠物属性.位置;
			宠物信息.五行 = 宠物属性.五行;
			宠物信息.形象 = 宠物属性.形象;
			宠物信息.状态 = 宠物属性.状态;
			宠物信息.指定五行 = 宠物属性.指定五行;
			宠物信息.自定义宠物名字 = 宠物属性.自定义宠物名字;
			宠物信息.已进化次数 = 宠物属性.已进化次数;
			宠物信息.成长 = Math.Round(Convert.ToDouble(宠物属性.成长), 2).ToString();
			return 宠物信息;
		}

		public static List<宠物信息> 计算宠物属性(List<宠物信息> 宠物属性)
		{
			List<宠物信息> list = new List<宠物信息>();
			List<装备信息> 所有装备 = new 数据处理().取玩家所有装备();
			for (int i = 0; i < 宠物属性.Count; i++)
			{
				宠物信息 宠物信息 = new 宠物信息();
				宠物信息.技能列表 = 宠物属性[i].技能列表;
				int value = 0;
				int value2 = 0;
				int value3 = 0;
				int value4 = 0;
				int value5 = 0;
				int value6 = 0;
				int value7 = 0;
				bool flag = 宠物属性[i].五行.Equals("神");
				if (flag)
				{
					value = 33;
					value2 = 6;
					value3 = 7;
					value7 = 4;
					value4 = 4;
					value5 = 15;
					value6 = 7;
				}
				else
				{
					bool flag2 = 宠物属性[i].五行.Equals("神圣");
					if (flag2)
					{
						value = 44;
						value2 = 7;
						value3 = 8;
						value7 = 4;
						value4 = 3;
						value5 = 15;
						value6 = 7;
					}
					else
					{
						bool flag3 = 宠物属性[i].五行.Equals("魔");
						if (flag3)
						{
							value = 44;
							value2 = 7;
							value3 = 8;
							value7 = 4;
							value4 = 3;
							value5 = 15;
							value6 = 7;
						}
						else
						{
							bool flag4 = 宠物属性[i].五行.Equals("妖");
							if (flag4)
							{
								value = 44;
								value2 = 7;
								value3 = 5;
								value7 = 6;
								value6 = 4;
								value5 = 15;
								value4 = 7;
							}
							else
							{
								bool flag5 = 宠物属性[i].五行.Equals("聖");
								if (flag5)
								{
									value = 50;
									value2 = 7;
									value3 = 11;
									value7 = 2;
									value4 = 3;
									value5 = 15;
									value6 = 6;
								}
								else
								{
									bool flag6 = 宠物属性[i].五行.Equals("金");
									if (flag6)
									{
										value = 21;
										value2 = 6;
										value3 = 4;
										value7 = 3;
										value6 = 4;
										value5 = 7;
										value4 = 4;
									}
									else
									{
										bool flag7 = 宠物属性[i].五行.Equals("木");
										if (flag7)
										{
											value = 20;
											value2 = 6;
											value3 = 4;
											value7 = 3;
											value6 = 5;
											value5 = 8;
											value4 = 3;
										}
										else
										{
											bool flag8 = 宠物属性[i].五行.Equals("水");
											if (flag8)
											{
												value = 21;
												value2 = 6;
												value3 = 3;
												value7 = 2;
												value6 = 3;
												value5 = 9;
												value4 = 5;
											}
											else
											{
												bool flag9 = 宠物属性[i].五行.Equals("火");
												if (flag9)
												{
													value = 20;
													value2 = 6;
													value3 = 5;
													value7 = 1;
													value6 = 4;
													value5 = 10;
													value4 = 3;
												}
												else
												{
													bool flag10 = 宠物属性[i].五行.Equals("土");
													if (flag10)
													{
														value = 23;
														value2 = 6;
														value3 = 3;
														value7 = 4;
														value6 = 4;
														value5 = 6;
														value4 = 3;
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				Stopwatch stopwatch = new Stopwatch();
				stopwatch.Start();
				宠物信息.生命 = ((long)((double)Convert.ToInt64(value) * Convert.ToDouble(宠物属性[i].成长) * (double)(Convert.ToInt64(宠物属性[i].等级) - 1L) + (double)Convert.ToInt64(宠物属性[i].生命))).ToString();
				宠物信息.魔法 = ((long)((double)Convert.ToInt64(value2) * Convert.ToDouble(宠物属性[i].成长) * (double)(Convert.ToInt64(宠物属性[i].等级) - 1L) + (double)Convert.ToInt64(宠物属性[i].魔法))).ToString();
				宠物信息.最大魔法 = ((long)((double)Convert.ToInt64(value2) * Convert.ToDouble(宠物属性[i].成长) * (double)(Convert.ToInt64(宠物属性[i].等级) - 1L) + (double)Convert.ToInt64(宠物属性[i].最大魔法))).ToString();
				宠物信息.生命 = ((long)((double)Convert.ToInt64(value) * Convert.ToDouble(宠物属性[i].成长) * (double)(Convert.ToInt64(宠物属性[i].等级) - 1L) + (double)Convert.ToInt64(宠物属性[i].生命))).ToString();
				宠物信息.最大生命 = ((long)((double)Convert.ToInt64(value) * Convert.ToDouble(宠物属性[i].成长) * (double)(Convert.ToInt64(宠物属性[i].等级) - 1L) + (double)Convert.ToInt64(宠物属性[i].最大生命))).ToString();
				宠物信息.攻击 = ((long)((double)Convert.ToInt64(value3) * Convert.ToDouble(宠物属性[i].成长) * (double)(Convert.ToInt64(宠物属性[i].等级) - 1L) + (double)Convert.ToInt64(宠物属性[i].攻击))).ToString();
				宠物信息.命中 = ((long)((double)Convert.ToInt64(value6) * Convert.ToDouble(宠物属性[i].成长) * (double)(Convert.ToInt64(宠物属性[i].等级) - 1L) + (double)Convert.ToInt64(宠物属性[i].命中))).ToString();
				宠物信息.速度 = ((long)((double)Convert.ToInt64(value5) * Convert.ToDouble(宠物属性[i].成长) * (double)(Convert.ToInt64(宠物属性[i].等级) - 1L) + (double)Convert.ToInt64(宠物属性[i].速度))).ToString();
				宠物信息.闪避 = ((long)((double)Convert.ToInt64(value4) * Convert.ToDouble(宠物属性[i].成长) * (double)(Convert.ToInt64(宠物属性[i].等级) - 1L) + (double)Convert.ToInt64(宠物属性[i].闪避))).ToString();
				宠物信息.防御 = ((long)((double)Convert.ToInt64(value7) * Convert.ToDouble(宠物属性[i].成长) * (double)(Convert.ToInt64(宠物属性[i].等级) - 1L) + (double)Convert.ToInt64(宠物属性[i].防御))).ToString();
				List<装备信息> list2 = new 数据处理().取指定宠物的装备(宠物属性[i].宠物序号, 所有装备);
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				double num5 = 0.0;
				double num6 = 0.0;
				double num7 = 0.0;
				List<技能信息> 信息 = 宠物信息.信息;
				foreach (技能信息 current in 信息)
				{
					技能配置 信息2 = current.信息;
					bool flag11 = 信息2 != null;
					if (flag11)
					{
						bool flag12 = 信息2.技能附带效果 == "攻击";
						if (flag12)
						{
							bool flag13 = 信息2.附带效果增量.IndexOf(".") != -1;
							if (flag13)
							{
								num += Convert.ToDouble(信息2.附带效果增量);
							}
							else
							{
								宠物信息.攻击 = (Convert.ToInt64(宠物信息.攻击) + Convert.ToInt64(信息2.附带效果增量)).ToString();
							}
						}
						else
						{
							bool flag14 = 信息2.技能附带效果 == "命中";
							if (flag14)
							{
								bool flag15 = 信息2.附带效果增量.IndexOf(".") != -1;
								if (flag15)
								{
									num7 += Convert.ToDouble(信息2.附带效果增量);
								}
								else
								{
									宠物信息.命中 = (Convert.ToInt64(宠物信息.命中) + Convert.ToInt64(信息2.附带效果增量)).ToString();
								}
							}
							else
							{
								bool flag16 = 信息2.技能附带效果 == "防御";
								if (flag16)
								{
									bool flag17 = 信息2.附带效果增量.IndexOf(".") != -1;
									if (flag17)
									{
										num2 += Convert.ToDouble(信息2.附带效果增量);
									}
									else
									{
										宠物信息.防御 = (Convert.ToInt64(宠物信息.防御) + Convert.ToInt64(信息2.附带效果增量)).ToString();
									}
								}
								else
								{
									bool flag18 = 信息2.技能附带效果 == "速度";
									if (flag18)
									{
										bool flag19 = 信息2.附带效果增量.IndexOf(".") != -1;
										if (flag19)
										{
											num6 += Convert.ToDouble(信息2.附带效果增量);
										}
										else
										{
											宠物信息.速度 = (Convert.ToInt64(宠物信息.速度) + Convert.ToInt64(信息2.附带效果增量)).ToString();
										}
									}
									else
									{
										bool flag20 = 信息2.技能附带效果 == "闪避";
										if (flag20)
										{
											bool flag21 = 信息2.附带效果增量.IndexOf(".") != -1;
											if (flag21)
											{
												num4 += Convert.ToDouble(信息2.附带效果增量);
											}
											else
											{
												宠物信息.闪避 = (Convert.ToInt64(宠物信息.闪避) + Convert.ToInt64(信息2.附带效果增量)).ToString();
											}
										}
										else
										{
											bool flag22 = 信息2.技能附带效果 == "生命";
											if (flag22)
											{
												bool flag23 = 信息2.附带效果增量.IndexOf(".") != -1;
												if (flag23)
												{
													num5 += Convert.ToDouble(信息2.附带效果增量);
												}
												else
												{
													宠物信息.生命 = (Convert.ToInt64(宠物信息.生命) + Convert.ToInt64(信息2.附带效果增量)).ToString();
												}
											}
											else
											{
												bool flag24 = 信息2.技能附带效果 == "魔法";
												if (flag24)
												{
													bool flag25 = 信息2.附带效果增量.IndexOf(".") != -1;
													if (flag25)
													{
														num3 += Convert.ToDouble(信息2.附带效果增量);
													}
													else
													{
														宠物信息.魔法 = (Convert.ToInt64(宠物信息.魔法) + Convert.ToInt64(信息2.附带效果增量)).ToString();
													}
												}
												else
												{
													bool flag26 = 信息2.技能附带效果 == "加深";
													if (flag26)
													{
														宠物信息 expr_9E4 = 宠物信息;
														expr_9E4.加深 += (Convert.ToDouble(宠物信息.加深) + Convert.ToDouble(信息2.附带效果增量)).ToString();
													}
													else
													{
														bool flag27 = 信息2.技能附带效果 == "抵消";
														if (flag27)
														{
															宠物信息 expr_A34 = 宠物信息;
															expr_A34.抵消 += (Convert.ToDouble(宠物信息.抵消) + Convert.ToDouble(信息2.附带效果增量)).ToString();
														}
														else
														{
															bool flag28 = 信息2.技能附带效果 == "吸血";
															if (flag28)
															{
																宠物信息 expr_A84 = 宠物信息;
																expr_A84.吸血 += (Convert.ToDouble(宠物信息.吸血) + Convert.ToDouble(信息2.附带效果增量)).ToString();
															}
															else
															{
																bool flag29 = 信息2.技能附带效果 == "吸魔";
																if (flag29)
																{
																	宠物信息 expr_AD1 = 宠物信息;
																	expr_AD1.吸魔 += (Convert.ToDouble(宠物信息.吸魔) + Convert.ToDouble(信息2.附带效果增量)).ToString();
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
				List<string> list3 = new List<string>();
				foreach (装备信息 current2 in list2)
				{
					装备类型 装备类型 = new 数据处理().取指定装备类型(current2.类ID);
					bool flag30 = true;
					foreach (string current3 in list3)
					{
						bool flag31 = current3 == 装备类型.suitID;
						if (flag31)
						{
							flag30 = false;
							break;
						}
						bool flag32 = 装备类型.suitID == null;
						if (flag32)
						{
							flag30 = false;
							break;
						}
					}
					bool flag33 = flag30;
					if (flag33)
					{
						list3.Add(装备类型.suitID);
						int num8 = -1;
						suits suits = new 数据处理().取指定套装(装备类型.suitID);
						foreach (装备信息 current4 in list2)
						{
							装备类型 装备类型2 = new 数据处理().取指定装备类型(current4.类ID);
							bool flag34 = 装备类型2 != null && 装备类型2.suitID != null && 装备类型2.suitID.Equals(装备类型.suitID);
							if (flag34)
							{
								bool flag35 = num8 > -1;
								if (flag35)
								{
									suit suit = suits.套装属性[num8];
									bool flag36 = suit.Type == "攻击";
									if (flag36)
									{
										bool flag37 = suit.addNump.IndexOf(".") != -1;
										if (flag37)
										{
											num += Convert.ToDouble(suit.addNump);
										}
										else
										{
											宠物信息.攻击 = (Convert.ToInt64(宠物信息.攻击) + Convert.ToInt64(suit.addNump)).ToString();
										}
									}
									else
									{
										bool flag38 = suit.Type == "命中";
										if (flag38)
										{
											bool flag39 = suit.addNump.IndexOf(".") != -1;
											if (flag39)
											{
												num7 += Convert.ToDouble(suit.addNump);
											}
											else
											{
												宠物信息.命中 = (Convert.ToInt64(宠物信息.命中) + Convert.ToInt64(suit.addNump)).ToString();
											}
										}
										else
										{
											bool flag40 = suit.Type == "防御";
											if (flag40)
											{
												bool flag41 = suit.addNump.IndexOf(".") != -1;
												if (flag41)
												{
													num2 += Convert.ToDouble(suit.addNump);
												}
												else
												{
													宠物信息.防御 = (Convert.ToInt64(宠物信息.防御) + Convert.ToInt64(suit.addNump)).ToString();
												}
											}
											else
											{
												bool flag42 = suit.Type == "速度";
												if (flag42)
												{
													bool flag43 = suit.addNump.IndexOf(".") != -1;
													if (flag43)
													{
														num6 += Convert.ToDouble(suit.addNump);
													}
													else
													{
														宠物信息.速度 = (Convert.ToInt64(宠物信息.速度) + Convert.ToInt64(suit.addNump)).ToString();
													}
												}
												else
												{
													bool flag44 = suit.Type == "闪避";
													if (flag44)
													{
														bool flag45 = suit.addNump.IndexOf(".") != -1;
														if (flag45)
														{
															num4 += Convert.ToDouble(suit.addNump);
														}
														else
														{
															宠物信息.闪避 = (Convert.ToInt64(宠物信息.闪避) + Convert.ToInt64(suit.addNump)).ToString();
														}
													}
													else
													{
														bool flag46 = suit.Type == "生命";
														if (flag46)
														{
															bool flag47 = suit.addNump.IndexOf(".") != -1;
															if (flag47)
															{
																num5 += Convert.ToDouble(suit.addNump);
															}
															else
															{
																宠物信息.生命 = (Convert.ToInt64(宠物信息.生命) + Convert.ToInt64(suit.addNump)).ToString();
															}
														}
														else
														{
															bool flag48 = suit.Type == "魔法";
															if (flag48)
															{
																bool flag49 = suit.addNump.IndexOf(".") != -1;
																if (flag49)
																{
																	num3 += Convert.ToDouble(suit.addNump);
																}
																else
																{
																	宠物信息.魔法 = (Convert.ToInt64(宠物信息.魔法) + Convert.ToInt64(suit.addNump)).ToString();
																}
															}
														}
													}
												}
											}
										}
									}
								}
								num8++;
							}
						}
					}
					bool flag50 = 装备类型.防御 != null && 装备类型.防御 != "Null" && 装备类型.防御.Length > 0;
					if (flag50)
					{
						long num9 = 0L;
						bool flag51 = 装备类型.防御.IndexOf(".") != -1;
						if (flag51)
						{
							num2 += Convert.ToDouble(装备类型.防御);
						}
						else
						{
							num9 = Convert.ToInt64(装备类型.防御);
						}
						宠物信息.防御 = (num9 + Convert.ToInt64(宠物信息.防御)).ToString();
					}
					bool flag52 = 装备类型.攻击 != null && 装备类型.攻击 != "Null" && 装备类型.攻击.Length > 0;
					if (flag52)
					{
						long num10 = 0L;
						bool flag53 = 装备类型.攻击.IndexOf(".") != -1;
						if (flag53)
						{
							num += Convert.ToDouble(装备类型.攻击);
						}
						else
						{
							num10 = Convert.ToInt64(装备类型.攻击);
						}
						宠物信息.攻击 = (num10 + Convert.ToInt64(宠物信息.攻击)).ToString();
					}
					bool flag54 = 装备类型.魔法 != null && 装备类型.魔法 != "Null" && 装备类型.魔法.Length > 0;
					if (flag54)
					{
						long num11 = 0L;
						bool flag55 = 装备类型.魔法.IndexOf(".") != -1;
						if (flag55)
						{
							num3 += Convert.ToDouble(装备类型.魔法);
						}
						else
						{
							num11 = Convert.ToInt64(装备类型.魔法);
						}
						宠物信息.最大魔法 = (num11 + Convert.ToInt64(宠物信息.最大魔法)).ToString();
					}
					bool flag56 = 装备类型.闪避 != null && 装备类型.闪避 != "Null" && 装备类型.闪避.Length > 0;
					if (flag56)
					{
						long num12 = 0L;
						bool flag57 = 装备类型.闪避.IndexOf(".") != -1;
						if (flag57)
						{
							num4 += Convert.ToDouble(装备类型.闪避);
						}
						else
						{
							num12 = Convert.ToInt64(装备类型.闪避);
						}
						宠物信息.闪避 = (num12 + Convert.ToInt64(宠物信息.闪避)).ToString();
					}
					bool flag58 = 装备类型.生命 != null && 装备类型.生命 != "Null" && 装备类型.生命.Length > 0;
					if (flag58)
					{
						long num13 = 0L;
						bool flag59 = 装备类型.生命.IndexOf(".") != -1;
						if (flag59)
						{
							num5 += Convert.ToDouble(装备类型.生命);
						}
						else
						{
							num13 = Convert.ToInt64(装备类型.生命);
						}
						宠物信息.最大生命 = (num13 + Convert.ToInt64(宠物信息.最大生命)).ToString();
					}
					bool flag60 = 装备类型.速度 != null && 装备类型.速度 != "Null" && 装备类型.速度.Length > 0;
					if (flag60)
					{
						long num14 = 0L;
						bool flag61 = 装备类型.速度.IndexOf(".") != -1;
						if (flag61)
						{
							num6 += Convert.ToDouble(装备类型.速度);
						}
						else
						{
							num14 = Convert.ToInt64(装备类型.速度);
						}
						宠物信息.速度 = (num14 + Convert.ToInt64(宠物信息.速度)).ToString();
					}
					bool flag62 = 装备类型.命中 != null && 装备类型.命中 != "Null" && 装备类型.命中.Length > 0;
					if (flag62)
					{
						long num15 = 0L;
						bool flag63 = 装备类型.命中.IndexOf(".") != -1;
						if (flag63)
						{
							num7 += Convert.ToDouble(装备类型.命中);
						}
						else
						{
							num15 = Convert.ToInt64(装备类型.命中);
						}
						宠物信息.命中 = (num15 + Convert.ToInt64(宠物信息.命中)).ToString();
					}
				}
				宠物信息.闪避 = (Convert.ToInt64(宠物信息.闪避) + Convert.ToInt64(Convert.ToDouble(宠物信息.闪避) * num4)).ToString();
				宠物信息.攻击 = (Convert.ToInt64(宠物信息.攻击) + Convert.ToInt64(Convert.ToDouble(宠物信息.攻击) * num)).ToString();
				宠物信息.命中 = (Convert.ToInt64(宠物信息.命中) + Convert.ToInt64(Convert.ToDouble(宠物信息.命中) * num7)).ToString();
				宠物信息.最大魔法 = (Convert.ToInt64(宠物信息.魔法) + Convert.ToInt64(Convert.ToDouble(宠物信息.魔法) * num3)).ToString();
				宠物信息.生命 = (Convert.ToInt64(宠物信息.生命) + Convert.ToInt64(Convert.ToDouble(宠物信息.生命) * num5)).ToString();
				宠物信息.速度 = (Convert.ToInt64(宠物信息.速度) + Convert.ToInt64(Convert.ToDouble(宠物信息.速度) * num6)).ToString();
				宠物信息.防御 = (Convert.ToInt64(宠物信息.防御) + Convert.ToInt64(Convert.ToDouble(宠物信息.防御) * num2)).ToString();
				stopwatch = new Stopwatch();
				stopwatch.Start();
				int num16 = 数据处理.取整数("47EC908C9DAE");
				bool flag64 = Convert.ToInt64(宠物信息.生命) < (long)num16;
				if (flag64)
				{
					宠物信息.生命 = 9223372036854775807L.ToString();
				}
				bool flag65 = Convert.ToInt64(宠物信息.魔法) < (long)num16;
				if (flag65)
				{
					宠物信息.魔法 = 9223372036854775807L.ToString();
				}
				bool flag66 = Convert.ToInt64(宠物信息.最大魔法) < (long)num16;
				if (flag66)
				{
					宠物信息.最大魔法 = 9223372036854775807L.ToString();
				}
				bool flag67 = Convert.ToInt64(宠物信息.生命) < (long)num16;
				if (flag67)
				{
					宠物信息.生命 = 9223372036854775807L.ToString();
				}
				bool flag68 = Convert.ToInt64(宠物信息.最大生命) < (long)num16;
				if (flag68)
				{
					宠物信息.最大生命 = 9223372036854775807L.ToString();
				}
				bool flag69 = Convert.ToInt64(宠物信息.攻击) < (long)num16;
				if (flag69)
				{
					宠物信息.攻击 = 9223372036854775807L.ToString();
				}
				bool flag70 = Convert.ToInt64(宠物信息.防御) < (long)num16;
				if (flag70)
				{
					宠物信息.防御 = 9223372036854775807L.ToString();
				}
				bool flag71 = Convert.ToInt64(宠物信息.闪避) < (long)num16;
				if (flag71)
				{
					宠物信息.闪避 = 9223372036854775807L.ToString();
				}
				bool flag72 = Convert.ToInt64(宠物信息.速度) < (long)num16;
				if (flag72)
				{
					宠物信息.速度 = 9223372036854775807L.ToString();
				}
				bool flag73 = Convert.ToInt64(宠物信息.命中) < (long)num16;
				if (flag73)
				{
					宠物信息.命中 = 9223372036854775807L.ToString();
				}
				宠物信息.生命 = 宠物信息.最大生命;
				宠物信息.宠物名字 = 宠物属性[i].宠物名字;
				宠物信息.宠物序号 = 宠物属性[i].宠物序号;
				宠物信息.当前经验 = 宠物属性[i].当前经验;
				宠物信息.等级 = 宠物属性[i].等级;
				宠物信息.位置 = 宠物属性[i].位置;
				宠物信息.五行 = 宠物属性[i].五行;
				宠物信息.形象 = 宠物属性[i].形象;
				宠物信息.状态 = 宠物属性[i].状态;
				宠物信息.已进化次数 = 宠物属性[i].已进化次数;
				宠物信息.指定五行 = 宠物属性[i].指定五行;
				宠物信息.自定义宠物名字 = 宠物属性[i].自定义宠物名字;
				宠物信息.成长 = Math.Round(Convert.ToDouble(宠物属性[i].成长), 2).ToString();
				list.Add(宠物信息);
			}
			return list;
		}
	}
}
