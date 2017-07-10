﻿using DPFP;
using LGU.Entities.Core;

namespace LGU.Models.HumanResource
{
    public sealed class FingerPrintModel : ModelBase<FingerPrint>
    {
        public FingerPrintModel(FingerPrint source) : base(source)
        {
            FingerType = source.FingerType;
            HandType = source.HandType;
            Data = source.Data;
        }

        private FingerType _FingerType;
        public FingerType FingerType
        {
            get { return _FingerType; }
            set { SetProperty(ref _FingerType, value); }
        }

        private HandType _HandType;
        public HandType HandType
        {
            get { return _HandType; }
            set { SetProperty(ref _HandType, value); }
        }

        private Template _Data;
        public Template Data
        {
            get { return _Data; }
            set { SetProperty(ref _Data, value); }
        }

        public override FingerPrint GetSource()
        {
            var fingerPrint = new FingerPrint(FingerType, HandType);
            fingerPrint.Data = Data;

            return fingerPrint;
        }
    }
}
