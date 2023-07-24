using UnityEngine;
using System.IO;
using System.Net;
// using Unity.Notifications.Android ;

public class ImageDownloadManager : MonoBehaviour
{
    public string bucketName = "cubi-island";
    public string region = "ap-northeast-2";
    public string objectKey = "큐비아일랜드_굴러오는사고력_전개도.png";
    //private const string S3BaseUrl = "https://s3.{0}.amazonaws.com/{1}/{2}";
    private const string S3BaseUrl = "https://{0}.s3.{1}.amazonaws.com/{2}";

    public void DownloadObject()
    {
        string url = string.Format(S3BaseUrl, bucketName, region, objectKey);
        Debug.Log("URL : " + url);

        // using (WebClient client = new WebClient())
        // {
        //     client.DownloadFile(url, Path.Combine(Application.persistentDataPath, objectKey));
        // }

        Application.OpenURL(url);
        Debug.Log("이미지 다운로드가 완료되었습니다.");
        //Show();
    }

    // public void Show() {

    //     // 채널 등록
    //     var c = new AndroidNotificationChannel() {

    //         Id = "Download_id",
    //         Name = "Download_channel",
    //         Importance = Importance.Default,
    //         Description = "전개도가 도착했습니다!",

    //     } ;

    //     AndroidNotificationCenter.RegisterNotificationChannel(c) ;


    //     // 알림 생성
    //     var notification = new AndroidNotification() ;

    //     notification.Title = "큐비 아일랜드" ;
    //     notification.Text = "큐비들이 전개도를 보내줬어요!" ;
    //     notification.FireTime = System.DateTime.Now.AddSeconds(3) ;

    //     notification.SmallIcon = "icon_0" ;
    //     notification.LargeIcon = "icon_1" ;

    //     AndroidNotificationCenter.SendNotification(notification, "Download_id");

    // }
}
