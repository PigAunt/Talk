using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalkSrv.Auth
{
    class PermissionCore
    {
        // 消息
        private bool sendMsg; /*发送消息*/
        private bool sendMsgTo; /*向指定用户发送消息*/
        private bool receiveMsg; /*接收消息*/

        // 用户
        private bool listUsers; /*列出用户*/
        private bool banUser; /*封禁用户*/
        private bool kickUser; /*将用户踢出当前会话*/
        private bool controlUser; /*以指定用户进行操作*/

        // 账户
        private bool multiLog; /*是否允许多重登录*/
        private bool addUser; /*添加账户*/
        private bool deleteUser; /*删除账户*/
        private bool setUser; /*更改存在的账户(不包括其权限)*/
        private bool setPermission; /*更改存在的账户权限(包括自己)*/

        // 服务器
        private bool setServer; /*设置服务器*/
        private bool shutdownServer; /*关闭服务器*/

        // 权限等级
        private int permissionLevel;
        /*
         * 权限等级说明
         * 0  服务器     Root
         * 10 管理员     Admin
         * 20 用户       User
         * 30 访客       Guset
         * 40 默认(无)   Default
         * 
         * 在原基础上增加一个权限 permissionLevel - 1;
         * 在原基础上减少一个权限 permissionLevel + 1;
         * 
         * permissionLevel最大值 40
         * 
         * permissionLevel是判定用户行为的扩展功能
         * permissionLevel低的用户无法对permissionLevel高的用户实施权限功能, 即使拥有对应权限
         * 
         * 在服务器端操作将锁定为0即Root的权限, 并使用名为TalkSrv的用户
        */
    }
}
