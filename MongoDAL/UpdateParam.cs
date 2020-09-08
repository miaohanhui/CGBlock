using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDAL
{
    public class UpdateParam
    {
        private string _updateKey;
        private string _updateValue;
        public string UpdateKey
        {
            set { this._updateKey = value; }
            get { return this._updateKey; }
        }
        public string UpateValue
        {
            set { this._updateValue = value; }
            get { return this._updateValue; }
        }
        public UpdateParam(string _key, string _value)
        {
            this._updateKey = _key;
            this._updateValue = _value;
        }

    }
}
