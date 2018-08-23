﻿using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace wanshu_api_demo
{
	/**
	 * 银行卡鉴权精细版
	 */
	public class YinhangkaJingXiBanApi
	{
		const string APP_ID_YINHANGKA = "12345678";
        const string APP_KEY_YINHANGKA = "12345678";
        const string API_URL_YINHANGKA = "https://api.253.com/open/bankcard/card-auth-detail";
    
		public static void Main(string[] args)
		{
			// 1.调用接口api
	        JObject jsonObject = InvokeYinhangka("李*", "11010120710101****",
	                "622600021110****", "1371234****");
	
	        // 2.处理返回结果
	        if (jsonObject != null) {
	            //响应code码。200000：成功，其他失败
	            string code = jsonObject["code"].ToString();
	            if ("200000".Equals(code) && null != jsonObject["data"]) {
	                // 调用成功
	                // 解析结果数据，进行业务处理
	                // 认证结果
	                Console.WriteLine("调用银行卡鉴权精细版接口成功,data:" + jsonObject["data"]);
	            } else {
	                // 记录错误日志，正式项目中请换成log打印
	                Console.WriteLine("调用银行卡鉴权精细版接口失败,code:" + code + ",msg:" + jsonObject["message"]);
	            }
	        }
	        Console.ReadLine();
		}
		
		
		static JObject InvokeYinhangka(string name, string idNum, string cardNo, string mobile) {
	        IDictionary<string, string> dic = new Dictionary<string, string>();
	        dic.Add("appId", APP_ID_YINHANGKA);
	        dic.Add("appKey", APP_KEY_YINHANGKA);
	        dic.Add("name", name);
	        dic.Add("idNum", idNum);
	        dic.Add("cardNo", cardNo);
	        dic.Add("mobile", mobile);
	        string result = HttpUtility.Post(API_URL_YINHANGKA, dic);
	        // 解析json,并返回结果
	        return string.IsNullOrEmpty(result) ? null : (JObject)JsonConvert.DeserializeObject(result);
    	}
	}
}