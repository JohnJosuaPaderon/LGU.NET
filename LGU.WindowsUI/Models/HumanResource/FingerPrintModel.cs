using DPFP;
using LGU.Entities.Core;

namespace LGU.Models.HumanResource
{
    public sealed class FingerPrintModel : ModelBase<IFingerPrint>
    {
        public static FingerPrintModel TryCreate(IFingerPrint fingerPrint)
        {
            return fingerPrint != null ? new FingerPrintModel(fingerPrint) : null;
        }

        public FingerPrintModel(IFingerPrint source) : base(source)
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

        public override IFingerPrint GetSource()
        {
            Source.Data = Data;

            return Source;
        }
    }
}
