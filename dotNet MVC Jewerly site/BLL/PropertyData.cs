using System;

namespace HProtest_BLL
{
    public class PropertyData
    {
        public enum ConfigType
        {
            AddedCost = 0,
            ShowOnlinePay = 1,
            ShowOfflinePay = 2
        }

        public enum MsgType
        {
            accept = 0,
            warning = 1
        }

        //////new enums

        public enum UserType
        {
            SuperAdmin = 1,
            Admin = 2,
            none = 3,
        }
        public enum AdminStatus
        {
            IsLocked = 0,
            Active = 1
        }

        //++++//
        /// <summary>
        /// used in ucUserSpecification
        /// </summary>
        public enum PageType
        {
            Profile=1,
            Register=2
        }
        //++++//
        public enum CriticismLockType
        {
            IsLock=0,
            NotLock=1
        }
        public enum FileType
        {
            none = 0,
            Picture = 1,
            Flash = 2,
            File = 3
        }
        public enum UserStatus
        {

        }
    }
}
