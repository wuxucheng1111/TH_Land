using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public float speed;

    private GameObject player;
    private float screenBorderX;
    private float screenBorderY;

    // Use this for initialization
    void Start()
    {
        player = MySceneManager.Instance.player;
        screenBorderX = MySceneManager.Instance.areaBorderX;
        screenBorderY = MySceneManager.Instance.areaBorderY;
    }

    // Update is called once per frame
    void Update()
    {
        float interpolation = speed * Time.deltaTime;
        Vector3 position = transform.position;
        position.x = Mathf.Lerp(transform.position.x, player.transform.position.x, interpolation);
        position.y = Mathf.Lerp(transform.position.y, player.transform.position.y, interpolation);
        float orthographicSize = GetComponent<Camera>().orthographicSize;//orthographicSize代表相机(或者称为游戏视窗)竖直方向一半的范围大小,且不随屏幕分辨率变化(水平方向会变)
        var cameraHalfWidth = orthographicSize * ((float)Screen.width / Screen.height);//的到视窗水平方向一半的大小
        position.x = Mathf.Clamp(position.x, -screenBorderX + cameraHalfWidth, screenBorderX - cameraHalfWidth);//限定x值
        position.y = Mathf.Clamp(position.y, -screenBorderY + orthographicSize, screenBorderY - orthographicSize);//限定y值
        transform.position = position;
    }
}
