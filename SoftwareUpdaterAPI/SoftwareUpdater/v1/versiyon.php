<?php 
header('Content-Type: application/json');
//$apiArgArray=explode("/", substr(@$_SERVER['REQUEST_URI'], 1));
if($_GET["request"]===""||$_GET["request"]==" "){$html = file_get_contents('404_error_page'); echo $html;
}else{
	include('../../baglanti.php');
	$apiArgArray=explode("/", $_GET["request"]);

	$namespace=$apiArgArray[0];
	$versiyon=$apiArgArray[1];
	switch (@$_SERVER['REQUEST_METHOD']) {
		case 'GET':
		$idSorgusu=$baglan->query("select ver.id from umit_uyg_versiyon_ver as ver inner join umit_uygulama_uyg as uyg on ver.namespace=uyg.namespace where ver.namespace='$namespace' and ver.versiyon='$versiyon' ORDER BY ver.id asc");
		if($idSorgusu->num_rows>0){
			while($satir=$idSorgusu->fetch_assoc())
				$baslamaid=$satir['id'];
		}

		$sonucSorgusu=$baglan->query("select * from umit_uyg_versiyon_ver as ver inner join umit_uygulama_uyg as uyg on ver.namespace=uyg.namespace where ver.namespace='$namespace' and ver.id>$baslamaid and guncelleme_durumu=1 order by ver.id asc");
		if($sonucSorgusu->num_rows>0){
			while ($satir=$sonucSorgusu->fetch_assoc()){
				$array[]= array(
					'versiyon' => $satir["versiyon"],
					'paketSayisi' => $satir["paket_sayisi"],
					'zorunlu'=>$satir["zorunlu"],
					'guncellemeNotu' => $satir["guncelleme_notu"],
					);
			}
		}


			break;
		
		default:
			# code...
			break;
	}
echo json_encode($array);
}
?>