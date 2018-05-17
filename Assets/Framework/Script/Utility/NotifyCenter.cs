
/* | ---   NEA_Platform   --- | */

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
//  NormalSingleton.cs
//  Create on 2/16/2018
/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/

/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/
/*  Script Editor: EazeyWang                      
/*	Blog   Adress: http://blog.csdn.net/eazey_wj     
/*	GitHub Adress: https://github.com/Eazey 		 
/*- - - - - - - - - - - - - - - - - - - - - - - - - -*/

/*	 Either none appetency, or determined to win.    */

/* * * * * * * * * * * * * * * * * * * * * * * * * * */
/* Script Overview: 
 * 消息分发类
/* * * * * * * * * * * * * * * * * * * * * * * * * * */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace EGUIFramework
{
    public class NotifyCenter
    {
        private Dictionary<Enum, NotifyHandler> _messageDic;
        private NotifyCenter()
        {
            _messageDic = new Dictionary<Enum, NotifyHandler>();
        }
        private static NotifyCenter _instance = null;
        public static NotifyCenter Dispatcher()
        {
            if (_instance == null)
                _instance = new NotifyCenter();
            return _instance;
        }
        /// <summary>
        /// 接收指定类型消息，并注册消息触发事件
        /// </summary>
        /// <param name="message"> 消息类型 </param>
        /// <param name="call"> 事件方法 </param>
        public void Register(Enum message, NotifyHandler call)
        {
            if (_messageDic.ContainsKey(message))
                _messageDic[message] += call;
            else
                _messageDic.Add(message, call);
        }
        /// <summary>
        /// 发送指定类型消息
        /// </summary>
        /// <param name="message"> 消息类型 </param>
        /// <param name="sender"> 发送者 </param>
        /// <param name="parameter"> 消息参数 </param>
        public void Send(Enum message, object sender = null, object parameter = null)
        {
            if (!_messageDic.ContainsKey(message))
                return;

            if (_messageDic[message] != null)
                _messageDic[message](sender, parameter);
        }
        /// <summary>
        /// 移除指定类型消息的指定事件
        /// </summary>
        /// <param name="message"> 消息类型 </param>
        /// <param name="call"> 事件方法 </param>
        public void Remove(Enum message, NotifyHandler call)
        {
            if (!_messageDic.ContainsKey(message))
                return;

            if (_messageDic[message] != call && _messageDic[message] != null)
                _messageDic[message] -= call;
            else
                _messageDic.Remove(message);
        }
        /// <summary>
        /// 移除指定类型消息的所有事件
        /// </summary>
        /// <param name="message"> 消息类型 </param>
        public void RemoveAll(Enum message)
        {
            if (!_messageDic.ContainsKey(message))
                return;

            _messageDic.Remove(message);
        }
        /// <summary>
        /// 清空所有类型消息以及所有事件
        /// </summary>
        public void Clear()
        {
            _messageDic = null;
        }
    }
}