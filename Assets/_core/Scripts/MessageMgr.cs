using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class MessageMgr : MonoBehaviour
{
    public Image bgImage;

    public Image headImage;

    public Text nameText;

    public Text contentText;

    //current dialogue object 
    private int index = 0;

    private List<Dialogue> _messageList;

    // Start is called before the first frame update
    void Start()
    {
        _messageList = new List<Dialogue>()
        {
            new Dialogue()
            {
                CharacterName = "小宋",
                Content = "女神你在忙吗？",
                ImageName = "neutral",
                BackgroundName = "background"
            },
            new Dialogue()
            {
                CharacterName = "小美",
                Content = "呵呵我有事",
                ImageName = "CiaraHead",
                BackgroundName = "DeepForest"
            },
            new Dialogue()
            {
                CharacterName = "小宋",
                Content = "这么每次跟你聊天你都在忙",
                ImageName = "pleased",
                BackgroundName = "background"
            },
            new Dialogue()
            {
                CharacterName = "小美",
                Content = "拜拜我去洗澡了",
                ImageName = "CiaraHead",
                BackgroundName = "DeepForest"
            },
            new Dialogue()
            {
                CharacterName = "小宋",
                Content = "难受",
                ImageName = "sad",
                BackgroundName = "background"
            },
        };
        //UpdateMessage when game start
        UpdateMessageOnStart();
    }

    // Update is called once per frame
    void Update()
    {
       
        UpdateMessage();
    }

    private void UpdateMessage()
    {
        if (Input.GetMouseButtonDown(0))
        {
        
            var diologue = GetDiologue();
            if (diologue!=null)
            {
                bgImage.sprite = Resources.Load<Sprite>(diologue.BackgroundName);
                headImage.sprite = Resources.Load<Sprite>(diologue.ImageName);
                contentText.text = diologue.Content;
                nameText.text = diologue.CharacterName;
            }
        }
    }
    
    private void UpdateMessageOnStart()
    {
       
            var diologue = GetDiologue();
            if (diologue!=null)
            {
                bgImage.sprite = Resources.Load<Sprite>(diologue.BackgroundName);
                headImage.sprite = Resources.Load<Sprite>(diologue.ImageName);
                contentText.text = diologue.Content;
                nameText.text = diologue.CharacterName;
            }
    }
    private Dialogue GetDiologue()
    {
        if (index>=_messageList.Count)
        {
            return null;
        }
        return _messageList[index++];
    }
    
}