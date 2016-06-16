using System;
using System.Collections.Generic;
using System.Text;

namespace Leation.VSAddin
{
    public class CopyStrategyModel
    {
        private List<string> _dirStrategyList = new List<string>();
        public List<string> DirStrategyList
        {
            get
            {
                return _dirStrategyList;
            }
            set
            {
                _dirStrategyList = value;
            }
        }

        private List<string> _strStrategyList = new List<string>();
        public List<string> StrStrategyList
        {
            get
            {
                return _strStrategyList;
            }
            set
            {
                _strStrategyList = value;
            }
        }

        private bool _useDirStrategy = false;
        public bool UseDirStrategy
        {
            get
            {
                return _useDirStrategy;
            }
            set
            {
                _useDirStrategy = value;
            }
        }

        private bool _useStrStrategy = false;
        public bool UseStrStrategy
        {
            get
            {
                return _useStrStrategy;
            }
            set
            {
                _useStrStrategy = value;
            }
        }

        private bool _deepCopy = false;
        /// <summary>
        /// 深层拷贝
        /// </summary>
        public bool DeepCopy
        {
            get
            {
                return _deepCopy;
            }
            set
            {
                _deepCopy = value;
            }
        }

        private bool _copyHideRefDlls = false;
        /// <summary>
        /// 拷贝隐藏依赖性
        /// </summary>
        public bool CopyHideRefDlls
        {
            get
            {
                return _copyHideRefDlls;
            }
            set
            {
                _copyHideRefDlls = value;
            }
        }


    }
}
