<?php

	$url = 'https://api.253.com/open/stock/structure';
	$params = [
		'appId' => 'xxx', // appId,登录万数平台查看
		'appKey' => 'xxx', // appKey,登录万数平台查看
		'companyKey' => '', // 搜索关键字（公司全名或公司id）
		'keyType' => '', // 搜索关键字类型（1-公司名、2-公司id）
		'year' => '', // 年份，例：2017
		'quarter' => '', // 季度（1-第一季度 2-第二季度 3-第三季度 4-第四季度）
	];
	$ch = curl_init();
	curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, false);
	curl_setopt($ch, CURLOPT_HEADER, 0);
	curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
	curl_setopt($ch, CURLOPT_URL, $url);
	curl_setopt($ch, CURLOPT_POST, 1);
	curl_setopt($ch, CURLOPT_POSTFIELDS, http_build_query($params));
	curl_setopt($ch, CURLOPT_TIMEOUT, 5);
	$result = curl_exec($ch);
	var_dump($result);
	exit;